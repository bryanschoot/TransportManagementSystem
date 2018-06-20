using System;
using System.Collections.Generic;
using System.Data;
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
        private string _procedure;

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
            PickOrder pickOrder = null;
            List<Order> orders = new List<Order>();
            this._procedure = "dbo.spPickOrder_GetById";

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._procedure, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    ad.Fill(ds);

                    DataTable pickOrderTable = ds.Tables[0];
                    DataTable orderTable = ds.Tables[1];

                    foreach (DataRow pickOrdeRow in pickOrderTable.Rows)
                    {

                        pickOrder = new PickOrder()
                        {
                            Id = Convert.ToInt32(pickOrdeRow[0]),
                            Lenght = Convert.ToDouble(pickOrdeRow[1]),
                            Width = Convert.ToDouble(pickOrdeRow[2]),
                            Height = Convert.ToDouble(pickOrdeRow[3]),
                            AmountOfOrders = Convert.ToInt32(pickOrdeRow[4]),
                        };

                        if (orderTable.Rows.Count > 0)
                        {
                            foreach (DataRow orderRow in orderTable.Rows)
                            {
                                orders.Add(new Order()
                                {
                                    Id = Convert.ToInt32(orderRow[0]),
                                    Description = orderRow[1].ToString(),
//                                    DeliverDate = (DateTime)orderRow[2],
                                    Length = Convert.ToDouble(orderRow[3]),
                                    Width = Convert.ToDouble(orderRow[4]),
                                    Height = Convert.ToDouble(orderRow[5]),
                                    Weight = Convert.ToDouble(orderRow[6]),
                                    Address = new Address
                                    {
                                        Country = orderRow[7].ToString(),
                                        City = orderRow[8].ToString(),
                                        StreetName = orderRow[9].ToString(),
                                        StreetNumber = orderRow[10].ToString(),
                                        ZipCode = orderRow[11].ToString(),
                                    }
                                });
                            }
                            pickOrder.Orders = orders;
                        }
                    }
                    return pickOrder;
                }
            }
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

        public bool CreatePickOrder(PickOrder pickOrder)
        {
            this._query = "INSERT INTO PickOrder (Length, Width, Height, Weight) VALUES (@Length, @Width, @Height, @Weight); SELECT SCOPE_IDENTITY()";

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Length", pickOrder.Lenght);
                    cmd.Parameters.AddWithValue("@Width", pickOrder.Width);
                    cmd.Parameters.AddWithValue("@Height", pickOrder.Height);
                    cmd.Parameters.AddWithValue("@Weight", pickOrder.Weight);

                    int Id = Convert.ToInt32(cmd.ExecuteScalar());

                    if (Id > 0)
                    {
                        return InsertIntoOrder(pickOrder, Id);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool InsertIntoOrder(PickOrder pickOrder, int Id)
        {
            int count = 0;
            for (int i = 0; i < pickOrder.Orders.Count; i++)
            {
                this._query = "UPDATE [Order] SET [Order].PickOrderId = @Id WHERE Id = @OrderId;";
        
                using (SqlConnection conn = new SqlConnection(this._connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand(this._query, conn))
                    {
                        conn.Open();


                            cmd.Parameters.Add(new SqlParameter("@OrderId", pickOrder.Orders[i].Id));
                            cmd.Parameters.Add(new SqlParameter("@Id", Id));

                            count = cmd.ExecuteNonQuery();

                    }
                }
            }
            return count > 0;
        }
    }
}