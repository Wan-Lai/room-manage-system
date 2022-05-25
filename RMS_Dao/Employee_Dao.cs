using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Model;

namespace RMS_Dao
{
    class UserLogin_Dao
    {

        // 添加用户
        public static int addEmployee(Employee employee)
        {
            // 编号 姓名 密码 性别 年龄 职位 电话 身份证号
            string sql = "INSERT INTO EMPLOYEE(e_no, e_name, e_password, e_gender, e_age, e_position, e_phone, e_id) VALUES(@no, @name, @password, @gender, @age, @position, @phone, @id)";
            SqlParameter sqlParameter = new SqlParameter("@no", employee.EmployeeNo);


            return 0;
        }

        // 查找用户
        public static Employee selectEmployeeByName(string name)
        {
            string sql = "SLELCT * FROM EMPLOYEE WHERE e_name = @name";
            SqlParameter sqlParameter = new SqlParameter("@name", name);
            Employee employee = null;
            using (SqlDataReader sqlDataReader = SqlHelper.executeReader(sql, sqlParameter))
            {
                if (sqlDataReader.Read())
                {
                    employee = new Employee();
                    // 编号 姓名 密码 性别 年龄 职位 电话 身份证号
                    employee.EmployeeNo = sqlDataReader.GetInt32(0);
                    employee.EmployeeName = sqlDataReader.GetString(1);
                    employee.EmployeePassword = sqlDataReader.GetString(2);
                    employee.EmployeeGender = sqlDataReader.GetInt32(3);
                    employee.EmployeeAge = sqlDataReader.GetInt32(4);
                    employee.EmployeePosition = sqlDataReader.GetInt32(5);
                    employee.EmployeeTel = sqlDataReader.GetString(6);
                    employee.EmployeeId = sqlDataReader.GetString(7);
                }
            }
            return employee;
        }

        /**
         * 登录检测
         *  result: {-1:未查到用户, 0:密码错误, 1:密码正确}
         **/
        public static int checkLogin(string name, string password)
        {
            int rst = 0;
            Employee employee = UserLogin_Dao.selectEmployeeByName(name);
            if (employee == null)
            {
                rst = -1;
            }
            else
            {
                if (password.Equals(employee.EmployeePassword))
                {
                    rst = 1;
                }
                else
                {
                    rst = 0;
                }
            }
            return rst;
        }
    }
}
