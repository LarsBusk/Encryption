using FOSS.Nova.Common.Encryption;

namespace EncryptDecrypt.Containers
{
    internal class CryptoVersionContent
    {
        public CryptoVersion CryptoVersion;

        public string CryptoVersionName;

        public CryptoVersionContent(CryptoVersion cryptoVersion, string cryptoVersionName)
        {
            this.CryptoVersion = cryptoVersion;
            this.CryptoVersionName = cryptoVersionName;
        }

        public override string ToString()
        {
            return this.CryptoVersionName;
        }
    }
}
