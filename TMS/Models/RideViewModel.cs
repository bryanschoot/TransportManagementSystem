using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TMS.Model;

namespace TMS.Models
{
    public class RideViewModel
    {
        public RideViewModel() { }

        public RideViewModel(IEnumerable<Account> accounts, IEnumerable<PickOrder> pickOrders, IEnumerable<Vehicle> vehicles)
        {
            this.PickOrders = (IList<PickOrder>)pickOrders;

            foreach (var account in accounts)
            {
                SelectListItem listItem = new SelectListItem()
                {
                    Value = account.Id.ToString(),
                    Text = $"{account.FirstName} {account.LastName}",
                };
                Accounts.Add(listItem);
            }

            foreach (var vehicle in vehicles)
            {
                SelectListItem listItem = new SelectListItem()
                {
                    Value = vehicle.Id.ToString(),
                    Text = vehicle.LicensePlate,
                };
                Vehicles.Add(listItem);
            }
        }

        public int Id { get; set; }

        [Required]
        public int SelectedDriver { get; set; }

        public int SelectedVehicle { get; set; }

        public DateTime RideDate { get; set; }

        public IList<PickOrder> PickOrders { get; set; }

        public IList<PickOrder> SelectedPickOrders { get; set; }

        public List<SelectListItem> Accounts { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> Vehicles { get; set; } = new List<SelectListItem>();
    }
}