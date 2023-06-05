using BusinessLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IOrderDetailService
    {
        public void AddOrderDetail(OrderDetailObject orderDetailBO);
        public void UpdateOrderDetail(OrderDetailObject orderDetailBO);
        public void DeleteOrderDetail(OrderDetailObject orderDetailBO);
        public OrderDetailObject? GetOrderDetailById(int id);
        public List<OrderDetailObject> GetAllOrderDetails();
    }
}
