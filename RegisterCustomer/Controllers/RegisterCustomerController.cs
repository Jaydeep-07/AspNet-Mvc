using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace RegisterCustomer.Controllers
{
    public class RegisterCustomerController : Controller
    {
        // GET: RegisterCustomer
        public ActionResult SaveData()
        {
            ViewBag.result = "";
            return View();
        }
        [HttpPost]
        public ActionResult SaveData(string cname, string emailid, string contactno, string city, string state, string country)
        {
            String query = "insert into CustomerDetails(customername,emailid,contactno,city,state,country) values('" + cname + "','" + emailid + "','" + contactno + "','" + city + "','" + state + "','" + country + "')";
            String mycon = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            ViewBag.result = "Registration Form Has Been Saved Successfully";
            return View();
        }
    }
}