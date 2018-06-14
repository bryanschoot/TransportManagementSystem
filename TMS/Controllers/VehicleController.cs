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
            try
            {
                VehicleViewModel model = new VehicleViewModel(this._vehicle.GetById(id));

                return View("Vehicle", model);
            }
            catch (Exception e)
            {
                TempData["errormessage"] = e.Message;
                return View("Vehicle");
            }
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
                        return RedirectToAction("Vehicles");
                    }
                    TempData["errormessage"] = "Vehicle could not been created!";
                    return RedirectToAction("Vehicles");
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
        public IActionResult UpdateVehicle(VehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Vehicle checkVehicle = this._vehicle.GetById(model.Id);
                    bool changed = checkVehicle.Brand != model.Brand || checkVehicle.Type != model.Type || checkVehicle.Fuel != model.Fuel || checkVehicle.LicensePlate != model.LicensePlate || checkVehicle.Length != model.Length || checkVehicle.Width != model.Width || checkVehicle.Height != model.Height;

                    if (changed)
                    {
                        Vehicle vehicle = model.CopyTo();
                        if (this._vehicle.UpdateVehicle(vehicle))
                        {
                            TempData["message"] = "Vehicle succesfully updated!";
                            return RedirectToAction("Vehicles");
                        }
                        TempData["errormessage"] = "Vehicle could not been updated!";
                        return RedirectToAction("Vehicles");
                    }
                    else
                    {
                        TempData["errormessage"] = "Vehicle could not been updated because you did not change a thing!";
                        return View("Vehicle", model);
                    }
                    
                }
                catch (Exception e)
                {
                    TempData["errormessage"] = e.Message;
                    return View("Vehicles");
                }
            }

            return View("Vehicle", model);
        }
    }
}