using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TMS.Logic.Interface;
using TMS.Models;

namespace TMS.Controllers
{
    public class HomeController : Controller
    {
        private Factory.Factory _factory;
        private IAccountLogic _account;
        //private IVehicleLogic _vehicle;
        private IOrderLogic _order;

        public HomeController(IConfiguration config)
        {
            this._factory = new Factory.Factory(config);
            this._account = this._factory.AccountLogic();
            //this._vehicle = this._factory.VehicleLogic();
            this._order = this._factory.OrderLogic();
        }

        public IActionResult Index()
        {
            ViewData["costumer"] = this._account.CountAllCustomers();
            ViewData["trucks"] = 24; //this._vehicle.CountAllVehicles();
            ViewData["orders"] = 216; //this._order.CountAllOrders();

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
