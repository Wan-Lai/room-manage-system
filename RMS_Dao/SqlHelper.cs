using System;
using System.Configuration;
using System.Data.SqlClient;

namespace RMS_Dao
{
    class SqlHelper
    {
        //1.连接字符串
        private static readonly string constr =
        ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;
        //2.执行增删改的
        public static int executeNonQuery(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                //创建执行Sql命令对象
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //3.执行返回单个值的
        public static object executeScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        //4.执行返回SqlDataReader
        public static SqlDataReader executeReader(string sql, params SqlParameter[] pms)
        {
            //创建链接对象
            SqlConnection con = new SqlConnection(constr);
            //创建执行命令对象
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    //打开链接
                    con.Open();
                    //指定操作
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                //报异常时关闭数据库销毁对象
                catch (Exception)
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }
    }
}
