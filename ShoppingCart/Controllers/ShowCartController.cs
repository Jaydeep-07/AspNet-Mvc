using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace ShoppingCart.Controllers
{
    public class ShowCartController : Controller
    {
        //
        // GET: /ShowCart/
        public ActionResult Index()
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)Session["buyitems"];
            if (dt1 != null)
            {

                ViewBag.cartnumber = dt1.Rows.Count.ToString();
            }
            else
            {
                ViewBag.cartnumber = "0";
            }
            return View(dt1);
        }
	}
}