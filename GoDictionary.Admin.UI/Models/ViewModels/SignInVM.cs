using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoDictionary.Admin.UI.Models.ViewModels
{
    public class SignInVM
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        public string Password { get; set; }
    }
}