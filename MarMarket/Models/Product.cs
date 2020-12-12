using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarMarket.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Rating { get; set; }

        public string ImageUrl { get; set; }

        public virtual Category Category{get; set;}
    }
}
