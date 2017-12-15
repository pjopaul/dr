using DR.Core.RepositoryInterfaces;
using DR.Services.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AutoMapper;
using DR.Core.Entities;

namespace DR.Services.WebAPI.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUsersRepository _usersRepository;

        public UserController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetUserById(int id)
        {
            try
            {
                var user = _usersRepository.Get(id);

                if (user == null)
                {
                    return BadRequest($"User with user id {id } not found");
                }

                return Ok(Mapper.Map<User, UserDTO>(user));
            }
            catch (Exception)
            {
                return InternalServerError();

            }
        }

        

        [Route("")]
        [HttpPost]
        public IHttpActionResult AddUser([FromBody] UserDTO userData)
        {
            if (userData == null)
            {
                return BadRequest();
            }

            User user = Mapper.Map<UserDTO, User>(userData);


            User newUser = null;
            if (userData.UserId == 0)
            {
                newUser = _usersRepository.Add(user);

                if (newUser.UserId > 0)
                {
                    return Created(Request.RequestUri + "/" + user.UserId.ToString(),
                        Mapper.Map<User, UserDTO>(newUser));
                }
            }


            return BadRequest();
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult UpdateUser([FromBody] UserDTO userData)
        {
            if (userData == null)
            {
                return BadRequest();
            }

            User user = Mapper.Map<UserDTO, User>(userData);

            if (userData.UserId > 0)
            {
                User updatedUser = _usersRepository.Update(user);

                if (updatedUser.UserId > 0)
                {
                    return Ok(Mapper.Map<User, UserDTO>(updatedUser));
                }
            }


            return BadRequest();
        }


    }
}
