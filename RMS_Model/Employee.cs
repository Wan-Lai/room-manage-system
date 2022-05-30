using System;

namespace RMS_Model
{
    // 定义员工实体
    public class Employee
    {
        private string[] POSITIONS = {"保洁员" ,"前台", "服务员", "经理"};
        // 员工编号
        public int EmployeeNo
        {
            set;
            get;
        }

        // 员工姓名
        public string EmployeeName
        {
            set;
            get;
        }

        // 员工密码
        public string EmployeePassword
        {
            set;
            get;
        }

        // 员工性别
        public int EmployeeGender
        {
            set;
            get;
        }

        // 员工年龄
        public int EmployeeAge
        {
            set;
            get;
        }

        // 员工职位
        public int EmployeePosition
        {
            set;
            get;
        }

        // 员工电话
        public string EmployeeTel
        {
            set;
            get;
        }

        // 员工身份证号
        public string EmployeeId
        {
            set;
            get;
        }

        // 获取职位名称
        public string getPosition()
        {
            return POSITIONS[EmployeePosition];
        }

        // 获取所有职位名称
        public string[] getAllPositions()
        {
            return POSITIONS;
        }
    }
}
