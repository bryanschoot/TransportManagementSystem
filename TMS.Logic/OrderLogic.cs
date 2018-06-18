using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using TMS.Logic.Interface;
using TMS.Model;
using TMS.Repositroy.Interface;

namespace TMS.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderRepository _repository;

        public OrderLogic(IOrderRepository repository)
        {
            this._repository = repository;
        }
        public List<Order> GetAllOrdersById(int id)
        {
            List<Order> orders = this._repository.GetAllOrdersById(id);
            if (orders.Count <= 0)
            {
                throw new NullReferenceException("There are no orders!");
            }
            return orders;
        }

        public bool CreateOrder(Order model, int id)
        {
            return this._repository.Insert(model, id);
        }

        public Order GetOrderById(int id, int accountId)
        {

            Order order = this._repository.GetById(id);

            if (order == null){return null;}
            if (order.Account.Id != accountId){return null;}

            return order;
        }

        public bool DeleteOrderById(int id)
        {
            //TODO no check is account may delete the order with this id
            return this._repository.DeleteById(id);
        }

        public bool UpdateOrder(Order order)
        {
            return this._repository.Update(order);
        }

        public int CountAllOrders()
        {
            return this._repository.CountAllOrders();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            IEnumerable<Order> orders = this._repository.All();

            if (!orders.Any())
            {
                throw new NullReferenceException("There are no orders.");
            }

            return orders;
        }
    }
}