using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsymmetricDecryption;
using FOSS.Nova.Common.Encryption;

namespace EncryptDecrypt
{
  public class EncryptionHelper
  {
    public static byte[] EncryptData(byte[] data, int cryptoVersion)
    {
      return EncryptionAsymmHelper.EncryptToXml(data);
    }
  }
}
