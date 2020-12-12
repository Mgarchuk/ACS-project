using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace MarMarket.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }

        public virtual User Author { get; set; }

        public virtual Product Product { get; set; }

    }
}
