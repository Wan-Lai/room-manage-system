using System;
using RMS_Dao;
using RMS_Model;
using System.Collections.Generic;
using System.Text;

namespace RMS_View
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Convert.ToString(Session["UserName"]);
            if ((username == null)||(String.Empty.Equals(username)))
            {
                Response.Write("<script>alert('未登录,请登录后再来');</script>");
                Response.Redirect("/Login.aspx");
            }
            else
            {
                Response.Write("<script>alert('欢迎"+ username +"登录');</script>");

                // Employee emp = Employee_Dao.selectEmployeeByName(username);
                /*int position = emp.EmployeePosition;
                if (position > 0)
                {
                    Index index = new Index();
                    index.showAllEmployee();
                }
                else
                {
                    Response.Write("<script>alert('您的职位是" + emp.getPosition() + ",权限不足。请重新登录。');</script>");
                    Response.Redirect("/Login.aspx");
                }*/
                List<Employee> emps = Employee_Dao.selectAllEmployee();
                StringBuilder sb = new StringBuilder();
                sb.Append("<table border='1'>");
                sb.Append("<tr>");
                sb.Append("<td>编号</td>");
                sb.Append("<td>姓名</td>");
                sb.Append("<td>性别</td>");
                sb.Append("<td>年龄</td>");
                sb.Append("<td>职位</td>");
                sb.Append("<td>电话</td>");
                sb.Append("<td>身份证号</td>");
                sb.Append("</tr>");
                foreach (Employee emp in emps)
                {
                    sb.Append("<tr>");
                    sb.Append("<td>" + emp.EmployeeNo + "</td>");
                    sb.Append("<td>" + emp.EmployeeName + "</td>");
                    sb.Append("<td>" + emp.EmployeeGender + "</td>");
                    sb.Append("<td>" + emp.EmployeeAge + "</td>");
                    sb.Append("<td>" + emp.EmployeePosition + "</td>");
                    sb.Append("<td>" + emp.EmployeeTel + "</td>");
                    sb.Append("<td>" + emp.EmployeeId + "</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                Response.Write(sb.ToString());
            }
        }

   
            
    }
}