using System.Collections.Generic;
using TMS.Dal.Interface;
using TMS.Model;
using TMS.Repositroy.Interface;

namespace TMS.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private IVehicleContext _context;

        public VehicleRepository(IVehicleContext context)
        {
            this._context = context;
        }

        public IEnumerable<Vehicle> All()
        {
            throw new System.NotImplementedException();
        }

        public Vehicle GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(Vehicle entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Vehicle entity, int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Vehicle entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Vehicle entity)
        {
            throw new System.NotImplementedException();
        }

        public int Count(Vehicle entity)
        {
            throw new System.NotImplementedException();
        }
    }
}