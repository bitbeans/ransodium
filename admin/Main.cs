using System;
using System.Windows.Forms;
using Sodium;
using StreamCryptor.Helper;

namespace admin
{
    public partial class Main : Form
    {
        private const string TargetPrivateKeyHex = "a47d32753b3e3834686482df9b5e69e8ab371a757dc589b93ce58c1e091fb42b";

        public Main()
        {
            InitializeComponent();
        }

        private void decryptAdminString_Click(object sender, EventArgs e)
        {
            try
            {
                var adminStringByteArray = Convert.FromBase64String(adminString.Text);
                var nonce = ArrayHelpers.SubArray(adminStringByteArray, 0, 24);
                var publicKey = ArrayHelpers.SubArray(adminStringByteArray, 24, 32);
                var cipher = ArrayHelpers.SubArray(adminStringByteArray, 56);
                var privateKey = Utilities.HexToBinary(TargetPrivateKeyHex);

                decryptionKey.Text = Utilities.BinaryToHex(PublicKeyBox.Open(cipher, nonce, privateKey, publicKey));
            }
            catch
            {
            }
        }
    }
}