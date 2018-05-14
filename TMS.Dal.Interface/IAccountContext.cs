﻿using TMS.Model;

namespace TMS.Dal.Interface
{
    public interface IAccountContext : IContext<Account>
    {
        bool IsAccountValid(string email, string password);
        bool DoesEmailExist(string email);
        Account GetAccountByEmail(string email);
        Account GetAccountById(int id);
        bool UpdateAccount(Account account);
        Address GetAddressById(int id);
        bool UpdateAddress(Address address);
        bool DeleteAddress(int id);
        bool CreateAddress(Address address, int id);
        int CountAllCustomers();
    }
}