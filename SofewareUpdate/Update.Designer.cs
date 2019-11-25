namespace SofewareUpdate
{
    partial class Update
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNeglect = new System.Windows.Forms.Button();
            this.btnLater = new System.Windows.Forms.Button();
            this.btnNow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNeglect
            // 
            this.btnNeglect.Location = new System.Drawing.Point(37, 179);
            this.btnNeglect.Name = "btnNeglect";
            this.btnNeglect.Size = new System.Drawing.Size(100, 30);
            this.btnNeglect.TabIndex = 0;
            this.btnNeglect.Text = "忽略这次更新";
            this.btnNeglect.UseVisualStyleBackColor = true;
            this.btnNeglect.Click += new System.EventHandler(this.btnNeglect_Click);
            // 
            // btnLater
            // 
            this.btnLater.Location = new System.Drawing.Point(178, 179);
            this.btnLater.Name = "btnLater";
            this.btnLater.Size = new System.Drawing.Size(100, 30);
            this.btnLater.TabIndex = 1;
            this.btnLater.Text = "以后提醒我";
            this.btnLater.UseVisualStyleBackColor = true;
            this.btnLater.Click += new System.EventHandler(this.btnLater_Click);
            // 
            // btnNow
            // 
            this.btnNow.Location = new System.Drawing.Point(319, 179);
            this.btnNow.Name = "btnNow";
            this.btnNow.Size = new System.Drawing.Size(100, 30);
            this.btnNow.TabIndex = 2;
            this.btnNow.Text = "立即更新";
            this.btnNow.UseVisualStyleBackColor = true;
            this.btnNow.Click += new System.EventHandler(this.btnNow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(61, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "1.修复代码错误";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(61, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "2.修复其他问题";
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 242);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNow);
            this.Controls.Add(this.btnLater);
            this.Controls.Add(this.btnNeglect);
            this.Name = "Update";
            this.Text = "新版本";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNeglect;
        private System.Windows.Forms.Button btnLater;
        private System.Windows.Forms.Button btnNow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

