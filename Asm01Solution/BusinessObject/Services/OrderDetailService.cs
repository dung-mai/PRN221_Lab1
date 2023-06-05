using AutoMapper;
using BusinessLayer.BusinessObject;
using DataAccess;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public void AddOrderDetail(OrderDetailObject orderDetailBO)
        {
            //map
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailBO);
            _orderDetailRepository.AddOrderDetail(orderDetail);
        }

        public void DeleteOrderDetail(OrderDetailObject orderDetailBO)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailBO);
            _orderDetailRepository.DeleteOrderDetail(orderDetail);
        }

        public List<OrderDetailObject> GetOrderDetailByOrderId(int id)
        {
            return _orderDetailRepository.GetOrderDetailByOrderId(id).Select(od => _mapper.Map<OrderDetailObject>(od)).ToList();
        }

        public OrderDetailObject? GetOrderDetailById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderDetail(OrderDetailObject orderDetailBO)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailBO);
            _orderDetailRepository.UpdateOrderDetail(orderDetail);
        }

        public List<OrderDetailObject> GetAllOrderDetails()
        {
            throw new NotImplementedException();
        }
    }
}
