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
    [RoutePrefix("api/entryposts")]
    public class EntryPostsController : ApiController
    {
        [HttpGet]
        [ActionName("GetEntryById")]
        public IHttpActionResult GetEntryById(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                int ID = (int)id;
                EntryPost entryPost = DataService.Service.EntryPostService.SelectFirst(x => x.ID == ID);
                if (entryPost == null)
                {
                    return NotFound();
                }
                else
                {
                    EntryPostDTO entryPostDTO = new EntryPostDTO
                    {
                        ID = entryPost.ID,
                        CategoryID = entryPost.CategoryID,
                        WebUserID = entryPost.WebUserID,
                        Content = entryPost.Content,
                        Like = entryPost.Like,
                        Dislike = entryPost.Dislike,
                        ImagePath = entryPost.ImagePath,
                        Link = entryPost.Link,
                        Summary = entryPost.Summary,
                        Title = entryPost.Title,
                        PostDate = (DateTime)entryPost.InsertDate
                    };

                    return Json(entryPostDTO);
                }
            }
        }

        [HttpGet]
        [ActionName("GetAllEntries")]
        public IHttpActionResult GetAllEntries()
        {
            List<EntryPostDTO> entryDTOList = new List<EntryPostDTO>();
            List<EntryPost> entryPostList = DataService.Service.EntryPostService.SelectAll();
            foreach (EntryPost item in entryPostList)
            {
                EntryPostDTO entryPost = new EntryPostDTO
                {
                    ID = item.ID,
                    CategoryID = item.CategoryID,
                    WebUserID = item.WebUserID,
                    Content = item.Content,
                    ImagePath = item.ImagePath,
                    Like = item.Like,
                    Dislike = item.Dislike,
                    Link = item.Link,
                    Title = item.Title,
                    PostDate = (DateTime)item.InsertDate,
                    Summary = item.Summary
                };
                entryDTOList.Add(entryPost);
            }
            if (entryDTOList.Count == 0)
                return NotFound();

            return Json(entryDTOList);
        }

        [HttpGet]
        [ActionName("GetEntryByUserId")]
        public IHttpActionResult GetEntryByUserId(int id)
        {
            List<EntryPostDTO> entryDTOList = new List<EntryPostDTO>();
            List<EntryPost> entryPostList = DataService.Service.EntryPostService.SelectByCondition(x => x.WebUserID == id)
                                            .OrderBy(x => x.InsertDate).ToList();
            foreach (EntryPost item in entryPostList)
            {
                EntryPostDTO entryPost = new EntryPostDTO
                {
                    ID = item.ID,
                    CategoryID = item.CategoryID,
                    WebUserID = item.WebUserID,
                    Content = item.Content,
                    ImagePath = item.ImagePath,
                    Like = item.Like,
                    Dislike = item.Dislike,
                    Link = item.Link,
                    Title = item.Title,
                    PostDate = (DateTime)item.InsertDate,
                    Summary = item.Summary
                };
                entryDTOList.Add(entryPost);
            }
            if (entryDTOList.Count == 0)
                return NotFound();

            return Json(entryDTOList);
        }

        [HttpGet]
        [ActionName("GetEntryByCategoryId")]
        public IHttpActionResult GetEntryByCategoryId(int id)
        {
            List<EntryPostDTO> entryDTOList = new List<EntryPostDTO>();
            List<EntryPost> entryPostList = DataService.Service.EntryPostService.SelectByCondition(x => x.CategoryID == id)
                                            .OrderBy(x => x.InsertDate).ToList();
            foreach (EntryPost item in entryPostList)
            {
                EntryPostDTO entryPost = new EntryPostDTO
                {
                    ID = item.ID,
                    CategoryID = item.CategoryID,
                    WebUserID = item.WebUserID,
                    Content = item.Content,
                    ImagePath = item.ImagePath,
                    Like = item.Like,
                    Dislike = item.Dislike,
                    Link = item.Link,
                    Title = item.Title,
                    PostDate = (DateTime)item.InsertDate,
                    Summary = item.Summary
                };
                entryDTOList.Add(entryPost);
            }
            if (entryDTOList.Count == 0)
                return NotFound();

            return Json(entryDTOList);
        }

        [HttpGet]
        [ActionName("GetActiveEntryByCategoryId")]
        public IHttpActionResult GetActiveEntryByCategoryId(int id)
        {
            List<EntryPostDTO> entryDTOList = new List<EntryPostDTO>();
            List<EntryPost> entryPostList = DataService.Service.EntryPostService.SelectByCondition(x => x.CategoryID == id && x.IsActive == true)
                                            .OrderBy(x => x.InsertDate).ToList();
            foreach (EntryPost item in entryPostList)
            {
                EntryPostDTO entryPost = new EntryPostDTO
                {
                    ID = item.ID,
                    CategoryID = item.CategoryID,
                    WebUserID = item.WebUserID,
                    Content = item.Content,
                    ImagePath = item.ImagePath,
                    Like = item.Like,
                    Dislike = item.Dislike,
                    Link = item.Link,
                    Title = item.Title,
                    PostDate = (DateTime)item.InsertDate,
                    Summary = item.Summary
                };
                entryDTOList.Add(entryPost);
            }
            if (entryDTOList.Count == 0)
                return NotFound();

            return Json(entryDTOList);
        }

        [HttpPost]
        [ActionName("CreateEntryPost")]
        public IHttpActionResult CreateEntryPost(EntryPostDTO newEntryDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Entry kaydı başarısız.");

            EntryPost entryPost = new EntryPost
            {
                CategoryID = newEntryDTO.CategoryID,
                WebUserID = newEntryDTO.WebUserID,
                Content = newEntryDTO.Content,
                ImagePath = newEntryDTO.ImagePath,
                Link = newEntryDTO.Link,
                Summary = newEntryDTO.Summary,
                Title = newEntryDTO.Title                
            };

            DataService.Service.EntryPostService.Insert(entryPost);

            return Ok(newEntryDTO);
        }

        [HttpPut]
        [ActionName("UpdateEntryPost")]
        public IHttpActionResult UpdateEntryPost(int? id, EntryPostDTO updatedEntryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != updatedEntryDTO.ID || id == null)
            {
                return BadRequest("Entry bilgisi güncellenemedi.");
            }

            int ID = (int)id;
            EntryPost oldEntry = new EntryPost();
            oldEntry = DataService.Service.EntryPostService.SelectFirst(x => x.ID == ID);
            oldEntry.Content = updatedEntryDTO.Content;
            oldEntry.ImagePath = updatedEntryDTO.ImagePath;
            oldEntry.Link = updatedEntryDTO.Link;
            oldEntry.Summary = updatedEntryDTO.Summary;
            oldEntry.Title = updatedEntryDTO.Title;
            

            DataService.Service.EntryPostService.Update(oldEntry);

            return Ok(updatedEntryDTO);
        }

        [HttpPut]
        [ActionName("UpdateLike")]
        public IHttpActionResult UpdateLike(int? id)
        {          
            if (id == null)
            {
                return BadRequest("Entry bilgisi güncellenemedi.");
            }

            int ID = (int)id;
            EntryPost oldEntry = new EntryPost();
            if (DataService.Service.EntryPostService.UpdateLikeCount(ID) > 0)
            {
                oldEntry = DataService.Service.EntryPostService.SelectFirst(x => x.ID == ID);
                return Ok(oldEntry);
            }
            else
            {
                return BadRequest("Entry bilgisi güncellenemedi.");
            }  
        }

        [HttpPut]
        [ActionName("UpdateDislike")]
        public IHttpActionResult UpdateDislike(int? id)
        {
            if (id == null)
            {
                return BadRequest("Entry bilgisi güncellenemedi.");
            }

            int ID = (int)id;
            EntryPost oldEntry = new EntryPost();
            if (DataService.Service.EntryPostService.UpdateDislikeCount(ID) > 0)
            {
                oldEntry = DataService.Service.EntryPostService.SelectFirst(x => x.ID == ID);
                return Ok(oldEntry);
            }
            else
            {
                return BadRequest("Entry bilgisi güncellenemedi.");
            }
        }

        [HttpDelete]
        [ActionName("DeleteEntryPost")]
        public IHttpActionResult DeleteEntryPost(int id)
        {
            if (DataService.Service.EntryPostService.Delete(id) > 0)
                return Ok();
            else
                return NotFound();
        }
    }
}
