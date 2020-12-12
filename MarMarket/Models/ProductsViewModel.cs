using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarMarket.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> products;
        public ProductsViewModel(IEnumerable<Product> products)
        {
            this.products = products;
        }
    }
}
