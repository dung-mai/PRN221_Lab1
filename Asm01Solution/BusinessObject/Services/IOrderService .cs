using BusinessLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IOrderService
    {
        public void AddOrder(OrderObject orderBO);
        public void UpdateOrder(OrderObject orderBO);
        public void DeleteOrder(OrderObject orderBO);
        public OrderObject? GetOrderById(int id);
        public List<OrderObject> GetAllOrders();
    }
}
