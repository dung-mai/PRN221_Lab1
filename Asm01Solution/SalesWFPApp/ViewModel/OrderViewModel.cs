using BusinessLayer.BusinessObject;
using BusinessLayer.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWFPApp.ViewModel
{
    public class OrderViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly IOrderService _orderService;

        private int _orderId;
        public int OrderId
        {
            get { return _orderId; }
            set
            {
                _orderId = value;
                OnPropertyChanged(nameof(OrderId));
            }
        }
        private int _memberId;
        public int MemberId
        {
            get { return _memberId; }
            set
            {
                _memberId = value;
                OnPropertyChanged(nameof(MemberId));
            }
        }
        private DateTime _orderDate;
        public DateTime OrderDate
        {
            get { return _orderDate; }
            set
            {
                _orderDate = value;
                OnPropertyChanged(nameof(OrderDate));
            }
        }
        private DateTime? _requiredDate;
        public DateTime? RequiredDate
        {
            get { return _requiredDate; }
            set
            {
                _requiredDate = value;
                OnPropertyChanged(nameof(RequiredDate));
            }
        }
        private DateTime? _shippedDate;
        public DateTime? ShippedDate
        {
            get { return _shippedDate; }
            set
            {
                _shippedDate = value;
                OnPropertyChanged(nameof(ShippedDate));
            }
        }
        private decimal? _freight;
        public decimal? Freight
        {
            get { return _freight; }
            set
            {
                _freight = value;
                OnPropertyChanged(nameof(Freight));
            }
        }
        private OrderObject _curOrder;
        public OrderObject CurOrder
        {
            get { return _curOrder; }
            set
            {
                _curOrder = value;
                if (value != null)
                {
                    OrderId = value.OrderId;
                    
                    MemberId = value.MemberId;
                    OrderDate = value.OrderDate;
                    ShippedDate = value.ShippedDate;
                    Freight = value.Freight;
                    RequiredDate = value.RequiredDate;
                    ShippedDate = value.ShippedDate;
                }
                OnPropertyChanged(nameof(CurOrder));
            }
        }
        private bool isCommandExecuted;
        public bool IsCommandExecuted
        {
            get => isCommandExecuted;
            set
            {
                isCommandExecuted = value;
                OnPropertyChanged(nameof(IsCommandExecuted));
            }
        }

        public ObservableCollection<OrderObject> Orders { get; set; }

        public RelayCommand<OrderObject> DeleteOrderCommand { get; set; }
        public RelayCommand<OrderObject> AddOrderCommand { get; set; }
        public RelayCommand<OrderObject> UpdateOrderCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }

        public OrderViewModel(IOrderService memberService)
        {
            _orderService = memberService;
            LoadAllOrders();
            DefineRelayCommand();
            IsCommandExecuted = false;
        }


        private void DefineRelayCommand()
        {
            AddOrderCommand = new RelayCommand<OrderObject>(
                p =>
                {
                    ///logic
                    OrderObject member = new OrderObject
                    {
                        OrderId = _orderId,
                        MemberId = _memberId,
                        OrderDate = _orderDate,
                        ShippedDate = _shippedDate,
                        Freight = _freight,
                        RequiredDate = _requiredDate
                    };
                    _orderService.AddOrder(member);
                    LoadAllOrders();
                    OnPropertyChanged(nameof(Orders));
                    IsCommandExecuted = true;
                },
                p => true);
            UpdateOrderCommand = new RelayCommand<OrderObject>(
                p =>
                {
                    if(CurOrder == null)
                    {
                        CurOrder = new OrderObject();
                    }
                    CurOrder.MemberId = MemberId;
                    CurOrder.OrderDate = OrderDate;
                    CurOrder.ShippedDate = ShippedDate;
                    CurOrder.RequiredDate = RequiredDate;
                    CurOrder.Freight = Freight;

                    //update in db
                    _orderService.UpdateOrder(CurOrder);

                    //update for Orders List in L
                    LoadAllOrders();
                    OnPropertyChanged(nameof(Orders));
                    IsCommandExecuted = true;
                },
                p => true);
            DeleteOrderCommand = new RelayCommand<OrderObject>(
                p =>
                {
                    _orderService.DeleteOrder(CurOrder);
                    Orders.Remove(CurOrder);
                },
                p => true);

            ResetCommand = new RelayCommand(() =>
            {
                OrderId = 0;
                MemberId = 0;
                OrderDate = default(DateTime);
                ShippedDate = default(DateTime);
                Freight = 0;
                RequiredDate = default(DateTime);

                IsCommandExecuted = false;
            });
        }

        private void LoadAllOrders()
        {
            Orders = new ObservableCollection<OrderObject>(_orderService.GetAllOrders());
        }


        public string this[string columnName]
        {
            get
            {
                string error = null;
                switch (columnName)
                {
                    case nameof(MemberId):
                        if (string.IsNullOrEmpty(MemberId.ToString()))
                        {
                            error = "MemberId is required.";
                        }
                        break;
                    //case nameof(ShippedDate):
                    //    if (string.IsNullOrEmpty(MemberId))
                    //    {
                    //        error = "MemberId is required.";
                    //    }
                    //    break;
                    //case nameof(RequiredDate):
                    //    if (string.IsNullOrEmpty(RequiredDate))
                    //    {
                    //        error = "RequiredDate is required.";
                    //    }
                    //    break;
                    case nameof(Freight):
                        if (Freight < 0)
                        {
                            error = "Freight must equal or greater than 0.";
                        }
                        break;
                    //case nameof(OrderDate):
                    //    if (string.IsNullOrEmpty(OrderDate))
                    //    {
                    //        error = "OrderDate is required.";
                    //    }
                    //    break;
                }
                return error;
            }
        }

        public string Error => null;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
