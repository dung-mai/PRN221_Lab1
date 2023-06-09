using BusinessLayer.BusinessObject;
using BusinessLayer.Services;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Models;
using SalesWFPApp.HelperObject;
using SalesWFPApp.Validator;
using SalesWFPApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace SalesWFPApp.ViewModel
{
    public class ViewOrderDetailViewModel : BaseViewModel
    {
        private readonly IOrderService _orderService;
        private OrderViewModelValidator validator;
        private bool isModify = false;

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
        private DateTime _orderDate;
        public DateTime OrderDate
        {
            get { return _orderDate; }
            set
            {
                _orderDate = value;
                isModify = true;
                ValidateProperty(nameof(OrderDate), value);
                ValidateProperty(nameof(ShippedDate), value);
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
                isModify = true;
                ValidateProperty(nameof(RequiredDate), value);
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
                ValidateProperty(nameof(ShippedDate), value);
                ValidateProperty(nameof(OrderDate), value);
                OnPropertyChanged(nameof(ShippedDate));
                isModify = true;
            }
        }
        private decimal? _freight;
        public decimal? Freight
        {
            get { return _freight; }
            set
            {
                _freight = value;
                isModify = true;
                ValidateProperty(nameof(Freight), value);
                OnPropertyChanged(nameof(Freight));
            }
        }
        public String Address { get; set; }



        private OrderObject? _curOrder;
        public OrderObject? CurOrder
        {
            get { return _curOrder; }
            set
            {
                _curOrder = value;
                if (value != null)
                {
                    _orderId = value.OrderId;
                    _orderDate = value.OrderDate;
                    _shippedDate = value.ShippedDate;
                    _freight = value.Freight;
                    _requiredDate = value.RequiredDate;
                }
            }
        }
        public RelayCommand<OrderObject>? DeleteOrderCommand { get; set; }
        public RelayCommand<OrderObject>? AddOrderCommand { get; set; }
        public RelayCommand<OrderObject>? UpdateOrderCommand { get; set; }
        public RelayCommand<int>? ViewCommand { get; set; }
        public RelayCommand? UpdateCommand { get; set; }
        public RelayCommand? BackCommand { get; set; }


        public ViewOrderDetailViewModel(IOrderService orderService, int orderId)
        {
            _orderService = orderService;
            validator = new OrderViewModelValidator();
            DefineRelayCommand();

            //Set data
            CurOrder = _orderService.GetAllOrderInfoById(orderId);
        }


        private void DefineRelayCommand()
        {
            ViewCommand = new RelayCommand<int>(i =>
            {
                EventAggregator.Instance.Publish("ViewOrderDetail", i);
            });

            UpdateOrderCommand = new RelayCommand<OrderObject>(UpdateOrder, p => isModify);

            BackCommand = new RelayCommand(BackToList);
        }

        private void BackToList()
        {
            var orderWindow = new OrderManagementWindow();
            orderWindow.Show();
            EventAggregator.Instance.Publish("CloseOrderDetailWindow", true);
        }
        private async void UpdateOrder(OrderObject? o)
        {
            var result = await validator.ValidateAsync(this);
            if (result.IsValid)
            {
                if (CurOrder == null)
                {
                    CurOrder = new OrderObject();
                }
                CurOrder.OrderDate = OrderDate;
                CurOrder.ShippedDate = ShippedDate;
                CurOrder.RequiredDate = RequiredDate;
                CurOrder.Freight = Freight;

                //update in db
                _orderService.UpdateOrder(CurOrder);
            }
            else
            {
                NotificationObject.DisplayMessage("Please enter again!");
            }
        }

        private async void ValidateProperty(string propertyName, object value)
        {
            var result = await validator.ValidateAsync(this);
            var errors = result.Errors.Where(e => e.PropertyName == propertyName).ToList();
            if (errors.Any())
            {
                var errorMsg = string.Join(Environment.NewLine, errors.Select(e => e.ErrorMessage));
                SetError(propertyName, errorMsg);
            }
            else
            {
                ClearError(propertyName);
            }
        }
    }
}
