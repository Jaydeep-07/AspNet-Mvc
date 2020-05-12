using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SumApiJQuery.Controllers
{
    public class FindSumController : Controller
    {

        [HttpGet]
        public string GetNumbers(string firstnumber, string secondnumber)
        {
            int c = Convert.ToInt16(firstnumber) + Convert.ToInt16(secondnumber);
            return (c.ToString());
        }
    }
}