using System;
using System.Collections.Generic;
using TMS.Model;

namespace TMS.Logic.Interface
{
    public interface IAccountLogic
    {
        bool DoesEmailExist(string email);
        bool IsAccountValid(string email, string password);
        bool UpdateAccount(Account account);
        bool AdminUpdateAccount(Account account);
        bool CreateAccount(Account account);

        bool CreateAddress(Address address, int id);
        bool UpdateAddress(Address address);
        bool DeleteAddress(int id);

        Account GetAccountByEmail(string email);
        Account GetAccountById(int id);

        Address GetAddressById(int id, int accountid);

        int CountAllCustomers();

        IEnumerable<Account> GetAllAccounts();
        IEnumerable<Role> GetAllRoles();
    }
}
