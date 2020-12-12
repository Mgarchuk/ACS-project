using MarMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarMarket.Core.Interfaces
{
    public interface ICategories
    {
        IEnumerable<Category> GetCategories { get; }
    }
}
