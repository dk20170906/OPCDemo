namespace OPCDemon
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.richTextBox_outtxt = new System.Windows.Forms.RichTextBox();
            this.button_emp = new System.Windows.Forms.Button();
            this.set = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(435, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "执行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(48, 42);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(339, 21);
            this.textBox_ip.TabIndex = 1;
            // 
            // richTextBox_outtxt
            // 
            this.richTextBox_outtxt.Location = new System.Drawing.Point(215, 234);
            this.richTextBox_outtxt.Name = "richTextBox_outtxt";
            this.richTextBox_outtxt.Size = new System.Drawing.Size(248, 157);
            this.richTextBox_outtxt.TabIndex = 2;
            this.richTextBox_outtxt.Text = "";
            // 
            // button_emp
            // 
            this.button_emp.Location = new System.Drawing.Point(459, 87);
            this.button_emp.Name = "button_emp";
            this.button_emp.Size = new System.Drawing.Size(75, 23);
            this.button_emp.TabIndex = 3;
            this.button_emp.Text = "清空内容";
            this.button_emp.UseVisualStyleBackColor = true;
            this.button_emp.Click += new System.EventHandler(this.button_emp_Click);
            // 
            // set
            // 
            this.set.Location = new System.Drawing.Point(349, 87);
            this.set.Name = "set";
            this.set.Size = new System.Drawing.Size(75, 23);
            this.set.TabIndex = 4;
            this.set.Text = "配置参数";
            this.set.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 450);
            this.Controls.Add(this.set);
            this.Controls.Add(this.button_emp);
            this.Controls.Add(this.richTextBox_outtxt);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.RichTextBox richTextBox_outtxt;
        private System.Windows.Forms.Button button_emp;
        private System.Windows.Forms.Button set;
    }
}

