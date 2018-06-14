using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TMS.Model;

namespace TMS.Models
{
    public class VehicleViewModel
    {
        public VehicleViewModel() { }

        public VehicleViewModel(Vehicle vehicle)
        {
            Id = vehicle.Id;
            Brand = vehicle.Brand;
            Type = vehicle.Type;
            Fuel = vehicle.Fuel;
            LicensePlate = vehicle.LicensePlate;
            Length = vehicle.Length;
            Width = vehicle.Width;
            Height = vehicle.Height;
            GetSpace = vehicle.GetSpace();
        }

        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Fuel { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        [Required]
        public double Length { get; set; }

        [Required]
        public double Width { get; set; }

        [Required]
        public double Height { get; set; }

        public double GetSpace { get; set; }

        public Vehicle CopyTo()
        {
            Vehicle vehicle = new Vehicle()
            {
                Id = this.Id,
                Brand = this.Brand,
                Type = this.Type,
                Fuel = this.Fuel,
                LicensePlate = this.LicensePlate,
                Length = this.Length,
                Width = this.Width,
                Height = this.Height,
        };
            return vehicle;
        }
    }
}
