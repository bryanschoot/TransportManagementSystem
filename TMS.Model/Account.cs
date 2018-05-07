using System;

namespace TMS.Model
{
    using System.Collections.Generic;

    public class Account
    {
        public Account()
        {
        }

        public Account(int id, string email, string password, string firstName, string lastName, string phoneNumber, List<Address> address, Role role, List<Order> orders)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.Role = role;
            this.Orders = orders;
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public List<Address> Address { get; set; }

        public Role Role { get; set; }

        public List<Order> Orders { get; set; }

        //public List<Ride> Rides { get; set; }
    }
}
