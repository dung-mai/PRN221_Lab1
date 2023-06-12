using BusinessLayer.BusinessObject;
using BusinessLayer.Services;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Models;
using SalesWFPApp.HelperObject;
using SalesWFPApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

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
        private string? _emptyMess;
        public string? EmptyMess
        {
            get { return _emptyMess; }
            set
            {
                _emptyMess = value;
                OnPropertyChanged(nameof(EmptyMess));
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

        public RelayCommand AddOrderCommand { get; set; }
        public RelayCommand ViewCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand SearchOrderCommand { get; set; }

        public OrderViewModel(IOrderService memberService)
        {
            _orderService = memberService;
            LoadAllOrders();
            DefineRelayCommand();
        }


        private void DefineRelayCommand()
        {
            AddOrderCommand = new RelayCommand(GoToAddOrder);
            //DeleteOrderCommand = new RelayCommand<OrderObject>(
            //    p =>
            //    {
            //        _orderService.DeleteOrder(CurOrder);
            //        Orders.Remove(CurOrder);
            //    },
            //    p => true);

            ViewCommand = new RelayCommand(ViewOrderDetail);
            ResetCommand = new RelayCommand(ResetOrderFilter);

            SearchOrderCommand = new RelayCommand(SearchOrder);

            

        }

        private void GoToAddOrder()
        {
            var addOrderItemWindow = new AddOrderItemWindow();
            EventAggregator.Instance.Publish("CloseOrderMgmtWindow", true);
            addOrderItemWindow.Show();
        }

        private void ResetOrderFilter()
        {
            Email = "";
            StartDate = null; 
            EndDate = null;
            SearchOrder();
        }

        private void SearchOrder()
        {
            Orders = new ObservableCollection<OrderObject>(_orderService.SearchByFilter(_email, _startDate, _endDate));
            if(Orders.Count == 0)
            {
                EmptyMess = "Không có kết quả nào phù hợp";
            } else
            {
                EmptyMess = null;

            }
            OnPropertyChanged(nameof(Orders));
        }

        private void ViewOrderDetail()
        {
            if (CurOrder != null)
            {
                var orderdetailViewModel = new ViewOrderDetailViewModel(_orderService, CurOrder.OrderId);
                var orderDetailWindow = new OrderDetailWindow();
                EventAggregator.Instance.Publish("CloseOrderMgmtWindow", true);
                orderDetailWindow.DataContext = orderdetailViewModel;
                orderDetailWindow.Show();
            }
            else
            {
                NotificationObject.DisplayMessage("Please select an order!");
            }
        }

        public void LoadAllOrders()
        {
            Orders = new ObservableCollection<OrderObject>(_orderService.GetAllOrders());
        }
    }
}
