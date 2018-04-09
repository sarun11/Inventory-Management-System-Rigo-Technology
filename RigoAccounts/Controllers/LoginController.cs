using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RigoAccounts.BLL.Manager;

namespace RigoAccounts.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            string searchText = "";
            var users = UserManager.GetAllUsers(searchText);

            return View(users);
        }
    }
}