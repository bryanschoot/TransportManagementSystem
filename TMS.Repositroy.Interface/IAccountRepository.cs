using System.Collections.Generic;
using TMS.Model;

namespace TMS.Repositroy.Interface
{
    public interface IAccountRepository : IRepository<Account>
    {
        bool IsAccountValid(string email, string password);
        bool DoesEmailExist(string email);
        bool UpdateAccount(Account account);
        bool AdminUpdateAccount(Account account);
        bool CreateAccount(Account account);

        bool UpdateAddress(Address address);
        bool DeleteAddress(int id);
        bool CreateAddress(Address address, int id);

        Account GetAccountByEmail(string email);
        Account GetAccountById(int id);
        Address GetAddressById(int id);

        int CountAllCustomers();

        IEnumerable<Role> GetAllRoles();
    }
}