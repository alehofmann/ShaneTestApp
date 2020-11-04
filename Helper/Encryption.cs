using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ShaneSampleApp.Helper
{
    public class Encryption
    {
        private static string _key;
        private static string _IV;

        public Encryption()
        {
            if (string.IsNullOrEmpty(_key) || string.IsNullOrEmpty(_IV))
            {
                Configuration myConfiguration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                _key = ConfigurationManager.AppSettings.Get("CryptoKey");
                _IV = ConfigurationManager.AppSettings.Get("CryptoIV");
                
                if (string.IsNullOrEmpty(_key) || string.IsNullOrEmpty(_IV))
                {
                    using (Aes aesAlg = Aes.Create())
                    {
                        aesAlg.GenerateKey();
                        _key = Convert.ToBase64String(aesAlg.Key);
                        aesAlg.GenerateIV();
                        _IV = Convert.ToBase64String(aesAlg.IV);
                        
                        myConfiguration.AppSettings.Settings["CryptoKey"].Value = _key;
                        myConfiguration.AppSettings.Settings["CryptoIV"].Value = _IV;
                        myConfiguration.Save();
                    }
                }
            }
        }
        
        public string Encrypt(string text)
        {            
            return EncryptString_Aes(text, _key, _IV);
        }

        public string Decrypt(string text)
        {         
            return DecryptString_Aes(text, _key, _IV);
        }

        string EncryptString_Aes(string plainText, string keyString, string IVString)
        {
            byte[] key = Convert.FromBase64String(keyString);
            byte[] IV = Convert.FromBase64String(IVString);

            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            
            return Convert.ToBase64String(encrypted);
        }

        string DecryptString_Aes(string cipherText, string keyString, string IVString)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] key = Convert.FromBase64String(keyString);
            byte[] IV = Convert.FromBase64String(IVString);

            // Check arguments.
            if (cipherBytes == null || cipherBytes.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
