using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using GoDictionary.Admin.UI.Models.DataTransferObjects;

namespace GoDictionary.Admin.UI.Controllers
{
    public class WebUserController : Controller
    {
        // GET: WebUser
        public async Task<ActionResult> GetUserByID(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            WebUserDTO userData = new WebUserDTO();
            string apiUrl = "http://localhost:21423/api/webusers/getwebuserbyid/" + id;
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    userData = Newtonsoft.Json.JsonConvert.DeserializeObject<WebUserDTO>(data);
                }
            }
            return View(userData);
        }

        public async Task<ActionResult> AllUserList()
        {
            List<WebUserDTO> userList = new List<WebUserDTO>();
            string apiUrl = "http://localhost:21423/api/webusers/GetAllUsers";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    userList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WebUserDTO>>(data);
                }
            }
            
            return View(userList);
        }

        public async Task<ActionResult> AdminList()
        {
            List<WebUserDTO> adminList = new List<WebUserDTO>();
            string apiUrl = "http://localhost:21423/api/webusers/GetAllUsers";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    adminList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WebUserDTO>>(data);
                }
            }
            adminList = adminList.Where(x => x.Role == "admin" || x.Role == "superadmin").ToList();
            return View(adminList);
        }

        public async Task<ActionResult> WriterList()
        {
            List<WebUserDTO> adminList = new List<WebUserDTO>();
            string apiUrl = "http://localhost:21423/api/webusers/GetAllUsers";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    adminList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WebUserDTO>>(data);
                }
            }
            adminList = adminList.Where(x => x.Role == "writer").ToList();
            return View(adminList);
        }

        public async Task<ActionResult> ActiveUserList()
        {
            List<WebUserDTO> userList = new List<WebUserDTO>();
            string apiUrl = "http://localhost:21423/api/webusers/GetActiveUsers";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    userList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WebUserDTO>>(data);
                }
            }
            
            return View(userList);
        }

        public async Task<ActionResult> DeletedUserList()
        {
            List<WebUserDTO> userList = new List<WebUserDTO>();
            string apiUrl = "http://localhost:21423/api/webusers/GetDeletedUsers";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    userList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WebUserDTO>>(data);
                }
            }
            
            return View(userList);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            WebUserDTO webUserDTO = new WebUserDTO();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                string apiUrl = "http://localhost:21423/api/webusers/GetWebUserById/" + id;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        webUserDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<WebUserDTO>(data);
                    }
                }
            }
            if (webUserDTO == null)
            {
                return HttpNotFound();
            }

            return View(webUserDTO);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,UserName,UserName,FirstName,LastName,Password,Role")] WebUserDTO webUserDTO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        WebUserDTO updatedWebUserDTO = new WebUserDTO()
        //        {
        //            ID = webUserDTO.ID,
        //            Email
        //        }
        //    }
        //    return View(categoryDTO);
        //}
    }
}