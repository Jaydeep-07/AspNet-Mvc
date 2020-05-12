using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace ShoppingCart.Controllers
{
    public class AddCartController : Controller
    {
        //
        public ActionResult AddCart(string productid)
        {
            ViewBag.productid = productid;

            if (this.Request.RequestType != "POST")
            {
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("sno");
                dt.Columns.Add("productid");
                dt.Columns.Add("productname");
                dt.Columns.Add("price");
                dt.Columns.Add("productimage");


                if (Request.QueryString["productid"] != null)
                {
                    if (Session["Buyitems"] == null)
                    {

                        dr = dt.NewRow();
                        String mycon = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
                        SqlConnection scon = new SqlConnection(mycon);
                        String myquery = "select * from ProductDetail where productid=" + Request.QueryString["productid"];
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = myquery;
                        cmd.Connection = scon;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dr["sno"] = 1;
                        dr["productid"] = ds.Tables[0].Rows[0]["productid"].ToString();
                        dr["productname"] = ds.Tables[0].Rows[0]["productname"].ToString();
                        dr["productimage"] = ds.Tables[0].Rows[0]["productimage"].ToString();
                        dr["price"] = ds.Tables[0].Rows[0]["price"].ToString();
                        dt.Rows.Add(dr);
                        //GridView1.DataSource = dt;
                        // GridView1.DataBind();
                        Session["buyitems"] = dt;
                    }
                    else
                    {

                        dt = (DataTable)Session["buyitems"];
                        int sr;
                        sr = dt.Rows.Count;

                        dr = dt.NewRow();
                        String mycon = "Data Source=DESKTOP-ND746LH;Initial Catalog=Practice;Integrated Security=True";
                        SqlConnection scon = new SqlConnection(mycon);
                        String myquery = "select * from ProductDetail where productid=" + Request.QueryString["productid"];
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = myquery;
                        cmd.Connection = scon;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dr["sno"] = sr + 1;
                        dr["productid"] = ds.Tables[0].Rows[0]["productid"].ToString();
                        dr["productname"] = ds.Tables[0].Rows[0]["productname"].ToString();
                        dr["productimage"] = ds.Tables[0].Rows[0]["productimage"].ToString();
                        dr["price"] = ds.Tables[0].Rows[0]["price"].ToString();
                        dt.Rows.Add(dr);
                        // GridView1.DataSource = dt;
                        // GridView1.DataBind();
                        Session["buyitems"] = dt;

                    }
                }
                else
                {
                    dt = (DataTable)Session["buyitems"];
                    // GridView1.DataSource = dt;
                    // GridView1.DataBind();

                }
            }

            return RedirectToAction("Index", "ShowCart");
        }
    }
}