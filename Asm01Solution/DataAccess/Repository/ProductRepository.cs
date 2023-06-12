using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
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
            try
            {
                if (product != null)
                {
                    _context.Products.Add(new Product
                    {
                        CategoryId = product.CategoryId,
                        ProductName = product.ProductName,
                        UnitPrice = product.UnitPrice,
                        UnitsInStock = product.UnitsInStock,
                        Weight = product.Weight
                    });
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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

        public void DeleteProduct(Product product)
        {
            try
            {
                if (product != null)
                {
                    Product? p = GetProductById(product.ProductId);
                    if(p != null)
                    {
                        _context.Products.Remove(p);
                    }
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                if (product != null)
                {
                    Product? p = GetProductById(product.ProductId);
                    if(p != null)
                    {
                        p.ProductName = product.ProductName;
                        p.UnitPrice = product.UnitPrice;
                        p.CategoryId = product.CategoryId;
                        p.UnitPrice = product.UnitPrice;
                        p.UnitsInStock = product.UnitsInStock;
                        _context.SaveChanges();
                    }
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Product> SearchByFilter(int productId, int categoryId, string productName)
        {
            productName = (productName != null) ? productName : "";

            return _context.Products
                   .Where(o => o.ProductName.ToLower().Contains(productName.ToLower())
                                && ( (productId == 0) || (o.ProductId == productId) )
                                && ( (categoryId == 0) || (o.CategoryId == categoryId) ))
                   .ToList();
        }
    }
}
