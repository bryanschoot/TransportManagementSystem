using System;
using System.Collections.Generic;
using TMS.Dal.Interface;
using TMS.Model;
using TMS.Repositroy.Interface;

namespace TMS.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private IOrderContext Context { get; }

        public OrderRepository(IOrderContext context)
        {
            this.Context = context;
        }

        #region NotImplemented
        public IEnumerable<Order> All()
        {
            throw new System.NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public int Count(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetAllOrdersById(int id)
        {
            return this.Context.GetAllOrdersById(id);
        }

        #endregion
    }
}