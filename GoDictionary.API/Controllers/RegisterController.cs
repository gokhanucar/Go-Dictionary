using GoDictionary.API.Models.ViewModels;
using GoDictionary.API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GoDictionary.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/register")]
    public class RegisterController : ApiController
    {
        [HttpGet]
        [ActionName("CheckCredential")]
        public IHttpActionResult CheckCredential(string userName, string password)
        {
            bool isExisted = DataService.Service.WebUserService.CheckCredential(userName, password);

            return Json(isExisted);
            
        }
    }
}
