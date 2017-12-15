using DR.Core.RepositoryInterfaces;
using DR.Services.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DR.Services.WebAPI.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController: ApiController
    {
        private readonly IUsersRepository _usersRepository;

        public AccountController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [Route("login")]
        [HttpPost]
        public IHttpActionResult Login(UserLoginDTO loginCredentials)
        {

            if (loginCredentials == null || string.IsNullOrEmpty(loginCredentials.LoginName)
                                       || string.IsNullOrEmpty(loginCredentials.Password))
            {
                return BadRequest("Invalid parameters");
            }

            try
            {
                var user = _usersRepository.Get(loginCredentials.LoginName);

                if (user == null)
                {
                    return BadRequest($"User with login name {loginCredentials.LoginName } not found");
                }

                if (user.Password != loginCredentials.Password)
                {
                    return Unauthorized();
                }
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();

            }
        }
    }
}
