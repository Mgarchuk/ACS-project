using MarMarket.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarMarket.Core.Interfaces
{
    public interface IUsers
    {
        IEnumerable<User> GetUsers { get; }
        bool HasUser(string Login);

        void CreateUser(RegistrationModel model);

        User GetUser(string Login);

    }
}
