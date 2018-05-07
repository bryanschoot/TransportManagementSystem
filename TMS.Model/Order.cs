namespace TMS.Model
{
    using System;

    public class Order
    {
        public Order()
        {
        }

        public Order(int id, string description, DateTime dateTime, double length, double width, double height, double weight, Address address, Account account)
        {
            this.Id = id;
            this.Description = description;
            this.DateTime = dateTime;
            this.Length = length;
            this.Width = width;
            this.Height = height;
            this.Weight = weight;
            this.Address = address;
            this.Account = account;
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