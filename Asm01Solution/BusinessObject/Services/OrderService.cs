using AutoMapper;
using BusinessLayer.BusinessObject;
using DataAccess;
using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IMemberRepository _memberRepository;
        private IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMemberRepository memberRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public void AddOrder(OrderObject orderBO)
        {
            var order = _mapper.Map<Order>(orderBO);
            if(_memberRepository.GetMemberById(orderBO.OrderId) == null)
            {
            }
            _orderRepository.AddOrder(order);
        }

        public void DeleteOrder(OrderObject orderBO)
        {
            var order = _mapper.Map<Order>(orderBO);
            _orderRepository.DeleteOrder(order);
        }

        public OrderObject? GetAllOrderInfoById(int id)
        {
            Order? o = _orderRepository.GetAllOrderInfoById(id);
            //ICollection<OrderDetailObject> orderDetailBOs = (ICollection<OrderDetailObject>)o.OrderDetails.Select(od => _mapper.Map<OrderDetailObject>(od)).ToList();
            OrderObject? orderObject = _mapper.Map<OrderObject>(o);
            //orderObject.OrderDetails = orderDetailBOs;
            return orderObject;
        }

        public List<OrderObject> GetAllOrders()
        {
            return _orderRepository.GetAllOrders().Select(p => _mapper.Map<OrderObject>(p)).ToList();
        }

        public OrderObject? GetOrderById(int id)
        {
            return _mapper.Map<OrderObject>(_orderRepository.GetOrderById(id));
        }

        public List<OrderObject> SearchByFilter(string? email, DateTime? startDate, DateTime? endDate)
        {
            return _orderRepository.SearchByFilter(email, startDate, endDate).Select(p => _mapper.Map<OrderObject>(p)).ToList();
        }

        public void UpdateOrder(OrderObject orderBO)
        {
            var order = _mapper.Map<Order>(orderBO);
            _orderRepository.UpdateOrder(order);
        }
    }
}
