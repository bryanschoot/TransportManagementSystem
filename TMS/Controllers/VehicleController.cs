using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TMS.Controllers
{
    public class VehicleController : Controller
    {
        private Factory.Factory _factory;
        private IVehicle vehicle;

        public VehicleController(IConfiguration config)
        {
            this._factory = new Factory.Factory(config);
            this.vehicle = this._factory.VehicleLogic();
        }


        public IActionResult Vehicles()
        {
            throw new System.NotImplementedException();
        }
    }
}