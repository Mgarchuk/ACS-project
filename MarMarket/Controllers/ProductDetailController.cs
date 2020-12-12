using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarMarket.Core.Interfaces;
using MarMarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarMarket.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly IComments comments;
        private readonly IProducts products;
      
        public ProductDetailController(IComments comments, IProducts products)
        {
            this.comments = comments;
            this.products = products;
          
        }

        [Route("ProductDetail/Index")]
        [Route("ProductDetail/Index/{id}")]
        public IActionResult Index(string id)
        {
            int productId;
            if (string.IsNullOrEmpty(id))
            {
                productId = 0;
            }else
            {
                if (Int32.TryParse(id, out productId))
                {  
                }
                else
                {
                    productId = 0;
                }
            }

            Product product = products.GetProductById(productId); 
            ProductDetailViewModel model = new ProductDetailViewModel(product, comments.GetCommentsByProduct(productId));
            return View(model);
        }
    }
}