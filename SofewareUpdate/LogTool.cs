using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofewareUpdate
{
    /// <summary>
    /// 日志操作
    /// </summary>
    class LogTool
    {
        /// <summary>
        /// 日志文件路径
        /// </summary>
        private static string logFile = AppDomain.CurrentDomain.BaseDirectory;
      
        public static void AddLog(String value)
        {
            Debug.WriteLine(value);
            if (Directory.Exists(Path.Combine(logFile, @"log\")) == false)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(logFile, @"log\"));
                directoryInfo.Create();
            }
            using (StreamWriter sw = File.AppendText(Path.Combine(logFile, @"log\update.log")))
            {
                sw.WriteLine(value);
            }
        }
    }
}
