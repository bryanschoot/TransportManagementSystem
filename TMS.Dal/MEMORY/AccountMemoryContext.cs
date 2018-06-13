using System.Collections.Generic;
using System.Linq;
using TMS.Dal.Interface;
using TMS.Model;

namespace TMS.Dal.MEMORY
{
    public class AccountMemoryContext : IAccountContext
    {
        private static List<Account> accounts = new List<Account>();
        private static List<Address> addresses = new List<Address>();

        public AccountMemoryContext()
        {
                initilizeAddress();
                initilizeAccounts();
        }

        public void initilizeAccounts()
        {
            accounts.Add(new Account{Id = 1, Email = "jan@test.nl", Password = "jantest123", FirstName = "Jan", LastName = "Willems", PhoneNumber = "0681022103", Role = new Role(1, "Admin"), Address = addresses});
            accounts.Add(new Account{Id = 2, Email = "bryan@test.nl", Password = "bryantest123", FirstName = "Bryan", LastName = "Schoot", PhoneNumber = "0681322803", Role = new Role(2, "Employee"), Address = addresses,});
            accounts.Add(new Account { Id = 3, Email = "sven@test.nl", Password = "sventest123", FirstName = "Sven", LastName = "Kloon", PhoneNumber = "0681322973", Role = new Role(3, "Customer"), Address = addresses, });
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
            return accounts.Any(a => a.Email == email && a.Password == password);
        }

        public bool DoesEmailExist(string email)
        {
            return accounts.Any(a => a.Email == email);
        }

        public bool AdminUpdateAccount(Account account)
        {
            accounts[2] = account;
            return accounts[2] == account;
        }

        public bool CreateAccount(Account account)
        {
            var oldCount = accounts.Count();
            accounts.Add(account);

            return oldCount < accounts.Count();
        }

        public Account GetAccountByEmail(string email)
        {
            Account account = accounts.FirstOrDefault(a => a.Email == email);
            return account;
        }

        public Account GetAccountById(int id)
        {
            Account account = accounts.FirstOrDefault(a => a.Id == id);
            return account;
        }

        public bool UpdateAccount(Account account)
        {
            accounts[2] = account;
            return accounts[2] == account;
        }

        public Address GetAddressById(int id)
        {
            Address address = addresses.FirstOrDefault(a => a.Id == id);
            return address;
        }

        public bool UpdateAddress(Address address)
        {
            addresses[1] = address;
            return addresses[1] == address;
        }

        public bool DeleteAddress(int id)
        {
            int odlCount = addresses.Count();
            addresses = addresses.Where(a => a.Id != id).ToList();

            return odlCount > addresses.Count();
        }

        public bool CreateAddress(Address address, int id)
        {
            int odlCount = addresses.Count();
            addresses.Add(address);

            return odlCount < addresses.Count();
        }

        public int CountAllCustomers()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            throw new System.NotImplementedException();
        }
    }
}