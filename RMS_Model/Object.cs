using System;

namespace RMS_Model
{
    // 定义物品实体
    class Object
    {
        // 物品编号
        public int ObjectNo
        {
            set;
            get;
        }

        // 物品名称
        public string ObjectName
        {
            set;
            get;
        }

        // 物品数量
        public int ObjectNumber
        {
            set;
            get;
        }

        // 物品价格
        public double ObjectPrice
        {
            set;
            get;
        }
    }
}
