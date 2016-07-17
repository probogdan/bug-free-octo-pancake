using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _IBS_InterfacesBLL;
using _IBS_Entities;
using _IBS_InterfacesDAL;

namespace _IBS_AuthBLL
{
    public class RoleManager : IRoleManager
    {
        private string[] usersRoles;
        private readonly Guid userId;
        private readonly IAuthDALRoleProvider _authDataProvider;
        private string[] defaultRoles = new string[] 
        {
            "user",
            "admin",
            "consultant" //в переводе - консультант
        };
        
        public string[] UsersRoles
        {
            get { return usersRoles; }
            private set { }
        }

        public Guid UserId
        {
            get { return userId; }
            private set { }
        }

        public RoleManager(Account account)
        {
            this.usersRoles = account.Roles;
            this.userId = account.Id;
        }

        public RoleManager(IAuthDALRoleProvider _authDataProvider)
        {          
            this._authDataProvider = _authDataProvider;
        }

        public void AddRoleToUser(string role)
        {
            if (this.usersRoles == null)
                return;

            var listOfRoles = new List<string>(this.usersRoles);

            if (!listOfRoles.Exists((x) => x.Equals(role)))
                listOfRoles.Add(role);

            this.usersRoles = listOfRoles.ToArray();
        }

        public void RemoveRoleFromUser(string role)
        {
            if (this.usersRoles == null)
                return;

            var listOfRoles = new List<string>(this.usersRoles);

            if (listOfRoles.Exists((x) => x.Equals(role)))
                listOfRoles.Remove(role);

            this.usersRoles = listOfRoles.ToArray();
        }

        public void RemoveRole(string role)
        {
            if (this._authDataProvider == null)
                return;

            var listOfRoles = new List<string>(this.usersRoles);

            if (listOfRoles.Exists((x) => x.Equals(role)))
                listOfRoles.Remove(role);

            this.usersRoles = listOfRoles.ToArray();
        }
    }
}
