using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace SearchDataApi.Controllers
{
    public class SearchDataController : ApiController
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
        

    }
}
