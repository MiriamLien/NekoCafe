using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace NekoCafe.Helpers
{
    public class AccountHelper
    {
        public static byte[] BuildNewSalt()
        {
            byte[] randBytes = new byte[32];
            RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();
            rand.GetBytes(randBytes);
            return randBytes;
        }

        /// <summary> 密碼進行雜湊 </summary>
        /// <param name="pwd">密碼</param>
        /// <param name="key">金鑰</param>
        /// <param name="salt">鹽</param>
        /// <returns></returns>
        public static byte[] GetHashPassword(string pwd, string key, byte[] salt)
        {
            byte[] keyByte = Encoding.UTF8.GetBytes(key);
            byte[] pwdBytes = Encoding.UTF8.GetBytes(pwd);
            byte[] totalBytes = salt.Union(pwdBytes).ToArray();

            HMACSHA512 hmacsha512 = new HMACSHA512(keyByte);
            byte[] hashPwd = hmacsha512.ComputeHash(totalBytes);
            return hashPwd;
        }

        static byte[] AesEncrypt(string plainText, byte[] Key, byte[] IV)
        {
            // 驗證參數
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // 產生加密器
                ICryptoTransform encryptor =
                    aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt =
                       new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }

    }
}

