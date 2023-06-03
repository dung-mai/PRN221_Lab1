using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        public void AddOrder(Order order);
        public void UpdateOrder(Order order);
        public void DeleteOrder(Order order);
        public Order? GetOrderById(int id);
        public List<Order> GetAllOrders();
    }
}
