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

        public string CommentText { get; set; }
        public int ProductId { get; set; }

        public int CommentId { get; set; }
        public ProductDetailViewModel()
        {

        }

        public ProductDetailViewModel(Product product, IEnumerable<Comment> comments, int ProductId)
        {
            this.product = product;
            this.comments = comments;
            this.ProductId = ProductId;
        }
    }
}
