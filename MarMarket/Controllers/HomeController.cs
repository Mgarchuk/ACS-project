using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarMarket.Models;
using MarMarket.Core.Interfaces;

namespace MarMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategories categories;

        public HomeController(ICategories categories)
        {
            this.categories = categories;
        }

        public IActionResult Index()
        {
            HomeModel home = new HomeModel(categories.GetCategories);
            return View(home);
        }

    }
}
