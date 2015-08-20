namespace decryptor
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
            this.browserFolder = new System.Windows.Forms.Button();
            this.rootFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userDecryptionKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.decryptFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // browserFolder
            // 
            this.browserFolder.Location = new System.Drawing.Point(581, 23);
            this.browserFolder.Name = "browserFolder";
            this.browserFolder.Size = new System.Drawing.Size(27, 22);
            this.browserFolder.TabIndex = 0;
            this.browserFolder.Text = "...";
            this.browserFolder.UseVisualStyleBackColor = true;
            this.browserFolder.Click += new System.EventHandler(this.browserFolder_Click);
            // 
            // rootFolder
            // 
            this.rootFolder.Location = new System.Drawing.Point(12, 25);
            this.rootFolder.Name = "rootFolder";
            this.rootFolder.ReadOnly = true;
            this.rootFolder.Size = new System.Drawing.Size(563, 20);
            this.rootFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "1. Choose your root folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "2. Enter your decryption key";
            // 
            // userDecryptionKey
            // 
            this.userDecryptionKey.Location = new System.Drawing.Point(12, 64);
            this.userDecryptionKey.Name = "userDecryptionKey";
            this.userDecryptionKey.Size = new System.Drawing.Size(563, 20);
            this.userDecryptionKey.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "3. Decrypt";
            // 
            // decryptFiles
            // 
            this.decryptFiles.Location = new System.Drawing.Point(12, 103);
            this.decryptFiles.Name = "decryptFiles";
            this.decryptFiles.Size = new System.Drawing.Size(596, 23);
            this.decryptFiles.TabIndex = 6;
            this.decryptFiles.Text = "Decrypt";
            this.decryptFiles.UseVisualStyleBackColor = true;
            this.decryptFiles.Click += new System.EventHandler(this.decryptFiles_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 133);
            this.Controls.Add(this.decryptFiles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userDecryptionKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rootFolder);
            this.Controls.Add(this.browserFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "ransodium User Decryptor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browserFolder;
        private System.Windows.Forms.TextBox rootFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userDecryptionKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button decryptFiles;
    }
}

