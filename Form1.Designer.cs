namespace WinFormsApp_Course_14
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
            label1 = new Label();
            textBox1 = new TextBox();
            btnDownload = new Button();
            cmbFormat = new ComboBox();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Window;
            label1.Font = new Font("Showcard Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(82, 87);
            label1.Name = "label1";
            label1.Size = new Size(813, 50);
            label1.TabIndex = 0;
            label1.Text = "Video Downloader (Yasser edition) ";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(119, 246);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(726, 31);
            textBox1.TabIndex = 1;
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(119, 333);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(251, 44);
            btnDownload.TabIndex = 2;
            btnDownload.Text = "Downolad";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // cmbFormat
            // 
            cmbFormat.FormattingEnabled = true;
            cmbFormat.Items.AddRange(new object[] { "mp4", "mp3" });
            cmbFormat.Location = new Point(583, 340);
            cmbFormat.Name = "cmbFormat";
            cmbFormat.Size = new Size(262, 33);
            cmbFormat.TabIndex = 4;
            cmbFormat.Tag = "";
            cmbFormat.Text = "Format";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(429, 436);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 25);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(972, 527);
            Controls.Add(lblStatus);
            Controls.Add(cmbFormat);
            Controls.Add(btnDownload);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "        cmbFormat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button btnDownload;
        private ComboBox cmbFormat;
        private Label lblStatus;
    }
}
