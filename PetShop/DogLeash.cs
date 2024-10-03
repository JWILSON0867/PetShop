using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 


namespace PetShop
{
    public class DogLeash : Product
    {
        public int LengthInches { get; set; }
        public string Material { get; set; }

        // Constructor
        public DogLeash(string name, decimal price, int quantity, string description, int lengthInches, string material)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Description = description;
            LengthInches = lengthInches;
            Material = material;
        }
    }
}


