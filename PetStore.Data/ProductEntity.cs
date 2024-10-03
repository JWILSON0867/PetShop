using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public class ProductEntity
    {

        // Primary Key
        public int ProductId { get; set; }

        // Add other properties (e.g., Name, Price)
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Example for Stock status
        public bool InStock { get; set; }
    }
}
