using BusinessLayer.BusinessObject;
using BusinessLayer.Services;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Models;
using SalesWFPApp.HelperObject;
using SalesWFPApp.Validator;
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
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace SalesWFPApp.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        private readonly IProductService _productService;
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
        private string _weight;
        public string Weight
        {
            get {return _weight ; }
            set
            {
                _weight = value;
                ValidateProperty(nameof(Weight), value);
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
                ValidateProperty(nameof(UnitPrice), value);
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
                ValidateProperty(nameof(UnitsInStock), value);
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

        public ObservableCollection<ProductObject> Products { get; set; }

        public RelayCommand<ProductObject> DeleteProductCommand { get; set; }
        public RelayCommand<ProductObject> AddProductCommand { get; set; }
        public RelayCommand<ProductObject> UpdateProductCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        #endregion

        public ProductViewModel(IProductService productService)
        {
            _productService = productService;
            validator = new ProductViewModelValidator();
            LoadAllProducts();
            DefineRelayCommand();
        }

        private void DefineRelayCommand()
        {
            AddProductCommand = new RelayCommand<ProductObject>(AddNewProduct,p => true);
            UpdateProductCommand = new RelayCommand<ProductObject>(UpdateProduct, p => true);
            DeleteProductCommand = new RelayCommand<ProductObject>(DeleteProduct, p => true);
            ResetCommand = new RelayCommand(ResetTextbox);
        }

        private async void AddNewProduct(ProductObject? p)
        {
            var result = await validator.ValidateAsync(this);
            if (result.IsValid)
            {
                ///update in DB
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
                NotificationObject.DisplayMessage("Added successfully!");

                //update in UI
                LoadAllProducts();
                OnPropertyChanged(nameof(Products));
                ResetTextbox();
            } else
            {
                NotificationObject.DisplayMessage("Please enter again!");
            }
        }

        private async void UpdateProduct(ProductObject? p)
        {
            var result = await validator.ValidateAsync(this);
            if (result.IsValid)
            {
                CurProduct.CategoryId = CategoryId;
                CurProduct.ProductName = ProductName;
                CurProduct.UnitPrice = UnitPrice;
                CurProduct.Weight = Weight;
                CurProduct.UnitsInStock = UnitsInStock;

                //update in db
                _productService.UpdateProduct(CurProduct);
                NotificationObject.DisplayMessage("Update successfully!");

                //update in UI
                LoadAllProducts();
                OnPropertyChanged(nameof(Products));
                ResetTextbox();
            }
            else
            {
                NotificationObject.DisplayMessage("Please enter again!");
            }
        }

        private void DeleteProduct(ProductObject? p)
        {
            _productService.DeleteProduct(CurProduct);
            NotificationObject.DisplayMessage("Delete successfully!");

            //Update in UI
            Products.Remove(CurProduct);
            ResetTextbox();
        }

        private void ResetTextbox()
        {
            SkipValidation(true);
            ProductId = 0;
            CategoryId = 0;
            ProductName = "";
            UnitPrice = 0;
            UnitsInStock = 0;
            Weight = "";
            SkipValidation(false);
        }

        private void LoadAllProducts()
        {
            Products = new ObservableCollection<ProductObject>(_productService.GetAllProducts());
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
