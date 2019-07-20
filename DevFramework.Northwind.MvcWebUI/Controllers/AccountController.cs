using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFramework.Core.CrossCuttingConcerns.Security.Web;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public string Login()
        {
            AuthenticationHelper.CreateAuthCookie(
                new Guid(),"ahmetundemir","ahmetundemir@gmail.com",DateTime.Now.AddDays(15),
                new []{"Admin"},false,"Ahmet","Ündemir");
            return "User is authenticated!";
        }
    }
}