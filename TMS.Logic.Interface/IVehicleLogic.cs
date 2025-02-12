﻿using System.Collections.Generic;
using TMS.Model;

namespace TMS.Logic.Interface
{
    public interface IVehicleLogic
    {
        IEnumerable<Vehicle> GetAllVehicles();
        bool CreateVehicle(Vehicle vehicle);
        Vehicle GetById(int id);
        bool UpdateVehicle(Vehicle vehicle);
        int CountAllVehicles();
    }
}