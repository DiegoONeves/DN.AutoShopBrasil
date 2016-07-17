using System.Security.Cryptography;
using System.Text;

namespace DN.AutoShopBrasil.Common.ExtensionMethods
{
    public static class StringExtension
    {
        public static string ClearPhoneNumber(this string target)
        {
            if (string.IsNullOrWhiteSpace(target))
                return string.Empty;

            return target.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
        }

        public static string Encrypt(this string target)
        {
            target += "|2d331cca-f6c0-40c0-bb43-6e32989c2881";
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(target));
            StringBuilder sbString = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sbString.Append(data[i].ToString("x2"));
            return sbString.ToString();
        }
    }
}
