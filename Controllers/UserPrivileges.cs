using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserPrivileges.Data;
using UserPrivileges.Models;
using UserPrivileges.Models.DTOs;
using UserPrivileges.Repository.IRepository;

namespace UserPrivileges.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPrivileges : Controller
    {
        
        private readonly IUserPrivilegeRepository _iuserprivilege;
        private readonly IMapper _imapper;

        public UserPrivileges(IUserPrivilegeRepository iuserprivilege, IMapper imapper)
        {
            _iuserprivilege = iuserprivilege;
            _imapper = imapper;
        }

        [HttpGet]
        public IActionResult GetUserPrivileges()
        {
            var userRoles= _iuserprivilege.GetUserPrivileges();

            var userprivilegeDto = new List<UserPrivilegeDto>();

            foreach (var userRole in userRoles)
            {
                userprivilegeDto.Add(_imapper.Map<UserPrivilegeDto>(userRole));
            }

            return Ok(userprivilegeDto);


        }


        [HttpPost]
        public IActionResult CreateUserRole([FromBody] UserPrivilegeDto userPrivilegedto)
        {
            try
            {
                if(userPrivilegedto == null)
                {
                    return BadRequest(ModelState);
                }

                var roleObj = _imapper.Map<UserPrivilege>(userPrivilegedto);
                //roleObj.Id = Guid.NewGuid().ToString();

                _iuserprivilege.AssignUserPrivilege(userPrivilegedto.UserId, userPrivilegedto.AuthItem);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error in controller when creating user: {ex.Message}");
            }
        }
    }
}
