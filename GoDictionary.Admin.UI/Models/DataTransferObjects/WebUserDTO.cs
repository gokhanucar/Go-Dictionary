using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoDictionary.Admin.UI.Models.DataTransferObjects
{
    public class WebUserDTO : BaseDTO
    {
        [Required(AllowEmptyStrings =false, ErrorMessage ="Kullanıcı adı boş geçilemez.")]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}