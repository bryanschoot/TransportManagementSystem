using System.Collections.Generic;
using TMS.Model;

namespace TMS.Repositroy.Interface
{
    public interface IRideRepository : IRepository<Ride>
    {
        IEnumerable<Ride> GetAllRides();
    }
}