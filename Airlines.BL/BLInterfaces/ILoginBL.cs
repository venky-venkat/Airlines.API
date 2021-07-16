using System;
using System.Collections.Generic;
using System.Text;
using Airlines.BL.DTO;
namespace Airlines.BL.BLInterfaces
{
    public interface ILoginBL
    {
        public LoginDTO Authenticate(LoginDTO l);
    }
}
