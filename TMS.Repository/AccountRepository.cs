using System;
using System.Collections.Generic;
using TMS.Dal.Interface;
using TMS.Model;
using TMS.Repositroy.Interface;

namespace TMS.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private IAccountContext Contex { get; }

        public AccountRepository(IAccountContext context)
        {
            this.Contex = context;
        }

        #region NotImplemented
        public IEnumerable<Model.Account> All()
        {
            throw new NotImplementedException();
        }

        public Model.Account GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Model.Account entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Model.Account entity)
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
            return this.Contex.IsAccountValid(email, password);
        }

        public bool DoesEmailExist(string email)
        {
            return this.Contex.DoesEmailExist(email);
        }

        public Account GetAccountByEmail(string email)
        {
            return this.Contex.GetAccountByEmail(email);
        }

        public Account GetAccountById(int id)
        {
            return this.Contex.GetAccountById(id);
        }

        public bool UpdateAccount(Account account)
        {
            return this.Contex.UpdateAccount(account);
        }

        public Address GetAddressById(int id)
        {
            return this.Contex.GetAddressById(id);
        }

        public bool UpdateAddress(Address address)
        {
            return this.Contex.UpdateAddress(address);
        }

        public bool DeleteAddress(int id)
        {
            return this.Contex.DeleteAddress(id);
        }

        public bool CreateAddress(Address address, int id)
        {
            return this.Contex.CreateAddress(address, id);
        }
    }
}
