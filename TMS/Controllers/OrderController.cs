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
        
        /// <summary>
        /// Get all orders of current logged in account
        /// </summary>
        /// <returns>view with all orders</returns>
        [HttpGet]
        public IActionResult Orders()
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault());
                List<Order> order = new List<Order>(this._order.GetAllOrdersById(id));
                return View(order);
            }
            catch (Exception e)
            {
                TempData["errormessage"] = e.Message;
                return View();
            }

        }

        /// <summary>
        /// Used for multiple actions/post
        /// </summary>
        /// <returns>Returns a filled form or empty form view</returns>
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

        /// <summary>
        /// Edit a order (displaying selected order)
        /// </summary>
        /// <param name="id">id of the selected order</param>
        /// <returns>view filled with a specific model</returns>
        [HttpGet]
        public IActionResult EditOrder(int id)
        {
            int accountId = Convert.ToInt32(User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault());
            Order order = this._factory.OrderLogic().GetOrderById(id, accountId);

            if (order != null)
            {
                OrderViewModel model = new OrderViewModel(order);
                return this.View("Order", model);
            }

            TempData["errormessage"] = "You dont have permission to do this!";
            return RedirectToAction("Orders", "Order");
        }

        /// <summary>
        /// Updates the model when the state of the model is valid
        /// </summary>
        /// <param name="model">Model of a order (Orderviewmodel)</param>
        /// <returns>Returns the view from the current order</returns>
        [HttpPost]
        public IActionResult UpdateOrder(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                int accountId = Convert.ToInt32(User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault());
                Order checkorder = this._factory.OrderLogic().GetOrderById(model.OrderId, accountId);

                bool changed = checkorder.Id != model.OrderId || checkorder.Description != model.Description || checkorder.DeliverDate != model.DeliverDate || checkorder.OrderDate != model.OrderDate || checkorder.Length != model.Length || checkorder.Width != model.Width || checkorder.Height != model.Height || checkorder.Weight != model.Weight || checkorder.Address.City != model.City || checkorder.Address.Country != model.Country || checkorder.Address.StreetName != model.StreetName || checkorder.Address.StreetNumber != model.StreetNumber || checkorder.Address.ZipCode != model.ZipCode;

                if (changed)
                {
                    Order order = model.CopyTo();
                    //TODO update the order + address assigned to it
                    if (this._factory.OrderLogic().UpdateOrder(order))
                    {
                        TempData["message"] = "Order succesfully updated!";
                        return View("Order", model);
                    }
                    TempData["errormessage"] = "Order cannot be updated!";
                    return View("Order", model);
                }
                TempData["errormessage"] = "Order cannot be update because you did not change anything!";
                return View("Order", model);
            }
            return View("Order", model);
        }

        [HttpGet]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                if (this._factory.OrderLogic().DeleteOrderById(id))
                {
                    TempData["message"] = "Order has been deleted succesfully!";
                    return RedirectToAction("Orders", "Order");
                }
                TempData["errormessage"] = "Order can not be deleted!";
                return RedirectToAction("Orders", "Order");
            }
            catch (Exception e)
            {
                TempData["errormessage"] = e.Message;
                return RedirectToAction("Orders", "Order");
            }
        }
    }
}