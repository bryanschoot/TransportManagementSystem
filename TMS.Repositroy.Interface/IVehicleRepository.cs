using TMS.Model;

namespace TMS.Repositroy.Interface
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        bool CreateVehicle(Vehicle vehicle);
        int CountAllVehicles();
    }
}