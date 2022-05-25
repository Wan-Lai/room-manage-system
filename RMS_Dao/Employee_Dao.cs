using RMS_Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RMS_Dao
{
    public class Employee_Dao
    {

        // 添加用户
        public static int addEmployee(Employee employee)
        {
            // 编号 姓名 密码 性别 年龄 职位 电话 身份证号
            string sql = "INSERT INTO employee(e_no, e_name, e_password, e_gender, e_age, e_position, e_tel, e_id) VALUES(@no, @name, @password, @gender, @age, @position, @tel, @id)";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@no", employee.EmployeeNo),
                new SqlParameter("@name", employee.EmployeeName),
                new SqlParameter("@password", employee.EmployeePassword),
                new SqlParameter("@gender", employee.EmployeeGender),
                new SqlParameter("@age" ,employee.EmployeeAge),
                new SqlParameter("@position", employee.EmployeePosition),
                new SqlParameter("@tel", employee.EmployeeTel),
                new SqlParameter("@id", employee.EmployeeId)
            };
            return SqlHelper.executeNonQuery(sql, sqlParameters);
        }

        //通过编号删除用户
        public static int deleteEmployee(int no)
        {
            string sql = "DELETE FROM employee WHERE e_no = @no";
            SqlParameter sqlParameter = new SqlParameter("@no", no);
            return SqlHelper.executeNonQuery(sql, sqlParameter);
        }

        // 修改用户信息
        public static int modifyEmployee(int no, Employee employee)
        {
            string sql = "UPDATE employee SET e_name=@name, e_password=@password, e_gender=@gender, e_age=@age, e_position=@position, e_phone=@phone, e_id=@id WHERE e_no=@no";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@name", employee.EmployeeName),
                new SqlParameter("@password", employee.EmployeePassword),
                new SqlParameter("@gender", employee.EmployeeGender),
                new SqlParameter("@age" ,employee.EmployeeAge),
                new SqlParameter("@position", employee.EmployeePosition),
                new SqlParameter("@tel", employee.EmployeeTel),
                new SqlParameter("@id", employee.EmployeeId),
                new SqlParameter("@no", no)
            };
            return SqlHelper.executeNonQuery(sql, sqlParameters);
        }

        // 通过名字查找用户
        public static Employee selectEmployeeByName(string name)
        {
            string sql = "SLELCT * FROM employee WHERE e_name = @name";
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

        // 查询所有员工
        public static List<Employee> selectAllEmployee()
        {
            string sql = "SLELCT * FROM employee";
            SqlParameter sqlParameter = new SqlParameter();
            List<Employee> employees = null;
            using (SqlDataReader sqlDataReader = SqlHelper.executeReader(sql, sqlParameter))
            {
                employees = new List<Employee>();
                while (sqlDataReader.Read())
                {
                    Employee employee = new Employee();
                    // 编号 姓名 密码 性别 年龄 职位 电话 身份证号
                    employee.EmployeeNo = sqlDataReader.GetInt32(0);
                    employee.EmployeeName = sqlDataReader.GetString(1);
                    employee.EmployeePassword = sqlDataReader.GetString(2);
                    employee.EmployeeGender = sqlDataReader.GetInt32(3);
                    employee.EmployeeAge = sqlDataReader.GetInt32(4);
                    employee.EmployeePosition = sqlDataReader.GetInt32(5);
                    employee.EmployeeTel = sqlDataReader.GetString(6);
                    employee.EmployeeId = sqlDataReader.GetString(7);
                    employees.Add(employee);
                }
            }
            return employees;
        }

        /**
         * 登录检测
         *  result: {-1:未查到用户, 0:密码错误, 1:密码正确}
         **/
        public static int checkLogin(string name, string password)
        {
            int rst = 0;
            Employee employee = Employee_Dao.selectEmployeeByName(name);
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
