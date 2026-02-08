using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        Ketnoi kn = new ketnoi();

        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [obsolete]

        protected System.Void btnLogin_Click(System.Object sender, System.EventArgs e)
        {

            string username = txtUsername.Text;
            string password = kn.Mahoa(txtPassword.Text);
            string sql = "SELECT * FROM tblUser WHERE Username='"+Username+"' AND Password='"+Password+"'";
            sqlDataAdapter adapter = new sqlDataAdapter(sql, kn.con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if(dt.Rows.cout > 0)
            {
                Session["user"] = Username;
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.wirte("<script>alert('Username/Password sai');</script>"); 
            }
        }

    }
}