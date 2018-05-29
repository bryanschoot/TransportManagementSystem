using System;
using TMS.Model;

namespace TMS.Models
{
    public class OrderViewModel
    {
        public OrderViewModel() { }

        public OrderViewModel(Order order)
        {
            Id = order.Id;
            Description = order.Description;
            DateTime = order.DateTime;
            Length = order.Length;
            Width = order.Width;
            Height = order.Height;
            Weight = order.Weight;
            Address = order.Address;
            Account = order.Account;
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public Address Address { get; set; }

        public Account Account { get; set; }
    }
}