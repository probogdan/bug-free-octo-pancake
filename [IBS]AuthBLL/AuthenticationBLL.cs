using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _IBS_Entities;
using _IBS_InterfacesBLL;
using _IBS_InterfacesDAL;
using _IBS_AuthDAL;

namespace _IBS_AuthBLL
{
    public class AuthenticationBLL : IAuthBLL
    {
        private readonly IAuthDALRoleProvider _authDataProvider;
        private readonly ICryptographyProvider _cryptographyProvider;
        private IRoleManager _roleManager;

        public AuthenticationBLL()
        {
            _authDataProvider = new AuthenticationDAL();
            _cryptographyProvider = new CryptographyProvider();
        }

        public void AddRole(Guid id, string roleName)
        {
            _roleManager = new RoleManager(new Account()
            {
                Id = id
            });
            _roleManager.AddRoleToUser(roleName);
        }

        public void CreateAccount(Account account)
        {
            account.Id = Guid.NewGuid();
            account.Age = DateTime.Now.Year - account.DateOfBirth.Year;
            account.Password = _cryptographyProvider.Crypt(account.Password);
            account.Roles = new string [] { "user" };
        }

        public string[] GetAllRoles()
            => _authDataProvider.GetAllRoles();

        public string[] GetRolesForUser(string username)
            => _authDataProvider.GetRolesForUser(username);

        public Account GetUser(Guid id)
            => _authDataProvider.GetUser(id);

        public Account GetUser(string name)
             => _authDataProvider.GetUser(name);

        public List<Account> GetUsersInRole(string roleName)
            => _authDataProvider.GetUsersInRole(roleName);

        public bool IsUserInRole(string username, string roleName)
            => _authDataProvider.IsUserInRole(username, roleName);

        public void AddRole(string name, string roleName)
        {
            var account = this.GetUser(name);

            if (account != null && !account.Roles.Contains(roleName))
               new RoleManager(account).AddRoleToUser(roleName);
        }
    }
}
