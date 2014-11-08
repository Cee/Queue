namespace Client
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.serverIPtextBox = new System.Windows.Forms.TextBox();
            this.linkButton = new System.Windows.Forms.Button();
            this.linkStatus = new System.Windows.Forms.Label();
            this.getNumberButton = new System.Windows.Forms.Button();
            this.myNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP地址";
            // 
            // serverIPtextBox
            // 
            this.serverIPtextBox.Location = new System.Drawing.Point(110, 47);
            this.serverIPtextBox.Name = "serverIPtextBox";
            this.serverIPtextBox.Size = new System.Drawing.Size(124, 21);
            this.serverIPtextBox.TabIndex = 1;
            this.serverIPtextBox.Text = "127.0.0.1";
            // 
            // linkButton
            // 
            this.linkButton.Location = new System.Drawing.Point(250, 45);
            this.linkButton.Name = "linkButton";
            this.linkButton.Size = new System.Drawing.Size(75, 23);
            this.linkButton.TabIndex = 2;
            this.linkButton.Text = "连接";
            this.linkButton.UseVisualStyleBackColor = true;
            this.linkButton.Click += new System.EventHandler(this.linkButton_Click);
            // 
            // linkStatus
            // 
            this.linkStatus.AutoSize = true;
            this.linkStatus.Location = new System.Drawing.Point(343, 50);
            this.linkStatus.Name = "linkStatus";
            this.linkStatus.Size = new System.Drawing.Size(0, 12);
            this.linkStatus.TabIndex = 3;
            this.linkStatus.Text = "尚未连接到服务器";
            // 
            // getNumberButton
            // 
            this.getNumberButton.Location = new System.Drawing.Point(250, 98);
            this.getNumberButton.Name = "getNumberButton";
            this.getNumberButton.Size = new System.Drawing.Size(75, 23);
            this.getNumberButton.TabIndex = 4;
            this.getNumberButton.Text = "叫号";
            this.getNumberButton.UseVisualStyleBackColor = true;
            this.getNumberButton.Click += new System.EventHandler(this.getNumberButton_Click);
            // 
            // myNumber
            // 
            this.myNumber.AutoSize = true;
            this.myNumber.Location = new System.Drawing.Point(108, 103);
            this.myNumber.Name = "myNumber";
            this.myNumber.Size = new System.Drawing.Size(35, 12);
            this.myNumber.TabIndex = 5;
            this.myNumber.Text = "号码:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 142);
            this.Controls.Add(this.myNumber);
            this.Controls.Add(this.getNumberButton);
            this.Controls.Add(this.linkStatus);
            this.Controls.Add(this.linkButton);
            this.Controls.Add(this.serverIPtextBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverIPtextBox;
        private System.Windows.Forms.Button linkButton;
        private System.Windows.Forms.Label linkStatus;
        private System.Windows.Forms.Button getNumberButton;
        private System.Windows.Forms.Label myNumber;
    }
}

