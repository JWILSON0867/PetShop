using PetStore.Data;
using System;
using System.Collections.Generic;

namespace PetShop
{


    public class ProductLogic : IProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeashes;
        private Dictionary<string, CatFood> _catFoods;

        // Add the repository variable
        private readonly IProductRepository _productRepository;

        // Modify constructor to accept repository interface
        public ProductLogic(IProductRepository productRepository)
        {
            _productRepository = productRepository; // Assign the repository

            _products = new List<Product>();
            _dogLeashes = new Dictionary<string, DogLeash>();
            _catFoods = new Dictionary<string, CatFood>();

            // Sample data
            AddProduct(new DogLeash("Strong Leash", 15.99m, 10, "A durable dog leash.", 48, "Nylon"));
            AddProduct(new DogLeash("Short Leash", 12.99m, 0, "A short dog leash.", 24, "Leather")); // Quantity 0
            AddProduct(new CatFood("Healthy Cat Food", 8.99m, 5, "Nutritious food for cats.", 2.5, false));
        }

        public void AddProduct(Product product)
        {
            // Convert the product into a ProductEntity
            var productEntity = new ProductEntity
            {
                Name = product.Name,
                Price = product.Price,
                InStock = product.Quantity > 0 // Determine InStock based on quantity
            };

            _productRepository.AddProd(productEntity);  // Call the AddProd method from the repository

            // Output for feedback purposes (optional)
            if (product is DogLeash dogLeash)
            {
                Console.WriteLine("DogLeash added: " + dogLeash.Name);
            }
            else if (product is CatFood catFood)
            {
                Console.WriteLine("CatFood added: " + catFood.Name);
            }
            else
            {
                Console.WriteLine("Product added: " + product.Name);
            }
        }

        public ProductEntity GetProductByID(int productId)
        {
            // Call the repository's GetProductById method
            var productEntity = _productRepository.GetProductById(productId);

            // Optional: Add logic to handle null cases if needed
            if (productEntity == null)
            {
                Console.WriteLine("Product not found.");
            }

            return productEntity;
        }


        public DogLeash GetDogLeashByName(string name)
        {
            return _dogLeashes.TryGetValue(name, out var dogLeash) ? dogLeash : null;
        }

        public List<string> GetOnlyInStockProducts()
        {
            return _products
                .Where(p => p.Quantity > 0)
                .Select(p => p.Name)
                .ToList();
        }

        public decimal GetTotalPriceOfInventory()
        {
            return _products
                .InStock() // Use the extension method
                .Select(p => p.Price * p.Quantity)
                .Sum();
        }
    }
}
