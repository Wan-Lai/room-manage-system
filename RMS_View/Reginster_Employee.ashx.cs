using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RMS_Model;
using RMS_Dao;

namespace RMS_View
{
    /// <summary>
    /// Reginster 的摘要说明
    /// </summary>
    public class Reginster_Employee : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string no = context.Request["no"];
            string username = context.Request["username"];
            string password = context.Request["password"];
            int gender = context.Request["gender"] == "man" ? 1 : 0;
            string age = context.Request["age"];
            string position = context.Request["position"];
            string phone = context.Request["phone"];
            string id = context.Request["id"];
            Employee emp = new Employee();
            emp.EmployeeNo = Convert.ToInt32(no);
            emp.EmployeeName = username;
            emp.EmployeePassword = password;
            emp.EmployeeGender = gender;
            emp.EmployeeAge = Convert.ToInt32(age);
            emp.EmployeePosition = Convert.ToInt32(position);
            emp.EmployeeTel = phone;
            emp.EmployeeId = id;
            if (Employee_Dao.addEmployee(emp) == 1)
                context.Response.Write("<script>alert('注册成功');</script>");
            else
                context.Response.Write("<script>alert('注册失败');</script>");
            context.Response.Redirect("index.html");

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