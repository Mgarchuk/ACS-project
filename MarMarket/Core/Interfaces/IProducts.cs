using MarMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarMarket.Core.Interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> GetProducts { get; }
        IEnumerable<Product> GetProductsByCategory(int categoryId);
        Product GetProductById(int id);



    }
}
