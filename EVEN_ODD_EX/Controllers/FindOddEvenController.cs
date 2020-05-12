using EVEN_ODD_EX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EVEN_ODD_EX.Controllers
{
    public class FindOddEvenController : Controller
    {
        // GET: FindOddEven
        public ActionResult Index()
        {
            var v = new EvenOdd();
            v.msg = "";
            return View(v);
        }
        [HttpPost]
        public ActionResult Index(String a)
        {
            int num = Convert.ToInt16(a);
            var v = new EvenOdd();
            if ((num % 2) == 0)
            {
                v.msg = "Number is Even";
            }
            else
            {
                v.msg = "Number is Odd";
            }

            return View(v);
        }


	}
}