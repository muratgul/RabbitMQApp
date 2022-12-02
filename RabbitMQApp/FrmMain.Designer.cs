namespace RabbitMQApp
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCreateDocument = new System.Windows.Forms.Button();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection String";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(374, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCreateDocument
            // 
            this.btnCreateDocument.Enabled = false;
            this.btnCreateDocument.Location = new System.Drawing.Point(109, 45);
            this.btnCreateDocument.Name = "btnCreateDocument";
            this.btnCreateDocument.Size = new System.Drawing.Size(99, 36);
            this.btnCreateDocument.TabIndex = 2;
            this.btnCreateDocument.Text = "Create Document";
            this.btnCreateDocument.UseVisualStyleBackColor = true;
            this.btnCreateDocument.Click += new System.EventHandler(this.btnCreateDocument_Click);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(108, 7);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(260, 20);
            this.txtConnectionString.TabIndex = 3;
            this.txtConnectionString.Text = "amqp://guest:guest@localhost:5672";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(3, 104);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(458, 248);
            this.txtLog.TabIndex = 4;
            this.txtLog.Text = "";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 355);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.btnCreateDocument);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnCreateDocument;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.RichTextBox txtLog;
    }
}

