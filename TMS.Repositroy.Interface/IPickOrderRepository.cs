using TMS.Model;

namespace TMS.Repositroy.Interface
{
    public interface IPickOrderRepository : IRepository<PickOrder>
    {
        bool CreatePickOrder(PickOrder pickOrder);
        bool DeletePickOrder(int id);
    }
}