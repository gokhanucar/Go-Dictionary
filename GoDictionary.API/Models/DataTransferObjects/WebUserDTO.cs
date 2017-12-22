using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoDictionary.API.Models.DataTransferObjects
{
    public class WebUserDTO : BaseDTO
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}