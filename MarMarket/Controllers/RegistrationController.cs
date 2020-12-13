using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MarMarket.Core.Interfaces;
using MarMarket.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MarMarket.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUsers users;
        public RegistrationController(IUsers users)
        {
            this.users = users;
        }

        public static async Task SendEmailAsync(string email, string subject, string text)
        {
            var EmailMessage = new MimeMessage();
            EmailMessage.From.Add(new MailboxAddress("Администрация", "marmarketbot@gmail.com"));
            EmailMessage.To.Add(new MailboxAddress("", email));
            EmailMessage.Subject = subject;
            EmailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = text
            };

            using (var client = new SmtpClient())
            {
                client.CheckCertificateRevocation = false;
                client.Connect("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("marmarketbot@gmail.com", "85350032Mgarchuk");
                await client.SendAsync(EmailMessage);

                await client.DisconnectAsync(true);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                if (users.HasUser(model.Login))
                {
                    ModelState.AddModelError("wrong", "Логин занят, попробуйте другой!");
                }
                else
                {
                    try
                    {
                        await SendEmailAsync(model.Email, "Завершение регистрации", "Вы успешно зарегистрировались на сайте");
                        users.CreateUser(model);
                        User user = users.GetUser(model.Login);

                        var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Login),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, "User"),
                    };

                        await HttpContext.SignOutAsync();

                        var claimIndentity = new ClaimsIdentity(claims, "Claims");
                        var userPrincipal = new ClaimsPrincipal(new[] { claimIndentity });

                        await HttpContext.SignInAsync(userPrincipal);

                        ViewBag.message = "Успешная регистрация.";
                        return Redirect("/Home/Index");
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("wrong", "Неккоректный email");
                    }
                    
                }
            } 

            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}