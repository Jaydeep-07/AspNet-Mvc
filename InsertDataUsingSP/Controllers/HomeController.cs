using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace InsertDataUsingSP.Controllers
{
    public class HomeController : Controller
    {
        //
        public ActionResult SaveData()
        {
            ViewBag.result = "";
            return View();
        }
        [HttpPost]
        public ActionResult SaveData(string rollno, string sname, string fname, string mname)
        {
            String constring = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "StudentDataInsert"; ;
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@rollno", Convert.ToInt16(rollno));
            com.Parameters.AddWithValue("@sname", sname);
            com.Parameters.AddWithValue("@fname", fname);
            com.Parameters.AddWithValue("@mname", mname);
            com.ExecuteNonQuery();
            sqlcon.Close();
            ViewBag.result = "Record Has Been Saved Successfully";
            return View();
        }


    }
}