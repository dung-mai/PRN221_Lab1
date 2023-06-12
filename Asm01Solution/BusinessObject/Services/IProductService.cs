using BusinessLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IProductService
    {
        public void AddProduct(ProductObject productBO);
        public void UpdateProduct(ProductObject productBO);
        public void DeleteProduct(ProductObject productBO);
        public ProductObject? GetProductById(int id);
        public List<ProductObject> GetAllProducts();
        public List<ProductObject> SearchByFilter(int productId, int categoryId, string productName);
    }
}
