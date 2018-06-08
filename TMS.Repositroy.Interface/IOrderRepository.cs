using System.Collections.Generic;
using TMS.Model;

namespace TMS.Repositroy.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetAllOrdersById(int id);
        bool DeleteById(int id);
    }
}