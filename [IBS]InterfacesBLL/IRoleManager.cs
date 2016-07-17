using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IBS_InterfacesBLL
{
    public interface IRoleManager
    {
        void AddRoleToUser(string role);

        void RemoveRoleFromUser(string role);

        void RemoveRole(string role);
    }
}
