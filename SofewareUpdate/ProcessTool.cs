using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofewareUpdate
{
    class ProcessTool
    {
        /// <summary>
        /// 校验当前程序是否在运行
        /// </summary>
        /// <param name="programName"></param>
        /// <returns></returns>
        public static bool CheckProcessExist(string programName)
        {
            return Process.GetProcessesByName(programName).Length > 0 ? true : false;
        }

        /// <summary>
        /// 杀掉当前运行的程序进程
        /// </summary>
        /// <param name="programName">程序名称</param>
        public static void KillProcessExist(string programName)
        {
            Process[] processes = Process.GetProcessesByName(programName);
            foreach (Process p in processes)
            {
                p.Kill();
                p.Close();
            }
        }
        /// <summary>
        /// 启动程序
        /// </summary>
        /// <param name="programName">程序名称</param>
        public static void StartProcess(string programName) 
        {
            Process isupdate = new Process();
            isupdate.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + programName;
            isupdate.Start();
        }
    }
}
