using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace DESPwd
{
    public class DESUtil
    {
        static DESCryptoServiceProvider des = new DESCryptoServiceProvider();

        public static DESCryptoServiceProvider DES
        {
            get { return des; }
        }
        const string EncryptionKey = "诺丽科技";
        const string EncryptionIV = "kell";
        public static string Encoder(string input)
        {
            byte[] SourceData = Encoding.Unicode.GetBytes(input);
            byte[] returnData = null;
            try
            {
                des.Key = ASCIIEncoding.Unicode.GetBytes(EncryptionKey);
                des.IV = ASCIIEncoding.Unicode.GetBytes(EncryptionIV);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(SourceData, 0, SourceData.Length);
                cs.FlushFinalBlock();
                returnData = ms.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Encoding.Unicode.GetString(returnData);
        }
        public static string Decoder(string input)
        {
            byte[] SourceData = Encoding.Unicode.GetBytes(input);
            byte[] returnData = null;
            try
            {
                DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();
                desProvider.Key = Encoding.Unicode.GetBytes(EncryptionKey);
                desProvider.IV = Encoding.Unicode.GetBytes(EncryptionIV);
                MemoryStream ms = new MemoryStream();
                ICryptoTransform encrypto = desProvider.CreateDecryptor();
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
                cs.Write(SourceData, 0, SourceData.Length);
                cs.FlushFinalBlock();
                returnData = ms.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Encoding.Unicode.GetString(returnData);
        }
    }
}
