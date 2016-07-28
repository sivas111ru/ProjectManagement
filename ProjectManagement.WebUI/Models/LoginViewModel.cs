using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagement.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DisplayName("Почтовый адресс")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}