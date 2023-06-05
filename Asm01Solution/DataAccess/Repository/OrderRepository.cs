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
        private readonly PRN221_SalesApplicationContext _context;

        public OrderRepository(PRN221_SalesApplicationContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            if (order != null)
            {
                _context.Orders.Add(new Order
                {
                    Freight = order.Freight,
                    MemberId = order.MemberId,
                    RequiredDate = order.RequiredDate,
                    ShippedDate = order.ShippedDate,
                    OrderDate = order.OrderDate
                });
                _context.SaveChanges();
            }
        }

        public void DeleteOrder(Order order)
        {
            try
            {
                if (order != null)
                {
                    Order? o = GetOrderById(order.OrderId);
                    _context.Orders.Remove(o);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
            try
            {
                if (order != null)
                {
                    Order? o = GetOrderById(order.OrderId);
                    if (o != null)
                    {
                        o.Freight = order.Freight;
                        o.MemberId = order.MemberId;
                        o.RequiredDate = order.RequiredDate;
                        o.ShippedDate = order.ShippedDate;
                        o.OrderDate = order.OrderDate;
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
