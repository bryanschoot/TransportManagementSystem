using System.Collections.Generic;
using TMS.Model;

namespace TMS.Dal.Interface
{
    public interface IRideContext : IContext<Ride>
    {
        IEnumerable<Ride> GetAllRides();
    }
}