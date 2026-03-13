using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;


namespace WebApplication1
{
    public partial class QLMonhoc : System.Web.UI.Page
    {
        Ketnoi kn = new Ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                hienthi();
                btnsua.Enabled = false;
                if (!String.IsNullOrEmpty(Request.QueryString["mamhs"]))
                {
                    string mamh = Request.QueryString["mamhs"];
                    string sql = "select * from [Monhoc] where MaMH='" + mamh + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtMaMH.Text = dt.Rows[0][0].ToString();
                        txtTenmon.Text = dt.Rows[0][1].ToString(); ;
                        txtSotiet.Text = dt.Rows[0][2].ToString(); ;
                        txtHocphi.Text = dt.Rows[0][3].ToString(); ;

                    }

                    txtMaMH.Enabled = false;
                    btnThem.Enabled = false;
                    btnsua.Enabled = true;

                }
                if (!String.IsNullOrEmpty(Request.QueryString["mamhx"]))
                {
                    string mamh = Request.QueryString["mamhx"];
                    string sql = "delete from [Monhoc] where MaMH='" + mamh + "'";
                    SqlCommand cmd = new SqlCommand(sql, kn.con);
                    kn.con.Open();
                    cmd.ExecuteNonQuery();
                    kn.con.Close();
                    // hienthi();
                    Response.Redirect("QLMonhoc.aspx");
                }
            }
        }
        void hienthi()
        {
            string sql = "select* from [Monhoc]";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rpMH.DataSource = dt;
            rpMH.DataBind();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string mamh = txtMaMH.Text;
            string tenmh = txtTenmon.Text;
            string sotiet = txtSotiet.Text;
            string hocphi = txtHocphi.Text;

            string checkus = "select * from [Monhoc] where MaMH='" + mamh + "'";
            SqlDataAdapter da = new SqlDataAdapter(checkus, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                Response.Write("<script>alert('MaMH đã tồn tại');</script>");
            else
            {

                string sql = "insert into [Monhoc](MaMH,TenMH,Sotiet,Hocphi) values('" + mamh + "',N'" + tenmh + "','" + sotiet + "','" + hocphi + "')";
                SqlCommand cmd = new SqlCommand(sql, kn.con);
                kn.con.Open();
                cmd.ExecuteNonQuery();
                kn.con.Close();
                hienthi();
            }
        }

        protected void btnsua_Click(object sender, EventArgs e)
        {

            string mamh = txtMaMH.Text;
            string tenmh = txtTenmon.Text;
            string sotiet = txtSotiet.Text;
            string hocphi = txtHocphi.Text;
            string sql = "update [Monhoc] set TenMH=N'" + tenmh + "', Sotiet='" + sotiet + "', Hocphi=N'" + hocphi + "' where MaMH='" + mamh + "'";
            SqlCommand cmd = new SqlCommand(sql, kn.con);
            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();
            hienthi();



            Response.Redirect("QLMonhoc.aspx");


        }
    }
}