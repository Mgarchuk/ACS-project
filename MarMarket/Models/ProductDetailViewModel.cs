using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarMarket.Models
{
    public class ProductDetailViewModel
    {
        public Product product;
        public IEnumerable<Comment> comments;

        public ProductDetailViewModel(Product product, IEnumerable<Comment> comments)
        {
            this.product = product;
            this.comments = comments;
        }
    }
}
