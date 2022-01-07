using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptAndDecrypt
{
    internal class Program
    {
        public static string Encrypt(string inputText)
        {
            //string encryptionkey = "SAUW193BX628TD57";
            string encryptionkey = "SAUW193BX628TD57";
            byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] plainText = Encoding.Unicode.GetBytes(inputText);
            PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
            using (ICryptoTransform encryptrans = rijndaelCipher.CreateEncryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
            {
                using (MemoryStream mstrm = new MemoryStream())
                {
                    using (CryptoStream cryptstm = new CryptoStream(mstrm, encryptrans, CryptoStreamMode.Write))
                    {
                        cryptstm.Write(plainText, 0, plainText.Length);
                        cryptstm.Close();
                        return Convert.ToBase64String(mstrm.ToArray());
                    }
                }
            }
        }
        public static string Decrypt(string encryptText)
        {
            string encryptionkey = "SAUW193BX628TD57";
            byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
            RijndaelManaged rijndaelCipher = new RijndaelManaged();

            byte[] encryptedData = Convert.FromBase64String(encryptText);
            PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
            using (ICryptoTransform decryptrans = rijndaelCipher.CreateDecryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
            {
                using (MemoryStream mstrm = new MemoryStream(encryptedData))
                {
                    using (CryptoStream cryptstm = new CryptoStream(mstrm, decryptrans, CryptoStreamMode.Read))
                    {
                        byte[] plainText = new byte[encryptedData.Length];
                        int decryptedCount = cryptstm.Read(plainText, 0, plainText.Length);
                        return Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                    }
                }
            }


        }
        static void Main(string[] args)
        {
            /*
            string Encrypts1 = Encrypt(DateTime.Now.ToString("HHmmss"));
            string Encrypts2 = Encrypt(DateTime.Now.ToString("HHmmss"));
            string Encrypts3 = Encrypt(DateTime.Now.ToString("HHmmss"));
            string Decrypts1 = Decrypt(Encrypts1);
            string Decrypts2 = Decrypt(Encrypts2);
            string Decrypts3 = Decrypt(Encrypts3);
            
            Console.WriteLine(Encrypts1);
            Console.WriteLine(Decrypts1);
            Console.WriteLine(Encrypts2);
            Console.WriteLine(Decrypts2);
            Console.WriteLine(Encrypts3);
            Console.WriteLine(Decrypts3);
            */

            Console.WriteLine("-----------------1---------------");
            Console.WriteLine("Enter   ....");
           string En=Encrypt(Convert.ToString( Console.ReadLine())).Replace("/", "ABDULLAH").Replace("==", "SALEH").Replace("+", "c");
           Console.WriteLine(En);
            Console.WriteLine("Decrypt   ....");
           Console.WriteLine(Decrypt(En.Replace("ABDULLAH", "/").Replace("SALEH", "==").Replace("c", "+")));
            Console.WriteLine("-----------------1---------------");
            Console.WriteLine("-----------------2---------------");
            Console.WriteLine("Enter   ....");
            string En2 = Encrypt(Convert.ToString(Console.ReadLine())).Replace("/", "ABDULLAH").Replace("==", "SALEH").Replace("+", "c");
            Console.WriteLine(En2);
            Console.WriteLine("Decrypt   ....");
           Console.WriteLine(Decrypt(En2.Replace("ABDULLAH", "/").Replace("SALEH", "==").Replace("c", "+")));
            Console.WriteLine("-----------------2---------------");
            Console.WriteLine("-----------------3---------------");
            Console.WriteLine("Enter   ....");
            string En3 = Encrypt(Convert.ToString(Console.ReadLine())).Replace("/", "ABDULLAH").Replace("==", "SALEH").Replace("+", "c");
            Console.WriteLine(En3);
            Console.WriteLine("Decrypt   ....");
            Console.WriteLine(Decrypt(En3.Replace("ABDULLAH", "/").Replace("SALEH", "==").Replace("c", "+")));
            Console.WriteLine("-----------------3---------------");

            Console.ReadKey(); 
            
        }
    }
}
