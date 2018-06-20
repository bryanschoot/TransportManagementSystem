using TMS.Model;

namespace TMS.Dal.Interface
{
    public interface IPickOrderContext : IContext<PickOrder>
    {
        bool CreatePickOrder(PickOrder pickOrder);
        bool DeletePickOrder(int id);
    }
}