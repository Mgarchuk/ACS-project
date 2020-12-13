using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarMarket.Core.Interfaces;
using MarMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace MarMarket.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly IComments comments;
        private readonly IProducts products;
        private readonly IUsers users;
        private readonly IHubContext<CommentHub> hub;
        public ProductDetailController(IComments comments, IProducts products, IUsers users, IHubContext<CommentHub> hub)
        {
            this.comments = comments;
            this.products = products;
            this.users = users;
            this.hub = hub;
          
        }

        [HttpPost]
        public IActionResult DeleteComment(ProductDetailViewModel model)
        {
            var userName = User.Identity.Name;
            User currentUser = users.GetUsers.Where(user => user.Login == userName).FirstOrDefault();
            Comment comment = comments.GetCommentById(model.CommentId);

            bool badUser = userName == null || comment == null || (currentUser.Role == "user" && currentUser.Id != comment.Author.Id);
            if (!badUser)
            {
                comments.DeleteComment(model.CommentId);
            } 

            return Redirect($"/ProductDetail/Index/{model.ProductId}");

        }

        [HttpPost]
        public IActionResult Checkout(ProductDetailViewModel model)
        {

            var userName = User.Identity.Name;
            User currentUser = users.GetUsers.Where(user => user.Login == userName).FirstOrDefault();
            var NewComment = comments.CreateComment(new Comment() {
                Text = model.CommentText, 
                Product = products.GetProductById(model.ProductId),
                Date = DateTime.Now,
                Author = currentUser
            });
            hub.Clients.All.SendAsync("HubEvent", NewComment);
            
            return Redirect($"/ProductDetail/Index/{model.ProductId}");
          
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
            ProductDetailViewModel model = new ProductDetailViewModel(product, comments.GetCommentsByProduct(productId), productId);
            return View(model);
        }
    }
}