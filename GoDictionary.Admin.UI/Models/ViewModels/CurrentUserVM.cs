using GoDictionary.Admin.UI.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoDictionary.Admin.UI.Models.ViewModels
{
    public class CurrentUserVM
    {
        public WebUserDTO WebUserDTO { get; set; }
        public List<CategoryDTO> CategoryDTOList { get; set; }
    }
}