using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Furniture.PL.Models.Authetification
{
    public class RegisterViewModel
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        //[DisplayName("Name")]
        public string UserName { get; set; }

        [Display(Name = "Адрес почты")]
        [Required(ErrorMessageResourceName = "Email", ErrorMessageResourceType = typeof(Properties.Resources))]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Неправильный email")]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessageResourceName = "Password", ErrorMessageResourceType = typeof(Properties.Resources))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Подтверждение")]
        [Required(ErrorMessage = "Введите подтверждение пароля")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        // [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }
    }
}