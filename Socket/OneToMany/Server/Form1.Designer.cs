
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
			this.TxtIp = new System.Windows.Forms.TextBox();
			this.TxtPort = new System.Windows.Forms.TextBox();
			this.BtnOpenPort = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.TxtIndex = new System.Windows.Forms.TextBox();
			this.TxtMessage = new System.Windows.Forms.TextBox();
			this.BtnSend = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// TxtIp
			// 
			this.TxtIp.Location = new System.Drawing.Point(13, 13);
			this.TxtIp.Name = "TxtIp";
			this.TxtIp.PlaceholderText = "put your ipv4 address. or leave it empty.";
			this.TxtIp.Size = new System.Drawing.Size(471, 23);
			this.TxtIp.TabIndex = 0;
			// 
			// TxtPort
			// 
			this.TxtPort.Location = new System.Drawing.Point(490, 14);
			this.TxtPort.Name = "TxtPort";
			this.TxtPort.PlaceholderText = "port to connect";
			this.TxtPort.Size = new System.Drawing.Size(215, 23);
			this.TxtPort.TabIndex = 1;
			// 
			// BtnOpenPort
			// 
			this.BtnOpenPort.Location = new System.Drawing.Point(711, 14);
			this.BtnOpenPort.Name = "BtnOpenPort";
			this.BtnOpenPort.Size = new System.Drawing.Size(75, 23);
			this.BtnOpenPort.TabIndex = 2;
			this.BtnOpenPort.Text = "Open Port";
			this.BtnOpenPort.UseVisualStyleBackColor = true;
			this.BtnOpenPort.Click += new System.EventHandler(this.BtnOpenPort_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
			this.dataGridView1.Location = new System.Drawing.Point(13, 43);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 25;
			this.dataGridView1.Size = new System.Drawing.Size(773, 249);
			this.dataGridView1.TabIndex = 3;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Column1";
			this.Column1.Name = "Column1";
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Column2";
			this.Column2.Name = "Column2";
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(13, 299);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(775, 139);
			this.listBox1.TabIndex = 4;
			// 
			// TxtIndex
			// 
			this.TxtIndex.Location = new System.Drawing.Point(13, 455);
			this.TxtIndex.Name = "TxtIndex";
			this.TxtIndex.PlaceholderText = "id of the column 2";
			this.TxtIndex.Size = new System.Drawing.Size(130, 23);
			this.TxtIndex.TabIndex = 5;
			// 
			// TxtMessage
			// 
			this.TxtMessage.Location = new System.Drawing.Point(149, 455);
			this.TxtMessage.Name = "TxtMessage";
			this.TxtMessage.PlaceholderText = "Message";
			this.TxtMessage.Size = new System.Drawing.Size(556, 23);
			this.TxtMessage.TabIndex = 6;
			// 
			// BtnSend
			// 
			this.BtnSend.Location = new System.Drawing.Point(711, 455);
			this.BtnSend.Name = "BtnSend";
			this.BtnSend.Size = new System.Drawing.Size(75, 23);
			this.BtnSend.TabIndex = 7;
			this.BtnSend.Text = "Send";
			this.BtnSend.UseVisualStyleBackColor = true;
			this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 495);
			this.Controls.Add(this.BtnSend);
			this.Controls.Add(this.TxtMessage);
			this.Controls.Add(this.TxtIndex);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.BtnOpenPort);
			this.Controls.Add(this.TxtPort);
			this.Controls.Add(this.TxtIp);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtIp;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.Button BtnOpenPort;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox TxtIndex;
        private System.Windows.Forms.TextBox TxtMessage;
        private System.Windows.Forms.Button BtnSend;
    }
}

