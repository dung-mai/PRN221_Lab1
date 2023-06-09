using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
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

        public Order? GetAllOrderInfoById(int id)
        {
            return _context.Orders
                            .Include(o => o.Member) // include the Member object
                            .Include(o => o.OrderDetails).
                            FirstOrDefault(o => o.OrderId == id);
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders
                            .Include(o => o.Member)
                            .Include(o => o.OrderDetails).ToList();
        }

        public Order? GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public List<Order> SearchByFilter(string? email, DateTime? startDate, DateTime? endDate)
        {
            email = (email != null) ? email : "";
            startDate = startDate != null ? startDate : DateTime.MinValue;
            endDate = endDate != null ? endDate : DateTime.MaxValue;

            return _context.Orders
                   .Include(o => o.Member)
                   .Include(o => o.OrderDetails)
                   .Where(o => o.Member.Email.StartsWith(email)
                                && DateTime.Compare(o.OrderDate, startDate.Value) >= 0
                                && DateTime.Compare(o.OrderDate, endDate.Value) <= 0)
                   .ToList();
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
