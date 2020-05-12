using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchDataUsingSP.Models;
using System.Data;
using System.Data.SqlClient;


namespace SearchDataUsingSP.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.searchresult = "";
            StudentData sd = new StudentData();
            sd.rollno = "";
            sd.sname = "";
            sd.fname = "";
            sd.mname = "";
            return View(sd);
        }
        [HttpPost]
        public ActionResult Index(string rollno)
        {
            StudentData sd = new StudentData();
            DataSet ds = new DataSet();
            String constring = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "SearchStudent"; ;
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@srollno", Convert.ToInt32(rollno));
            SqlDataReader dr;
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                ViewBag.searchresult = "Roll Number Has Been Found";
                sd.rollno = rollno;
                sd.sname = dr["sname"].ToString();
                sd.fname = dr["fathername"].ToString();
                sd.mname = dr["mothername"].ToString();

            }
            else
            {

                sd.sname = "";
                sd.fname = "";
                sd.mname = "";
                ViewBag.searchresult = "Roll Number Not Found";
            }


            sqlcon.Close();


            return View(sd);
        }

    }
}