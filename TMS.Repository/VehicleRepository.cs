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
            return this._context.All();
        }

        public Vehicle GetById(int id)
        {
            return this._context.GetById(id);
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
            return this._context.Update(entity);
        }

        public bool Delete(Vehicle entity)
        {
            throw new System.NotImplementedException();
        }

        public int Count(Vehicle entity)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateVehicle(Vehicle vehicle)
        {
            return this._context.CreateVehicle(vehicle);
        }

        public int CountAllVehicles()
        {
            return this._context.CountAllVehicles();
        }
    }
}