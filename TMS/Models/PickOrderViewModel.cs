using System.Collections.Generic;
using System.Linq;
using TMS.Model;

namespace TMS.Models
{
    public class PickOrderViewModel
    {
        public PickOrderViewModel() { }

        public PickOrderViewModel(IEnumerable<Order> orders)
        {
            this.Orders = (IList<Order>)orders;
        }

        public PickOrderViewModel(IEnumerable<Order> orders, PickOrder pickOrder)
        {
            this.Orders = (IList<Order>) orders;
            this.SelectedOrders = (IList<Order>) pickOrder.Orders;
        }

        public int Id { get; set; }

        public IList<Order> SelectedOrders { get; set; }

        public IList<Order> Orders { get; set; }

        public PickOrder CopyTo()
        {
            List<Order> orders = new List<Order>();
            if (this.Orders != null)
            {
                orders.AddRange(this.Orders);
            }
            if (this.SelectedOrders != null)
            {
                orders.AddRange(SelectedOrders);
            }

            PickOrder pickOrder = new PickOrder()
            {
                Id = this.Id,
                Orders = orders,
                Lenght = orders.Sum(o => o.Length),
                Width = orders.Sum(o => o.Width),
                Height = orders.Sum(o => o.Height),
                Weight = orders.Sum(o => o.Weight),
        };
            return pickOrder;
        }
    }
}