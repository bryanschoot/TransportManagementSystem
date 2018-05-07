using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using TMS.Model;

namespace TMS.Models
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
        }

        public ProfileViewModel(Account account)
        {
            this.Id = account.Id;
            this.Email = account.Email;
            this.FirstName = account.FirstName;
            this.LastName = account.LastName;
            this.PhoneNumber = account.PhoneNumber;
            this.Addresses = account.Address;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "*The email field is required."), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "*The firstname field is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*The lastname field is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*The phonenumber field is required.")]
        [Phone(ErrorMessage = "*The phonenumber field is not a valid phone number!")]
        public string PhoneNumber { get; set; }

        public List<Address> Addresses { get; set; }

        public Account CopyTo()
        {
            return new Account
            {
                Id = this.Id,
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                PhoneNumber = this.PhoneNumber
            };
        }
    }
}