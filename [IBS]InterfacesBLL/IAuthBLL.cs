using _IBS_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IBS_InterfacesBLL
{
    public interface IAuthBLL
    {
        Account GetUser(string name);

        Account GetUser(Guid id);

        void CreateAccount(Account account);

        string[] GetAllRoles();

        string[] GetRolesForUser(string username);

        List<Account> GetUsersInRole(string roleName);

        bool IsUserInRole(string username, string roleName);

        void AddRole(string name, string roleName);

        void AddRole(Guid id, string roleName);
    }
}
