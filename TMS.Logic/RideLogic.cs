using TMS.Logic.Interface;
using TMS.Repositroy.Interface;

namespace TMS.Logic
{
    public class RideLogic : IRideLogic
    {
        private IRideRepository _repository;

        public RideLogic(IRideRepository repository)
        {
            this._repository = repository;
        }
    }
}