namespace TMS.Model
{
    public class Vehicle
    {
        public Vehicle() { }

        public Vehicle(int id, string brand, string type, string fuel, string licensePlate, double length, double width, double height)
        {
            Id = id;
            Brand = brand;
            Type = type;
            Fuel = fuel;
            LicensePlate = licensePlate;
            Length = length;
            Width = width;
            Height = height;
        }

        public int Id { get; set; }

        public string Brand { get; set; }

        public string Type { get; set; }

        public string Fuel { get; set; }

        public string LicensePlate { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double GetSpace()
        {
            return this.Length * this.Width * this.Height;
        }

    }
}