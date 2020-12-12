using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarMarket.Models
{
    public class HomeModel
    {
        public IEnumerable<Category> categories;
        public HomeModel(IEnumerable<Category> categories)
        {
            this.categories = categories;
        }
    }
}
