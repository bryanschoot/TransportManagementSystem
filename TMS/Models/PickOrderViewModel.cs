using System.Collections.Generic;
using TMS.Model;

namespace TMS.Models
{
    public class PickOrderViewModel
    {
        public PickOrderViewModel() { }

        public PickOrderViewModel(IEnumerable<Order> orders)
        {
            this.Orders = orders;
        }

        public int Id { get; set; }

        public List<Order> SelectedOrders { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}