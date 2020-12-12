using MarMarket.Core.Interfaces;
using MarMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MarMarket.Core.Repository
{
    public class UsersRepository : IUsers
    {
        public static String GetHash(String data)
        {
            using (var algorithm = SHA512.Create())
            {
                var hashedBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(data));

                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
        private readonly AppDBContent appDBContent;
        public UsersRepository(AppDBContent dBContent)
        {
            appDBContent = dBContent;
        }

        public IEnumerable<User> GetUsers => appDBContent.Users.ToList();

        public bool HasUser(string Login)
        {
            User user = appDBContent.Users.FirstOrDefault(user => user.Login == Login);
            if (user == null) return false;
            return true;
        }

        public User GetUser(string Login)
        {
            User user = appDBContent.Users.FirstOrDefault(user => user.Login == Login);
            return user;
        }

        public void CreateUser(RegistrationModel model)
        {
            appDBContent.Users.Add(new User() {
                Login = model.Login,
                Password = GetHash(model.Password),
                Email = model.Email,
                Role = "user"
            });
            appDBContent.SaveChanges();
        }
    }
}
