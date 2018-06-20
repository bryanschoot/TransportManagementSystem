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
            return this._context.All();
        }

        public PickOrder GetById(int id)
        {
            return this._context.GetById(id);
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
            return this._context.Update(entity);
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
            return this._context.CreatePickOrder(pickOrder);
        }

        public bool DeletePickOrder(int id)
        {
            return this._context.DeletePickOrder(id);
        }
    }
}