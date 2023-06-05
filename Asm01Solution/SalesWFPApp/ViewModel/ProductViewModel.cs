using BusinessLayer.BusinessObject;
using BusinessLayer.Services;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace SalesWFPApp.ViewModel
{
    public class ProductViewModel :INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly IProductService _productService;

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
                OnPropertyChanged(nameof(ProductName));
            }
        }
        private string _weight;
        public string Weight
        {
            get {return _weight ; }
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }
        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                _unitPrice = value;
                OnPropertyChanged(nameof(UnitPrice));
            }
        }
        private int _unitsInStock;
        public int UnitsInStock
        {
            get { return _unitsInStock; }
            set
            {
                _unitsInStock = value;
                OnPropertyChanged(nameof(UnitsInStock));
            }
        }
        private ProductObject _curProduct;
        public ProductObject CurProduct
        {
            get { return _curProduct; }
            set
            {
                _curProduct = value;
                if (value != null)
                {
                    ProductId = value.ProductId;
                    CategoryId = value.CategoryId;
                    ProductName = value.ProductName;
                    UnitPrice = value.UnitPrice;
                    UnitsInStock = value.UnitsInStock;
                    Weight = value.Weight;
                    UnitPrice = value.UnitPrice;
                }
                OnPropertyChanged(nameof(CurProduct));
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

        public ObservableCollection<ProductObject> Products { get; set; }

        public RelayCommand<ProductObject> DeleteProductCommand { get; set; }
        public RelayCommand<ProductObject> AddProductCommand { get; set; }
        public RelayCommand<ProductObject> UpdateProductCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }

        public ProductViewModel(IProductService productService)
        {
            _productService = productService;
            LoadAllProducts();
            DefineRelayCommand();
            IsCommandExecuted = false;
        }


        private void DefineRelayCommand()
        {
            AddProductCommand = new RelayCommand<ProductObject>(
                p =>
                {
                    ///logic
                    ProductObject product = new ProductObject
                    {
                        ProductId = _productId,
                        CategoryId = _categoryId,
                        ProductName = _productName,
                        UnitPrice = _unitPrice,
                        UnitsInStock = _unitsInStock,
                        Weight = _weight
                    };
                    _productService.AddProduct(product);
                    //Products.Add(product);
                    LoadAllProducts();
                    OnPropertyChanged(nameof(Products));
                    IsCommandExecuted = true;
                },
                p => true);
            UpdateProductCommand = new RelayCommand<ProductObject>(
                p =>
                {
                    CurProduct.CategoryId = CategoryId;
                    CurProduct.ProductName = ProductName;
                    CurProduct.UnitPrice = UnitPrice;
                    CurProduct.Weight = Weight;
                    CurProduct.UnitsInStock = UnitsInStock;

                    //update in db
                    _productService.UpdateProduct(CurProduct);

                    //update for Products List in L
                    LoadAllProducts();
                    OnPropertyChanged(nameof(Products));
                    IsCommandExecuted = true;
                },
                p => true);
            DeleteProductCommand = new RelayCommand<ProductObject>(
                p =>
                {
                    _productService.DeleteProduct(CurProduct);
                    Products.Remove(CurProduct);
                },
                p => true);

            ResetCommand = new RelayCommand(() =>
            {
                ProductId = 0;
                CategoryId = 0;
                ProductName = "";
                UnitPrice = 0;
                UnitsInStock = 0;
                Weight = "";

                IsCommandExecuted = false;
            });
        }

        private void LoadAllProducts()
        {
            Products = new ObservableCollection<ProductObject>(_productService.GetAllProducts());
        }


        public string this[string columnName]
        {
            get
            {
                string error = null;
                switch (columnName)
                {
                    case nameof(CategoryId):
                        if (string.IsNullOrEmpty(CategoryId.ToString()))
                        {
                            error = "CategoryId is required.";
                        }
                        break;
                    case nameof(UnitPrice):
                        if (UnitPrice <= 0)
                        {
                            error = "Price must be greater than 0.";
                        }
                        break;
                    case nameof(Weight):
                        if (string.IsNullOrEmpty(Weight))
                        {
                            error = "Weight is required.";
                        }
                        break;
                    case nameof(UnitsInStock):
                        if (string.IsNullOrEmpty(UnitsInStock.ToString()))
                        {
                            error = "UnitsInStock is required.";
                        }
                        break;
                    case nameof(ProductName):
                        if (string.IsNullOrEmpty(ProductName))
                        {
                            error = "ProductName is required.";
                        }
                        break;
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
