using RMS_Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RMS_Dao
{
    public class Guest_Dao
    {

        // 添加用户
        public static int addGuest(Guest guest)
        {
            // 编号 姓名 性别 年龄 电话 身份证号
            string sql = "INSERT INTO Guest(g_no, g_name, g_gender, g_age, g_tel, g_id) VALUES(@no, @name, @gender, @age, @tel, @id)";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@no", guest.GuestNo),
                new SqlParameter("@name", guest.GuestName),
                new SqlParameter("@gender", guest.GuestGender),
                new SqlParameter("@age" ,guest.GuestAge),
                new SqlParameter("@tel", guest.GuestTel),
                new SqlParameter("@id", guest.GuestId)
            };
            return SqlHelper.executeNonQuery(sql, sqlParameters);
        }

        //通过编号删除用户
        public static int deleteGuest(int no)
        {
            string sql = "DELETE FROM Guest WHERE g_no = @no";
            SqlParameter sqlParameter = new SqlParameter("@no", no);
            return SqlHelper.executeNonQuery(sql, sqlParameter);
        }

        // 修改用户信息
        public static int modifyGuest(int no, Guest guest)
        {
            string sql = "UPDATE Guest SET g_name=@name, g_gender=@gender, g_age=@age, g_tel=@tel, g_id=@id WHERE g_no=@no";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@name", guest.GuestName),
                new SqlParameter("@gender", guest.GuestGender),
                new SqlParameter("@age" ,guest.GuestAge),
                new SqlParameter("@tel", guest.GuestTel),
                new SqlParameter("@id", guest.GuestId),
                new SqlParameter("@no", no)
            };
            return SqlHelper.executeNonQuery(sql, sqlParameters);
        }

        // 通过名字查找用户
        public static Guest selectGusetByName(string name)
        {
            string sql = "SELECT g_no, g_name, g_gender, g_age, g_tel, g_id FROM Guest WHERE g_name = @name";
            SqlParameter sqlParameter = new SqlParameter("@name", name);
            Guest guest = null;
            using (SqlDataReader sqlDataReader = SqlHelper.executeReader(sql, sqlParameter))
            {
                if (sqlDataReader.Read())
                {
                    guest = new Guest();
                    // 编号 姓名 性别 年龄 电话 身份证号
                    guest.GuestNo = sqlDataReader.GetInt32(0);
                    guest.GuestName = sqlDataReader.GetString(1);
                    guest.GuestGender = sqlDataReader.GetInt32(2);
                    guest.GuestAge = sqlDataReader.GetInt32(3);
                    guest.GuestTel = sqlDataReader.GetString(4);
                    guest.GuestId = sqlDataReader.GetString(5);
                }
            }
            return guest;
        }

        // 查询所有员工
        public static List<Guest> selectAllGuest()
        {
            string sql = "SELECT g_no, g_name, g_gender, g_age, g_tel, g_id FROM Guest";
            return sql2list(sql);
        }
        // 查询所有员工
        public static List<Guest> selectAllGuestOrder()
        {
            string sql = "SELECT g_no, g_name, g_gender, g_age, g_tel, g_id FROM Guest ORDER BY(g_no)";
            return sql2list(sql);
        }
        // 查询所有员工
        public static List<Guest> selectAllGuestIOrder()
        {
            string sql = "SELECT g_no, g_name, g_gender, g_age, g_tel, g_id FROM Guest ORDER BY(g_no) DESC";
            return sql2list(sql);
        }

        // 通过页面查询
        public static List<Guest> selectGuestByPage(int pagesize, int page)
        {
            string sql = "SELECT TOP " + pagesize + " * FROM Guest WHERE g_no NOT IN(SELECT TOP " + (page - 1) * pagesize + " g_no FROM Guest ORDER BY g_no) ORDER BY g_no";
            return sql2list(sql);
        }

        private static List<Guest> sql2list(string sql)
        {
            List<Guest> guests = null;
            using (SqlDataReader sqlDataReader = SqlHelper.executeReader(sql, null))
            {
                guests = new List<Guest>();
                while (sqlDataReader.Read())
                {
                    Guest guest = new Guest();
                    // 编号 姓名 性别 年龄 电话 身份证号
                    guest.GuestNo = sqlDataReader.GetInt32(0);
                    guest.GuestName = sqlDataReader.GetString(1);
                    guest.GuestGender = sqlDataReader.GetInt32(2);
                    guest.GuestAge = sqlDataReader.GetInt32(3);
                    guest.GuestTel = sqlDataReader.GetString(4);
                    guest.GuestId = sqlDataReader.GetString(5);
                    guests.Add(guest);
                }
            }
            return guests;
        }
    }
}
