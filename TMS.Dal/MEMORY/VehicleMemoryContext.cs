﻿using System.Collections.Generic;
using TMS.Dal.Interface;
using TMS.Model;

namespace TMS.Dal.MEMORY
{
    public class VehicleMemoryContext : IVehicleContext
    {
        public IEnumerable<Vehicle> All()
        {
            throw new System.NotImplementedException();
        }

        public Vehicle GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(Vehicle entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Vehicle entity, int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Vehicle entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Vehicle entity)
        {
            throw new System.NotImplementedException();
        }

        public int Count(Vehicle entity)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateVehicle(Vehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        public int CountAllVehicles()
        {
            throw new System.NotImplementedException();
        }
    }
}