using MarMarket.Core.Interfaces;
using MarMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarMarket.Core.Repository
{
    public class CategoriesRepository : ICategories
    {
        private readonly AppDBContent appDBContent;
        public CategoriesRepository(AppDBContent dBContent)
        {
            appDBContent = dBContent;
        }
        public IEnumerable<Category> GetCategories => appDBContent.Categories.ToList();
    }
}
