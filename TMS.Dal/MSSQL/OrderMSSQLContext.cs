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

        public List<Order> GetAllOrdersById(int id)
        {
            List<Order> orders = new List<Order>();
            this.query = "SELECT [Order].Id, [Order].Description, [Order].DeliverDate FROM [Order] INNER JOIN Account ON [Order].AccountId = Account.Id WHERE Account.Id=@Id";

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
                        };
                        orders.Add(order);
                    }

                    return orders;
                }
            }
        }
    }
}