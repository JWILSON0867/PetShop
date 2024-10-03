using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.Data
{

    public interface IProductRepository
    {
        void AddProd(ProductEntity product);
        ProductEntity GetProductById(int productId);
        IEnumerable<ProductEntity> GetAllProducts();
        void UpdateProduct(ProductEntity product);
        void DeleteProduct(int productId);
    }


    public class ProductRepository : IProductRepository // Implementing the interface
    {
        private readonly ProductContext _context; // Private readonly variable

        // Constructor
        public ProductRepository()
        {
            // Initialize the ProductContext instance
            _context = new ProductContext();
        }

        public void AddProd(ProductEntity product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public ProductEntity GetProductById(int productId)
        {
            return _context.Products.Find(productId);
        }

        public IEnumerable<ProductEntity> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public void UpdateProduct(ProductEntity product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
