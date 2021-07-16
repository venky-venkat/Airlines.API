using Airlines.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airlines.DL.Interfaces
{
    public interface ILogin
    {
        public Login Authenticate(Login l);
    }
}
