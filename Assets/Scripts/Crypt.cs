using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/*
 EXAMPLE:
        
        string cr = CCrypt.GetCrypted("let's go!!!", "=o!-C%#4!AZ6,Rgf", "9x.Z'A)#]K5nh^}s");
 
        string cr = CCrypt.GetCrypted(anyString, gm.crKey, gm.crIv);    // klice v game manageru
  
        string dec = CCrypt.GetDecrypted(dataFromServer, gm.crKey, gm.crIv);    // klice v game manageru 
 */

public static class Crypt
{
    /// <summary>
    /// crypts given string
    /// </summary>
    /// <param name="pStr">string to crypt</param>
    /// <param name="pKey">secred key</param>
    /// <param name="pIv">initialization vector</param>
    public static string GetCrypted(string pStr, string pKey, string pIv)
    {
        Encoding byteEncoder = Encoding.ASCII;
        byte[] rijnKey = byteEncoder.GetBytes(pKey);
        byte[] rijnIV = byteEncoder.GetBytes(pIv);

        return Crypt.GetCrypted(pStr, rijnKey, rijnIV);
    }

    public static string GetCrypted(string pStr, byte[] pRijnKey, byte[] pRijnIv)
    {
//#if !UNITY_WP8 && !UNITY_METRO
        string cstr;

        RijndaelManaged rijn = new RijndaelManaged();
        rijn.Mode = CipherMode.CBC;
        rijn.Padding = PaddingMode.Zeros;

        using (MemoryStream msEncrypt = new MemoryStream())
        {
            using (ICryptoTransform encryptor = rijn.CreateEncryptor(pRijnKey, pRijnIv))
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(pStr);
                        swEncrypt.Close();
                    }
                    csEncrypt.Close();
                }
            }
            cstr = System.Convert.ToBase64String(msEncrypt.ToArray());
            msEncrypt.Close();
        }
        rijn.Clear();
        rijn = null;

        return cstr;
/*#else
            return str;
#endif*/
    }

    /// <summary>
    /// decrypts given data
    /// </summary>
    /// <param name="data">data to decrypt</param>
    /// <param name="pKey">secred key</param>
    /// <param name="pIv">initialization vector</param>
    public static string GetDecrypted(string data, string pKey, string pIv)
    {
        Encoding byteEncoder = Encoding.ASCII;
        byte[] rijnKey = byteEncoder.GetBytes(pKey);
        byte[] rijnIV = byteEncoder.GetBytes(pIv);

        return Crypt.GetDecrypted(data, rijnKey, rijnIV);
    }

    public static string GetDecrypted(string data, byte[] rijnKey, byte[] rijnIV)
    {
//#if !UNITY_WP8 && !UNITY_METRO
        try
        {
            string dstr;

            RijndaelManaged rijn = new RijndaelManaged();
            rijn.Mode = CipherMode.CBC;
            rijn.Padding = PaddingMode.Zeros;

            byte[] cipher = System.Convert.FromBase64String(data);

            ICryptoTransform decryptor = rijn.CreateDecryptor(rijnKey, rijnIV);

            // Create the streams used for decryption. 
            using (MemoryStream msDecrypt = new MemoryStream(cipher))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        // Read the decrypted bytes from the decrypting stream 
                        // and place them in a string.
                        dstr = srDecrypt.ReadToEnd();
                        srDecrypt.Close();
                    }
                    csDecrypt.Close();
                }
                msDecrypt.Close();
            }
            decryptor = null;

            cipher = null;
            rijn = null;

            return dstr.TrimEnd('\0');
        }
        catch (System.Exception e)
        {
            Debug.LogError("CCrypt.GetDecrypted ERROR\n" + e.Message);
            return null;
        }
//#else
                //return str;
//#endif
    }
}