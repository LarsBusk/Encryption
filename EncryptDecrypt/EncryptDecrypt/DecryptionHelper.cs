using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using AsymmetricDecryption;
using FOSS.Nova.Common.Encryption;

namespace EncryptDecrypt
{
  public static class DecryptionHelper
  {
    public static byte[] DecryptBlackBoxData(byte[] encryptedBytes)
    {
      return Asymmetric.Decrypt(encryptedBytes);
    }

    public static byte[] DecryptFile(byte[] encryptedData)
    {
      if (encryptedData == null)
      {
        return null;
      }

      try
      {
        XDocument xd;

        using (var stream = new MemoryStream(encryptedData))
        {
          using (XmlReader xmlReader = XmlReader.Create(stream))
          {
            xd = XDocument.Load(xmlReader);
          }
        }

        XElement root = xd.Root;

        if (root == null)
        {
          return null;
        }

        var crVersion = (int?)root.Attribute("CrVersion");

        if (!crVersion.HasValue)
        {
          return null;
        }

        switch (crVersion.Value)
        {
          case (int)CryptoVersion.CrV0AsymRaw1:
            return Asymmetric.Decrypt(encryptedData);
          case (int)CryptoVersion.CrV1SymRaw1:
          case (int)CryptoVersion.CrV4SymRaw2:
          case (int)CryptoVersion.CrV5SymRaw3:
            return EncryptionSymmHelper.Decrypt(encryptedData);
          case (int)CryptoVersion.CrV2SymSettings1:
          case (int)CryptoVersion.CrV6SymSettings2:
            return EncryptionSettingsHelper.Decrypt(encryptedData);
          case (int)CryptoVersion.CrV3AsymRaw2:
            return Asymmetric.Decrypt(encryptedData);
          default:
            return null;
        }
      }
      catch (Exception)
      {

      }

      return null;
    }
  }
}