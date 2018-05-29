using TMS.Model;

namespace TMS.Logic.Interface
{
    public interface IOrderLogic
    {
        Order GetAllOrdersById(int id);
    }
}