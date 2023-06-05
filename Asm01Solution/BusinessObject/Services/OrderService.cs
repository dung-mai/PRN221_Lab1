using AutoMapper;
using BusinessLayer.BusinessObject;
using DataAccess;
using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
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

        public OrderService(IOrderRepository orderRepository, IMemberRepository _memberRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public void AddOrder(OrderObject orderBO)
        {
            var order = _mapper.Map<Order>(orderBO);
            _orderRepository.AddOrder(order);
        }

        public void DeleteOrder(OrderObject orderBO)
        {
            var order = _mapper.Map<Order>(orderBO);
            _orderRepository.DeleteOrder(order);
        }

        public List<OrderObject> GetAllOrders()
        {
            return _orderRepository.GetAllOrders().Select(p => _mapper.Map<OrderObject>(p)).ToList();
        }

        public OrderObject? GetOrderById(int id)
        {
            return _mapper.Map<OrderObject>(_orderRepository.GetOrderById(id));
        }

        public void UpdateOrder(OrderObject orderBO)
        {
            var order = _mapper.Map<Order>(orderBO);
            _orderRepository.UpdateOrder(order);
        }
    }
}
