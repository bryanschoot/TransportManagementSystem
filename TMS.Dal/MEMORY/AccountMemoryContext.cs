using System.Collections.Generic;
using TMS.Dal.Interface;
using TMS.Model;

namespace TMS.Dal.MEMORY
{
    public class AccountMemoryContext : IAccountContext
    {
        public AccountMemoryContext() { }

        public IEnumerable<Account> All()
        {
            throw new System.NotImplementedException();
        }

        public Account GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(Account entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Account entity, int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Account entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Account entity)
        {
            throw new System.NotImplementedException();
        }

        public int Count(Account entity)
        {
            throw new System.NotImplementedException();
        }

        public bool IsAccountValid(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public bool DoesEmailExist(string email)
        {
            throw new System.NotImplementedException();
        }

        public Account GetAccountByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Account GetAccountById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateAccount(Account account)
        {
            throw new System.NotImplementedException();
        }

        public Address GetAddressById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateAddress(Address address)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteAddress(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateAddress(Address address, int id)
        {
            throw new System.NotImplementedException();
        }

        public int CountAllCustomers()
        {
            throw new System.NotImplementedException();
        }
    }
}