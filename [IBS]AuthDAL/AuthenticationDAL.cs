using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _IBS_Entities;
using _IBS_InterfacesDAL;
using System.Configuration;
using System.Data.SqlClient;

namespace _IBS_AuthDAL
{
    public class AuthenticationDAL : IAuthDALRoleProvider
    {
        string _connectionString;

        public AuthenticationDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }       

        public void CreateAccount(Account account)
        {
            string queryString =
                "";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("accountid", account.Id);
                
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }           
        }
             
        
        public string[] GetAllRoles()
        {
            var queryString = "SELECT DISTINCT [Name] " +
                              "FROM[dbo].[Roles];";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                var roles = new List<string>();
                
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    roles.Add((string)reader[0]);
                }
                return roles.ToArray();
            }
        }

        public string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException(); //TO DO  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
        }

        public Account GetUser(Guid id)
        {
            var queryString = "SELECT [Id], [Name], [Password], [DateOfBirth], [Age] " +
                              "FROM [dbo].[Accounts] " +
                              "WHERE  [Id] = @accountid";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("accountid", id);

                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Account()
                    {
                       Id = (Guid)reader[0],
                       Name = (string)reader[1],
                       Password = (string)reader[2],
                       DateOfBirth = (DateTime)reader[3],
                       Age = (int)reader[4]
                    };
                }
                return null;
            }
        }

        public Account GetUser(string name)
        {
            var queryString = "SELECT [Id], [Name], [Password], [DateOfBirth], [Age] " +
                             "FROM [dbo].[Accounts] " +
                             "WHERE  [Name] = @name";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("name", name);

                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Account()
                    {
                        Id = (Guid)reader[0],
                        Name = (string)reader[1],
                        Password = (string)reader[2],
                        DateOfBirth = (DateTime)reader[3],
                        Age = (int)reader[4]
                    };
                }
                return null;
            }
        }

        public List<Account> GetUsersInRole(string roleName)
        {
            var queryString = "SELECT A.[Id], A.[Name], [Password], [DateOfBirth], [Age] " +
                             " FROM[dbo].[Accounts] A " +
                              "INNER JOIN[dbo].[Roles] R " +
                              "ON R.[IdUser] = A.[Id] " +
                              " WHERE R.[Name] = @roleName;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                var accounts = new List<Account>();

                command.Parameters.AddWithValue("roleName", roleName);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    accounts.Add(new Account()
                    {
                        Id = (Guid)reader[0],
                        Name = (string)reader[1],
                        Password = (string)reader[2],
                        DateOfBirth = (DateTime)reader[3],
                        Age = (int)reader[4]
                    });
                }
                return accounts;
            }
        }

        public bool IsUserInRole(string username, string roleName)
        {
            var queryString =
                "SELECT A.[Name] " +
                "FROM[dbo].[Accounts] A" +
                "INNER JOIN[dbo].[Roles] R" +
                "ON R.[IdUser] = A.[Id]" +
                "WHERE A.[Name] = @username AND R.[Name] = @roleName;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("username", username);
                command.Parameters.AddWithValue("roleName", roleName);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if ((string)reader[0] != null)
                        return true;
                }                
            }

            return false;
        }              
    }
}
