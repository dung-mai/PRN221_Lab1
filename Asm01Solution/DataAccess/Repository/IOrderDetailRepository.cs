using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail orderDetail);
        public void UpdateOrderDetail(OrderDetail orderDetail);
        public void DeleteOrderDetail(OrderDetail orderDetail);
        public List<OrderDetail> GetOrderDetailByOrderId(int id);
    }
}
