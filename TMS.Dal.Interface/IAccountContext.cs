using System.Collections.Generic;
using TMS.Model;

namespace TMS.Dal.Interface
{
    public interface IAccountContext : IContext<Account>
    {
        bool IsAccountValid(string email, string password);
        bool DoesEmailExist(string email);
        bool UpdateAccount(Account account);
        bool UpdateAddress(Address address);
        bool DeleteAddress(int id);
        bool CreateAddress(Address address, int id);
        bool AdminUpdateAccount(Account account);
        bool CreateAccount(Account account);

        Account GetAccountByEmail(string email);
        Account GetAccountById(int id);
        Address GetAddressById(int id);

        int CountAllCustomers();

        IEnumerable<Role> GetAllRoles();
        IEnumerable<Account> GetAllEmployees();
    }
}