using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS.Logic.Interface;
using TMS.Model;

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
        }

        public void initilizeAddress()
        {
            addresses.Add(new Address { Id = 1, Country = "Netherlands", City = "Arnhem", StreetName = "Marxsingel", StreetNumber = "10", ZipCode = "6836PZ" });
        }

        //Test function register and login
        [TestMethod]
        public void RegisterLoginFailTest()
        {
            bool createAccount = this._factory.AccountLogic().CreateAccount(accounts[5]);

            Assert.IsTrue(createAccount);

            bool loginAccount = this._factory.AccountLogic().IsAccountValid(accounts[5].Email, accounts[5].Password);

            Assert.IsTrue(loginAccount);
        }

        public void RegisterLoginTest()
        {

        }
        //End
    }
}
