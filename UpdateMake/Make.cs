using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateMake
{
    public partial class Make : Form
    {
        public Make()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 软件文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        /// <summary>
        /// 生成文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnsure_Click(object sender, EventArgs e)
        {
            XmlTool tool = new XmlTool(textBox2.Text, textBox3.Text, textBox1.Text, textBox4.Text, richTextBox1.Text, textBox5.Text);
            foreach (Control con in this.Controls)
            {
                if (con.Text == "") 
                {
                    MessageBox.Show("请填写完整信息");
                    return;
                }
            }

            if (tool.CreateUpDateFileXML())
            {
                MessageBox.Show("制作成功！");
            }
            else 
            {
                MessageBox.Show("制作失败！");
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
