using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string userName, string password);
    }
}