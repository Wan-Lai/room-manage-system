using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RMS_Dao;
using RMS_Model;

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
                    Employee employee = Employee_Dao.selectEmployeeByName(username);
                    HttpCookie cookies = new HttpCookie("preEmployee");
                    cookies["username"] = employee.EmployeeName;
                    cookies["position"] = Convert.ToString(employee.EmployeePosition);
                    context.Response.AppendCookie(cookies);
                    context.Response.Write("1");
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