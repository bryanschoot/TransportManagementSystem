using System;
using System.Collections.Generic;
using TMS.Dal.Interface;
using TMS.Model;
using TMS.Repositroy.Interface;

namespace TMS.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderContext _context;

        public OrderRepository(IOrderContext context)
        {
            this._context = context;
        }

        #region NotImplemented
        public IEnumerable<Order> All()
        {
            return this._context.All();
        }

        public Order GetById(int id)
        {
            return this._context.GetById(id);
        }

        public bool Exists(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Order entity, int id)
        {
            return this._context.Insert(entity, id);
        }

        public bool Update(Order entity)
        {
            return this._context.Update(entity);
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
            return this._context.GetAllOrdersById(id);
        }

        public bool DeleteById(int id)
        {
            return this._context.DeleteById(id);
        }

        public int CountAllOrders()
        {
            return this._context.CountAllOrders();
        }

        #endregion
    }
}