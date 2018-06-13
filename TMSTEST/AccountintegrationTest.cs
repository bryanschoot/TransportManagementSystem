using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS.Logic.Interface;
using TMS.Model;
using TMS.Model.Exceptions;

namespace TMSTEST
{
    [TestClass]
    public class AccountIntegrationTest
    {
        private TMS.Factory.Factory _factory;
        private IAccountLogic accountLogic;

        private static List<Account> accounts = new List<Account>();
        private static List<Address> addresses = new List<Address>();

        public AccountIntegrationTest()
        {
            this._factory = new TMS.Factory.Factory();
        }

        [TestInitialize]
        public void initialize()
        {
            initilizeAddress();
            initilizeAccounts();
        }

        public void initilizeAccounts()
        {
            accounts.Add(new Account { Id = 1, Email = "jan@test.nl", Password = "jantest123", FirstName = "Jan", LastName = "Willems", PhoneNumber = "0681022103", Role = new Role(1, "Admin"), Address = addresses });
            accounts.Add(new Account { Id = 2, Email = "bryan@test.nl", Password = "bryantest123", FirstName = "Bryan", LastName = "Schoot", PhoneNumber = "0681322803", Role = new Role(2, "Employee"), Address = addresses, });
            accounts.Add(new Account { Id = 3, Email = "sven@test.nl", Password = "sventest123", FirstName = "Sven", LastName = "Kloon", PhoneNumber = "0681322973", Role = new Role(3, "Customer"), Address = addresses, });
            accounts.Add(new Account { Id = 4, Email = "melle@test.nl", Password = "melletest123", FirstName = "Melle", LastName = "Regels", PhoneNumber = "0685842973", Role = new Role(3, "Customer"), Address = addresses, });
            accounts.Add(new Account { Id = 5, Email = "jasper@test.nl", Password = "jaspertest123", FirstName = "Jasper", LastName = "Lol", PhoneNumber = "0685842973", Role = new Role(3, "Customer"), Address = addresses, });
            accounts.Add(new Account { Id = 6, Email = "jeroen@test.nl", Password = "jeroentest123", FirstName = "Jeroen", LastName = "Klein", PhoneNumber = "0685423973", Role = new Role(3, "Customer"), Address = addresses, });
            accounts.Add(new Account { Id = 7, Email = "esther@test.nl", Password = "esthertest123", FirstName = "Esther", LastName = "Hooijveld", PhoneNumber = "068555573", Role = new Role(2, "Employee"), Address = addresses, });
        }

        public void initilizeAddress()
        {
            addresses.Add(new Address { Id = 1, Country = "Netherlands", City = "Arnhem", StreetName = "Marxsingel", StreetNumber = "10", ZipCode = "6836PZ" });
            addresses.Add(new Address { Id = 2, Country = "Netherlands", City = "Nijmegen", StreetName = "Koningstraat", StreetNumber = "31A", ZipCode = "6855NI" });
            addresses.Add(new Address { Id = 3, Country = "Germany", City = "Strabe", StreetName = "Strafe", StreetNumber = "322", ZipCode = "6123DE" });
        }

        //Test function register and login
        [TestMethod]
        public void RegisterLoginTest()
        {
            //Try to login
            bool tryLogin = this._factory.AccountLogic().IsAccountValid(accounts[5].Email, accounts[5].Password);
            Assert.IsFalse(tryLogin);

            //Create the account
            bool createAccount = this._factory.AccountLogic().CreateAccount(accounts[5]);
            Assert.IsTrue(createAccount);

            //Try to log in again
            bool loginAccount = this._factory.AccountLogic().IsAccountValid(accounts[5].Email, accounts[5].Password);
            Assert.IsTrue(loginAccount);
        }
        //End

        //Test function edit account while not logged in
        [TestMethod]
        public void UpdateAccountTest()
        {
            //Try to login
            bool tryLogin = this._factory.AccountLogic().IsAccountValid(accounts[5].Email, accounts[5].Password);
            Assert.IsTrue(tryLogin);

            //Get account by email
            Account account = this._factory.AccountLogic().GetAccountByEmail(accounts[5].Email);
            Assert.AreEqual(account, accounts[5]);

            //Edit account
            bool check = this._factory.AccountLogic().UpdateAccount(accounts[6]);
            Assert.IsTrue(check);
        }
        //End

        //Test function edit address create address then update address and eventually delete address
        [TestMethod]
        public void UpdateAddressTest()
        {
            //Try to find a non existing address
            Address address = this._factory.AccountLogic().GetAddressById(addresses[1].Id, accounts[0].Id);
            Assert.IsNull(address);

            //Create the current address that does not exist.
            bool create = this._factory.AccountLogic().CreateAddress(addresses[1], accounts[0].Id);
            Assert.IsTrue(create);

            //Update address
            bool update = this._factory.AccountLogic().UpdateAddress(addresses[2]);
            Assert.IsTrue(update);

            //Delete address
            bool delete = this._factory.AccountLogic().DeleteAddress(addresses[2].Id);
            Assert.IsTrue(delete);

            //Try to find a non existing address
            Address address2 = this._factory.AccountLogic().GetAddressById(addresses[2].Id, accounts[0].Id);
            Assert.IsNull(address2);
        }
        //End
    }
}
