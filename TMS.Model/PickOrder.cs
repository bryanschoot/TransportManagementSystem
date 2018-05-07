namespace TMS.Model
{
    using System.Collections.Generic;

    public class PickOrder
    {
        public PickOrder()
        {
        }

        public PickOrder(int id, double lenght, double width, double height, double weight, Vehicle vehicle, List<Order> orders)
        {
            this.Id = id;
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
            this.Weight = weight;
            this.Vehicle = vehicle;
            this.Orders = orders;
        }

        public int Id { get; set; }

        public double Lenght { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public Vehicle Vehicle { get; set; }

        public List<Order> Orders { get; set; }
    }
}