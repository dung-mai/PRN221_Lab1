using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private FStoreContext _context;

        public OrderRepository()
        {
            _context = FStoreContext.GetInstance();
        }

        public void AddOrder(Order order)
        {
            if (order != null)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
        }

        public void DeleteOrder(Order order)
        {
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public Order? GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public void UpdateOrder(Order order)
        {
            if (order != null)
            {
                _context.Orders.Update(order);
                _context.SaveChanges();
            }
        }
    }
}
