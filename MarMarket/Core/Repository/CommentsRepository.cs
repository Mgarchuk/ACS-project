using MarMarket.Core.Interfaces;
using MarMarket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarMarket.Core.Repository
{
    public class CommentsRepository : IComments
    {
        private readonly AppDBContent appDBContent;
        public CommentsRepository(AppDBContent dBContent)
        {
            appDBContent = dBContent;
        }

        public IEnumerable<Comment> GetComments => appDBContent.Comments.ToList();

        public IEnumerable<Comment> GetCommentsByProduct(int productId)
        {
            return appDBContent.Comments.Include(comment => comment.Product).Include(comment => comment.Author).Where(comment => comment.Product.Id == productId).ToList();
        }

      

        public void CreateComment(Comment comment)
        {
            appDBContent.Comments.Add(new Comment()
            {
                Text = comment.Text,
                Date = DateTime.Now,
                Author = comment.Author,
                Product = comment.Product
            }) ;
            appDBContent.SaveChanges();
        }

        public Comment GetCommentById(int id)
        {
            return appDBContent.Comments.FirstOrDefault(product => product.Id == id);
        }

        public void DeleteComment(int id)
        {
            var comment = GetCommentById(id);
            if (comment == null) return;
             
            appDBContent.Comments.Remove(comment);
            appDBContent.SaveChanges();
        }
    }
}
