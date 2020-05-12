using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchStudentData.Models;
using System.Data;
using System.Data.SqlClient;

namespace SearchStudentData.Controllers
{
    public class SearchDataController : Controller
    {
        // GET: SearchData
        public ActionResult Index()
        {
            ViewBag.searchresult = "";
            ViewBag.updateresult = "";
            StudentData sd = new StudentData();
            sd.rollno = "";
            sd.sname = "";
            sd.fname = "";
            sd.mname = "";
            return View(sd);
        }
        [HttpPost]
        public ActionResult Index(string rollno,string cbutton,string sname,string mname,string fname)
        {
            StudentData sd = new StudentData();
            if (cbutton=="Search")
            {

                String mycon = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
                String myquery = "Select * from StudentData where rollno=" + Convert.ToInt32(rollno);
                SqlConnection con = new SqlConnection(mycon);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = myquery;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewBag.searchresult = "Roll Number Has Been Found";
                    sd.rollno = rollno;
                    sd.sname = ds.Tables[0].Rows[0]["sname"].ToString();
                    sd.fname = ds.Tables[0].Rows[0]["fathername"].ToString();
                    sd.mname = ds.Tables[0].Rows[0]["mothername"].ToString();

                }
                else
                {
                    ViewBag.searchresult = "Roll Number Has Not Found";

                }
                con.Close();
            }
            else if(cbutton=="Update")
            {
                String mycon = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
                String updatedata = "Update StudentData set sname='" + sname  + "', fathername='" + fname + "', mothername='" + mname + "' where rollno=" + Convert.ToInt32(rollno);
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updatedata;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                sd.rollno = "";
                sd.sname = "";
                sd.fname = "";
                sd.mname = "";
                ViewBag.updateresult = "Data Has Been Updated Successfully with Rollno " + rollno;
            }
            

            
            
            return View(sd);
        }
    }
	
}