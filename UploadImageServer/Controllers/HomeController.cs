using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UploadImageServer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.uploadresult = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file1)
        {
            string pic = "";
            if (file1 != null)
            {
                pic = System.IO.Path.GetFileName(file1.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/SavedImages"), pic);
                // file is uploaded
                file1.SaveAs(path);

            }
            ViewBag.uploadresult = "File " + pic + " Has Been Uploaded Successfully";
            return View();
        }
    }
}