using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UpdateMake
{
    /// <summary>
    /// XML文件操作
    /// </summary>
    class XmlTool
    {
        /// <summary>
        /// 服务器地址
        /// </summary>
        private string url;
        /// <summary>
        /// 版本号
        /// </summary>
        private string version;
        /// <summary>
        /// 文件路径
        /// </summary>
        private string filepath;
        /// <summary>
        /// 保存路径
        /// </summary>
        private string savepath;
        /// <summary>
        /// 更新信息
        /// </summary>
        private string updateInfo;
        /// <summary>
        /// 软件名称
        /// </summary>
        private string name;
        /// <summary>
        /// 文件信息集合
        /// </summary>
        private List<RemoteInfo> list = new List<RemoteInfo>();
        /// <summary>
        /// 构造函数
        /// <summary>
        /// <param name="url">服务器地址</param>
        /// <param name="version">版本号</param>
        /// <param name="filepath">文件路径</param>
        /// <param name="savepath">保存路径</param>
        /// <param name="updateInfo">更新信息</param>
        /// <param name="name">软件名称</param>
        public XmlTool(string url, string version, string filepath, string savepath, string updateInfo, string name)
        {
            this.url = url;
            this.version = version;
            this.filepath = filepath;
            this.savepath = savepath;
            this.updateInfo = updateInfo;
            this.name = name;
        }
        /// <summary>
        /// 创建文件更新XML
        /// </summary>
        /// <returns>成功or失败</returns>
        public bool CreateUpDateFileXML()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode header = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(header);
                XmlElement xmlRoot = xmlDoc.CreateElement("UpdateFile");
                xmlDoc.AppendChild(xmlRoot);
                XmlElement xmlurl = xmlDoc.CreateElement("UpdateUrl");
                xmlurl.InnerText = url;
                xmlRoot.AppendChild(xmlurl);
                XmlElement xmlversion = xmlDoc.CreateElement("Version");
                xmlversion.InnerText = version;
                xmlRoot.AppendChild(xmlversion);
                XmlElement xmlInfo = xmlDoc.CreateElement("UpdateInfo");
                xmlInfo.InnerText = updateInfo;
                xmlRoot.AppendChild(xmlInfo);
                XmlElement xmlfile = xmlDoc.CreateElement("UpdateFileList");
                foreach (RemoteInfo info in GetFileInfo(filepath))
                {
                    XmlElement xmlElementInner = xmlDoc.CreateElement("LocalFile");
                    xmlElementInner.SetAttribute("Name", info.Name);
                    xmlElementInner.SetAttribute("Size", info.Size);
                    xmlElementInner.SetAttribute("Version", info.Version);
                    xmlElementInner.SetAttribute("Url", info.Url);
                    xmlfile.AppendChild(xmlElementInner);
                }
                xmlRoot.AppendChild(xmlfile);
                if (CopyDirectory(filepath, savepath + @"\" + name + version))
                {
                    xmlDoc.Save(savepath + @"\" + name + version + @"\ServerVersion.xml");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 获取本地文件信息
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns>本地文件信息集合</returns>
        private List<RemoteInfo> GetFileInfo(string path)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (DirectoryInfo file in root.GetDirectories())
            {
                GetFileInfo(file.FullName);
            }
            foreach (FileInfo file in root.GetFiles())
            {
                RemoteInfo info = new RemoteInfo
                {
                    Url = url + "/" + name + version + file.FullName.Replace(filepath, "").Replace("\\", "/"),
                    Name = file.Name,
                    Size = file.Length.ToString(),
                    Version = FileVersionInfo.GetVersionInfo(file.FullName).FileVersion == null ? Hash.GetHash(file.FullName) : FileVersionInfo.GetVersionInfo(file.FullName).FileVersion
                };
                list.Add(info);
            }
            return list;
        }
        /// <summary>
        /// 文件拷贝
        /// </summary>
        /// <param name="srcPath">源目录</param>
        /// <param name="destPath">目标目录</param>
        /// <returns>成功OR失败</returns>
        private bool CopyDirectory(string srcPath, string destPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //获取目录下（不包含子目录）的文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)     //判断是否文件夹
                    {
                        if (!Directory.Exists(destPath + "\\" + i.Name))
                        {
                            Directory.CreateDirectory(destPath + "\\" + i.Name);   //目标目录下不存在此文件夹即创建子文件夹
                        }
                        CopyDirectory(i.FullName, destPath + "\\" + i.Name);    //递归调用复制子文件夹
                    }
                    else
                    {
                        File.Copy(i.FullName, destPath + "\\" + i.Name, true);      //不是文件夹即复制文件，true表示可以覆盖同名文件
                    }
                }
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}
