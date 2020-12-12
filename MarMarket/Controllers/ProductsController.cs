using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarMarket.Core.Interfaces;
using MarMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace MarMarket.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts products;
        private int categoryId { get; set; }
        public ProductsController(IProducts products)
        {
            this.products = products;
            this.categoryId = -1;
        }
         
        [Route("Products/Index")]
        [Route("Products/Index/{id}")]
        public IActionResult Index(string id)
        {
            IEnumerable<Product> curProducts;
            if (string.IsNullOrEmpty(id))
            {
                curProducts = products.GetProducts;
            }else
            {
                int thisID = -1;
                if (Int32.TryParse(id, out thisID))
                {
                    curProducts = products.GetProductsByCategory(thisID);
                }else
                {
                    curProducts = products.GetProducts;
                }
                
            }

            ProductsViewModel productsModel = new ProductsViewModel(curProducts);
            return View(productsModel);
        }
    }
}