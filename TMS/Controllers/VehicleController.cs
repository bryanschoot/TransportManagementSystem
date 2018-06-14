using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TMS.Logic.Interface;
using TMS.Model;
using TMS.Models;

namespace TMS.Controllers
{
    public class VehicleController : Controller
    {
        private readonly Factory.Factory _factory;
        private readonly IVehicleLogic _vehicle;

        public VehicleController(IConfiguration config)
        {
            this._factory = new Factory.Factory(config);
            this._vehicle = this._factory.VehicleLogic();
        }


        public IActionResult Vehicles()
        {
            try
            {
                IEnumerable<Vehicle> vehicles = this._vehicle.GetAllVehicles();
                return View(vehicles);
            }
            catch (NullReferenceException e)
            {
                TempData["errormessage"] = e.Message;
                return View();
            }
        }

        public IActionResult EditVehicle(int id)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult DeleteVehicle(int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public IActionResult Vehicle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateVehicle(VehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
                Vehicle vehicle = model.CopyTo();
                try
                {
                    if (this._vehicle.CreateVehicle(vehicle))
                    {
                        TempData["message"] = "Vehicle succesfully created!";
                        return View("Vehicles");
                    }
                    TempData["errormessage"] = "Vehicle could not been created!";
                    return View("Vehicles");
                }
                catch (Exception e)
                {
                    TempData["errormessage"] = e.Message;
                    return View("Vehicles");
                }
            }

            return View("Vehicle", model);
        }

        [HttpPost]
        public IActionResult UpdateVehicle()
        {
            throw new NotImplementedException();
        }
    }
}