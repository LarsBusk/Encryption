using Foss.Platform.IO.SignalCompression;
using System.IO;
using System.Text;

namespace EncryptDecrypt.Helpers
{
    public class DecrompressionHelper
    {
        public static void Decompress(string decryptedFileName, string readFileName)
        {
            using (FileStream stream = File.Open(readFileName, FileMode.Open))
            {
                if (!FloatCompression.TryUnpack(stream, out float[] floats)) return;

                StringBuilder builder = new StringBuilder();

                foreach (var f in floats)
                {
                    builder.Append(f.ToString());
                    builder.Append(";");
                }

                var writeStrings = new[] { builder.ToString() };

                File.WriteAllLines(decryptedFileName, writeStrings);
            }
        }
    }
}

