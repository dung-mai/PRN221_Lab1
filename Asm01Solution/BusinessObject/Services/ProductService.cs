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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void AddProduct(ProductObject productBO)
        {
            var product = _mapper.Map<Product>(productBO);
            _productRepository.AddProduct(product);
        }

        public void DeleteProduct(ProductObject productBO)
        {
            var product = _mapper.Map<Product>(productBO);
            _productRepository.DeleteProduct(product);
        }

        public List<ProductObject> GetAllProducts()
        {
            return _productRepository.GetAllProducts().Select(p => _mapper.Map<ProductObject>(p)).ToList();
        }

        public ProductObject? GetProductById(int id)
        {
            return _mapper.Map<ProductObject>(_productRepository.GetProductById(id));
        }

        public List<ProductObject> SearchByFilter(int productId, int categoryId, string productName)
        {
            return _productRepository.SearchByFilter(productId, categoryId, productName).Select(p => _mapper.Map<ProductObject>(p)).ToList();

        }

        public void UpdateProduct(ProductObject productBO)
        {
            var product = _mapper.Map<Product>(productBO);
            _productRepository.UpdateProduct(product);
        }
    }
}
