namespace admin
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.adminString = new System.Windows.Forms.TextBox();
            this.decryptAdminString = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.decryptionKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // adminString
            // 
            this.adminString.Location = new System.Drawing.Point(15, 25);
            this.adminString.Name = "adminString";
            this.adminString.Size = new System.Drawing.Size(433, 20);
            this.adminString.TabIndex = 0;
            // 
            // decryptAdminString
            // 
            this.decryptAdminString.Location = new System.Drawing.Point(15, 51);
            this.decryptAdminString.Name = "decryptAdminString";
            this.decryptAdminString.Size = new System.Drawing.Size(433, 23);
            this.decryptAdminString.TabIndex = 1;
            this.decryptAdminString.Text = "Decrypt Base64 string";
            this.decryptAdminString.UseVisualStyleBackColor = true;
            this.decryptAdminString.Click += new System.EventHandler(this.decryptAdminString_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter the users Base64 string";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Users decryption key";
            // 
            // decryptionKey
            // 
            this.decryptionKey.Location = new System.Drawing.Point(15, 93);
            this.decryptionKey.Name = "decryptionKey";
            this.decryptionKey.ReadOnly = true;
            this.decryptionKey.Size = new System.Drawing.Size(433, 20);
            this.decryptionKey.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 123);
            this.Controls.Add(this.decryptionKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decryptAdminString);
            this.Controls.Add(this.adminString);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "ransodium Admin Decryptor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox adminString;
        private System.Windows.Forms.Button decryptAdminString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox decryptionKey;
    }
}

