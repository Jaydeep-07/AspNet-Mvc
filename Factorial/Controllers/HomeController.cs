using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Factorial.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string factnumber)
        {
            int number = Convert.ToInt32(factnumber);
            int factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial = factorial * i;

            }
            ViewBag.result = "Factorial of " + factnumber + " is " + factorial.ToString();
            return View();
        }

	}
}