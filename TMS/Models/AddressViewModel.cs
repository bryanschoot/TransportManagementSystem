using System.ComponentModel.DataAnnotations;
using TMS.Model;

namespace TMS.Models
{
    public class AddressViewModel
    {
        public AddressViewModel()
        {
        }

        public AddressViewModel(Address address)
        {
            this.Id = address.Id;
            this.Country = address.Country;
            this.City = address.City;
            this.StreetName = address.StreetName;
            this.StreetNumber = address.StreetNumber;
            this.ZipCode = address.ZipCode;
        }

        public int Id { get; set; }

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

        public Address CopyTo()
        {
            return new Address
            {
                Id = this.Id,
                Country = this.Country,
                City = this.City,
                StreetName = this.StreetName,
                StreetNumber = this.StreetNumber,
                ZipCode = this.ZipCode,
            };
        }
    }
}