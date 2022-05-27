using RMS_Dao;
using RMS_Model;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace RMS_View
{
    /// <summary>
    /// Login_successs 的摘要说明
    /// </summary>
    public class Login_successs : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            List<Employee> employees = Employee_Dao.selectAllEmployee();
            StringBuilder sb = new StringBuilder();
            JavaScriptSerializer json = new JavaScriptSerializer();
            json.Serialize(employees, sb);
            context.Response.Write(sb.ToString());
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