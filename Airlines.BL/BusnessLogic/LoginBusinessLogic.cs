
using System;
using System.Collections.Generic;
using System.Text;
using Airlines.BL.BLInterfaces;
using Airlines.BL.DTO;
using Airlines.DL.Interfaces;
using Airlines.DL.Models;

namespace Airlines.BL.BusnessLogic
{
    public class LoginBusinessLogic : ILoginBL
    {
        public readonly ILogin _login;
        public LoginBusinessLogic(ILogin login)
        {
            _login = login;
        }
        public LoginDTO Authenticate(LoginDTO l)
        {
            Login login = new Login()
            {
                Password = l.Password,
                Username = l.Username
            };
            login = _login.Authenticate(login);
            if (login != null)
            {
                LoginDTO loginDTO = new LoginDTO()
                {
                    Password = "",
                    Username = login.Username,
                    Role = login.Role,
                    Id = login.Id
                };
                return loginDTO;
            }
            return null;
        }
    }
}
