
namespace Server
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.BtnOpenport = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.TxtMessage = new System.Windows.Forms.TextBox();
			this.BtnSend = new System.Windows.Forms.Button();
			this.TxtIp = new System.Windows.Forms.TextBox();
			this.TxtPort = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// BtnOpenport
			// 
			this.BtnOpenport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnOpenport.Location = new System.Drawing.Point(713, 12);
			this.BtnOpenport.Name = "BtnOpenport";
			this.BtnOpenport.Size = new System.Drawing.Size(75, 23);
			this.BtnOpenport.TabIndex = 1;
			this.BtnOpenport.Text = "Open Port";
			this.BtnOpenport.UseVisualStyleBackColor = true;
			this.BtnOpenport.Click += new System.EventHandler(this.BtnOpenport_Click);
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(13, 48);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(776, 244);
			this.listBox1.TabIndex = 2;
			// 
			// TxtMessage
			// 
			this.TxtMessage.Location = new System.Drawing.Point(12, 313);
			this.TxtMessage.Name = "TxtMessage";
			this.TxtMessage.PlaceholderText = "Message";
			this.TxtMessage.Size = new System.Drawing.Size(695, 23);
			this.TxtMessage.TabIndex = 3;
			// 
			// BtnSend
			// 
			this.BtnSend.Location = new System.Drawing.Point(714, 313);
			this.BtnSend.Name = "BtnSend";
			this.BtnSend.Size = new System.Drawing.Size(74, 23);
			this.BtnSend.TabIndex = 4;
			this.BtnSend.Text = "Send";
			this.BtnSend.UseVisualStyleBackColor = true;
			this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
			// 
			// TxtIp
			// 
			this.TxtIp.Location = new System.Drawing.Point(13, 12);
			this.TxtIp.Name = "TxtIp";
			this.TxtIp.PlaceholderText = "put your ipv4 address. or leave it empty.";
			this.TxtIp.Size = new System.Drawing.Size(443, 23);
			this.TxtIp.TabIndex = 5;
			// 
			// TxtPort
			// 
			this.TxtPort.Location = new System.Drawing.Point(462, 12);
			this.TxtPort.Name = "TxtPort";
			this.TxtPort.PlaceholderText = "port to open";
			this.TxtPort.Size = new System.Drawing.Size(246, 23);
			this.TxtPort.TabIndex = 6;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 355);
			this.Controls.Add(this.TxtPort);
			this.Controls.Add(this.TxtIp);
			this.Controls.Add(this.BtnSend);
			this.Controls.Add(this.TxtMessage);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.BtnOpenport);
			this.MaximumSize = new System.Drawing.Size(816, 394);
			this.MinimumSize = new System.Drawing.Size(816, 394);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnOpenport;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.TextBox TxtMessage;
        private System.Windows.Forms.TextBox TxtIp;
        private System.Windows.Forms.TextBox TxtPort;
    }
}

