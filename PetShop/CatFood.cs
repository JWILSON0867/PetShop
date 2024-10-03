using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class CatFood : Product
    {
        public double WeightPounds { get; set; }
        public bool KittenFood { get; set; }

        // Constructor
        public CatFood(string name, decimal price, int quantity, string description, double weightPounds, bool kittenFood)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Description = description;
            WeightPounds = weightPounds;
            KittenFood = kittenFood;
        }
    }

}
