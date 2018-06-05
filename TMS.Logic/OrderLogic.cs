﻿using System.Collections.Generic;
using System.Net.Http.Headers;
using TMS.Logic.Interface;
using TMS.Model;
using TMS.Repositroy.Interface;

namespace TMS.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private IOrderRepository Repository { get; }

        public OrderLogic(IOrderRepository repository)
        {
            this.Repository = repository;
        }
        public List<Order> GetAllOrdersById(int id)
        {
            return this.Repository.GetAllOrdersById(id);
        }

        public bool CreateOrder(Order model, int id)
        {
            return this.Repository.Insert(model, id);
        }
    }
}