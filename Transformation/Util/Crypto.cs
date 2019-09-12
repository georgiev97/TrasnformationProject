using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
namespace Transformation.Util
{
    public class Crypto
    {
        public static string Hash(string value)
        {
            if(value == null)
            {
                value = "";
            }
            var passwordBytes = Encoding.UTF8.GetBytes(value);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            return Convert.ToBase64String(passwordBytes);
        }
    }
}