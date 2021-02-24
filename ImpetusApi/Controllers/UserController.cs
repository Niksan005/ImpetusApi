using ImpetusApi.Controllers.Data;
using ImpetusApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpetusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(ILogger<UserController> logger, ImpetusApiContext context)
            : base(logger, context)
        { }


        [HttpPost("login")]
        public string Login(InputClass _user)
        {
            AppUser _newuser = GetUserByString(_user.Username);
            if (_newuser == null) return "@UserNotFound";
            if (_newuser.Password == _user.Password) return "@SuccessfulLogin";
            return "@WrongPassword";
        }

        [HttpPost("register")]
        public string Register(InputClass _user)
        {
            if (GetUserByString(_user.Username) != null) return "@UsernameTaken";
            _context.Users.Add(
                new AppUser
                {
                    Username = _user.Username,
                    Password = _user.Password,
                    Points = 100,
                    MatchHistory = null
                });
            _context.SaveChanges();
            return "@SuccessfulRegister";
        }

    }
}
