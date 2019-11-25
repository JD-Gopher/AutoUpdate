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
    /// <summary>
    /// XML文件操作
    /// </summary>
    class XmlTool
    {
        /// <summary>
        /// 程序文件夹地址
        /// </summary>
        private static string SofeWarePath = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 获取服务器Url
        /// </summary>
        /// <returns>服务器Url</returns>
        public static string GetServerUrl()
        {
            XmlDocument xmllocal = new XmlDocument();
            xmllocal.Load(SofeWarePath + "LocalVersion.xml");
            XmlNode xmlRoot = xmllocal.SelectSingleNode("UpdateFile");
            XmlNode xmlurl = xmlRoot.SelectSingleNode("UpdateUrl");
            return xmlurl.InnerText;
        }
        /// <summary>
        /// 获取本地Xml中版本号
        /// </summary>
        /// <returns>本地Xml中版本号</returns>
        private static string GetLocalVersion()
        {
            XmlDocument xmllocal = new XmlDocument();
            xmllocal.Load(SofeWarePath + "LocalVersion.xml");
            XmlNode xmlRoot = xmllocal.SelectSingleNode("UpdateFile");
            XmlNode xmlurl = xmlRoot.SelectSingleNode("Version");
            return xmlurl.InnerText;
        }
        /// <summary>
        /// 获取服务器Xml中版本号
        /// </summary>
        /// <returns>服务器Xml中版本号</returns>
        private static string GetServerVersion()
        {
            XmlReader xml = XmlReader.Create(GetServerUrl() + "/ServerVersion.xml");
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(GetServerUrl() + "/ServerVersion.xml");
            XmlNode xmlRoot = xdoc.SelectSingleNode("UpdateFile");
            XmlNode xmlurl = xmlRoot.SelectSingleNode("Version");
            return xmlurl.InnerText;
        }
        /// <summary>
        /// 获取本地Xml中文件集合
        /// </summary>
        /// <param name="doc">本地XML中文件集合</param>
        private static List<RemoteInfo> GetLocalXMLFileList()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(SofeWarePath + "LocalVersion.xml");
            List<RemoteInfo> list = new List<RemoteInfo>();
            XmlNode xmlRoot = doc.SelectSingleNode("UpdateFile");
            XmlNode xmlurl = xmlRoot.SelectSingleNode("UpdateUrl");
            XmlNode xmlfile = xmlRoot.SelectSingleNode("UpdateFileList");
            foreach (XmlNode node in xmlfile.ChildNodes)
            {
                RemoteInfo info = new RemoteInfo();
                foreach (XmlAttribute pItem in node.Attributes)
                {
                    info.GetType().GetProperty(pItem.Name).SetValue(info, pItem.InnerText, null);
                }
                list.Add(info);
            }
            return list;
        }
        /// <summary>
        /// 获取服务器Xml中文件集合
        /// </summary>
        /// <returns>服务器Xml中文件集合</returns>
        private static List<RemoteInfo> GetServerXMLFileList()
        {
            List<RemoteInfo> list = new List<RemoteInfo>();
            XmlReader xml = XmlReader.Create(GetServerUrl() + "/ServerVersion.xml");
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(GetServerUrl() + "/ServerVersion.xml");
            XmlNode xmlRoot = xdoc.SelectSingleNode("UpdateFile");
            XmlNode xmlurl = xmlRoot.SelectSingleNode("UpdateUrl");
            XmlNode xmlfile = xmlRoot.SelectSingleNode("UpdateFileList");
            foreach (XmlNode node in xmlfile.ChildNodes)
            {
                RemoteInfo info = new RemoteInfo();
                foreach (XmlAttribute pItem in node.Attributes)
                {
                    info.GetType().GetProperty(pItem.Name).SetValue(info, pItem.InnerText, null);
                }
                list.Add(info);
            }
            return list;
        }
        /// <summary>
        /// 获取下载文件
        /// </summary>
        /// <returns>需要下载文件</returns>
        public static List<RemoteInfo> GetUpdateFileList() 
        {
            List<RemoteInfo> local =GetLocalXMLFileList();
            List<RemoteInfo> server=GetServerXMLFileList();
            return local;
        }
        /// <summary>
        /// 是否需要更新
        /// </summary>
        /// <returns>需要OR不需要</returns>
        public static bool IsNeedUpdate()
        {
            if (downloadXml())
            {
                string loacl = GetLocalVersion();
                string server = GetServerVersion();
                return loacl != server;
            }
            else 
            {
                return false;
            }
        }
        /// <summary>
        /// 下载ServerVersion
        /// </summary>
        /// <returns></returns>
        private static bool downloadXml() 
        {
            try
            {
                List<RemoteInfo> list = new List<RemoteInfo>();
                XmlReader xml = XmlReader.Create(GetServerUrl() + "/ServerVersion.xml");
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(GetServerUrl() + "/ServerVersion.xml");
                xdoc.Save(SofeWarePath + "/ServerVersion.xml");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
