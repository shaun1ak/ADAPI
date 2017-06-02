using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Dal
{
    public class Encryption
    {
        //ToDo: move to settings
        //private const string EncryptionKey = "qFfS+EYV241HR2cS4ZNTg68BjJleaVb2vmdD/X8X+XU=";


        public static string EncryptString(string plainText, string innitializationVector, string key)
        {
            if (plainText == null)
            {
                return null;
            }

            return
                Convert.ToBase64String(EncryptStringToBytes_Aes(plainText,
                    Convert.FromBase64String(key),
                    Convert.FromBase64String(innitializationVector)));
        }

        public static string DecryptString(string encryptedText, string innitializationVector, string key)
        {
            if (encryptedText == null)
            {
                return null;
            }

            return DecryptStringFromBytes_Aes(Convert.FromBase64String(encryptedText),
                Convert.FromBase64String(key),
                Convert.FromBase64String(innitializationVector));
        }

        // See http://msdn.microsoft.com/en-us/library/system.security.cryptography.aes(v=vs.110).aspx
        private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments. 
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("key");

            byte[] encrypted;
            // Create an Aes object
            // with the specified key and IV. 
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(key, iv);

                // Create the streams used for encryption. 
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                            //csEncrypt.FlushFinalBlock();
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream. 
            return encrypted;
        }

        private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments. 
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("key");

            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext;

            // Create an Aes object 
            // with the specified key and IV. 
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(key, iv);

                // Create the streams used for decryption. 
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
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
