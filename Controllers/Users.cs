using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserPrivileges.Models;
using UserPrivileges.Models.DTOs;
using UserPrivileges.Repository.IRepository;

namespace UserPrivileges.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users  : Controller
    {
        private readonly IUserRepository _iuserRepository;
        private readonly IMapper _imapper;
        private IUserPrivilegeRepository _iuserPrivilegeRepository;

        public Users(IUserRepository iuserRepository, IMapper imapper, IUserPrivilegeRepository iuserPrivilegeRepository)
        {
            _iuserRepository = iuserRepository;
            _imapper = imapper;
            _iuserPrivilegeRepository = iuserPrivilegeRepository;
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _iuserRepository.GetUsers();

            var userDto = new List<UserDto>();

            foreach (var user in users)
            {
                userDto.Add(_imapper.Map<UserDto>(user));
            }

            return Ok(userDto);
        }


        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userdto)
        {
            try
            {
                if (userdto == null)
                {
                    return BadRequest(ModelState);
                }

            //Check if user already exist
                if (_iuserRepository.UserExists(userdto.Email))
                {
                    ModelState.AddModelError("", "User already exist");
                    return StatusCode(404, ModelState);
                }

                var userObj = _imapper.Map<User>(userdto);
                userObj.Id = Guid.NewGuid().ToString();
                var userId = userObj.Id;

                userObj.Password = _iuserRepository.EncryptUserPassword(userdto.Password);

                if (!_iuserRepository.CreateUser(userObj))
                {
                    ModelState.AddModelError("", $"Please check {userObj.Firstname} details");
                    return StatusCode(500, ModelState);
                }

                _iuserPrivilegeRepository.AssignUserPrivilege(userId, userdto.PrivilegeName);

                return Ok();

            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error in controller when creating user: {ex.Message}");
            }

        }


        //[HttpPatch("change-password")]
        //public IActionResult ChangeUserPassword([FromBody] string email, [FromBody] string password, UserDto userdto)
        //{


        //    if (!_iuserRepository.UserExists(email))
        //    {
        //        throw new MethodAccessException("This email do not exist onn our system. Kindly check email again");
        //    }

        //    var userObj = _imapper.Map<User>(userdto);
        //    userObj.Password = _iuserRepository.EncryptUserPassword(userdto.Password);

        //    if (!_iuserRepository.ChangeUserPassword(password))
        //    {
        //        ModelState.AddModelError("", $"Something went wrong when updating {userObj.Firstname}");
        //        return StatusCode(500, ModelState);
        //    }


        //    return NoContent();
        //}

    }
}
