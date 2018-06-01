using TMS.Logic.Interface;
using TMS.Model;
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
            return this.Repository.GetAccountById(id);
        }

        public bool UpdateAccount(Account account)
        {
            return this.Repository.UpdateAccount(account);
        }

        public Address GetAddressById(int id, int accountid)
        {
            Address address = this.Repository.GetAddressById(id);

            if (address.Account.Id == accountid)
            {
                return address;
            }

            return null;
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

        public string CreateHash(string tobehashed)
        {
            string hash = Hash.CreateHash(tobehashed);
            return hash;
        }
    }
}
