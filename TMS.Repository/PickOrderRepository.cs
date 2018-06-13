using System.Collections.Generic;
using TMS.Dal.Interface;
using TMS.Model;
using TMS.Repositroy.Interface;

namespace TMS.Repository
{
    public class PickOrderRepository : IPickOrderRepository
    {
        private IPickOrderContext _context;

        public PickOrderRepository(IPickOrderContext context)
        {
            this._context = context;
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