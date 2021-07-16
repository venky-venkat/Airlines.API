using System;
using System.Collections.Generic;
using System.Text;

namespace Airlines.DL.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
