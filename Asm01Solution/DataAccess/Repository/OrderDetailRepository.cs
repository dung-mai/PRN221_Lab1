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
        private readonly PRN221_SalesApplicationContext _context;

        public OrderDetailRepository(PRN221_SalesApplicationContext context)
        {
            _context = context;
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            if (orderDetail != null)
            {
                _context.OrderDetails.Add(new OrderDetail
                {
                    OrderId = orderDetail.OrderId,
                    Discount = orderDetail.Discount,
                    ProductId = orderDetail.ProductId,
                    Quantity = orderDetail.Quantity,
                    UnitPrice = orderDetail.UnitPrice,
                });
                _context.SaveChanges();
            }
        }

        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            //try
            //{
            //    if (orderDetail != null)
            //    {
            //        OrderDetail? p = GetOrderDetailById(orderDetail.OrderDetailId);
            //        _context.OrderDetails.Remove(p);
            //        _context.SaveChanges();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
        }

        public List<OrderDetail> GetOrderDetailByOrderId(int id)
        {
            return _context.OrderDetails.Where(od => od.OrderId == id).ToList();
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            //try
            //{
            //    if (orderDetail != null)
            //    {
            //        OrderDetail? od = GetOrderDetailById(orderDetail.OrderDetailId);
            //        if (od != null)
            //        {
            //            od.OrderId = orderDetail.OrderId;
            //            od.Discount = orderDetail.Discount;
            //            od.ProductId = orderDetail.ProductId;
            //            od.Quantity = orderDetail.Quantity;
            //            od.UnitPrice = orderDetail.UnitPrice;
            //            _context.SaveChanges();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
        }
    }
}
