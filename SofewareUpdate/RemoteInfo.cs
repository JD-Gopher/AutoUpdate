using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofewareUpdate
{
    /// <summary>
    /// 文件信息
    /// </summary>
    class RemoteInfo
    {
        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        public string  Size { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 下载地址
        /// </summary>
        public string Url { get; set; }
    }
}
