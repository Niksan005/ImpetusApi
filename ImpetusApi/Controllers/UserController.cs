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
        public BaseInput<bool> Login(InputClass _user)
        {
            BaseInput<bool> _output = new BaseInput<bool>();

            AppUser _newuser = GetUserByString(_user.Username);
            if (_newuser == null)
            {
                _output.Status = "@UserNotFound";
                return _output;
            }
            if (_newuser.Password == _user.Password)
            {
                _output.Status = "@SuccessfulLogin";
            }
            else
            {
                _output.Status = "@WrongPassword";
            }

            _output.Output = true;
            return _output;
        }

        [HttpPost("register")]
        public async Task<BaseInput<bool>> Register(InputClass _user)
        {
            BaseInput<bool> _output = new BaseInput<bool>();

            if (GetUserByString(_user.Username) != null) _output.Status = "@UsernameTaken";
            _context.Users.Add(
                new AppUser
                {
                    Username = _user.Username,
                    Password = _user.Password,
                    Points = 100,
                    MatchHistory = null
                });
            await _context.SaveChangesAsync();
            _output.Status = "@SuccessfulRegister";
            _output.Output = true;

            return _output;
        }


        [HttpPost("getuser")]
        public BaseInput<AppUserOutput> GetUser(string _user)
        {
            BaseInput<AppUserOutput> _output = new BaseInput<AppUserOutput>();
            AppUser _newuser = GetUserByString(_user);

            if (_newuser == null) _output.Status = "@UserNotFound";
            _output.Output = new AppUserOutput(_newuser);
            _output.Status = "@UserFound";

            return _output;
        }

    }
}
