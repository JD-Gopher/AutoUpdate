using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SofewareUpdate
{
    public partial class Update : Form
    {
        private string[] args;
        public Update(string[] args)
        {
            this.args = args;
            InitializeComponent();
        }
        /// <summary>
        /// 忽略这次更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNeglect_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 以后提醒我
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLater_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 立即更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNow_Click(object sender, EventArgs e)
        {
            UpdateWork.StartUpdate(XmlTool.GetUpdateFileList(), "args[0]");
        }
    }
}
