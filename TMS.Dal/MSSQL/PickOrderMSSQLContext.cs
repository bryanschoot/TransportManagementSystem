using System.Collections.Generic;
using TMS.Dal.Interface;
using TMS.Model;

namespace TMS.Dal.MSSQL
{
    public class PickOrderMSSQLContext : IPickOrderContext
    {
        private readonly string _connectionstring;

        public PickOrderMSSQLContext(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public IEnumerable<PickOrder> All()
        {
            throw new System.NotImplementedException();
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