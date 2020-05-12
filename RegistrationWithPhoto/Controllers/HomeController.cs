using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace RegistrationWithPhoto.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            ViewBag.result = "";
            return View();
        }


        [HttpPost]


        public ActionResult Index(HttpPostedFileBase file1, string rollno, string sname, string fname, string course)
        {
            string pic = "";
            if (file1 != null)
            {
                pic = System.IO.Path.GetFileName(file1.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/SavedImages"), pic);
                // file is uploaded
                file1.SaveAs(path);
                string imagelink = "SavedImages/" + pic;
                String query = "insert into RegistraionDetails(rollno,sname,fname,class,studentphoto) values(" + Convert.ToInt16(rollno) + ",'" + sname + "','" + fname + "','" + course + "','" + imagelink + "')";
                String mycon = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

            }

            ViewBag.result = "Student Has Been Registered Successfully, Thanks for Registration";
            return View();
        }

    }
}