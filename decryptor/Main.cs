using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using Sodium;
using StreamCryptor;

namespace decryptor
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void browserFolder_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Choose your root folder";
            folderBrowserDialog.SelectedPath = @"C:\";
            var res = folderBrowserDialog.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                rootFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void decryptFiles_Click(object sender, EventArgs e)
        {
            var searchPattern = new[] {"locked"};
            if ((!string.IsNullOrEmpty(rootFolder.Text)) && (!string.IsNullOrEmpty(userDecryptionKey.Text)))
            {
                if (Directory.Exists(rootFolder.Text))
                {
                    var privateKey = Utilities.HexToBinary(userDecryptionKey.Text);
                    var files = GetFiles(rootFolder.Text, searchPattern);
                    foreach (var file in files)
                    {
                        // should run in background ...
                        Cryptor.DecryptFileWithStream(privateKey, file, Path.GetDirectoryName(file), true);
                        File.Delete(file);
                    }
                }
            }
        }

        /// <summary>
        ///     Get a recursive file list.
        /// </summary>
        /// <param name="root">The root folder to start.</param>
        /// <param name="searchPattern">The file pattern to search for.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        internal static List<string> GetFiles(string root, string[] searchPattern)
        {
            var files = new List<string>();
            try
            {
                files.AddRange(
                    Directory.EnumerateFiles(root, "*.*")
                        .Where(file => searchPattern.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))));
                foreach (var directory in Directory.EnumerateDirectories(root))
                {
                    files.AddRange(
                        Directory.EnumerateFiles(directory, "*.*")
                            .Where(file => searchPattern.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))));
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (PathTooLongException)
            {
            }
            catch (SecurityException)
            {
            }
            catch (DirectoryNotFoundException)
            {
            }
            catch (IOException)
            {
            }
            return files;
        }
    }
}