using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TMS.Logic.Interface;
using TMS.Model;
using TMS.Models;

namespace TMS.Controllers
{
    public class RideController : Controller
    {
        private Factory.Factory _factory;
        private readonly IRideLogic _rideLogic;
        private readonly IAccountLogic _accountLogic;
        private readonly IPickOrderLogic _pickOrderLogic;
        private readonly IVehicleLogic _vehicleLogic;

        public RideController(IConfiguration config)
        {
            this._factory = new Factory.Factory(config);
            this._rideLogic = this._factory.RideLogic();
            this._accountLogic = this._factory.AccountLogic();
            this._pickOrderLogic = this._factory.PickOrderLogic();
            this._vehicleLogic = this._factory.VehicleLogic();
        }

        public IActionResult Rides()
        {
            IEnumerable<Ride> rides = this._rideLogic.GetAllRides();

            return View(rides);
        }

        public IActionResult Ride()
        {
            IEnumerable<Account> account = this._accountLogic.GetAllEmployees();
            IEnumerable<PickOrder> pickOrders = this._pickOrderLogic.GetAllPickOrders();
            IEnumerable<Vehicle> vehicles = this._vehicleLogic.GetAllVehicles();

            RideViewModel model = new RideViewModel(account, pickOrders, vehicles);

            return View(model);
        }
    }
}