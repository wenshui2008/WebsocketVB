namespace CSTester
{
    partial class mainForm
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.urlInput = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.msgListbox = new System.Windows.Forms.TextBox();
            this.msgInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(49, 25);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // urlInput
            // 
            this.urlInput.Location = new System.Drawing.Point(130, 27);
            this.urlInput.Name = "urlInput";
            this.urlInput.Size = new System.Drawing.Size(266, 21);
            this.urlInput.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(402, 27);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // msgListbox
            // 
            this.msgListbox.Location = new System.Drawing.Point(52, 60);
            this.msgListbox.Multiline = true;
            this.msgListbox.Name = "msgListbox";
            this.msgListbox.Size = new System.Drawing.Size(424, 277);
            this.msgListbox.TabIndex = 3;
            // 
            // msgInput
            // 
            this.msgInput.Location = new System.Drawing.Point(52, 343);
            this.msgInput.Name = "msgInput";
            this.msgInput.Size = new System.Drawing.Size(333, 21);
            this.msgInput.TabIndex = 4;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(401, 343);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 407);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.msgInput);
            this.Controls.Add(this.msgListbox);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.urlInput);
            this.Controls.Add(this.btnOpen);
            this.Name = "mainForm";
            this.Text = "C# Websocket Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox urlInput;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox msgListbox;
        private System.Windows.Forms.TextBox msgInput;
        private System.Windows.Forms.Button btnSend;
    }
}

