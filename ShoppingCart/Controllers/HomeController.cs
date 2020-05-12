using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using ShoppingCart.Models;


namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            String mycon = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
            String myquery = "Select * from ProductDetail";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            ProductDetails pd1 = new ProductDetails();
            List<ProductDetails> productlist = new List<ProductDetails>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ProductDetails pd = new ProductDetails();
                pd.productid = Convert.ToInt32(ds.Tables[0].Rows[i]["productid"].ToString());
                pd.productname = ds.Tables[0].Rows[i]["productname"].ToString();
                pd.price = Convert.ToInt64(ds.Tables[0].Rows[i]["price"].ToString());
                pd.productimage = ds.Tables[0].Rows[i]["productimage"].ToString();
                productlist.Add(pd);
            }
            pd1.productlist = productlist;
            con.Close();
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)Session["buyitems"];
            if (dt1 != null)
            {

                ViewBag.cartnumber = dt1.Rows.Count.ToString();
            }
            else
            {
                ViewBag.cartnumber = "0";
            }

            return View(pd1);
        }


	}
}