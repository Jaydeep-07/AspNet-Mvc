using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace SaveDataApi.Controllers
{
    public class SaveDataController : ApiController
    {
        [HttpGet]
        public string GetSaveintoSQL(string rollno, string sname, string fname, string mname)
        {

            String mycon = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
            String query = "insert into StudentData(rollno,sname,fathername,mothername) values(" + Convert.ToInt32(rollno) + ",'" + sname + "','" + fname + "','" + mname + "')";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            return ("Data Has Been Saved Successfully with Roll Number " + rollno);
        }
    }
}
