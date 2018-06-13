using System;
using System.Collections.Generic;

namespace TMS.Model
{
    public class Ride
    {
        public Ride() { }

        public Ride(int id, DateTime rideDate, Vehicle vehicle, List<PickOrder> pickOrders)
        {
            Id = id;
            RideDate = rideDate;
            Vehicle = vehicle;
            PickOrders = pickOrders;
        }

        public int Id { get; set; }
        public DateTime RideDate { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<PickOrder> PickOrders { get; set; }
    }
}