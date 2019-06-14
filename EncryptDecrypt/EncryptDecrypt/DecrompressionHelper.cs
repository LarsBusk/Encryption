using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foss.Platform.IO.SignalCompression;
using Google.Protobuf;

namespace EncryptDecrypt
{
  public class DecrompressionHelper
  {
    public static void Decompress(string decryptedFileName, string readFileName)
    {
      FileStream stream = File.Open(readFileName, FileMode.Open);

      var floats = FloatCompression.Unpack(stream);

      StringBuilder builder = new StringBuilder();

      foreach (var f in floats)
      {
        builder.Append(f.ToString());
        builder.Append(";");
      }

      string[] writeStrings = new[] { builder.ToString() };

      File.WriteAllLines(decryptedFileName, writeStrings);
    }
  }
}

