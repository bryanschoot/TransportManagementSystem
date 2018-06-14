using System;
using System.Collections.Generic;
using TMS.Logic.Interface;
using TMS.Logic.Validation;
using TMS.Model;
using TMS.Model.Exceptions;
using TMS.Repositroy.Interface;

namespace TMS.Logic
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IAccountRepository _repository;
        private HashLogic Hash;
        private Validation.Validation Validation;

        public AccountLogic(IAccountRepository repository)
        {
            this._repository = repository;
            this.Hash = new HashLogic();
            this.Validation = new Validation.Validation();
        }

        public bool IsAccountValid(string email, string password)
        {
            return this._repository.IsAccountValid(email, password);
        }

        public bool DoesEmailExist(string email)
        {
            return this._repository.DoesEmailExist(email);
        }

        public Account GetAccountByEmail(string email)
        {
            if (!this.Validation.IsValid(email))
            {
                new AccountException("Email is not valid.");
            }
            Account account = this._repository.GetAccountByEmail(email);
            return account;
        }

        public Account GetAccountById(int id)
        {
            if (id == 0)
            {
                new AccountException("Id cannot be empty");
            }
            return this._repository.GetAccountById(id);
        }

        public bool UpdateAccount(Account account)
        {
            if (account == null)
            {
                new AccountException("Account = null.");
                return false;
            }
            return this._repository.UpdateAccount(account);
        }

        public bool AdminUpdateAccount(Account account)
        {
            if (account == null)
            {
                new AccountException("Account = null.");
                return false;
            }
            return this._repository.AdminUpdateAccount(account);
        }

        public bool CreateAccount(Account account)
        {
            if (account == null)
            {
                new AccountException("Account = null.");
                return false;
            }
            return this._repository.CreateAccount(account);
        }

        public Address GetAddressById(int id, int accountid)
        {
            Address address = this._repository.GetAddressById(id);

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
            return this._repository.UpdateAddress(address);
        }

        public bool DeleteAddress(int id)
        {
            return this._repository.DeleteAddress(id);
        }

        public bool CreateAddress(Address address, int id)
        {
            return this._repository.CreateAddress(address, id);
        }

        public int CountAllCustomers()
        {
           return this._repository.CountAllCustomers();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return this._repository.All();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return this._repository.GetAllRoles();
        }

        public string CreateHash(string tobehashed)
        {
            string hash = Hash.CreateHash(tobehashed);
            return hash;
        }
    }
}
