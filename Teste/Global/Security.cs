using System.Security.Cryptography;
using System.Text;

namespace Teste.Global
{
    public class Security
    {
        public string encryptKey = "se35h68r4g20,f-awdwafwaga35f1a8w4dd1WA";

        #region codificacao
        public string EncodeToBytes(string text)
        {
            string result = string.Empty;

            byte[] textBytes = Encoding.UTF8.GetBytes(text);


            for (int i = 0; i < textBytes.Length; i++)
            {
                result += textBytes[i].ToString();

                if (i < textBytes.Length - 1)
                    result += " - ";
            }
            return result;
        }


        public string DecodeToBytes(string text)
        {
            string result = string.Empty;

            string textBytes = text.Trim();
            string[] byteTextArray = textBytes.Split("-");
            byte[] bytes = new byte[byteTextArray.Length];

            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(byteTextArray[i]);
            }

            result = Encoding.UTF8.GetString(bytes);

            return result;
        }

        public string DecodeFromBase64(string text)
        {
            string result = string.Empty;
            byte[] bytes = Convert.FromBase64String(text);
            result = Encoding.UTF8.GetString(bytes);
            return result;
        }

        public string EncodeFromBase64(string text)
        {
            string result = string.Empty;
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            result = Convert.ToBase64String(bytes);
            return result;
        }

        #endregion

        public string EncryptMD5(string text)
        {
            string result = string.Empty;

            MD5 md5Hash = MD5.Create();

            byte[] textBytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

            for (int i = 0; i < textBytes.Length; i++)
            {
                result += textBytes[i].ToString("x2");
            }

            return result;
        }

        public string EncryptTripleDES(string text)
        {
            string result = string.Empty;

            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            byte[] keyBytes = Encoding.UTF8.GetBytes(encryptKey);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] temp = sha256.ComputeHash(keyBytes);
                byte[] key = new byte[24];
                Array.Copy(temp, key, 24);

                using (TripleDES tripleDES = TripleDES.Create())
                {
                    tripleDES.Key = key;
                    tripleDES.Mode = CipherMode.ECB;
                    tripleDES.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = tripleDES.CreateEncryptor();

                    byte[] resultBytes = cTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                    result = Convert.ToBase64String(resultBytes);
                }
            }

            return result;
        }

        public string DecryptTrypleDES(string text)
        {
            string result = string.Empty;

            byte[] textBytes = Convert.FromBase64String(text);
            byte[] keyBytes = Encoding.UTF8.GetBytes(encryptKey);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] temp = sha256.ComputeHash(keyBytes);
                byte[] key = new byte[24];
                Array.Copy(temp, key, 24);

                using (TripleDES tripleDES = TripleDES.Create())
                {
                    tripleDES.Key = key;
                    tripleDES.Mode = CipherMode.ECB;
                    tripleDES.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = tripleDES.CreateDecryptor();

                    byte[] resultArray = cTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);

                    result = Encoding.UTF8.GetString(resultArray);
                }
            }
            return result;
        }
    }
}