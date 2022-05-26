using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RMS_Dao;

namespace RMS_View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            Username.Text = "";
            Password.Text = "";
            Response.Write("<script>alert('重置成功');</script>");
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string username = Username.Text.Trim();
            string password = Password.Text.Trim();
            switch (Employee_Dao.checkLogin(username, password))
            {
                case -1:
                    Response.Write("<script>alert('账户不存在');</script>");
                    break;
                case 0:
                    Response.Write("<script>alert('密码错误');</script>");
                    break;
                case 1:
                    Response.Write("<script>alert('登录成功');</script>");
                    Session["UserName"] = username;
                    Response.Redirect("/Index.aspx");
                    break;
            }
        }
    }
}