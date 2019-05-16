using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Furniture.PL.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Адрес почты")]
        [Required(ErrorMessageResourceName = "Email", ErrorMessageResourceType = typeof(Properties.Resources))]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Неправильный email")]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}