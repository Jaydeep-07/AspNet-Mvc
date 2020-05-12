using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDStudentData.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUDStudentData.Controllers
{
    public class CRUDOperationController : Controller
    {
                // GET: CRUDOperation
        public ActionResult Index()
        {
            ViewBag.searchresult = "";
            ViewBag.updateresult = "";
            StudentData sd = new StudentData();
            sd.rollno = "";
            sd.sname = "";
            sd.fname = "";
            sd.mname = "";
            ViewBag.cancelbutton = "disabled";
            ViewBag.updatebutton = "disabled";
            ViewBag.deletebutton = "disabled";
            ViewBag.savebutton = "disabled";
            ViewBag.searchbutton = "";
            ViewBag.addnewbutton = "";
            return View(sd);
           
        }
        [HttpPost]
        public ActionResult Index(string rollno, string cbutton, string sname, string mname, string fname)
        {
            StudentData sd = new StudentData();
            if (cbutton == "Search")
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
                    ViewBag.updateresult = "Note : You can perform delete or update or cancel operation";
                    ViewBag.cancelbutton = "";
                    ViewBag.updatebutton = "";
                    ViewBag.deletebutton = "";
                    ViewBag.savebutton = "disabled";
                    ViewBag.addnewbutton = "disabled";

                }
                else
                {
                    ViewBag.updateresult = "";
                    ViewBag.searchresult = "Roll Number Has Not Found";
                    ViewBag.cancelbutton = "disabled";
                    ViewBag.updatebutton = "disabled";
                    ViewBag.deletebutton = "disabled";
                    ViewBag.savebutton = "disabled";
                    ViewBag.addnewbutton = "";
                }
                con.Close();


            }
            else if (cbutton == "Update")
            {
                String mycon = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
                String updatedata = "Update StudentData set sname='" + sname + "', fathername='" + fname + "', mothername='" + mname + "' where rollno=" + Convert.ToInt32(rollno);
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
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.addnewbutton = "";
            }
            else if (cbutton == "Cancel")
            {
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.searchbutton = "";
                ViewBag.addnewbutton = "";
                ViewBag.updateresult = "Add New Form and Search Cancelled";
            }
            else if (cbutton == "AddNew")
            {
                ViewBag.cancelbutton = "";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "";
                ViewBag.addnewbutton = "disabled";
                ViewBag.searchbutton = "disabled";
                ViewBag.updateresult = "New Blank Form Has Been Added Successfully";
            }
            else if (cbutton == "Save")
            {
                String mycon = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
                
                String query = "insert into StudentData(rollno,sname,fathername,mothername) values(" + rollno + ",'" + sname + "','" + fname + "','" + mname + "')";
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.searchbutton = "";
                ViewBag.addnewbutton = "";
                ViewBag.updateresult = "New Data Has Been Successfully";
            }
            else if (cbutton == "Delete")
            {
                String mycon = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
                String updatedata = "delete from StudentData where rollno=" + rollno;
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updatedata;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.searchbutton = "";
                ViewBag.addnewbutton = "";
                ViewBag.updateresult = "Data Has Been Deleted Successfully with Rollno "+rollno;
            }




            return View(sd);
        }
    }

	
}