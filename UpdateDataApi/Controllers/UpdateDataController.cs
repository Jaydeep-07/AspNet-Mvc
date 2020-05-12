using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;


namespace UpdateDataApi.Controllers
{
    public class UpdateDataController : ApiController
    {
        [HttpGet]
        public string GetSearchInfo(string rollno)
        {
            string data = "";
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

                data = ds.Tables[0].Rows[0]["sname"].ToString();
                data = data + "||" + ds.Tables[0].Rows[0]["fathername"].ToString();
                data = data + "||" + ds.Tables[0].Rows[0]["mothername"].ToString();

            }
            else
            {
                data = "notfound";
            }
            con.Close();
            return (data);
        }
        [HttpGet]
        public string GetUpdateData(string updaterollno, string sname, string fname, string mname)
        {
            String mycon = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
            String updatedata = "Update StudentData set sname='" + sname + "', fathername='" + fname + "', mothername='" + mname + "' where rollno=" + Convert.ToInt32(updaterollno);
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = updatedata;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            return "Record with Roll Number " + updaterollno + " Has Been Updated Successfully";
        }

    }
}
