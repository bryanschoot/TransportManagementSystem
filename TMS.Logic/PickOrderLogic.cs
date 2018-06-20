using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Logic.Interface;
using TMS.Model;
using TMS.Repositroy.Interface;

namespace TMS.Logic
{
    public class PickOrderLogic : IPickOrderLogic
    {
        private IPickOrderRepository _repository;

        public PickOrderLogic(IPickOrderRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<PickOrder> GetAllPickOrders()
        {
            IEnumerable<PickOrder> pickOrders = this._repository.All();

            if (!pickOrders.Any()) { throw new NullReferenceException("There are no pickorders!"); }

            return pickOrders;
        }

        public bool CreatePickOrder(PickOrder pickOrder)
        {
            if(pickOrder == null) { throw new ArgumentNullException("Pickorder cannot be null"); }

            return this._repository.CreatePickOrder(pickOrder);
        }

        public PickOrder GetPickOrderById(int id)
        {
            if(id <= 0) { throw new Exception("Id cannot be like this.");}
            return this._repository.GetById(id);
        }

        public bool UpdatePickOrder(PickOrder pickOrder)
        {
            if(pickOrder == null) { throw new ArgumentNullException("PickOrder cannot be null"); }

            return this._repository.Update(pickOrder);
        }

        public bool DeletePickOrer(int id)
        {
            if(id <= 0 ){ throw new ArgumentNullException("Id of the pickorder cannot be null"); }

            return this._repository.DeletePickOrder(id);
        }
    }
}