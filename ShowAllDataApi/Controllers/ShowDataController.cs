using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace ShowAllDataApi.Controllers
{
    public class ShowDataController : ApiController
    {
        // GET api/showdata
        [HttpGet]
        public string GetAllStudents()
        {
            String mycon = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
            String myquery = "Select * from StudentData";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            //DataTable firstTable = ds.Tables[0];
            return ds.GetXml();

        }

    }
}
