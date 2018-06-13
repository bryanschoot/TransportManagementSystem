using TMS.Logic.Interface;
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
    }
}