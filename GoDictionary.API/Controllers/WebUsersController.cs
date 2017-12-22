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
    [RoutePrefix("api/webusers")]
    public class WebUsersController : ApiController
    {
        [HttpGet]
        [ActionName("GetWebUserById")]
        public IHttpActionResult GetWebUserById(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            else
            {
                int ID = (int)id;
                WebUser webUser = DataService.Service.WebUserService.SelectFirst(x => x.ID == ID);
                if(webUser == null)
                {
                    return NotFound();
                }
                else
                {
                    WebUserDTO userDTO = new WebUserDTO
                    {
                        ID = webUser.ID,
                        Email = webUser.Email,
                        FirstName = webUser.FirstName,
                        LastName = webUser.LastName,
                        Password = webUser.Password,
                        Role = webUser.Role,
                        UserName = webUser.UserName,
                        MembershipDate = (DateTime)webUser.InsertDate
                    };
                    return Json(userDTO);
                }
            }            
        }

        [HttpGet]
        [ActionName("GetWebUserByName")]
        public IHttpActionResult GetWebUserByName(string userName)
        {
            if (userName == null)
            {
                return NotFound();
            }
            else
            {
                WebUser webUser = DataService.Service.WebUserService.SelectFirst(x => x.UserName == userName);
                if (webUser == null)
                {
                    return NotFound();
                }
                else
                {
                    WebUserDTO userDTO = new WebUserDTO
                    {
                        ID = webUser.ID,
                        Email = webUser.Email,
                        FirstName = webUser.FirstName,
                        LastName = webUser.LastName,
                        Password = null,
                        Role = webUser.Role,
                        UserName = webUser.UserName,
                        MembershipDate = (DateTime)webUser.InsertDate
                    };
                    return Json(userDTO);
                }
            }
        }

        //[Authorize(Roles ="superadmin")]
        [HttpGet]
        [ActionName("GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            List<WebUserDTO> userList = new List<WebUserDTO>();
            List<WebUser> webUserList = DataService.Service.WebUserService.SelectAll();
            foreach(WebUser webUser in webUserList)
            {
                WebUserDTO user = new WebUserDTO
                {
                    Email = webUser.Email,
                    FirstName = webUser.FirstName,
                    ID = webUser.ID,
                    LastName = webUser.LastName,
                    MembershipDate = (DateTime)webUser.InsertDate,
                    Password = null,
                    Role = webUser.Role,
                    UserName = webUser.UserName
                };
                userList.Add(user);
            }
            if (userList.Count == 0)
                return NotFound();

            return Json(userList);
        }

        [HttpGet]
        [ActionName("GetActiveUsers")]
        public IHttpActionResult GetActiveUsers()
        {
            List<WebUserDTO> userList = new List<WebUserDTO>();
            List<WebUser> webUserList = DataService.Service.WebUserService.SelectByState(true);
            foreach (WebUser webUser in webUserList)
            {
                WebUserDTO user = new WebUserDTO
                {
                    Email = webUser.Email,
                    FirstName = webUser.FirstName,
                    ID = webUser.ID,
                    LastName = webUser.LastName,
                    MembershipDate = (DateTime)webUser.InsertDate,
                    Password = null,
                    Role = webUser.Role,
                    UserName = webUser.UserName
                };
                userList.Add(user);
            }
            if (userList.Count == 0)
                return NotFound();

            return Json(userList);
        }

        [HttpGet]
        [ActionName("GetDeletedUsers")]
        public IHttpActionResult GetDeletedUsers()
        {
            List<WebUserDTO> userList = new List<WebUserDTO>();
            List<WebUser> webUserList = DataService.Service.WebUserService.SelectByState(false, true);
            foreach (WebUser webUser in webUserList)
            {
                WebUserDTO user = new WebUserDTO
                {
                    Email = webUser.Email,
                    FirstName = webUser.FirstName,
                    ID = webUser.ID,
                    LastName = webUser.LastName,
                    MembershipDate = (DateTime)webUser.InsertDate,
                    Password = null,
                    Role = webUser.Role,
                    UserName = webUser.UserName
                };
                userList.Add(user);
            }
            if (userList.Count == 0)
                return NotFound();

            return Json(userList);
        }

        [HttpPost]
        [ActionName("CreateWebUser")]
        public IHttpActionResult CreateWebUser(WebUserDTO newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest("Kullanıcı kaydı başarısız.");
            
            if (DataService.Service.WebUserService.CheckCredential(newUser.Email, newUser.Password))
            {
                return BadRequest("Kullanıcı kaydı mevcut.");
            }
            else
            {
                WebUser user = new WebUser
                {
                    Email = newUser.Email,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Password = newUser.Password,
                    Role = newUser.Role,
                    UserName = newUser.UserName
                };
                DataService.Service.WebUserService.Insert(user);

                return Ok(newUser);
            }
        }

        // PUT /api/webusers/UpdateWebUser/{id}
        [HttpPut]
        [ActionName("UpdateWebUser")]
        public IHttpActionResult UpdateWebUser(int? id, WebUserDTO updatedUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != updatedUserDTO.ID || id == null)
            {
                return BadRequest("Kullanıcı bilgisi güncellenemedi.");
            }

            int ID = (int)id;
            WebUser oldUser = new WebUser();
            oldUser = DataService.Service.WebUserService.SelectFirst(user => user.ID == ID);
            oldUser.FirstName = updatedUserDTO.FirstName;
            oldUser.LastName = updatedUserDTO.LastName;
            oldUser.Password = updatedUserDTO.Password;
            oldUser.Role = updatedUserDTO.Role;
                            
            DataService.Service.WebUserService.Update(oldUser);

            return Ok(updatedUserDTO);               
        }

        // DELETE /api/webusers/DeleteWebUser/{id}
        [HttpDelete]
        [ActionName("DeleteWebUser")]
        public IHttpActionResult DeleteWebUser(int id)
        {
            if (DataService.Service.WebUserService.Delete(id) > 0)
                return Ok();
            else
                return NotFound();            
        }

    }
}
