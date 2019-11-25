using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SofewareUpdate
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// <param name="args">传入参数,arr[0] 程序名称 arr[1]版本Xml</param>
        [STAThread]
        static void Main(string[] args)
        {
            if (XmlTool.IsNeedUpdate())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Update(args));
            } 
        }
    }
}
