using System.Collections.Generic;
using TMS.Dal.Interface;
using TMS.Model;

namespace TMS.Dal.MEMORY
{
    public class PickOrderMemoryContext : IPickOrderContext
    {
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

        public bool CreatePickOrder(PickOrder pickOrder)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePickOrder(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}