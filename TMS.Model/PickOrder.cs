namespace TMS.Model
{
    using System.Collections.Generic;

    public class PickOrder
    {
        public PickOrder()
        {
        }

        public PickOrder(int id, double lenght, double width, double height, double weight, Vehicle vehicle, List<Order> orders, int amountOfOrders)
        {
            Id = id;
            Lenght = lenght;
            Width = width;
            Height = height;
            Weight = weight;
            Vehicle = vehicle;
            Orders = orders;
            AmountOfOrders = amountOfOrders;
        }

        public int Id { get; set; }

        public double Lenght { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public Vehicle Vehicle { get; set; }

        public List<Order> Orders { get; set; }

        public int AmountOfOrders { get; set; }

        public double GetSpace()
        {
            return (this.Lenght / 100) * (this.Width / 100) * (this.Height / 100);
        }
    }
}