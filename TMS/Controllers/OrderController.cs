using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TMS.Logic.Interface;

namespace TMS.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private Factory.Factory _factory;
        private IOrderLogic _order;

        public OrderController(IConfiguration configuration)
        {

            this._factory = new Factory.Factory(configuration);
            this._order = this._factory.OrderLogic();
        }

        public IActionResult Order()
        {
            return View();
        }
    }
}