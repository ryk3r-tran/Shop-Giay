using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
namespace KarmaModels.Payment
{
    public class Util
    {
        public static string Hash(string key, string inputData)
        {
            var hash = new StringBuilder();
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputData);
            using (var hashmac = new HMACSHA512(keyBytes))
            {
                byte[] hashValue = hashmac.ComputeHash(inputBytes);
                foreach (var Byte in hashValue)
                {
                    hash.Append(Byte.ToString("x2"));
                }
            }
            return hash.ToString();
        }

        public static string GeIpAddress()
        {
            string ipAddress;
            try
            {
                ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ipAddress) || (ipAddress.ToLower() ==  "unknown"))
                {
                    ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
            }
            catch (Exception ex)
            {
                ipAddress = "Invalid IP: " + ex.Message; 
            }
            return ipAddress;
        }
    }
}
