using BusinessLayer.BusinessObject;
using BusinessLayer.Services;
using CommunityToolkit.Mvvm.Input;
using FluentValidation;
using SalesWFPApp.Validator;
using SalesWFPApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWFPApp.ViewModel
{
    public class ProgressOrderViewModel : BaseViewModel
    {
        private readonly IOrderService _orderService;
        private OrderViewModelValidator validator;

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
                ValidateProperty(nameof(OrderDate), value);
                OnPropertyChanged(nameof(OrderDate));
            }
        }
        private decimal? _freight;
        public decimal? Freight
        {
            get { return _freight; }
            set
            {
                _freight = value;
                ValidateProperty(nameof(Freight), value);
                OnPropertyChanged(nameof(Freight));
            }
        }
        public ObservableCollection<OrderDetailObject> CartItems { get; set; }
        public RelayCommand? FinishCommand { get; set; }
        public RelayCommand? BackCommand { get; set; }

        public ProgressOrderViewModel(IOrderService orderService, ObservableCollection<OrderDetailObject> cart)
        {
            _orderService = orderService;
            CartItems = cart;
            BackCommand = new RelayCommand(BackToChooseItem);
            FinishCommand = new RelayCommand(FinishOrdering);
        }

        private void BackToChooseItem()
        {
            var addOrderItemWindow = new AddOrderItemWindow();
            addOrderItemWindow.Show();
            EventAggregator.Instance.Publish("CloseProgressOrderWindow", true);
        }

        private void FinishOrdering()
        {
            throw new NotImplementedException();
        }

        private async void ValidateProperty(string propertyName, object value)
        {
            //var result = await validator.ValidateAsync(this);
            //var errors = result.Errors.Where(e => e.PropertyName == propertyName).ToList();
            //if (errors.Any())
            //{
            //    var errorMsg = string.Join(Environment.NewLine, errors.Select(e => e.ErrorMessage));
            //    SetError(propertyName, errorMsg);
            //}
            //else
            //{
            //    ClearError(propertyName);
            //}
        }
    }
}
