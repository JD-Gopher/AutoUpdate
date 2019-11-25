using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SofewareUpdate
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    class FileTool
    {
        private static string Url = XmlTool.GetServerUrl();
        /// <summary>
        /// 程序文件夹地址
        /// </summary>
        private static string SofeWarePath = AppDomain.CurrentDomain.BaseDirectory;
         /// <summary>
        /// 备份文件夹地址
        /// </summary>
        public static string backupsPath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory) + "bak";
        /// <summary>
        /// 备份文件夹地址
        /// </summary>
        public static string DownLoadPath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory) + "temp";
        /// <summary>
        /// 备份当前的程序目录信息
        /// </summary>
        /// <returns>成功OR失败</returns>
        public static bool Backups()
        {
            try
            {
                LogTool.AddLog("更新程序：准备执行备份操作");
                DirectoryInfo dir = new DirectoryInfo(SofeWarePath);
                foreach (var item in dir.GetFiles())
                {   //复制安装文件夹下的文件
                    File.Copy(item.FullName, backupsPath +@"\"+ item.Name, true);
                }
                foreach (var item in dir.GetDirectories())
                {   //复制安装文件夹下的文件夹
                    if (item.Name != "bak" && item.Name != "temp")
                    {
                        CopyDirectory(item.FullName, backupsPath);
                    }
                }
                LogTool.AddLog("更新程序：备份操作执行完成,开始关闭应用程序");
                return true;
            }
            catch (Exception EX)
            {
                LogTool.AddLog("更新程序：准备执行备份操作" + EX);
                return false;
            }
        }
        /// <summary>
        /// 下载更新文件
        /// </summary>
        /// <param name="UpdateFileList">更新文件列表</param>
        /// <returns>成功OR失败</returns>
        public static bool DownLoad(List<RemoteInfo> UpdateFileList)
        {
            using (WebClient web = new WebClient())
            {
                foreach (var item in UpdateFileList)
                {
                    try
                    {
                        LogTool.AddLog("更新程序：下载更新包文件" + item.Name + " " + item.Version);
                        string path = item.Url.Substring(0, item.Url.IndexOf(item.Name)).Substring(Url.Length, item.Url.Substring(0, item.Url.IndexOf(item.Name)).Length - Url.Length - 1);
                        if (Directory.Exists(DownLoadPath + path.Replace("/", @"\")) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(DownLoadPath + path.Replace("/", @"\"));
                        }
                        web.DownloadFileAsync(new Uri(item.Url), DownLoadPath  + item.Url.Substring(Url.Length, item.Url.Length - Url.Length).Replace("/", @"\"));
                    }
                    catch (Exception ex)
                    {
                        LogTool.AddLog("更新程序：更新包文件" + item.Name + " " + item.Version + "下载失败,本次停止更新，异常信息：" + ex.Message);
                        return false;
                    }
                }
                return true;
            }
        }
        /// <summary>
        /// 文件拷贝
        /// </summary>
        /// <param name="srcdir">源目录</param>
        /// <param name="desdir">目标目录</param>
        /// <returns>成功OR失败</returns>
        public static bool CopyDirectory(string srcdir, string desdir)
        {
            string folderName = srcdir.Substring(srcdir.LastIndexOf("\\") + 1);
            string desfolderdir = desdir + "\\" + folderName;
            if (desdir.LastIndexOf("\\") == (desdir.Length - 1))
            {
                desfolderdir = desdir + folderName;
            }
            string[] filenames = Directory.GetFileSystemEntries(srcdir);
            foreach (string file in filenames)// 遍历所有的文件和目录
            {
                if (Directory.Exists(file))// 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                {
                    string currentdir = desfolderdir + "\\" + file.Substring(file.LastIndexOf("\\") + 1);
                    if (!Directory.Exists(currentdir))
                    {
                        Directory.CreateDirectory(currentdir);
                    }
                    CopyDirectory(file, desfolderdir);
                }
                else // 否则直接copy文件
                {
                    string srcfileName = file.Substring(file.LastIndexOf("\\") + 1);
                    srcfileName = desfolderdir + "\\" + srcfileName;
                    if (!Directory.Exists(desfolderdir))
                    {
                        Directory.CreateDirectory(desfolderdir);
                    }
                    File.Copy(file, srcfileName, true);
                }
            }
            return true;
        }
        /// <summary>
        /// 删除本地文件夹的文件
        /// </summary>
        /// <returns>成功OR失败</returns>
        public static bool DeleteLocalFile()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(SofeWarePath);
                foreach (var item in di.GetFiles())
                {
                    if (item.Name != "SofewareUpdate.exe"&&item.Name!= "ServerVersion.xml"&&item.Name!= "SofewareUpdate.vshost.exe")
                    {
                        LogTool.AddLog("更新程序：删除原始文件" + item.Name);
                        File.Delete(item.FullName);
                    }
                }
                foreach (var item in di.GetDirectories())
                {
                    if (item.Name != "bak" && item.Name != "temp")
                    {
                        LogTool.AddLog("更新程序：删除原始文件夹" + item.Name);
                        item.Delete(true);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogTool.AddLog("更新程序：删除文件出错,本次停止更新，异常信息：" + ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除备份下载文件
        /// </summary>
        /// <returns>成功OR失败</returns>
        public static bool DeleteExtraDirectory()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(SofeWarePath);
                foreach (var item in di.GetDirectories())
                {
                    if (item.Name =="bak" || item.Name == "temp")
                    {
                        item.Delete(true);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
