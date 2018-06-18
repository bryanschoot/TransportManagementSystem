using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TMS.Logic.Interface;
using TMS.Model;
using TMS.Models;

namespace TMS.Controllers
{
    public class PickOrderController : Controller
    {
        private Factory.Factory _factory;
        private IPickOrderLogic _pickOrder;
        private IOrderLogic _order;

        public PickOrderController(IConfiguration config)
        {
            _factory = new Factory.Factory(config);
            _pickOrder = this._factory.PickOrderLogic();
            _order = this._factory.OrderLogic();
        }

        public IActionResult PickOrders()
        {
            try
            {
                IEnumerable<PickOrder> pickOrders = this._pickOrder.GetAllPickOrders();
                return View(pickOrders);
            }
            catch (Exception e)
            {
                TempData["errormessage"] = e.Message;
                return View();
            }
            
        }

        public IActionResult PickOrder()
        {
            try
            {
                IEnumerable<Order> orders = this._order.GetAllOrders();
                PickOrderViewModel model = new PickOrderViewModel(orders);
                return View(model);
            }
            catch (Exception e)
            {
                TempData["errormessage"] = e.Message;
                return View();
            }

        }
    }
}