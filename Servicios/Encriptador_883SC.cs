using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Encriptador_883SC
    {
        public static string EncriptarIrrev_883SC(string dato)
        {
            byte[] data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(dato));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }
            return builder.ToString();
        }

        private const int TamanioIV_883SC = 16;
        private const string ClaveConfig_883SC = "ClaveCifrado";
        private static readonly byte[] Salt_883SC = Encoding.UTF8.GetBytes("FerreSV.Servicios.Salt.v1#Aes256");
        private static byte[] clave_883SC;
        private static readonly object bloqueoClave_883SC = new object();

        private static byte[] ObtenerClave_883SC()
        {
            if (clave_883SC != null) { return clave_883SC; }
            lock (bloqueoClave_883SC)
            {
                if (clave_883SC == null)
                {
                    string frase = ConfigurationManager.AppSettings[ClaveConfig_883SC];
                    if (string.IsNullOrWhiteSpace(frase))
                    {
                        throw new InvalidOperationException("Falta la configuracion '" + ClaveConfig_883SC + "' en appSettings del App.config. No se puede cifrar ni descifrar.");
                    }
                    using (Rfc2898DeriveBytes kdf = new Rfc2898DeriveBytes(frase, Salt_883SC, 100000))
                    {
                        clave_883SC = kdf.GetBytes(32);
                    }
                }
                return clave_883SC;
            }
        }

        public static string EncriptarRev_883SC(string texto)
        {
            if (string.IsNullOrEmpty(texto)) { return texto; }

            byte[] claveAes = ObtenerClave_883SC();
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = claveAes;
                aes.GenerateIV();

                byte[] plano = Encoding.UTF8.GetBytes(texto);
                using (ICryptoTransform cifrador = aes.CreateEncryptor())
                using (MemoryStream salida = new MemoryStream())
                {
                    salida.Write(aes.IV, 0, aes.IV.Length);
                    using (CryptoStream cs = new CryptoStream(salida, cifrador, CryptoStreamMode.Write))
                    {
                        cs.Write(plano, 0, plano.Length);
                    }
                    return Convert.ToBase64String(salida.ToArray());
                }
            }
        }

        public static string DesencriptarRev_883SC(string cifrado)
        {
            if (string.IsNullOrEmpty(cifrado)) { return cifrado; }

            byte[] claveAes = ObtenerClave_883SC();
            try
            {
                byte[] datos = Convert.FromBase64String(cifrado);
                if (datos.Length <= TamanioIV_883SC) { throw new CryptographicException("Datos demasiado cortos."); }

                byte[] iv = new byte[TamanioIV_883SC];
                Array.Copy(datos, 0, iv, 0, TamanioIV_883SC);

                using (Aes aes = Aes.Create())
                {
                    aes.KeySize = 256;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Key = claveAes;
                    aes.IV = iv;

                    using (ICryptoTransform descifrador = aes.CreateDecryptor())
                    using (MemoryStream entrada = new MemoryStream(datos, TamanioIV_883SC, datos.Length - TamanioIV_883SC))
                    using (CryptoStream cs = new CryptoStream(entrada, descifrador, CryptoStreamMode.Read))
                    using (MemoryStream salida = new MemoryStream())
                    {
                        cs.CopyTo(salida);
                        return new UTF8Encoding(false, true).GetString(salida.ToArray());
                    }
                }
            }
            catch (Exception ex) when (ex is FormatException || ex is CryptographicException || ex is ArgumentException)
            {
                throw new CryptographicException("No se pudo descifrar el dato: esta alterado, no esta cifrado o la clave de cifrado es otra.", ex);
            }
        }
    }
}
