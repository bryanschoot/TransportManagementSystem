using TMS.Model;

namespace TMS.Dal.Interface
{
    public interface IVehicleContext : IContext<Vehicle>
    {
        bool CreateVehicle(Vehicle vehicle);
        int CountAllVehicles();
    }
}