using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Dal.Interface;
using TMS.Model;

namespace TMS.Dal.MEMORY
{
    public class OrderMemoryContext : IOrderContext
    {
        private static List<Order> orders = new List<Order>();
        private static List<Address> addresses = new List<Address>();
        private static List<Account> accounts = new List<Account>();

        public OrderMemoryContext()
        {
            initilizeAddress();
            initilizeOrders();
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
            orders.Add(new Order { Id = 1, Description = "Pallet", Length = 120f, Width = 120f, Height = 120f, Weight = 12, OrderDate = new DateTime(2018, 06, 01), DeliverDate = new DateTime(2018, 05, 05), Address = addresses[0] });
            orders.Add(new Order { Id = 2, Description = "Box", Length = 50f, Width = 50f, Height = 50f, Weight = 2, OrderDate = new DateTime(2018, 05, 10), DeliverDate = new DateTime(2018, 05, 22), Address = addresses[1] });
            orders.Add(new Order { Id = 3, Description = "Plane", Length = 5000f, Width = 5000f, Height = 505f, Weight = 200, OrderDate = new DateTime(2018, 05, 10), DeliverDate = new DateTime(2018, 05, 22), Address = addresses[1] });
        }

        public void initilizeAddress()
        {
            addresses.Add(new Address { Id = 1, Country = "Netherlands", City = "Arnhem", StreetName = "Marxsingel", StreetNumber = "10", ZipCode = "6836PZ" });
            addresses.Add(new Address { Id = 2, Country = "Netherlands", City = "Nijmegen", StreetName = "Koningstraat", StreetNumber = "31A", ZipCode = "6855NI" });
        }

        public IEnumerable<Order> All()
        {
            throw new System.NotImplementedException();
        }

        public Order GetById(int id)
        {
            Order order = orders.FirstOrDefault(o => o.Id == id);
            return order;
        }

        public bool Exists(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Order entity, int id)
        {
            int oldCount = orders.Count();
            orders.Add(entity);
            return oldCount < orders.Count();
        }

        public bool Update(Order entity)
        {
            orders[2] = entity;
            return orders[2] == entity;
        }

        public bool Delete(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public int Count(Order entity)
        {
            throw new System.NotImplementedException();
        }

        List<Order> IOrderContext.GetAllOrdersById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            int odlCount = orders.Count();
            orders = orders.Where(a => a.Id != id).ToList();

            return odlCount > addresses.Count();
        }

        public int CountAllOrders()
        {
            throw new NotImplementedException();
        }
    }
}