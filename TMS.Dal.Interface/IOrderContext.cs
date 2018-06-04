using System.Collections.Generic;
using TMS.Model;

namespace TMS.Dal.Interface
{
    public interface IOrderContext : IContext<Order>
    {
        List<Order> GetAllOrdersById(int id);
    }
}