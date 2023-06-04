using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly PRN221_SalesApplicationContext _context;

        public ProductRepository(PRN221_SalesApplicationContext context) {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            if (product != null)
            {
                _context.Products.Add(new Product { 
                                            CategoryId = product.CategoryId,
                                            ProductName = product.ProductName,
                                            OrderDetails = product.OrderDetails,
                                            UnitPrice = product.UnitPrice,
                                            UnitsInStock = product.UnitsInStock,
                                            Weight = product.Weight
                                     });
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(Product product)
        {
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public void UpdateProduct(Product product)
        {
            if (product != null)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
            }
        }
    }
}
