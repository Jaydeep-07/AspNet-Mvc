using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace DisplayImagesFromServer.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {

            String Path = Server.MapPath("~/images/");
            String[] imagefiles = Directory.GetFiles(Path);
            ViewBag.imagearray = imagefiles;
            return View();

        }
	}
}