using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _IBS_InterfacesBLL;
using System.Security.Cryptography;

namespace _IBS_AuthBLL
{
    public class CryptographyProvider : ICryptographyProvider
    {
        private SHA256 _shaProvider;

        public CryptographyProvider()
        {
            _shaProvider = SHA256.Create();
        }
        
        public string Crypt(string input)
        {
            input = input + "AzaAAzaZAazAZazAZAzaZAZAZaz"; //усложнение входной строки
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var stringBuilder = new StringBuilder();

            var offset = 1;
            var count = inputBytes.Length - offset - 2;

            var computedHash = _shaProvider.ComputeHash(inputBytes, offset, count);
            for (int i = 0; i < computedHash.Length; i++)
                stringBuilder.Append(computedHash[i].ToString());

            input = stringBuilder.ToString();

            return input;
        }
    }
}
