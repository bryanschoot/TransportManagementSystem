using System.Collections.Generic;
using TMS.Model;

namespace TMS.Logic.Interface
{
    public interface IOrderLogic
    {
        List<Order> GetAllOrdersById(int id);
        bool CreateOrder(Order model, int id);
    }
}