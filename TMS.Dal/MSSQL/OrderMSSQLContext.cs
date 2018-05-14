using System.Collections.Generic;
using TMS.Dal.Interface;
using TMS.Model;

namespace TMS.Dal.MSSQL
{
    public class OrderMSSQLContext : IOrderContext
    {
        private string _connestionstring;

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
            throw new System.NotImplementedException();
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
    }
}