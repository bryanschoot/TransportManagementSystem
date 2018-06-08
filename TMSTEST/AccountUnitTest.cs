using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS.Logic.Interface;
using TMS.Model;

namespace TMSTEST
{
    [TestClass]
    public class AccountUnitTest
    {
        private TMS.Factory.Factory _factory;
        private IAccountLogic accountLogic;

        private List<Account> accounts = new List<Account>();
        private List<Address> addresses = new List<Address>();

        public AccountUnitTest()
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
        }

        public void initilizeAddress()
        {
            addresses.Add(new Address { Id = 1, Country = "Netherlands", City = "Arnhem", StreetName = "Marxsingel", StreetNumber = "10", ZipCode = "6836PZ" });
        }

        //Test function DoesEmailExist
        [TestMethod]
        public void AccountEmailExist()
        {
            bool _check = this._factory.AccountLogic().DoesEmailExist(accounts[0].Email);
            Assert.IsTrue(_check);
        }

        [TestMethod]
        public void AccountEmailDoesNotExcist()
        {
            bool _check = this._factory.AccountLogic().DoesEmailExist(accounts[1].Email);
            Assert.IsFalse(_check);
        }
        //End

        //Test function IsAccountValid
        [TestMethod]
        public void AccountCanLogin()
        {
            bool _check = this._factory.AccountLogic().IsAccountValid(accounts[0].Email, accounts[0].Password);
            Assert.IsTrue(_check);
        }

        [TestMethod]
        public void AccountCannotLogin()
        {
            bool _check = this._factory.AccountLogic().IsAccountValid(accounts[1].Email, accounts[1].Password);
            Assert.IsFalse(_check);
        }
        //End

        //Test function GetAccountByEmail
        [TestMethod]
        public void GetAccountByEmail()
        {
            Account requestedAccount = this._factory.AccountLogic().GetAccountByEmail(accounts[0].Email);
            Account expectedAccount = (Account) accounts[0];
            
            Assert.AreEqual(requestedAccount.Email, expectedAccount.Email);
        }
        //End
        //TODO create a flow for example log in without creating a account and then a flow that registers logs in and creates a order;
        //TODO testmethod that test multiple units == intergration test.
    }
}