using BusinessLayer.BusinessObject;
using BusinessLayer.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace SalesWFPApp.ViewModel
{
    public class ProductViewModel :INotifyPropertyChanged
    {
        private IProductService _productService;

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
                    //Id = value.id;
                    //Name = value.name;
                }
                OnPropertyChanged(nameof(CurProduct));
            }
        }

        public ObservableCollection<ProductObject> Products { get; set; }

        public RelayCommand<ProductObject> DeleteProductCommand { get; set; }
        public RelayCommand<ProductObject> AddProductCommand { get; set; }
        public RelayCommand<ProductObject> UpdateProductCommand { get; set; }


        public ProductViewModel(IProductService productService)
        {
            _productService = productService;
            LoadAllProducts();
            DefineRelayCommand();
        }


        private void DefineRelayCommand()
        {
            AddProductCommand = new RelayCommand<ProductObject>(
                p =>
                {
                    _productService.AddProduct(CurProduct);
                    Products.Add(CurProduct);
                },
                p => p != null);
            UpdateProductCommand = new RelayCommand<ProductObject>(
                p =>
                {
                    _productService.UpdateProduct(CurProduct);
                    Products.Add(CurProduct);
                },
                p => p != null);
            AddProductCommand = new RelayCommand<ProductObject>(
                p =>
                {
                    _productService.DeleteProduct(CurProduct);
                },
                p => p != null);
        }

        private void LoadAllProducts()
        {
            Products = new ObservableCollection<ProductObject>(_productService.GetAllProducts());
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
