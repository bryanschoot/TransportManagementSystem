using TMS.Logic.Interface;
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
    }
}