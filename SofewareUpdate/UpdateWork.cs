using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SofewareUpdate
{
    class UpdateWork
    {
        /// <summary>
        /// 程序文件夹地址
        /// </summary>
        private static string SofeWarePath = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 开始升级
        /// </summary>
        public static void StartUpdate(List<RemoteInfo> UpdateFileList,string programName)
        {
            if (FileTool.Backups()) //备份文件
            {
                if (FileTool.DownLoad(UpdateFileList)) //下载更新文件
                {
                    //ProcessTool.KillProcessExist(programName);
                    if (FileTool.DeleteLocalFile()) //删除低版本文件
                    {
                        //if (FileTool.CopyDirectory(SofeWarePath + "bak", SofeWarePath)) //将新版本的文件拷贝到安装目录
                        //{
                        //    if (FileTool.DeleteExtraDirectory()) //删除删除备份下载文件
                        //    {

                        //    }
                        //    else
                        //    {

                        //    }
                        //}
                        //else
                        //{
                        //}

                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
            else
            {
               
            }
        }
       
    }
}
