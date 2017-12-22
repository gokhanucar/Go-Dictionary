using GoDictionary.API.Models.DataTransferObjects;
using GoDictionary.API.Service;
using GoDictionary.DAL.ORM.Entity;
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
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        [HttpGet]
        [ActionName("GetCategoryById")]
        public IHttpActionResult GetCategoryById(int? id)
        {            
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                int ID = (int)id;
                Category category = DataService.Service.CategoryService.SelectFirst(x => x.ID == ID);
                if (category == null)
                {
                    return NotFound();
                }
                else
                {
                    CategoryDTO categoryDTO = new CategoryDTO
                    {
                        ID = category.ID,
                        Description = category.Description,
                        Title = category.Title,
                        PublishDate = (DateTime)category.InsertDate
                    };
                    
                    return Json(categoryDTO);
                }
            }
        }

        [HttpGet]
        [ActionName("GetAllCategories")]
        public IHttpActionResult GetAllCategories()
        {
            List<CategoryDTO> categoryDTOList = new List<CategoryDTO>();
            List<Category> categoryEntityList = DataService.Service.CategoryService.SelectAll().OrderByDescending(x => x.InsertDate).ToList();
            foreach (Category c in categoryEntityList)
            {
                CategoryDTO category = new CategoryDTO
                {
                    ID = c.ID,
                    Title = c.Title,
                    Description = c.Description,
                    PublishDate = (DateTime)c.InsertDate
                };
                categoryDTOList.Add(category);
            }
            if (categoryDTOList.Count == 0)
                return NotFound();

            return Json(categoryDTOList);
        }

        [HttpPost]
        [ActionName("CreateCategory")]
        public IHttpActionResult CreateCategory(CategoryDTO newCategoryDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Kategori kaydı başarısız.");

            Category category = new Category
            {
                Description = newCategoryDTO.Description,
                Title = newCategoryDTO.Title
            };
                
            DataService.Service.CategoryService.Insert(category);

            return Ok(newCategoryDTO);            
        }

        [HttpPost]
        [ActionName("UpdateCategory")]
        public IHttpActionResult UpdateWebUser(int? id, CategoryDTO updatedCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != updatedCategoryDTO.ID || id == null)
            {
                return BadRequest("Kullanıcı bilgisi güncellenemedi.");
            }

            int ID = (int)id;
            Category oldCategory = new Category();
            oldCategory = DataService.Service.CategoryService.SelectFirst(c => c.ID == ID);
            oldCategory.Description = updatedCategoryDTO.Description;
            oldCategory.Title = updatedCategoryDTO.Title;
            
            DataService.Service.CategoryService.Update(oldCategory);

            return Ok(updatedCategoryDTO);
        }

        [HttpDelete]
        [ActionName("DeleteCategory")]
        public IHttpActionResult DeleteCategory(int id)
        {
            if (DataService.Service.CategoryService.Delete(id) > 0)
                return Ok();
            else
                return NotFound();
        }
    }
}
