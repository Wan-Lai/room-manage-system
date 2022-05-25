using System;
using RMS_Model;

namespace RMS_Dao
{
    class Test
    {
        static void Main(string[] args)
        {
            
            Employee employee = new Employee();
            employee.EmployeeNo = 3;
            employee.EmployeeName = "张三四";
            employee.EmployeePassword = "1234";
            employee.EmployeeGender = 1;
            employee.EmployeeAge = 21;
            employee.EmployeePosition = 1;
            employee.EmployeeTel = "12312311313";
            employee.EmployeeId = "64131313231231413131";

            // 添加员工
            // Console.WriteLine("执行结果:{0}", Employee_Dao.addEmployee(employee));
            // 删除员工
            // Console.WriteLine("执行结果:{0}", Employee_Dao.deleteEmployee(2));
            // 修改员工
            // Console.WriteLine("执行结果:{0}", Employee_Dao.modifyEmployee(1,employee));
            // 查询员工
            // List<Employee> employees = Employee_Dao.selectAllEmployee();
            // Employee emp = Employee_Dao.selectEmployeeByName("张三");
            // Console.WriteLine("id:{0} tel:{1}", emp.EmployeeId, emp.EmployeeTel);
            /* foreach(Employee emp in employees)
            {
                Console.WriteLine("id:{0} name:{1}", emp.EmployeeId, emp.EmployeeName);
            }*/


            Guest guest = new Guest();
            guest.GuestNo = 3;
            guest.GuestName = "张三一";
            guest.GuestGender = 1;
            guest.GuestAge = 21;
            guest.GuestTel = "12312311313";
            guest.GuestId = "64131313231231413131";
            // 添加客人
            // Console.WriteLine("执行结果:{0}", Guest_Dao.addGuest(guest));
            // 删除客人
            // Console.WriteLine("执行结果:{0}", Guest_Dao.deleteGuest(2));
            // 修改客人
            // Console.WriteLine("执行结果:{0}", Guest_Dao.modifyGuest(1,guest));
            // 查询客人
            // List<Guest> guests = Guest_Dao.selectAllGuest();
            // Guest gue = Guest_Dao.selectGusetByName("张三");
            // Console.WriteLine("id:{0} tel:{1}", gue.GuestId, gue.GuestTel);
            /*foreach(Guest gue in guests)
            {
                Console.WriteLine("id:{0} name:{1}", gue.GuestId, gue.GuestName);
            }*/


            RObject mobjcet = new RObject();
            mobjcet.ObjectNo = 3;
            mobjcet.ObjectName = "牙刷套";
            mobjcet.ObjectNumber = 20;
            mobjcet.ObjectPrice = 20.00;
            // 添加物品
            // Console.WriteLine("执行结果:{0}", Object_Dao.addObject(mobjcet));
            // 删除物品
            // Console.WriteLine("执行结果:{0}", Object_Dao.deleteObject(2));
            // 修改物品
            // Console.WriteLine("执行结果:{0}", Object_Dao.modifymobject(1, mobjcet));
            // 查询物品
            // List<RObject> objs = Object_Dao.selectAllObject();
            // RObject obj = Object_Dao.selectObjectByName("牙刷");
            // Console.WriteLine("id:{0} tel:{1}", obj.ObjectName, obj.ObjectNumber);
            /* foreach(RObject obj in objs)
            {
                Console.WriteLine("id:{0} name:{1}", obj.ObjectName, obj.ObjectNumber);
            }*/

            Room room = new Room();
            room.RoomNo = "A001";
            room.RoomPrice = 150.00;
            room.RoomStatu = 0;
            room.RoomType = 1;
            // 添加房间
            // Console.WriteLine("执行结果:{0}", Room_Dao.addRoom(room));
            // 删除房间
            // Console.WriteLine("执行结果:{0}", Room_Dao.deleteRoom("A002"));
            // 修改房间
            // Console.WriteLine("执行结果:{0}", Room_Dao.modifyRoom("A001", room));
            // 查询房间
            // List<Room> rooms = Room_Dao.selectAllRoom();
            Room mroom = Room_Dao.selectRoomByNo("A003");
            Console.WriteLine("id:{0} tel:{1}", mroom.RoomNo, mroom.RoomPrice);
            /* foreach(RObject obj in objs)
            {
                Console.WriteLine("id:{0} name:{1}", obj.ObjectName, obj.ObjectNumber);
            }*/

        }
    }
}
