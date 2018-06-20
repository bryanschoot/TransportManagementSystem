using System.Collections.Generic;
using TMS.Model;

namespace TMS.Logic.Interface
{
    public interface IRideLogic
    {
        IEnumerable<Ride> GetAllRides();
    }
}