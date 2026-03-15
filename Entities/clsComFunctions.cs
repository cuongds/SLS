using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MDSolution
{
    public class clsComFunctions
    {
        public static string ConvertToEngland(string strVNDatatime)
        {
            string strENDateTime = strVNDatatime;
            string ngay, thang;
            if (!string.IsNullOrEmpty(strENDateTime))
            {
                ngay = strENDateTime.Substring(0,strENDateTime.IndexOf("/"));
                strENDateTime =strENDateTime.Substring(strENDateTime.IndexOf("/")+1);
                thang =strENDateTime.Substring(0,strENDateTime.IndexOf("/"));
                strENDateTime = thang +"/" +ngay+strENDateTime.Substring(strENDateTime.IndexOf("/"));
            }
            return strENDateTime;
        }        
        public static string HoTen_Format(string s)
        {
            string Result = "";
            string[] temp = s.Trim().Split(' ');
            foreach (string item in temp )
            {
                Result += item[0].ToString().ToUpper() + item.Substring(1) + " ";
            }
            return Result.Trim();
        }

        public static bool isNumber(string s)
        {
            bool result = true;
            double t = -1;
            try
            {
                t = double.Parse(s);
            }
            catch
            {
                t = -1;
            }
            if (t < 0)
            {
                result = false;
            }
            return result;
        }

        private const string cryptoKey = "md2008";

        // The Initialization Vector for the DES encryption routine
        private static readonly byte[] IV =
            new byte[8] { 240, 39, 45, 29, 0, 76, 173, 64 };

        public static string Encrypt(string s)
        {
            if (s == null || s.Length == 0) return string.Empty;

            string result = string.Empty;

            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(s);

                TripleDESCryptoServiceProvider des =
                    new TripleDESCryptoServiceProvider();

                MD5CryptoServiceProvider MD5 =
                    new MD5CryptoServiceProvider();

                des.Key =
                    MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                des.IV = IV;
                result = Convert.ToBase64String(
                    des.CreateEncryptor().TransformFinalBlock(
                        buffer, 0, buffer.Length));
            }
            catch
            {
                throw;
            }

            return result.Replace('=','@');
        }

        /// <summary>
        /// Decrypts provided string parameter
        /// </summary>
        public static string Decrypt(string s)
        {
            s=s.Replace('@', '=');
            if (s == null || s.Length == 0) return string.Empty;

            string result = string.Empty;

            try
            {
                byte[] buffer = Convert.FromBase64String(s);

                TripleDESCryptoServiceProvider des =
                    new TripleDESCryptoServiceProvider();

                MD5CryptoServiceProvider MD5 =
                    new MD5CryptoServiceProvider();

                des.Key =
                    MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                des.IV = IV;

                result = Encoding.ASCII.GetString(
                    des.CreateDecryptor().TransformFinalBlock(
                    buffer, 0, buffer.Length));
            }
            catch
            {
                throw;
            }

            return result;
        }
    }
}
