using System.Collections.Generic;

namespace PetShop
{
    internal interface IProductLogic
    {
        void AddProduct(Product product);
        DogLeash GetDogLeashByName(string name);
        List<string> GetOnlyInStockProducts();
        decimal GetTotalPriceOfInventory();
    }
}

