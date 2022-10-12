using Foss.Platform.IO.SignalCompression;
using System.IO;
using System.Text;

namespace EncryptDecrypt.Helpers
{
    public class DecrompressionHelper
  {
    public static void Decompress(string decryptedFileName, string readFileName)
    {
      FileStream stream = File.Open(readFileName, FileMode.Open);
      float[] floats;
      if (FloatCompression.TryUnpack(stream, out floats))
      {
        StringBuilder builder = new StringBuilder();

        foreach (var f in floats)
        {
          builder.Append(f.ToString());
          builder.Append(";");
        }

        string[] writeStrings = new[] {builder.ToString()};

        File.WriteAllLines(decryptedFileName, writeStrings);
      }
    }
  }
}

