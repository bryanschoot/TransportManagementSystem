using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using TMS.Dal.Interface;
using TMS.Model;

namespace TMS.Dal.MSSQL
{
    public class AccountMSSQLContext : IAccountContext
    {
        private readonly string _connectionstring;
        private string _query;
        private string _procedure;

        public AccountMSSQLContext(string connectionstring)
        {
            this._connectionstring = connectionstring;
        }

        public bool OpenConnection(SqlConnection connection)
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception exception)
            {
                throw new Exception("There is no connection");
            }
        }

        #region NotImplemented
        public IEnumerable<Account> All()
        {
            this._query = "SELECT Account.Id, Account.Email, Account.FirstName, Account.LastName, Role.RoleName FROM Account INNER JOIN Role on Account.RoleId = Role.Id ORDER BY Role.RoleName ";
            List<Account> accounts = new List<Account>();

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    foreach (DbDataRecord record in cmd.ExecuteReader())
                    {
                        Account account = new Account
                        {
                            Id = record.GetInt32(record.GetOrdinal("Id")),
                            Email = record.GetString(record.GetOrdinal("Email")),
                            FirstName = record.GetString(record.GetOrdinal("FirstName")),
                            LastName = record.GetString(record.GetOrdinal("LastName")),
                            Role = new Role
                            {
                                RoleName = record.GetString(record.GetOrdinal("RoleName"))
                            },
                        };
                        accounts.Add(account);
                    }
                    return accounts;
                }
            }
        }

        public Account GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(Account entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Account entity, int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Account entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Account entity)
        {
            throw new System.NotImplementedException();
        }

        public int Count(Account entity)
        {
            throw new System.NotImplementedException();
        }
        #endregion
        /// <summary>
        /// Check if the account is valid compares it a excisting account
        /// </summary>
        /// <param name="email">Email from form (User sbmit)</param>
        /// <param name="password">Password from form (User sbmit)</param>
        /// <returns></returns>
        #region IsAccountValid
        public bool IsAccountValid(string email, string password)
        {
            this._query = "SELECT [Email], [Password] FROM [Account] WHERE [Email]=@Email AND [Password]=@Password";

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }

        public bool DoesEmailExist(string email)
        {
            this._query = "SELECT Email FROM Account WHERE Account.Email=@Email";

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Email", email);

                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }

        #endregion

        #region GetAccountByEmail

        public bool CreateAccount(Account account)
        {
            if (account.Password != null)
            {
                this._query = "INSERT INTO Account (Email, FirstName, LastName, Password, PhoneNumber, RoleId) VALUES (@Email, @FirstName, @LastName, @Password, @PhoneNumber, @RoleId);";
            }
            else
            {
                this._query = "INSERT INTO Account (Email, FirstName, LastName, PhoneNumber, RoleId) VALUES (@Email, @FirstName, @LastName, @PhoneNumber, @RoleId);";
            }

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Email", account.Email);
                    cmd.Parameters.AddWithValue("@FirstName", account.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", account.LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", account.PhoneNumber);
                    if (account.Password != null)
                    {
                        cmd.Parameters.AddWithValue("@Password", account.Password);
                    }
                    cmd.Parameters.AddWithValue("@RoleId", account.Role.Id);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
        }

        public Account GetAccountByEmail(string email)
        {
            Account account = null;
            this._query = "SELECT Account.Id, Account.Email, Role.RoleName FROM Account LEFT JOIN Role On Account.RoleId=Role.Id WHERE Account.Email=@Email";

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Email", email);

                    foreach (DbDataRecord record in cmd.ExecuteReader())
                    {
                        account = new Account
                        {
                            Id = record.GetInt32(record.GetOrdinal("Id")),
                            Email = record.GetString(record.GetOrdinal("Email")),

                            Role = new Role
                            {
                                RoleName = record.GetString(record.GetOrdinal("RoleName")),
                            }
                        };
                    }
                    return account;
                }
            }
        }
        #endregion

        #region GetAccountById
        /// <summary>
        /// Get all user data with 0,1 or more addresses
        /// </summary>
        /// <param name="id">id of the user</param>
        /// <returns></returns>
        public Account GetAccountById(int id)
        {
            Account account = null;
            List<Address> addresses = new List<Address>();

            this._procedure = "dbo.spAccount_GetById";

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._procedure, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountId", id);

                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    ad.Fill(ds);

                    DataTable accountTable = ds.Tables[0];
                    DataTable addressTable = ds.Tables[1];

                    foreach (DataRow accountRow in accountTable.Rows)
                    {

                        account = new Account
                        {
                            Id = Convert.ToInt32(accountRow[0]),
                            Email = accountRow[1].ToString(),
                            FirstName = accountRow[2].ToString(),
                            LastName = accountRow[3].ToString(),
                            PhoneNumber = accountRow[4].ToString(),

                            Role = new Role
                            {
                                Id = Convert.ToInt32(accountRow[5]),
                                RoleName = accountRow[6].ToString(),
                            }
                        };

                        if (addressTable.Rows.Count > 0)
                        {
                            foreach (DataRow addressRow in addressTable.Rows)
                            {
                                addresses.Add(new Address()
                                {
                                    Id = Convert.ToInt32(addressRow[0]),
                                    City = addressRow[1].ToString(),
                                    Country = addressRow[2].ToString(),
                                    StreetName = addressRow[3].ToString(),
                                    StreetNumber = addressRow[4].ToString(),
                                    ZipCode = addressRow[5].ToString(),
                                });
                            }
                            account.Address = addresses;
                        }
                    }
                    return account;
                }
            }
        }
        #endregion

        /// <summary>
        /// Update a user account
        /// </summary>
        /// <param name="account">Model account</param>
        /// <returns>A true of false based on update query</returns>
        public bool UpdateAccount(Account account)
        {
            this._query = "UPDATE Account SET Account.Email=@Email, Account.FirstName=@FirstName, Account.LastName=@LastName, Account.PhoneNumber=@PhoneNumber WHERE Account.Id=@Id";

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", account.Id);
                    cmd.Parameters.AddWithValue("@Email", account.Email);
                    cmd.Parameters.AddWithValue("@FirstName", account.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", account.LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", account.PhoneNumber);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// Admin update allows you to update the role of the user
        /// </summary>
        /// <param name="account">account + roleid</param>
        /// <returns>bool true or false</returns>
        public bool AdminUpdateAccount(Account account)
        {
            this._query = "UPDATE Account SET Account.Email=@Email, Account.FirstName=@FirstName, Account.LastName=@LastName, Account.PhoneNumber=@PhoneNumber, Account.RoleId=@RoleId WHERE Account.Id=@Id";

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", account.Id);
                    cmd.Parameters.AddWithValue("@Email", account.Email);
                    cmd.Parameters.AddWithValue("@FirstName", account.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", account.LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", account.PhoneNumber);
                    cmd.Parameters.AddWithValue("@RoleId", account.Role.Id);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
        }

        /// <summary>
        /// Get address by id used to edit a selected address
        /// </summary>
        /// <param name="id">Id of the selected address</param>
        /// <returns>The selected address properties</returns>
        public Address GetAddressById(int id)
        {
            Address address = null;
            this._query = "SELECT Address.Id, Address.Country, Address.City, Address.StreetName, Address.StreetNumber, Address.ZipCode, Address.AccountId FROM Address WHERE Address.Id=@Id";

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", id);

                    foreach (DbDataRecord record in cmd.ExecuteReader())
                    {
                        address = new Address
                        {
                            Id = record.GetInt32(record.GetOrdinal("Id")),
                            City = record.GetString(record.GetOrdinal("City")),
                            Country = record.GetString(record.GetOrdinal("Country")),
                            StreetName = record.GetString(record.GetOrdinal("StreetName")),
                            StreetNumber = record.GetString(record.GetOrdinal("StreetNumber")),
                            ZipCode = record.GetString(record.GetOrdinal("ZipCode")),
                            Account = new Account
                            {
                                Id = record.GetInt32(record.GetOrdinal("AccountId"))
                            }
                        };   
                    }

                    return address;
                }
            }
        }

        /// <summary>
        /// Update address
        /// </summary>
        /// <param name="address">Model address</param>
        /// <returns>true or false based on update query</returns>
        public bool UpdateAddress(Address address)
        {
            this._query = "UPDATE Address SET Address.Country=@Country, Address.City=@City, Address.StreetName=@Streetname, Address.StreetNumber=@Streetnumber, Address.ZipCode=@Zipcode  WHERE Address.Id=@Id";

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", address.Id);
                    cmd.Parameters.AddWithValue("@Country", address.Country);
                    cmd.Parameters.AddWithValue("@City", address.City);
                    cmd.Parameters.AddWithValue("@Streetname", address.StreetName);
                    cmd.Parameters.AddWithValue("@Streetnumber", address.StreetNumber);
                    cmd.Parameters.AddWithValue("@Zipcode", address.ZipCode);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// Delete address by id
        /// </summary>
        /// <param name="id">Id of the selected address</param>
        /// <returns>true or false based on delete query</returns>
        public bool DeleteAddress(int id)
        {
            this._query = "DELETE FROM Address WHERE Address.Id=@Id; ";

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", id);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
        }

        /// <summary>
        /// Create a address for logged in account
        /// </summary>
        /// <param name="address">Model address</param>
        /// <param name="id">of the user</param>
        /// <returns>true or false based on insert query</returns>
        public bool CreateAddress(Address address, int id)
        {
            this._query = "INSERT INTO Address (Country, City, StreetName, StreetNumber, ZipCode, AccountId) VALUES (@Country, @City, @StreetName, @StreetNumber, @ZipCode, @AccoutId);";

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", address.Id);
                    cmd.Parameters.AddWithValue("@Country", address.Country);
                    cmd.Parameters.AddWithValue("@City", address.City);
                    cmd.Parameters.AddWithValue("@StreetName", address.StreetName);
                    cmd.Parameters.AddWithValue("@StreetNumber", address.StreetNumber);
                    cmd.Parameters.AddWithValue("@ZipCode", address.ZipCode);
                    cmd.Parameters.AddWithValue("@AccoutId", id);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
        }

        /// <summary>
        /// Count costumer to show on the homepage
        /// </summary>
        /// <returns>int of all costumers</returns>
        public int CountAllCustomers()
        {
            this._query = "SELECT COUNT (*) FROM Account INNER JOIN Role ON Account.RoleId = Role.Id WHERE Role.RoleName = 'Costumer';";
            int total = 0;

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    if (OpenConnection(conn))
                    {
                        total = (Int32)cmd.ExecuteScalar();
                    }
                    return total;
                }
            }
        }

        public IEnumerable<Role> GetAllRoles()
        {
            this._query = "SELECT Role.Id, Role.RoleName From Role";
            List<Role> roles = new List<Role>();

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    foreach (DbDataRecord record in cmd.ExecuteReader())
                    {
                        Role role = new Role
                        {
                            Id = record.GetInt32(record.GetOrdinal("Id")),
                            RoleName = record.GetString(record.GetOrdinal("RoleName"))
                        };
                        roles.Add(role);
                    }

                    return roles;
                }
            }

        }
    }
}