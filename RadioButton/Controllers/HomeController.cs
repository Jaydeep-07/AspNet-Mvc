using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RadioButton.Controllers
{
    public class HomeController : Controller
    {
 public ActionResult Index()
        {
            ViewBag.maleoption = "checked";
            ViewBag.femaleoption = "";

            ViewBag.result = "";
            return View();
        }

        [HttpPost]

        public ActionResult Index(string gender)
        {
            ViewBag.result ="You Have Selected "+gender.ToString();
            if(gender=="Male")
            {
                ViewBag.maleoption = "checked";
                ViewBag.femaleoption = "";
            }
            if (gender == "Female")
            {
                ViewBag.maleoption = "";
                ViewBag.femaleoption = "checked";
            }

            return View();
        }
	}
}