using System;
using System.Collections.Generic;
using System.Linq;
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
                return RedirectToAction("PickOrders");
            }

        }

        public IActionResult CreatePickOrder(PickOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                PickOrder pickOrder = model.CopyTo();
                if (pickOrder.Orders.Any())
                {
                    if (pickOrder.Orders.Count >= 4)
                    {
                        if (this._pickOrder.CreatePickOrder(pickOrder))
                        {
                            TempData["message"] = "Pickorder has been created";
                            return RedirectToAction("PickOrders");
                        }
                        else
                        {
                            TempData["errormessage"] = "Pickorder cannot be created";
                            return View("PickOrder", model);
                        }
                    }
                    else
                    {
                        TempData["errormessage"] = "Must be atleast 4 orders within a pickorder";
                        return View("PickOrder", model);
                    }
                }
                else
                {
                    TempData["errormessage"] = "Pickorder cannot be empty";
                    return RedirectToAction("PickOrder", model);
                }
            }
            return View("PickOrder", model);
        }

        public IActionResult EditPickOrder(int id)
        {
            try
            {
                IEnumerable<Order> orders = this._order.GetAllOrders();
                PickOrder pickOrder = this._pickOrder.GetPickOrderById(id);
                PickOrderViewModel model = new PickOrderViewModel(orders, pickOrder);
                return View("PickOrder", model);
            }
            catch (Exception e)
            {
                TempData["errormessage"] = e.Message;
                IEnumerable<Order> orders = null;
                PickOrder pickOrder = this._pickOrder.GetPickOrderById(id);
                PickOrderViewModel model = new PickOrderViewModel(orders, pickOrder);
                return View("PickOrder", model);
            }
        }

        public IActionResult UpdatePickOrder(PickOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                PickOrder pickOrder = model.CopyTo();
                if (pickOrder.Orders.Count >= 4)
                {
                    if (this._pickOrder.UpdatePickOrder(pickOrder))
                    {
                        try
                        {
                            TempData["message"] = "PickOrder has been succesfully updated.";
                            return RedirectToAction("PickOrders");
                        }
                        catch (Exception e)
                        {
                            TempData["message"] = e.Message;
                            return RedirectToAction("PickOrders");
                        }

                    }
                    else
                    {
                        TempData["errormessage"] = "PickOrder cannot be updated.";
                        return RedirectToAction("PickOrders");
                    }
                }
                else
                {
                    TempData["errormessage"] = "Must be atleast 4 orders within a pickorder";
                    return View("PickOrder", model);
                }
            }
            return View("PickOrder", model);
        }

        public IActionResult DeletePickOrder(int id)
        {
            try
            {
                if (this._pickOrder.DeletePickOrer(id))
                {
                    TempData["message"] = "Pickorder succesfully deleted.";
                    return RedirectToAction("PickOrders");
                }
                else
                {
                    TempData["errormessage"] = "Pickorder could not been deleted";
                    return RedirectToAction("PickOrders");
                }
            }
            catch (Exception e)
            {
                TempData["errormessage"] = e.Message;
                return RedirectToAction("PickOrders");
            }
        }
    }
}