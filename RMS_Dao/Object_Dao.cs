using RMS_Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RMS_Dao
{
    public class Object_Dao
    {

        // 添加物品
        public static int addObject(RObject mobject)
        {
            // 编号 姓名 数量 价格
            string sql = "INSERT INTO object(o_no, o_name, o_number, o_price) VALUES(@no, @name, @number, @price)";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@no", mobject.ObjectNo),
                new SqlParameter("@name", mobject.ObjectName),
                new SqlParameter("@number", mobject.ObjectNumber),
                new SqlParameter("@price", mobject.ObjectPrice)
            };
            return SqlHelper.executeNonQuery(sql, sqlParameters);
        }

        //通过编号删除物品
        public static int deleteObject(int no)
        {
            string sql = "DELETE FROM object WHERE o_no = @no";
            SqlParameter sqlParameter = new SqlParameter("@no", no);
            return SqlHelper.executeNonQuery(sql, sqlParameter);
        }

        // 修改物品信息
        public static int modifymobject(int no, RObject mobject)
        {
            string sql = "UPDATE object SET o_name=@name, o_number=@number, o_price=@price WHERE o_no=@no";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@name", mobject.ObjectName),
                new SqlParameter("@number", mobject.ObjectNumber),
                new SqlParameter("@price", mobject.ObjectPrice),
                new SqlParameter("@no", no)
            };
            return SqlHelper.executeNonQuery(sql, sqlParameters);
        }

        // 通过名字物品用户
        public static RObject selectObjectByName(string name)
        {
            string sql = "SELECT o_no, o_name, o_number, o_price FROM object WHERE o_name = @name";
            SqlParameter sqlParameter = new SqlParameter("@name", name);
            RObject mobject = null;
            using (SqlDataReader sqlDataReader = SqlHelper.executeReader(sql, sqlParameter))
            {
                if (sqlDataReader.Read())
                {
                    mobject = new RObject();
                    // 编号 姓名 数量 价格
                    mobject.ObjectNo = sqlDataReader.GetInt32(0);
                    mobject.ObjectName = sqlDataReader.GetString(1);
                    mobject.ObjectNumber = sqlDataReader.GetInt32(2);
                    mobject.ObjectPrice = sqlDataReader.GetDouble(3);
                }
            }
            return mobject;
        }

        // 查询所有物品
        public static List<RObject> selectAllObject()
        {
            string sql = "SELECT o_no, o_name, o_number, o_price FROM mobject";
            return sql2list(sql);
        }

        // 查询所有物品
        public static List<RObject> selectAllObjectOrder()
        {
            string sql = "SELECT o_no, o_name, o_number, o_price FROM mobject ORDER BY(o_no)";
            return sql2list(sql);
        }

        // 查询所有物品
        public static List<RObject> selectAllObjectIOrder()
        {
            string sql = "SELECT o_no, o_name, o_number, o_price FROM mobject ORDER BY(o_no) DESC";
            return sql2list(sql);
        }

        // 定义sql转list的方法
        private static List<RObject> sql2list(string sql)
        {
            SqlParameter sqlParameter = new SqlParameter();
            List<RObject> mobjects = null;
            using (SqlDataReader sqlDataReader = SqlHelper.executeReader(sql, null))
            {
                mobjects = new List<RObject>();
                while (sqlDataReader.Read())
                {
                    RObject mobject = new RObject();
                    // 编号 姓名 数量 价格
                    mobject.ObjectNo = sqlDataReader.GetInt32(0);
                    mobject.ObjectName = sqlDataReader.GetString(1);
                    mobject.ObjectNumber = sqlDataReader.GetInt32(2);
                    mobject.ObjectPrice = sqlDataReader.GetDouble(3);
                    mobjects.Add(mobject);
                }
            }
            return mobjects;
        }
    }
}
