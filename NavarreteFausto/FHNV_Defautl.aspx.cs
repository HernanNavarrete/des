using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace NavarreteFausto
{
    public partial class FHNV_Defautl : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Paises;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                refreshdata();
            }
        }

        public void refreshdata()
        {

            con.Open();

            SqlCommand cmd = new SqlCommand("select * from Pais", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();


        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                con.Open();
                DropDownList DropDownList1 = (e.Row.FindControl("DropDownList1") as DropDownList);


                SqlCommand cmd = new SqlCommand("select * from Cuidad", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                DropDownList1.DataSource = dt;

                DropDownList1.DataTextField = "Ciudad";
                DropDownList1.DataValueField = "Cuidad";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("--Select Qualification--", "0"));


            }

        }
    }
}