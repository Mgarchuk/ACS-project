using MarMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarMarket.Core.Interfaces
{
    public interface IComments
    {
        IEnumerable<Comment> GetComments { get; }
        IEnumerable<Comment> GetCommentsByProduct(int productId);

        Comment GetCommentById(int id);

        void CreateComment(Comment comment);

        void DeleteComment(int id);
    }
}
