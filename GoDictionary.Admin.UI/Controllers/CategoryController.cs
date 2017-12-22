using GoDictionary.Admin.UI.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GoDictionary.Admin.UI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public async Task<ActionResult> ListAllCategories()
        {
            List<CategoryDTO> categoryList = new List<CategoryDTO>();
            string apiUrl = "http://localhost:21423/api/categories/GetAllCategories";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    categoryList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CategoryDTO>>(data);
                }
            }
            return View(categoryList);
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        public async Task<ActionResult> EditCategory(int? id)
        {
            CategoryDTO categoryDTO = new CategoryDTO();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                int ID = (int)id;
                string apiUrl = "http://localhost:21423/api/categories/GetCategoryById/" + ID;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        categoryDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<CategoryDTO>(data);
                    }
                }
            }

            if (categoryDTO == null)
            {
                return HttpNotFound();
            }

            return View(categoryDTO);
        }

        public async Task<ActionResult> DeleteCategory(int? id)
        {
            CategoryDTO categoryDTO = new CategoryDTO();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                int ID = (int)id;
                string apiUrl = "http://localhost:21423/api/categories/GetCategoryById/" + ID;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        categoryDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<CategoryDTO>(data);
                    }
                }
            }
            if (categoryDTO == null)
            {
                return HttpNotFound();
            }

            return View(categoryDTO);
        }
    }
}