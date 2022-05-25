using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Model;
using System.Data.SqlClient;
using System.Configuration;

namespace RMS_Dao
{
    class Test
    {
        static void Main(string[] args)
        {
            
            Employee employee = new Employee();
            employee.EmployeeNo = 1;
            employee.EmployeeName = "张三";
            employee.EmployeePassword = "1234";
            employee.EmployeeGender = 1;
            employee.EmployeeAge = 21;
            employee.EmployeePosition = 1;
            employee.EmployeeTel = "12312311313";
            employee.EmployeeId = "64131313231231413131";

            Employee_Dao.deleteEmployee(1);
            
        }
    }
}
