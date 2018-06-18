using System.Collections.Generic;
using TMS.Model;

namespace TMS.Logic.Interface
{
    public interface IOrderLogic
    {
        List<Order> GetAllOrdersById(int id);
        bool CreateOrder(Order model, int id);
        Order GetOrderById(int id, int accountId);
        bool DeleteOrderById(int id);
        bool UpdateOrder(Order order);
        int CountAllOrders();
        IEnumerable<Order> GetAllOrders();
    }
}