using System;
using System.Data;

namespace RMS_Model
{
    // 客人实体
    public class Guest
    {
        // 客人编号
        public int GuestNo
        {
            set;
            get;
        }

        // 客人姓名
        public string GuestName
        {
            set;
            get;
        }

        // 客人性别
        public int GuestGender
        {
            set;
            get;
        }

        // 客人年龄
        public int GuestAge
        {
            set;
            get;
        }

        // 客人电话号
        public string GuestTel
        {
            set;
            get;
        }

        // 客人身份证
        public string GuestId
        {
            set;
            get;
        }

    }
}
