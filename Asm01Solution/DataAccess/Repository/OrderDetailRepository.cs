using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private FStoreContext _context;

        public OrderDetailRepository()
        {
            _context = FStoreContext.GetInstance();
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            if (orderDetail != null)
            {
                _context.OrderDetails.Add(orderDetail);
                _context.SaveChanges();
            }
        }

        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            if (orderDetail != null)
            {
                _context.OrderDetails.Add(orderDetail);
                _context.SaveChanges();
            }
        }

        public List<OrderDetail> GetOrderDetailByOrderId(int id)
        {
            return _context.OrderDetails.Where(od => od.OrderId == id).ToList();
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            if (orderDetail != null)
            {
                _context.OrderDetails.Add(orderDetail);
                _context.SaveChanges();
            }
        }
    }
}
