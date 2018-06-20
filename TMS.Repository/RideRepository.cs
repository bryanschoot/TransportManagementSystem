using System.Collections.Generic;
using TMS.Dal.Interface;
using TMS.Model;
using TMS.Repositroy.Interface;

namespace TMS.Repository
{
    public class RideRepository : IRideRepository
    {
        private IRideContext _context;

        public RideRepository(IRideContext context)
        {
            this._context = context;
        }

        public IEnumerable<Ride> All()
        {
            throw new System.NotImplementedException();
        }

        public Ride GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(Ride entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Ride entity, int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Ride entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Ride entity)
        {
            throw new System.NotImplementedException();
        }

        public int Count(Ride entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Ride> GetAllRides()
        {
            return this._context.GetAllRides();
        }
    }
}