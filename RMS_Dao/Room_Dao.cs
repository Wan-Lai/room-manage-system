using RMS_Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RMS_Dao
{
    public class Room_Dao
    {

        // 添加房间
        public static int addRoom(Room room)
        {
            // 编号 价格 状态 类型
            string sql = "INSERT INTO room(r_no, r_price, r_statu, r_type) VALUES(@no, @price, @statu, @type)";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@no", room.RoomNo),
                new SqlParameter("@price", room.RoomPrice),
                new SqlParameter("@statu", room.RoomStatu),
                new SqlParameter("@type", room.RoomType)
            };
            return SqlHelper.executeNonQuery(sql, sqlParameters);
        }

        //通过编号删除房间
        public static int deleteRoom(string no)
        {
            string sql = "DELETE FROM room WHERE r_no = @no";
            SqlParameter sqlParameter = new SqlParameter("@no", no);
            return SqlHelper.executeNonQuery(sql, sqlParameter);
        }

        // 修改房间信息
        public static int modifyRoom(string no, Room room)
        {
            string sql = "UPDATE room SET r_price=@price, r_statu=@statu, r_type=@type WHERE r_no=@no";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@price", room.RoomPrice),
                new SqlParameter("@statu", room.RoomStatu),
                new SqlParameter("@type", room.RoomType),
                new SqlParameter("@no", no)
            };
            return SqlHelper.executeNonQuery(sql, sqlParameters);
        }

        // 通过编号查找房间
        public static Room selectRoomByNo(string no)
        {
            string sql = "SELECT r_no, r_price, r_statu, r_type FROM room WHERE r_no = @no";
            SqlParameter sqlParameter = new SqlParameter("@no", no);
            Room room = null;
            using (SqlDataReader sqlDataReader = SqlHelper.executeReader(sql, sqlParameter))
            {
                if (sqlDataReader.Read())
                {
                    room = new Room();
                    // 编号 价格 状态 类型
                    room.RoomNo = sqlDataReader.GetString(0);
                    room.RoomPrice = sqlDataReader.GetDouble(1);
                    room.RoomStatu = sqlDataReader.GetInt32(2);
                    room.RoomType = sqlDataReader.GetInt32(3);
                }
            }
            return room;
        }

        // 查询所有房间
        public static List<Room> selectAllRoom()
        {
            string sql = "SELECT r_no, r_price, r_statu, r_type FROM room";
            SqlParameter sqlParameter = new SqlParameter();
            List<Room> rooms = null;
            using (SqlDataReader sqlDataReader = SqlHelper.executeReader(sql, sqlParameter))
            {
                rooms = new List<Room>();
                while (sqlDataReader.Read())
                {
                    Room room = new Room();
                    // 编号 价格 状态 类型
                    room.RoomNo = sqlDataReader.GetString(0);
                    room.RoomPrice = sqlDataReader.GetDouble(1);
                    room.RoomStatu = sqlDataReader.GetInt32(2);
                    room.RoomType = sqlDataReader.GetInt32(3);
                    rooms.Add(room);
                }
            }
            return rooms;
        }
    }
}
