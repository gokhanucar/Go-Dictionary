using GoDictionary.Admin.UI.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace GoDictionary.Admin.UI.Security.Authorization
{
    public class CustomAuthorizeAttribute : ActionFilterAttribute
    {
        string[] _authorizedRoles;
        public CustomAuthorizeAttribute()
        {
            _authorizedRoles = new string[]
            {
                "superadmin", "admin", "writer"
            };
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string currentUserRole = null;
            string currentUserName = HttpContext.Current.User.Identity.Name;
            string apiUrl = "http://localhost:21423/api/webusers/GetWebUserByName?userName=" + currentUserName;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response =  client.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ToString();
                    currentUserRole = Newtonsoft.Json.JsonConvert.DeserializeObject<WebUserDTO>(data).Role;
                }
            }

            bool authorize = false;
            foreach(string role in _authorizedRoles)
            {
                if (role == currentUserRole)
                {
                    authorize = true;
                    break;
                }
            }

            if (!authorize)
                filterContext.Result = new RedirectResult("/");
        }
    }
}