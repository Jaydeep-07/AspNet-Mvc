using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace LoginLogout.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string uname, string pass)
        {
            String cpassword = "";
            String mycon = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
            SqlConnection scon = new SqlConnection(mycon);
            String myquery = "select * from UserLogin where username='" + uname + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = scon;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                cpassword = ds.Tables[0].Rows[0]["password"].ToString();
                scon.Close();
                if (pass == cpassword)
                {
                    Session["username"] = uname;
                    return RedirectToAction("UserHome", "DashBoard");
                }
                else
                {
                    ViewBag.loginresult = "Invalid Username or Password";
                    return View();
                }
            }
            else
            {
                ViewBag.loginresult = "Invalid Username or Password";
                return View();
            }


        }

    }
}