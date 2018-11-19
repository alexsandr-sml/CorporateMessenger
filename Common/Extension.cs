using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public static class Extension
    {
        public static int ToInt(this object value, int defaultValue = 0)
        {
            if (value is int)
                return (int)value;

            if (value == null)
                return defaultValue;

            if (string.IsNullOrEmpty(value.ToString()))
                return defaultValue;

            int res;
            if (int.TryParse(value.ToString(), out res))
                return res;

            return defaultValue;
        }

        public static float ToFloat(this object value, float defaultValue = 0)
        {
            if (value is int)
                return (float)value;

            if (value == null)
                return defaultValue;

            if (string.IsNullOrEmpty(value.ToString()))
                return defaultValue;

            float res;
            if (float.TryParse(value.ToString(), out res))
                return res;

            return defaultValue;
        }

        public static double ToDouble(this object value, double defaultValue = 0)
        {
            if (value is double)
                return (double)value;

            if (value == null)
                return defaultValue;

            if (string.IsNullOrEmpty(value.ToString()))
                return defaultValue;

            double res;
            if (double.TryParse(value.ToString(), out res))
                return res;

            return defaultValue;
        }

        public static DateTime ToDateTime(this object value, DateTime defaultValue = default(DateTime))
        {
            if (value is DateTime)
                return (DateTime)value;

            if (value == null)
                return defaultValue;

            if (string.IsNullOrEmpty(value.ToString()))
                return defaultValue;

            DateTime res;
            if (DateTime.TryParse(value.ToString(), out res))
                return res;

            return defaultValue;
        }

        public static IEnumerable<TControl> GetChildControls<TControl>(this Control control) where TControl : Control
        {
            var children = (control.Controls != null) ? control.Controls.OfType<TControl>() : Enumerable.Empty<TControl>();
            return children.SelectMany(c => GetChildControls<TControl>(c)).Concat(children);
        }

        public static string CleanFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        public static string GetMD5(string text)
        {
            var hash = string.Empty;
            using (MD5 md5Hash = MD5.Create())
                hash = GetMd5Hash(md5Hash, text);

            return hash;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes and create a string.
            var sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static bool VerifyMd5Hash(string input, string hash)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Hash the input.
                var hashOfInput = GetMd5Hash(md5Hash, input);
                // Create a StringComparer an compare the hashes.
                var comparer = StringComparer.OrdinalIgnoreCase;

                return (0 == comparer.Compare(hashOfInput, hash) ? true : false);
            }
        }
    }
}
