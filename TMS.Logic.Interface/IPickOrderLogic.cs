using System.Collections.Generic;
using TMS.Model;

namespace TMS.Logic.Interface
{
    public interface IPickOrderLogic
    {
        IEnumerable<PickOrder> GetAllPickOrders();
        bool CreatePickOrder(PickOrder pickOrder);
        PickOrder GetPickOrderById(int id);
    }
}