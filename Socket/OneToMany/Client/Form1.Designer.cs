
namespace Client
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
			this.BtnConnect = new System.Windows.Forms.Button();
			this.TxtPort = new System.Windows.Forms.TextBox();
			this.TxtIp = new System.Windows.Forms.TextBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.TxtMessage = new System.Windows.Forms.TextBox();
			this.BtnSend = new System.Windows.Forms.Button();
			this.TxtName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// BtnConnect
			// 
			this.BtnConnect.Location = new System.Drawing.Point(710, 13);
			this.BtnConnect.Name = "BtnConnect";
			this.BtnConnect.Size = new System.Drawing.Size(75, 23);
			this.BtnConnect.TabIndex = 5;
			this.BtnConnect.Text = "Connect";
			this.BtnConnect.UseVisualStyleBackColor = true;
			this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
			// 
			// TxtPort
			// 
			this.TxtPort.Location = new System.Drawing.Point(448, 13);
			this.TxtPort.Name = "TxtPort";
			this.TxtPort.PlaceholderText = "port to connect";
			this.TxtPort.Size = new System.Drawing.Size(101, 23);
			this.TxtPort.TabIndex = 4;
			// 
			// TxtIp
			// 
			this.TxtIp.Location = new System.Drawing.Point(12, 12);
			this.TxtIp.Name = "TxtIp";
			this.TxtIp.PlaceholderText = "put the ipv4 of the client.";
			this.TxtIp.Size = new System.Drawing.Size(430, 23);
			this.TxtIp.TabIndex = 3;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(13, 42);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(772, 259);
			this.listBox1.TabIndex = 6;
			// 
			// TxtMessage
			// 
			this.TxtMessage.Location = new System.Drawing.Point(13, 320);
			this.TxtMessage.Name = "TxtMessage";
			this.TxtMessage.PlaceholderText = "Message";
			this.TxtMessage.Size = new System.Drawing.Size(691, 23);
			this.TxtMessage.TabIndex = 7;
			// 
			// BtnSend
			// 
			this.BtnSend.Location = new System.Drawing.Point(711, 320);
			this.BtnSend.Name = "BtnSend";
			this.BtnSend.Size = new System.Drawing.Size(75, 23);
			this.BtnSend.TabIndex = 8;
			this.BtnSend.Text = "Send";
			this.BtnSend.UseVisualStyleBackColor = true;
			this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
			// 
			// TxtName
			// 
			this.TxtName.Location = new System.Drawing.Point(555, 12);
			this.TxtName.Name = "TxtName";
			this.TxtName.PlaceholderText = "Your name as register";
			this.TxtName.Size = new System.Drawing.Size(142, 23);
			this.TxtName.TabIndex = 9;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 352);
			this.Controls.Add(this.TxtName);
			this.Controls.Add(this.BtnSend);
			this.Controls.Add(this.TxtMessage);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.BtnConnect);
			this.Controls.Add(this.TxtPort);
			this.Controls.Add(this.TxtIp);
			this.MaximumSize = new System.Drawing.Size(816, 391);
			this.MinimumSize = new System.Drawing.Size(816, 391);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.TextBox TxtIp;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox TxtMessage;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.TextBox TxtName;
    }
}

