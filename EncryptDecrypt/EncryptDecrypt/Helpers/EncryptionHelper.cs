using FOSS.Nova.Common.Encryption;

namespace EncryptDecrypt.Helpers
{
    public class EncryptionHelper
    {
        public static byte[] EncryptData(byte[] data, CryptoVersion cryptoVersion)
        {
            switch (cryptoVersion)
            {
                case CryptoVersion.CrV0AsymRaw1:
                    return EncryptAssym(data, CryptoVersion.CrV0AsymRaw1);
                case CryptoVersion.CrV3AsymRaw2:
                    return EncryptAssym(data, CryptoVersion.CrV3AsymRaw2);
                case CryptoVersion.CrV6SymSettings2:
                    return EncryptSettings(data);
                default:
                    return null;

            }
        }

        private static byte[] EncryptSettings(byte[] content)
        {
            return EncryptionSettingsHelper.EncryptToSettingsXml(content, CryptoVersion.CrV6SymSettings2);
        }

        private static byte[] EncryptAssym(byte[] content, CryptoVersion cryptoVersion)
        {
            return EncryptionAsymmHelper.Encrypt(content, cryptoVersion);
        }
    }
}
