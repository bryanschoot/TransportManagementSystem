using System;
using System.Collections.Generic;
using TMS.Dal.Interface;
using TMS.Model;
using TMS.Repositroy.Interface;

namespace TMS.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IAccountContext _contex;

        public AccountRepository(IAccountContext context)
        {
            this._contex = context;
        }

        #region NotImplemented
        public IEnumerable<Account> All()
        {
            return this._contex.All();
        }

        public Model.Account GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Model.Account entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Model.Account entity, int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Model.Account entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Model.Account entity)
        {
            throw new NotImplementedException();
        }

        public int Count(Model.Account entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        public bool IsAccountValid(string email, string password)
        {
            return this._contex.IsAccountValid(email, password);
        }

        public bool DoesEmailExist(string email)
        {
            return this._contex.DoesEmailExist(email);
        }

        public Account GetAccountByEmail(string email)
        {
            return this._contex.GetAccountByEmail(email);
        }

        public Account GetAccountById(int id)
        {
            return this._contex.GetAccountById(id);
        }

        public bool UpdateAccount(Account account)
        {
            return this._contex.UpdateAccount(account);
        }

        public bool AdminUpdateAccount(Account account)
        {
            return this._contex.AdminUpdateAccount(account);
        }

        public bool CreateAccount(Account account)
        {
            return this._contex.CreateAccount(account);
        }

        public Address GetAddressById(int id)
        {
            return this._contex.GetAddressById(id);
        }

        public bool UpdateAddress(Address address)
        {
            return this._contex.UpdateAddress(address);
        }

        public bool DeleteAddress(int id)
        {
            return this._contex.DeleteAddress(id);
        }

        public bool CreateAddress(Address address, int id)
        {
            return this._contex.CreateAddress(address, id);
        }

        public int CountAllCustomers()
        {
            return this._contex.CountAllCustomers();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return this._contex.GetAllRoles();
        }
    }
}
