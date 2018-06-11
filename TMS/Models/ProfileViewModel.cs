using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TMS.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public ProfileViewModel(IEnumerable<Role> roles)
        {
            foreach (var role in roles)
            {
                SelectListItem listItem = new SelectListItem()
                {
                    Value = role.Id.ToString(),
                    Text = role.RoleName
                };
                Roles.Add(listItem);
            }
        }

        public ProfileViewModel(Account account, IEnumerable<Role> roles)
        {
            this.Id = account.Id;
            this.Email = account.Email;
            this.FirstName = account.FirstName;
            this.LastName = account.LastName;
            this.PhoneNumber = account.PhoneNumber;
            this.Addresses = account.Address;
            this.Role = account.Role;

            foreach (var role in roles)
            {
                if (role.RoleName == this.Role.RoleName)
                {
                    SelectListItem listItem = new SelectListItem()
                    {
                        Value = role.Id.ToString(),
                        Text = role.RoleName
                    };
                    CurrentRole.Add(listItem);
                }
                else
                {
                    SelectListItem listItem = new SelectListItem()
                    {
                        Value = role.Id.ToString(),
                        Text = role.RoleName
                    };
                    OtherRole.Add(listItem);
                }
            }

            Roles.AddRange(CurrentRole);
            Roles.AddRange(OtherRole);
        }

        public List<SelectListItem> CurrentRole = new List<SelectListItem>();
        public List<SelectListItem> OtherRole = new List<SelectListItem>();

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }

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

        public Role Role { get; set; }

        public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();

        public int SelectedRole { get; set; }

        public List<Address> Addresses { get; set; }

        public Account CopyTo()
        {
            return new Account
            {
                Id = this.Id,
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                PhoneNumber = this.PhoneNumber,
                Password = this.Password,

                Role = new Role
                {
                    Id = this.SelectedRole,
                }
            };
        }
    }
}