using System;

namespace RMS_Model
{
    // 定义房间实体
    public class Room
    {
        private string[] STATUS = {"空闲", "已住人", "预约", "维修" };
        private string[] TYPES = {"单人房", "标准房", "豪华房", "商务房" };

        // 房间编号
        public string RoomNo
        {
            set;
            get;
        }

        // 房间价格
        public double RoomPrice
        {
            set;
            get;
        }
        
        // 房间状态
        public int RoomStatu
        {
            set;
            get;
        }

        // 房间类型
        public int RoomType
        {
            set;
            get;
        }

        // 获取当前房间的状态
        public string getStatu()
        {
            return STATUS[RoomStatu];
        }

        // 获取所有状态
        public string[] getAllStatus()
        {
            return STATUS;
        }

        // 获取当前房间的类型
        public string getType()
        {
            return TYPES[RoomType];
        }

        // 获取所有房间类型
        public string[] getAllTypes()
        {
            return TYPES;
        }
    }
}
