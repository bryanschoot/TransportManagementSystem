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

            return View(order);
        }

        [HttpGet]
        public IActionResult Order()
        {
            return View();
        }

        /// <summary>
        /// Createorder create a new order and check if address excist if not create new one and add it to the users addresses
        /// </summary>
        /// <param name="model">Order model</param>
        /// <returns>View of order.</returns>
        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault());
                Order order = model.CopyTo();
                if (this._factory.OrderLogic().CreateOrder(order, id))
                {
                    TempData["message"] = "Order has been created!";
                }
                else
                {
                    TempData["errormessage"] = "Order was not created!";
                }
                return RedirectToAction("Orders");
            }
            return View("Order", model);
        }

        [HttpGet]
        public IActionResult EditOrder()
        {
            //get account id from cookies
            int id = Convert.ToInt32(User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault());

            Order order = this._factory.OrderLogic().GetOrderById(id);

            if (order != null)
            {
                OrderViewModel model = new OrderViewModel(order);
                return this.View("Order", model);
            }

            TempData["errormessage"] = "You dont have permission to do this!";
            return RedirectToAction("Profile", "Account");
        }
    }
}