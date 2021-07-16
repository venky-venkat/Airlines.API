using Airlines.DL.DBcontext;
using Airlines.DL.Interfaces;
using Airlines.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Airlines.DL.Repositories
{
    public class LoginRepository : ILogin
    {
        public readonly AirlinesDBContext _DB;

        public LoginRepository(AirlinesDBContext DB)
        {
            _DB = DB;
        }

        public Login Authenticate(Login l)
        {
            Login ll = new Login();
            ll = _DB.Login.FirstOrDefault(x => x.Username == l.Username && x.Password == l.Password);
            return ll;
        }
    }
}
