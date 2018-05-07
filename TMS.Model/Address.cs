namespace TMS.Model
{
    public class Address
    {
        public Address()
        {
        }

        public Address(int id, string country, string city, string streetname, string streetnumber, string zipcode, Account account)
        {
            this.Id = id;
            this.Country = country;
            this.City = city;
            this.StreetName = streetname;
            this.StreetNumber = streetnumber;
            this.ZipCode = zipcode;
            this.Account = account;
        }

        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public string ZipCode { get; set; }

        public Account Account { get; set; }
    }
}