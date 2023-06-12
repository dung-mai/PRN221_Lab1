using BusinessLayer.BusinessObject;
using BusinessLayer.Services;
using CommunityToolkit.Mvvm.Input;
using FluentValidation;
using SalesWFPApp.HelperObject;
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
    public class AddOrderItemViewModel : BaseViewModel
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private ProductViewModelValidator validator;

        #region for defined properties of ProductViewModel
        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set
            {
                _productId = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }
        private int _categoryId;
        public int CategoryId
        {
            get { return _categoryId; }
            set
            {
                _categoryId = value;
                ValidateProperty(nameof(CategoryId), value);
                OnPropertyChanged(nameof(CategoryId));
            }
        }
        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                ValidateProperty(nameof(ProductName), value);
                OnPropertyChanged(nameof(ProductName));
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

        public RelayCommand? SearchProductCommand { get; set; }
        public RelayCommand? ResetCommand { get; set; }
        public RelayCommand? NextCommand { get; set; }
        public RelayCommand? BackCommand { get; set; }
        public RelayCommand<ProductObject>? AddItemCommand { get; set; }
        public RelayCommand<OrderDetailObject>? RemoveItemCommand { get; set; }

        private ProductObject? _curProduct;
        public ProductObject? CurProduct
        {
            get { return _curProduct; }
            set
            {
                _curProduct = value;
                OnPropertyChanged(nameof(CurProduct));
            }
        }
        private OrderDetailObject? _curItem;
        public OrderDetailObject? CurItem
        {
            get { return _curItem; }
            set
            {
                _curItem = value;
                OnPropertyChanged(nameof(CurItem));
            }
        }

        public ObservableCollection<ProductObject> Products { get; set; }
        public ObservableCollection<OrderDetailObject> CartItems { get; set; }
        #endregion 

        public AddOrderItemViewModel(IProductService productService, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            this._productService = productService;
            this._orderDetailService = orderDetailService;
            this._orderService = orderService;
            CartItems = new ObservableCollection<OrderDetailObject>();
            Products = new ObservableCollection<ProductObject>();
            DefineRelayCommand();
        }

        private void DefineRelayCommand()
        {
            SearchProductCommand = new RelayCommand(SearchProduct);
            AddItemCommand = new RelayCommand<ProductObject>(AddNewItem, i => true);
            RemoveItemCommand = new RelayCommand<OrderDetailObject>(RemoveItemFromCart, i => true);
            BackCommand = new RelayCommand(BackToOrderManagement);
            NextCommand = new RelayCommand(ProgressOrder);
            ResetCommand = new RelayCommand(ResetFilter);
        }

        private void RemoveItemFromCart(OrderDetailObject? item)
        {
            if (item != null)
            {
                CartItems.Remove(item);
                NotificationObject.DisplayMessage("You've just remove 1 item");
            }
            else
            {
                NotificationObject.DisplayMessage("Please select an item!");
            }
        }

        private void AddNewItem(ProductObject? product)
        {
            if (product != null)
            {
                OrderDetailObject? existedItem = CartItems.FirstOrDefault(c => c.ProductId == product.ProductId);
                if (existedItem != null)
                {
                    existedItem.Quantity++;
                    existedItem.Total = existedItem.Quantity * (double)existedItem.UnitPrice * (1 - existedItem.Discount);
                    CartItems = new ObservableCollection<OrderDetailObject>(CartItems);
                    OnPropertyChanged(nameof(CartItems));
                }
                else
                {
                    CartItems.Add(new OrderDetailObject
                    {
                        Product = product,
                        ProductId = product.ProductId,
                        Discount = 0,
                        Quantity = 1,
                        UnitPrice = product.UnitPrice,
                        Total = (double)product.UnitPrice
                    });
                }
                NotificationObject.DisplayMessage("Add item successfully!");
            }
            else
            {
                NotificationObject.DisplayMessage("Please select a product!");
            }
        }

        private void SearchProduct()
        {
            Products = new ObservableCollection<ProductObject>(_productService.SearchByFilter(_productId, _categoryId, _productName));
            if (Products.Count == 0)
            {
                EmptyMess = "Không có kết quả nào phù hợp";
            }
            else
            {
                EmptyMess = null;

            }
            OnPropertyChanged(nameof(Products));
        }

        private void ResetFilter()
        {
            ProductId = 0;
            CategoryId = 0;
            ProductName = "";
        }

        private void ProgressOrder()
        {
            var progressOrderViewModel = new ProgressOrderViewModel(_orderService, CartItems);
            var progressOrderWindow = new ProgressOrderWindow();
            EventAggregator.Instance.Publish("CloseAddCartWindow", true);
            progressOrderWindow.DataContext = progressOrderViewModel;
            progressOrderWindow.Show();
        }

        private void BackToOrderManagement()
        {
            var orderWindow = new OrderManagementWindow();
            orderWindow.Show();
            EventAggregator.Instance.Publish("CloseAddCartWindow", true);
        }

        private async void ValidateProperty(string propertyName, object value)
        {
            //var result = await validator.ValidateAsync();
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
