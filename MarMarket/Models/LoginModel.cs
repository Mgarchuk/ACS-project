using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarMarket.Models
{
    public class LoginModel
    {
        [Display(Name = "Введите логин")]
        [StringLength(50)]
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Введите пароль")]
        [StringLength(50)]
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Password { get; set; }
    }
}
