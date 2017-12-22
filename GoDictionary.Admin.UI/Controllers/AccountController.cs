using GoDictionary.Admin.UI.Models.DataTransferObjects;
using GoDictionary.Admin.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GoDictionary.Admin.UI.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignIn()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return Redirect("http://localhost:51663/home/index");

            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> SignIn(SignInVM credentials)
        //{
        //    bool isExists = false;
        //    if (ModelState.IsValid)
        //    {
        //        string apiUrl = "http://localhost:21423/api/register/checkcredential?userName=" + credentials.UserName + "&password=" + credentials.Password;
        //        using (HttpClient client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(apiUrl);
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    

        //            HttpResponseMessage response = await client.GetAsync(apiUrl);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var data = await response.Content.ReadAsStringAsync();
        //                isExists = Newtonsoft.Json.JsonConvert.DeserializeObject<bool>(data);
        //            }
        //        }
        //    }

        //    if (isExists)
        //    {
        //        WebUserDTO currentUser = null;

        //        string apiUrl = "http://localhost:21423/api/webusers/GetWebUserByName?userName=" + credentials.UserName;
        //        using (HttpClient client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(apiUrl);
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //            HttpResponseMessage response = await client.GetAsync(apiUrl);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var data = await response.Content.ReadAsStringAsync();
        //                currentUser = Newtonsoft.Json.JsonConvert.DeserializeObject<WebUserDTO>(data);
        //            }
        //        }

        //        string cookie = $"{currentUser.ID}-{currentUser.Role}-{currentUser.UserName}";
        //        FormsAuthentication.SetAuthCookie(cookie, true);

        //        return Redirect("/");
        //    }

        //    return View();
        //}

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/account/signin");
        }

    }
}