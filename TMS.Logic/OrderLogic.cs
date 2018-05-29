using TMS.Logic.Interface;
using TMS.Model;
using TMS.Repositroy.Interface;

namespace TMS.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private IOrderRepository Repository { get; }

        public OrderLogic(IOrderRepository repository)
        {
            this.Repository = repository;
        }

        public Order GetAllOrdersById(int id)
        {
            return this.Repository.GetById(id);
        }
    }
}