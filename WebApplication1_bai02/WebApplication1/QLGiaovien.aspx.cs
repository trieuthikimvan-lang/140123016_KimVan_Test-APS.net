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

namespace WebApplication1
{
    public partial class QLGiaovien : System.Web.UI.Page
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
            }
            btnsua.Enabled = false;

        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string magv = txtMaGV.Text;
            string ho = txtHo.Text;
            string ten = txtTen.Text;
            string diachi = txtDiachi.Text;
            // Kiểm tra nếu Magv đã tồn tại rồi thì hong cho thêm
            string checkus = "select * from tblGiaovien where MaGV='" + magv + "'";
            SqlDataAdapter da = new SqlDataAdapter(checkus, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0) // username đã tồn tại
                Response.Write("<script>alert('MaGV đã tồn tại');</script>");
            else
            {

                string sql = "insert into tblGiaovien(MaGV,HoGV,TenGV,DiaChi) values('" + magv + "',N'" + ho + "',N'" + ten + "',N'" + diachi + "')";
                SqlCommand cmd = new SqlCommand(sql, kn.con);
                kn.con.Open();
                cmd.ExecuteNonQuery();
                kn.con.Close();
                hienthi();
            }


        }
        void hienthi()
        {
            string sql = "select MaGV,HoGV,TenGV,Diachi from tblGiaovien";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvGV.DataSource = ds;
            gvGV.DataBind();
        }

        protected void gvGV_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtMaGV.Text = gvGV.SelectedRow.Cells[2].Text;
            txtHo.Text = HttpUtility.HtmlDecode(gvGV.SelectedRow.Cells[3].Text);
            txtTen.Text = HttpUtility.HtmlDecode(gvGV.SelectedRow.Cells[4].Text);
            txtDiachi.Text = HttpUtility.HtmlDecode(gvGV.SelectedRow.Cells[5].Text);
            txtMaGV.Enabled = false;
            btnThem.Enabled = false;
            btnsua.Enabled = true;

        }

        protected void gvGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string magv = gvGV.DataKeys[e.RowIndex].Values["MaGV"].ToString();
            string sql = "Delete from tblGiaovien where MaGV='" + magv + "'";
            SqlCommand cmd = new SqlCommand(sql, kn.con);
            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();
            hienthi();

        }

        protected void btnsua_Click(object sender, EventArgs e)
        {
            string magv = txtMaGV.Text;
            string ho = txtHo.Text;
            string ten = txtTen.Text;
            string diachi = txtDiachi.Text;
            string sql = "update tblGiaovien set HoGV=N'" + ho + "', TenGV=N'" + ten + "', Diachi=N'" + diachi + "' where MaGV='" + magv + "'";
            SqlCommand cmd = new SqlCommand(sql, kn.con);
            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();
            hienthi();

            btnThem.Enabled = true;
            txtMaGV.Enabled = true;
            txtMaGV.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            txtDiachi.Text = "";

        }

        void timkiem(string keywords)
        {
            string sql = "select MaGV,HoGV,TenGV,Diachi from tblGiaovien where TenGV like '%" + keywords + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvGV.DataSource = ds;
            gvGV.DataBind();
        }

        protected void bttim_Click(object sender, EventArgs e)
        {
            string tengv = txttim.Text;
            timkiem(tengv);
        }

        protected void Btnsua_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
 }

