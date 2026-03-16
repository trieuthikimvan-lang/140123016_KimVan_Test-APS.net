using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using Microsoft.SqlServer.Server;

namespace WebApplication1.Admin
{
    public partial class QLDiem : System.Web.UI.Page
    {
        Ketnoi kn = new Ketnoi();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                hienthi();
                loadHV();
                loadMH();
            }

            txtusername.Text = Session["user"].ToString();
        }

        void hienthi()
        {
            string sql = "select * from KetQua";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvDiem.DataSource = dt;
            gvDiem.DataBind();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string mahv = ddlHV.SelectedValue;
            string mamh = ddlMH.SelectedValue;
            string diem = txtdiem.Text;
            string username = Session["user"].ToString();
            if (Session["user"] != null)
            {
                username = Session["user"].ToString();
            }
            string checkus = "select * from Ketqua where MaHV='" + mahv +
                "' and MaMH='" + mamh +
                "' and Username='" + username + "'";
            SqlDataAdapter da = new SqlDataAdapter(checkus, kn.con);
            DataTable dt = new DataTable();
            if (dt.Rows.Count == 0)
            {
                string sql = "insert into KetQua values('" + mahv + "','" + mamh + "','" + diem + "','" + username + "')";
                SqlCommand cmd = new SqlCommand(sql, kn.con);

                kn.con.Open();
                cmd.ExecuteNonQuery();
                kn.con.Close();
            }

            hienthi();
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            string mahv = ddlHV.SelectedValue;
            string mamh = ddlMH.SelectedValue;
            string diem = txtdiem.Text;
            string username = txtusername.Text;

            string sql = "update KetQua set Diem='" + diem + "' where MaHV='" + mahv + "' and MaMH='" + mamh + "' and Username='" + username + "'";

            SqlCommand cmd = new SqlCommand(sql, kn.con);

            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();

            hienthi();
        }

        protected void gvDiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlHV.Text = gvDiem.SelectedRow.Cells[2].Text;
            ddlMH.Text = gvDiem.SelectedRow.Cells[3].Text;
            txtdiem.Text = gvDiem.SelectedRow.Cells[4].Text;
            txtusername.Text = gvDiem.SelectedRow.Cells[5].Text;

            btnThem.Enabled = false;
        }

        protected void gvDiem_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            string mahv = gvDiem.DataKeys[e.RowIndex].Values["MaHV"].ToString();
            string mamh = gvDiem.DataKeys[e.RowIndex].Values["MaMH"].ToString();
            string username = gvDiem.DataKeys[e.RowIndex].Values["Username"].ToString();

            string sql = "delete from KetQua where MaHV='" + mahv + "' and MaMH='" + mamh + "' and Username='" + username + "'";

            SqlCommand cmd = new SqlCommand(sql, kn.con);

            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();

            hienthi();
        }

        void loadHV()
        {
            string sql = "select MaHV from HocVien";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlHV.DataSource = dt;
            ddlHV.DataTextField = "MaHV";
            ddlHV.DataValueField = "MaHV";
            ddlHV.DataBind();
        }

        void loadMH()
        {
            string sql = "select MaMH from MonHoc";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlMH.DataSource = dt;
            ddlMH.DataTextField = "MaMH";
            ddlMH.DataValueField = "MaMH";
            ddlMH.DataBind();
        }

        void timkiem(string keyword)
        {
            string sql = "select * from KetQua where MaHV like '%" + keyword + "%'";

            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            gvDiem.DataSource = ds;
            gvDiem.DataBind();
        }

        protected void btntim_Click(object sender, EventArgs e)
        {
            timkiem(txttim.Text);
        }
    }
}