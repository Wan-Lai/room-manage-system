using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RMS_Dao;

namespace RMS_View
{
    // 实现用户登录检测
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string username = context.Request["username"];
            string password = context.Request["password"];
            switch (Employee_Dao.checkLogin(username, password))
            {
                case -1:
                    context.Response.Write("-1");
                    break;
                case 0:
                    context.Response.Write("0");
                    break;
                case 1:
                    context.Response.Write("<script>alert('登录成功');</script>");
                    // context.Session["UserName"] = username;
                    context.Response.Redirect("/Index.aspx");
                    break;
            } 
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}