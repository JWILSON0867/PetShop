using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public static class ListExtensions
    {

        public static List<T> InStock<T>(this List<T> list) where T : Product
        {
            // This method will return only the products that have a quantity greater than 0
            return list.Where(product => product.Quantity > 0).ToList();
        }

    }
}
