using GoDictionary.Admin.UI.Models.DataTransferObjects;
using GoDictionary.Admin.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GoDictionary.Admin.UI.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public async Task<ActionResult> Index(string userName)
        {
            //if (!HttpContext.User.Identity.IsAuthenticated)
            //    return Redirect("http://localhost:51663/Account/SignIn");

            //string currentUserName = HttpContext.User.Identity.Name;

            if (userName == null)
                return RedirectToAction("SignIn", "Account");
            CurrentUserVM currentUserVM = new CurrentUserVM();

            string apiUrl = "http://localhost:21423/api/webusers/GetWebUserByName?userName=" + userName;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    currentUserVM.WebUserDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<WebUserDTO>(data);
                }
            }

            apiUrl = "http://localhost:21423/api/categories/GetAllCategories";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    currentUserVM.CategoryDTOList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CategoryDTO>>(data);
                }
            }

            return View(currentUserVM);
        }
    }
}