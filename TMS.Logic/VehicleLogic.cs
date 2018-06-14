using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Logic.Interface;
using TMS.Model;
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

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            IEnumerable<Vehicle> vehicles = this._repository.All();
            if (!vehicles.Any())
            {
                throw new NullReferenceException("There are no vehicles.");
            }
            return vehicles;
        }

        public bool CreateVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new NullReferenceException("Vehicle model cannot be null");
            }

            return this._repository.CreateVehicle(vehicle);
        }
    }
}