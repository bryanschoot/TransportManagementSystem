using System;
using System.Collections.Generic;
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

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Order entity)
        {
            throw new System.NotImplementedException();
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
                            DateTime = record.GetDateTime(record.GetOrdinal("Deliverdate")),
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