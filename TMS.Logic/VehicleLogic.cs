using TMS.Logic.Interface;
using TMS.Repositroy.Interface;

namespace TMS.Logic
{
    public class VehicleLogic : IVehicleLogic
    {
        private IVehicleRepository _repository;

        public VehicleLogic(IVehicleRepository repository)
        {
            this._repository = repository;
        }
    }
}