using System.Collections.Generic;
using TMS.Dal.Interface;
using TMS.Model;

namespace TMS.Dal.MEMORY
{
    public class RideMemoryContext : IRideContext
    {
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
    }
}