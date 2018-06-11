using System;
using System.Collections.Generic;
using TMS.Logic.Interface;
using TMS.Model;
using TMS.Model.Exceptions;
using TMS.Repositroy.Interface;

namespace TMS.Logic
{
    public class AccountLogic : IAccountLogic
    {
        private IAccountRepository Repository { get; }
        private HashLogic Hash;

        public AccountLogic(IAccountRepository repository)
        {
            this.Repository = repository;
            this.Hash = new HashLogic();
        }

        public bool IsAccountValid(string email, string password)
        {
            return this.Repository.IsAccountValid(email, password);
        }

        public bool DoesEmailExist(string email)
        {
            return this.Repository.DoesEmailExist(email);
        }

        public Account GetAccountByEmail(string email)
        {
            return this.Repository.GetAccountByEmail(email);
        }

        public Account GetAccountById(int id)
        {
            if (id == 0)
            {
                new AccountException("Id cannot be empty");
            }
            return this.Repository.GetAccountById(id);
        }

        public bool UpdateAccount(Account account)
        {
            if (account == null)
            {
                new AccountException("Account = null.");
                return false;
            }
            return this.Repository.UpdateAccount(account);
        }

        public bool AdminUpdateAccount(Account account)
        {
            if (account == null)
            {
                new AccountException("Account = null.");
                return false;
            }
            return this.Repository.AdminUpdateAccount(account);
        }

        public bool CreateAccount(Account account)
        {
            if (account == null)
            {
                new AccountException("Account = null.");
                return false;
            }
            return this.Repository.CreateAccount(account);
        }

        public Address GetAddressById(int id, int accountid)
        {
            Address address = this.Repository.GetAddressById(id);

            if (address == null)
            {
                new AddressException("Address = null");
                return null;
            }
            if (address.Account.Id != accountid)
            {
                new AddressException("Address is not yours");
                return null;
            }

            return address;

        }

        public bool UpdateAddress(Address address)
        {
            return this.Repository.UpdateAddress(address);
        }

        public bool DeleteAddress(int id)
        {
            return this.Repository.DeleteAddress(id);
        }

        public bool CreateAddress(Address address, int id)
        {
            return this.Repository.CreateAddress(address, id);
        }

        public int CountAllCustomers()
        {
           return this.Repository.CountAllCustomers();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return this.Repository.All();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return this.Repository.GetAllRoles();
        }

        public string CreateHash(string tobehashed)
        {
            string hash = Hash.CreateHash(tobehashed);
            return hash;
        }
    }
}
