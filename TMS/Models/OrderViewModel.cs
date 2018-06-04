using System;
using System.Collections.Generic;
using TMS.Model;

namespace TMS.Models
{
    public class OrderViewModel
    {
        public OrderViewModel() { }

        //Constructor for getting all orders
        public OrderViewModel(List<Order> order)
        {
            Orders = order;

        }

        //Construtor for creating or editing a order

        //List of all orders
        public List<Order> Orders { get; set; }

        //Properties for form
    }
}