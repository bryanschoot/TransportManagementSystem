using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TMS.Logic.Interface;
using TMS.Model;
using TMS.Models;

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
        
        [HttpGet]
        public IActionResult Orders()
        {
            int id = Convert.ToInt32(User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault());

            List<Order> order = new List<Order>(this._order.GetAllOrdersById(id));
//            OrderViewModel model = new OrderViewModel(order);

            return View(order);
        }

        [HttpGet]
        public IActionResult Order()
        {
            return View();
        }

        public IActionResult CreateOrder(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View("Order", model);
        }
    }
}