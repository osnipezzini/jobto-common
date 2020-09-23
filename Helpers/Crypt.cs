using System;
using System.Security.Cryptography;
using System.Text;

namespace JobTo.Common.Helpers
{
    public static class Crypt
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public static string Decrypt(string value)
        {
            try
            {
                byte[] data = Convert.FromBase64String(value); // decrypt the incrypted text
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Settings.Secret));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        return UTF8Encoding.UTF8.GetString(results);
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.Error(exc);
            }
            return value;
        }
        public static string Encrypt(string value)
        {
            try
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(value);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Settings.Secret));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateEncryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        return Convert.ToBase64String(results, 0, results.Length);
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.Error(exc);
            }
            return value;

        }
    }
}
