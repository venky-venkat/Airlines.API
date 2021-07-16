using System;
using System.Collections.Generic;
using System.Text;

namespace Airlines.BL.DTO
{
    public class LoginDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
