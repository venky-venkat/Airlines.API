using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airlines.BL.BLInterfaces;
using Airlines.BL.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Airlines.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly ILoginBL _loginBL;

        public LoginController(ILoginBL loginBL)
        {
            _loginBL = loginBL;
        }
        // GET: api/<LoginController>
        [HttpGet]
        public LoginDTO GetLogin(string username,string password)
        {
            LoginDTO loginDTO = new LoginDTO();
            loginDTO.Password = password;
            loginDTO.Username = username;
            loginDTO = _loginBL.Authenticate(loginDTO);
            if (loginDTO != null)
            {
                return loginDTO;
            }
            else
            {
                return null;
            }
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        
    }
}
