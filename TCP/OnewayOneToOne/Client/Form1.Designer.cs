﻿
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
			this.button1 = new System.Windows.Forms.Button();
			this.TxtIp = new System.Windows.Forms.TextBox();
			this.TxtMessage = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(301, 143);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(145, 51);
			this.button1.TabIndex = 0;
			this.button1.Text = "Fire";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// TxtIp
			// 
			this.TxtIp.Location = new System.Drawing.Point(233, 55);
			this.TxtIp.Name = "TxtIp";
			this.TxtIp.PlaceholderText = "put the ipv4 of the server.";
			this.TxtIp.Size = new System.Drawing.Size(316, 23);
			this.TxtIp.TabIndex = 1;
			// 
			// TxtMessage
			// 
			this.TxtMessage.Location = new System.Drawing.Point(233, 84);
			this.TxtMessage.Multiline = true;
			this.TxtMessage.Name = "TxtMessage";
			this.TxtMessage.PlaceholderText = "Put the message";
			this.TxtMessage.Size = new System.Drawing.Size(316, 53);
			this.TxtMessage.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.TxtMessage);
			this.Controls.Add(this.TxtIp);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtIp;
        private System.Windows.Forms.TextBox TxtMessage;
    }
}

