using System.Collections.Generic;
using System.Linq;
using TMS.Dal.Interface;
using TMS.Model;

namespace TMS.Dal.MEMORY
{
    public class AccountMemoryContext : IAccountContext
    {
        private List<Account> accounts = new List<Account>();
        private List<Address> addresses = new List<Address>();

        public AccountMemoryContext()
        {
            initilizeAddress();
            initilizeAccounts();
        }

        public void initilizeAccounts()
        {
            accounts.Add(new Account{Id = 1, Email = "jan@test.nl", Password = "jantest123", FirstName = "Jan", LastName = "Willems", PhoneNumber = "0681022103", Role = new Role(1, "Admin"), Address = addresses});
            accounts.Add(new Account{Id = 2, Email = "bryan@test.nl", Password = "bryantest123", FirstName = "Bryan", LastName = "Schoot", PhoneNumber = "0681322803", Role = new Role(2, "Employee"), Address = addresses,});
        }

        public void initilizeAddress()
        {
            addresses.Add(new Address{Id = 1, Country = "Netherlands", City = "Arnhem", StreetName = "Marxsingel", StreetNumber = "10", ZipCode = "6836PZ"});
        }

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
            if (email == accounts[0].Email && password == accounts[0].Password)
            {
                return true;
            }

            return false;
        }

        public bool DoesEmailExist(string email)
        {
            if (email == accounts[0].Email)
            {
                return true;
            }

            return false;
        }

        public Account GetAccountByEmail(string email)
        {
            Account account = accounts.FirstOrDefault(a => a.Email == email);
            return account;
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