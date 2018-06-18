using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using TMS.Dal.Interface;
using TMS.Model;

namespace TMS.Dal.MSSQL
{
    public class PickOrderMSSQLContext : IPickOrderContext
    {
        private readonly string _connectionstring;
        private string _query;

        public PickOrderMSSQLContext(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public IEnumerable<PickOrder> All()
        {
            //TODO finish this function
            this._query = "SELECT PickOrder.Id, PickOrder.Length, PickOrder.Width, PickOrder.Height, OCount =  (SELECT COUNT(*) FROM [Order] WHERE PickOrder.Id = [Order].PickOrderId) FROM PickOrder;";
            List<PickOrder> pickOrders = new List<PickOrder>();

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    foreach (DbDataRecord record in cmd.ExecuteReader())
                    {
                        PickOrder pickOrder = new PickOrder()
                        {
                            Id = record.GetInt32(record.GetOrdinal("Id")),
                            Lenght = record.GetDouble(record.GetOrdinal("Length")),
                            Width = record.GetDouble(record.GetOrdinal("Width")),
                            Height = record.GetDouble(record.GetOrdinal("Height")),
                            AmountOfOrders = record.GetInt32(record.GetOrdinal("OCount")),
                        };

                        pickOrders.Add(pickOrder);
                    }
                    return pickOrders;
                }
            }
        }

        public PickOrder GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(PickOrder entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(PickOrder entity, int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(PickOrder entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(PickOrder entity)
        {
            throw new System.NotImplementedException();
        }

        public int Count(PickOrder entity)
        {
            throw new System.NotImplementedException();
        }
    }
}