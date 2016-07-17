using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace _IBS_InterfacesBLL
{
    public interface ICryptographyProvider
    {
        string Crypt(string input);
    }
}
