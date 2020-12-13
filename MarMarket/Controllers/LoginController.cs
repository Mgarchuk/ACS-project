using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MarMarket.Core.Interfaces;
using MarMarket.Core.Repository;
using MarMarket.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;

namespace MarMarket.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsers users;
        public LoginController(IUsers users)
        {
            this.users = users;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Home/Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginModel model)
        {

            await HttpContext.SignOutAsync();

            if (ModelState.IsValid)
            {
                string PasswordHash = UsersRepository.GetHash(model.Password);

                if (users.HasUser(model.Login))
                {
                    User user = users.GetUser(model.Login);
                    if (user.Password == PasswordHash)
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name, user.Login),
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.Role, user.Role),
                        };

                        await HttpContext.SignOutAsync();
                        
                        var claimIndentity = new ClaimsIdentity(claims, "Claims");
                        var userPrincipal = new ClaimsPrincipal(new[] { claimIndentity });
                        
                        await HttpContext.SignInAsync(userPrincipal);

                        ViewBag.message = "Авторизация удалась";
                        return Redirect("/Home/Index");

                    }
                    else
                    {
                        ModelState.AddModelError("wrong", "Неверный пароль");
                    }
                }else
                {
                    ModelState.AddModelError("wrong", "Неверный логин");
                }
               
            }
            return View(model);
        }
    }
}