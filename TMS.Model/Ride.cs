using System;
using System.Collections.Generic;

namespace TMS.Model
{
    public class Ride
    {
        public Ride() { }

        public Ride(int id, int amountOfPickOrders, Account account, DateTime rideDate, Vehicle vehicle, List<PickOrder> pickOrders)
        {
            Id = id;
            AmountOfPickOrders = amountOfPickOrders;
            Account = account;
            RideDate = rideDate;
            Vehicle = vehicle;
            PickOrders = pickOrders;
        }

        public int Id { get; set; }
        public int AmountOfPickOrders { get; set; }
        public Account Account { get; set; }
        public DateTime RideDate { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<PickOrder> PickOrders { get; set; }
    }
}