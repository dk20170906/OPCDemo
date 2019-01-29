namespace OPCDemon
{
    partial class AdmFrm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.but_linkserver = new System.Windows.Forms.Button();
            this.but_cleartxt = new System.Windows.Forms.Button();
            this.textBox_serverip = new System.Windows.Forms.TextBox();
            this.but_setcofig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.but_setcofig);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_serverip);
            this.splitContainer1.Panel1.Controls.Add(this.but_cleartxt);
            this.splitContainer1.Panel1.Controls.Add(this.but_linkserver);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 72;
            this.splitContainer1.TabIndex = 0;
            // 
            // but_linkserver
            // 
            this.but_linkserver.Location = new System.Drawing.Point(406, 24);
            this.but_linkserver.Name = "but_linkserver";
            this.but_linkserver.Size = new System.Drawing.Size(73, 23);
            this.but_linkserver.TabIndex = 0;
            this.but_linkserver.Text = "连接";
            this.but_linkserver.UseVisualStyleBackColor = true;
            // 
            // but_cleartxt
            // 
            this.but_cleartxt.Location = new System.Drawing.Point(701, 24);
            this.but_cleartxt.Name = "but_cleartxt";
            this.but_cleartxt.Size = new System.Drawing.Size(73, 23);
            this.but_cleartxt.TabIndex = 1;
            this.but_cleartxt.Text = "清空数据";
            this.but_cleartxt.UseVisualStyleBackColor = true;
            // 
            // textBox_serverip
            // 
            this.textBox_serverip.Location = new System.Drawing.Point(78, 25);
            this.textBox_serverip.Name = "textBox_serverip";
            this.textBox_serverip.Size = new System.Drawing.Size(322, 21);
            this.textBox_serverip.TabIndex = 2;
            // 
            // but_setcofig
            // 
            this.but_setcofig.Location = new System.Drawing.Point(550, 24);
            this.but_setcofig.Name = "but_setcofig";
            this.but_setcofig.Size = new System.Drawing.Size(73, 23);
            this.but_setcofig.TabIndex = 3;
            this.but_setcofig.Text = "配置参数";
            this.but_setcofig.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "ServerIP:";
            // 
            // AdmFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AdmFrm";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_setcofig;
        private System.Windows.Forms.TextBox textBox_serverip;
        private System.Windows.Forms.Button but_cleartxt;
        private System.Windows.Forms.Button but_linkserver;
    }
}

