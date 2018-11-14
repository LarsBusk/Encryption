using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foss.Platform.IO.SignalCompression;

namespace EncryptDecrypt
{
  public class DecrompressionHelper
  {
    public static float[] Decompress(string fileName)
    {
      FileStream stream = File.Open(fileName, FileMode.Open);

      var decr = FloatCompression.Unpack(stream);

      return decr;
    }
  }
}

