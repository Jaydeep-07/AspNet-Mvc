using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DisplayData.Models;
namespace DisplayData.Controllers
{
    public class CollegeController : Controller
    {
        // GET: College
        public ActionResult DisplayData()
        {
            StudentData s1 = new StudentData
            {
                rollno = 1001,
                sname = "Vijay Sharma",
                fname = "Mohit Sharma",
                mname = "Mamta Sharma"
            };
            ViewData["StudentInfo"] = s1;
            return View();
        }
    }
	
}