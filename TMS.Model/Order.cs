namespace TMS.Model
{
    using System;

    public class Order
    {
        public Order()
        {
        }

        public Order(int id, string description, DateTime deliverDate, DateTime orderDate, double length, double width, double height, double weight, Address address, Account account)
        {
            Id = id;
            Description = description;
            DeliverDate = deliverDate;
            OrderDate = orderDate;
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
            Address = address;
            Account = account;
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime DeliverDate { get; set; }

        public DateTime OrderDate { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public Address Address { get; set; }

        public Account Account { get; set; }
    }
}