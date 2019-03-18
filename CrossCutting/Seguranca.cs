using System.Security.Cryptography;
using System.Text;

namespace CrossCutting
{
    public static class Seguranca
    {
        public static string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}