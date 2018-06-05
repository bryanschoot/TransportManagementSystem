using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
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

        //List of all orders
        public List<Order> Orders { get; set; }

        //Construtor for creating or editing a order
        public OrderViewModel(Order order)
        {
            OrderId = order.Id;
            Description = order.Description;
            OrderDate = order.OrderDate;
            DeliverDate = order.DeliverDate;
            Length = order.Length;
            Width = order.Width;
            Height = order.Height;
            Weight = order.Weight;
            AddressId = order.Address.Id;
            Country = order.Address.Country;
            City = order.Address.City;
            StreetName = order.Address.StreetName;
            StreetNumber = order.Address.StreetNumber;
            ZipCode = order.Address.ZipCode;
        }

        //Order details
        public int OrderId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DeliverDate { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        public double Length { get; set; }

        [Required]
        public double Width { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public double Weight { get; set; }

        //Address details
        public int AddressId { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public string StreetNumber { get; set; }

        [Required]
        public string ZipCode { get; set; }


        public Order CopyTo()
        {
            Order order = new Order
            {
                Id = this.OrderId,
                Description = this.Description,
                DeliverDate = this.DeliverDate,
                OrderDate = this.OrderDate,
                Length = this.Length,
                Width = this.Width,
                Height = this.Height,
                Weight = this.Weight,

                Address = new Address
                {
                    Id = this.AddressId,
                    Country = this.Country,
                    City = this.City,
                    StreetName = this.StreetName,
                    StreetNumber = this.StreetNumber,
                    ZipCode = this.ZipCode,
                },
            };
            return order;
        }
    }
}