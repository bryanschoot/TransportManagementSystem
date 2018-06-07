using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using TMS.Dal.Interface;
using TMS.Model;

namespace TMS.Dal.MSSQL
{
    public class OrderMSSQLContext : IOrderContext
    {
        private string _connestionstring;
        private string query;
        private string procedure;

        public OrderMSSQLContext(string connestionstring)
        {
            this._connestionstring = connestionstring;
        }

        public IEnumerable<Order> All()
        {
            throw new System.NotImplementedException();
        }

        //TODO make this thing
        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="id">id from the selected order</param>
        /// <returns>Object of 1 order.</returns>
        public Order GetById(int id)
        {
            Order order = null;
            this.query = "SELECT [Order].id as OrderId, [Order].Description, [Order].DeliverDate, [Order].Orderdate, [Order].Length, [Order].Width, [Order].Height, [Order].Weight, [Address].Id as AddressId, [Address].Country, [Address].City, [Address].StreetName, [Address].StreetNumber, [Address].ZipCode, [Account].Id as AccountId FROM [Order] INNER JOIN Address on [Order].AddressId = [Address].Id INNER JOIN Account on [Order].AccountId = [Account].Id WHERE [Order].Id = @Id;";

            using (SqlConnection conn = new SqlConnection(this._connestionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this.query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Id", id);

                    foreach (DbDataRecord record in cmd.ExecuteReader())
                    {
                        order = new Order
                        {
                            Id = record.GetInt32(record.GetOrdinal("OrderId")),
                            Description = record.GetString(record.GetOrdinal("Description")),
                            DeliverDate = record.GetDateTime(record.GetOrdinal("Deliverdate")),
                            OrderDate = record.GetDateTime(record.GetOrdinal("OrderDate")),
                            Length = record.GetDouble(record.GetOrdinal("Length")),
                            Width = record.GetDouble(record.GetOrdinal("Width")),
                            Height = record.GetDouble(record.GetOrdinal("Height")),
                            Weight = record.GetDouble(record.GetOrdinal("Weight")),

                            Address = new Address
                            {
                                Id = record.GetInt32(record.GetOrdinal("AddressId")),
                                Country = record.GetString(record.GetOrdinal("Country")),
                                City = record.GetString(record.GetOrdinal("City")),
                                StreetName = record.GetString(record.GetOrdinal("StreetName")),
                                StreetNumber = record.GetString(record.GetOrdinal("StreetNumber")),
                                ZipCode = record.GetString(record.GetOrdinal("ZipCode")),
                            },

                            Account = new Account
                            {
                                Id = record.GetInt32(record.GetOrdinal("AccountId"))
                            }
                        };
                    }
                    return order;
                }
            }
        }

        public bool Exists(Order entity)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Insert a new order
        /// </summary>
        /// <param name="entity">Order model</param>
        /// <returns>true or false based on inserted.</returns>
        public bool Insert(Order entity, int accountid)
        {
            this.procedure = "spCreateOrder";

            using (SqlConnection conn = new SqlConnection(this._connestionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this.procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AccountId", accountid);
                    cmd.Parameters.AddWithValue("@Description", entity.Description);
                    cmd.Parameters.AddWithValue("@DeliverDate", entity.DeliverDate.ToString("yyyy-MM-dd hh:mm:ss"));
                    cmd.Parameters.AddWithValue("@Length", entity.Length);
                    cmd.Parameters.AddWithValue("@Width", entity.Width);
                    cmd.Parameters.AddWithValue("@Height", entity.Height);
                    cmd.Parameters.AddWithValue("@Weight", entity.Weight);
                    cmd.Parameters.AddWithValue("@Country", entity.Address.Country);
                    cmd.Parameters.AddWithValue("@City", entity.Address.City);
                    cmd.Parameters.AddWithValue("@StreetName", entity.Address.StreetName);
                    cmd.Parameters.AddWithValue("@StreetNumber", entity.Address.StreetNumber);
                    cmd.Parameters.AddWithValue("@ZipCode", entity.Address.ZipCode);

                    try
                    {
                        conn.Open();
                        if (Math.Abs(cmd.ExecuteNonQuery()) > 0)
                        {
                            return true;
                        }
                        return false;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                   
                }
            }
        }

        public bool Update(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public int Count(Order entity)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get all orders from a account
        /// </summary>
        /// <param name="id">Account id from logged in user</param>
        /// <returns></returns>
        public List<Order> GetAllOrdersById(int id)
        {
            List<Order> orders = new List<Order>();
            this.query = "SELECT [Order].Id, [Order].Description, [Order].DeliverDate, Address.Country, Address.City, Address.StreetName, Address.StreetNumber, Address.ZipCode FROM [Order] INNER JOIN Account ON [Order].AccountId = Account.Id INNER JOIN Address ON [Order].AddressId = Address.id WHERE Account.Id=@Id";

            using (SqlConnection conn = new SqlConnection(this._connestionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this.query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Id", id);

                    foreach (DbDataRecord record in cmd.ExecuteReader())
                    {
                        Order order = new Order
                        {
                            Id = record.GetInt32(record.GetOrdinal("Id")),
                            Description = record.GetString(record.GetOrdinal("Description")),
                            DeliverDate = record.GetDateTime(record.GetOrdinal("Deliverdate")),
                            Address = new Address
                            {
                                Country = record.GetString(record.GetOrdinal("Country")),
                                City = record.GetString(record.GetOrdinal("City")),
                                StreetName = record.GetString(record.GetOrdinal("StreetName")),
                                StreetNumber = record.GetString(record.GetOrdinal("StreetNumber")),
                                ZipCode = record.GetString(record.GetOrdinal("ZipCode")),
                            }
                        };
                        orders.Add(order);
                    }

                    return orders;
                }
            }
        }
    }
}