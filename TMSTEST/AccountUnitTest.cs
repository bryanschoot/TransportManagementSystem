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
            accounts.Add(new Account { Id = 4, Email = "melle@test.nl", Password = "melletest123", FirstName = "Melle", LastName = "Regels", PhoneNumber = "0685842973", Role = new Role(3, "Customer"), Address = addresses, });
        }

        public void initilizeAddress()
        {
            addresses.Add(new Address { Id = 1, Country = "Netherlands", City = "Arnhem", StreetName = "Marxsingel", StreetNumber = "10", ZipCode = "6836PZ" });
        }

        //Test function DoesEmailExist
        [TestMethod]
        public void AccountEmailExist()
        {
            bool check = this._factory.AccountLogic().DoesEmailExist(accounts[0].Email);
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void AccountEmailDoesNotExcist()
        {
            bool check = this._factory.AccountLogic().DoesEmailExist(accounts[3].Email);
            Assert.IsFalse(check);
        }
        //End

        //Test function IsAccountValid
        [TestMethod]
        public void IsAccountValidTest()
        {
            bool check = this._factory.AccountLogic().IsAccountValid(accounts[0].Email, accounts[0].Password);
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void IsAccountNotValidTest()
        {
            bool check = this._factory.AccountLogic().IsAccountValid(accounts[3].Email, accounts[3].Password);
            Assert.IsFalse(check);
        }
        //End

        //Test function GetAccountByEmail
        [TestMethod]
        public void GetAccountByEmailEqualTest()
        {
            Account requestedAccount = this._factory.AccountLogic().GetAccountByEmail(accounts[0].Email);
            Account expectedAccount = accounts[0];
            
            Assert.AreEqual(requestedAccount.Email, expectedAccount.Email);
        }

        [TestMethod]
        public void GetAccountByEmailNotEqualTest()
        {
            Account requestedAccount = this._factory.AccountLogic().GetAccountByEmail(accounts[3].Email);
            Account expectedAccount = accounts[0];

            Assert.IsNull(requestedAccount);
            Assert.AreNotEqual(requestedAccount, expectedAccount);
        }
        //End

        //TODO create a flow for example log in without creating a account and then a flow that registers logs in and creates a order;
        //TODO testmethod that test multiple units == intergration test.
    }
}