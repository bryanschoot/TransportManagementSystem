using System;
using TMS.Model;

namespace TMS.Logic.Interface
{
    public interface IAccountLogic
    {
        bool DoesEmailExist(string email);
        bool IsAccountValid(string email, string password);
        Account GetAccountByEmail(string email);
        Account GetAccountById(int id);
        bool UpdateAccount(Account account);
        Address GetAddressById(int id, int accountid);
        bool UpdateAddress(Address address);
        bool DeleteAddress(int id);
        bool CreateAddress(Address address, int id);
        int CountAllCustomers();
    }
}
