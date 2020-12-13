using MarMarket.Core.Interfaces;
using MarMarket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarMarket.Core.Repository
{
    public class ProductRepository : IProducts
    {
        private readonly AppDBContent appDBContent;
        public ProductRepository(AppDBContent dBContent)
        {
            appDBContent = dBContent;
        }
        public IEnumerable<Product> GetProducts => appDBContent.Products.ToList();

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return appDBContent.Products.Include(product => product.Category).Where(product => product.Category.Id == categoryId).ToList();
        }

        public Product GetProductById(int id)
        {
            return appDBContent.Products.FirstOrDefault(product => product.Id == id);
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product == null) return;
            appDBContent.Remove(product);
            appDBContent.SaveChanges();
        }

      
    }
}
