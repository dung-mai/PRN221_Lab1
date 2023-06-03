using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private FStoreContext _context;

        public ProductDAO()
        {
            _context = FStoreContext.GetInstance();
        }

        public void AddProduct(Product product)
        {
            if (product != null)
            {
                _context.Products.Add(product);
            }
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            if (product != null)
            {
                _context.Products.Update(product);
            }
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            _context.SaveChanges();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}
