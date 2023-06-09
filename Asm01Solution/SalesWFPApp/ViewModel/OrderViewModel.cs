using BusinessLayer.BusinessObject;
using BusinessLayer.Services;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Models;
using SalesWFPApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWFPApp.ViewModel
{
    public class OrderViewModel : BaseViewModel
    {
        private readonly IOrderService _orderService;

        //private int _orderId;
        //public int OrderId
        //{
        //    get { return _orderId; }
        //    set
        //    {
        //        _orderId = value;
        //        OnPropertyChanged(nameof(OrderId));
        //    }
        //}
        //private int _memberId;
        //public int MemberId
        //{
        //    get { return _memberId; }
        //    set
        //    {
        //        _memberId = value;
        //        OnPropertyChanged(nameof(MemberId));
        //    }
        //}
        //private DateTime _orderDate;
        //public DateTime OrderDate
        //{
        //    get { return _orderDate; }
        //    set
        //    {
        //        _orderDate = value;
        //        OnPropertyChanged(nameof(OrderDate));
        //    }
        //}
        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }
        private string? _email;
        public string? Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private OrderObject _curOrder;
        public OrderObject CurOrder
        {
            get { return _curOrder; }
            set
            {
                _curOrder = value;
                OnPropertyChanged(nameof(CurOrder));
            }
        }

        public ObservableCollection<OrderObject> Orders { get; set; }

        public RelayCommand<OrderObject> AddOrderCommand { get; set; }
        public RelayCommand ViewCommand { get; set; }
        public RelayCommand SearchOrderCommand { get; set; }

        public OrderViewModel(IOrderService memberService)
        {
            _orderService = memberService;
            LoadAllOrders();
            DefineRelayCommand();
        }


        private void DefineRelayCommand()
        {
            AddOrderCommand = new RelayCommand<OrderObject>(
                p =>
                {
                    /////logic
                    //OrderObject member = new OrderObject
                    //{
                    //    OrderId = _orderId,
                    //    MemberId = _memberId,
                    //    OrderDate = _orderDate,
                    //    ShippedDate = _shippedDate,
                    //    Freight = _freight,
                    //    RequiredDate = _requiredDate
                    //};
                    //_orderService.AddOrder(member);
                    //LoadAllOrders();
                    //OnPropertyChanged(nameof(Orders));
                },
                p => true);

            //UpdateOrderCommand = new RelayCommand<OrderObject>(
            //    p =>
            //    {
            //        if(CurOrder == null)
            //        {
            //            CurOrder = new OrderObject();
            //        }
            //        CurOrder.MemberId = MemberId;
            //        CurOrder.OrderDate = OrderDate;
            //        CurOrder.ShippedDate = ShippedDate;
            //        CurOrder.RequiredDate = RequiredDate;
            //        CurOrder.Freight = Freight;

            //        //update in db
            //        _orderService.UpdateOrder(CurOrder);

            //        //update for Orders List in L
            //        LoadAllOrders();
            //        OnPropertyChanged(nameof(Orders));
            //    },
            //    p => true);
            //DeleteOrderCommand = new RelayCommand<OrderObject>(
            //    p =>
            //    {
            //        _orderService.DeleteOrder(CurOrder);
            //        Orders.Remove(CurOrder);
            //    },
            //    p => true);

            ViewCommand = new RelayCommand(() =>
            {
                //EventAggregator.Instance.Publish("ViewOrderDetail", CurOrder.OrderId);
                var orderdetailViewModel = new ViewOrderDetailViewModel(_orderService, CurOrder.OrderId);
                var orderDetailWindow = new OrderDetailWindow();
                EventAggregator.Instance.Publish("CloseOrderMgmtWindow", true);
                orderDetailWindow.DataContext = orderdetailViewModel;
                orderDetailWindow.Show();
            });

            SearchOrderCommand = new RelayCommand(() =>
            {
                Orders = new ObservableCollection<OrderObject>(_orderService.SearchByFilter(_email, _startDate, _endDate));
                OnPropertyChanged(nameof(Orders));
            });

        }

        private void LoadAllOrders()
        {
            Orders = new ObservableCollection<OrderObject>(_orderService.GetAllOrders());
        }
    }
}
