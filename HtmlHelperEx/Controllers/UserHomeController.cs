using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlHelperEx.Models;

namespace HtmlHelperEx.Controllers
{
    public class UserHomeController : Controller
    {
                // GET: UserHome
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserData ud)
        {
            return View(ud);
        }
    }

	
}