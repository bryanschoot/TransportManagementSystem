using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS.Factory;
using TMS.Logic.Interface;
using TMS.Model;

namespace TMSTEST
{
    [TestClass]
    public class OrderIntergrationTest
    {
        private List<Order> orders = new List<Order>();
        private List<Address> addresses = new List<Address>();
        private List<Account> accounts = new List<Account>();

        private Factory _factory;
        private IOrderLogic _order;

        public OrderIntergrationTest()
        {
            this._factory = new Factory();
        }

        [TestInitialize]
        public void initialize()
        {
            initilizeOrders();
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
            accounts.Add(new Account { Id = 5, Email = "ruud@test.nl", Password = "ruudtest123", FirstName = "Ruud", LastName = "Naam", PhoneNumber = "0663242973", Role = new Role(3, "Customer"), Address = addresses, });
        }

        public void initilizeOrders()
        {
            orders.Add(new Order { Id = 1, Description = "Pallet", Length = 120f, Width = 120f, Height = 120f, Weight = 12, OrderDate = new DateTime(2018, 06, 01), DeliverDate = new DateTime(2018, 05, 05), Address = addresses[0]});
            orders.Add(new Order { Id = 2, Description = "Box", Length = 50f, Width = 50f, Height = 50f, Weight = 2, OrderDate = new DateTime(2018, 05, 10), DeliverDate = new DateTime(2018, 05, 22), Address = addresses[1]});
        }

        public void initilizeAddress()
        {
            addresses.Add(new Address { Id = 1, Country = "Netherlands", City = "Arnhem", StreetName = "Marxsingel", StreetNumber = "10", ZipCode = "6836PZ" });
            addresses.Add(new Address { Id = 2, Country = "Netherlands", City = "Nijmegen", StreetName = "Koningstraat", StreetNumber = "31A", ZipCode = "6855NI" });
        }

        [TestMethod]
        public void CreateUpdateOrder()
        {
            Order order = this._factory.OrderLogic().GetOrderById(orders[0].Id, accounts[0].Id);
            Assert.IsNull(order);
        }
    }
}
