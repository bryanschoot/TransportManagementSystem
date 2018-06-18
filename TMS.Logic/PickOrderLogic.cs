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

            if (!pickOrders.Any())
            {
                throw new NullReferenceException("There are no pickorders!");
            }

            return pickOrders;
        }
    }
}