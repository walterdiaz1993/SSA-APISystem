using System.Security.Cryptography;
using System.Text;

namespace Services.NetCore.Crosscutting.Helpers
{
    public static class AESEncryptor
    {
        public static string Encrypt(string stringText)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(stringText));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
