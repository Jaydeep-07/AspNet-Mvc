using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LargestNo.Models;

namespace LargestNo.Controllers
{
    public class LargestNumberController : Controller
    {
        // GET: LargestNumber
        public ActionResult Index()
        {
            var r = new LargerData();
            r.result = "";
            return View(r);
        }
        [HttpPost]
        public ActionResult Index(String a, String b)
        {
            var r = new LargerData();
            int num1 = Convert.ToInt16(a);
            int num2 = Convert.ToInt16(b);
            if( num1 == num2)
            {
                r.result="Both are equal";
            }
            else if  (num1 > num2)
            {
                r.result = "Largest Number is " + num1;
            }
            else
            {
                r.result = "Largest Number is " + num2;
            }

            return View(r);
        }
    }
}