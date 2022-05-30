using RMS_Dao;
using RMS_Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace RMS_View
{
    /// <summary>
    /// Login_successs 的摘要说明
    /// </summary>
    public class GetInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int pagesize = 5;
            string model = context.Request["model"];
            // type = {all 全部,order 正序,iorder 倒叙, 筛选}
            string type = context.Request["type"];
            string name = context.Request["name"];
            int page = Convert.ToInt32(context.Request["page"]);
            StringBuilder sb = new StringBuilder();
            JavaScriptSerializer json = new JavaScriptSerializer();
            switch (model)
            {
                case "employee":
                    if (name != null)
                    {
                        Employee emp = Employee_Dao.selectEmployeeByName(name);
                        json.Serialize(emp, sb);
                        context.Response.Write(sb.ToString());
                    }
                    List<Employee> employees;
                    switch (type)
                    {
                        case "login":
                            string username = context.Request["username"];
                            string password = context.Request["password"];
                            int empstatu = Employee_Dao.checkLogin(username, password);
                            if ( empstatu == 1)
                            {
                                Employee emp1 = Employee_Dao.selectEmployeeByName(username);
                                string emusername = emp1.EmployeeName;
                                int emposition = emp1.EmployeePosition;
                                HttpCookie cookies = new HttpCookie("preemployee");
                                cookies["username"] = emusername;
                                cookies["position"] = Convert.ToString(emposition);
                                context.Response.SetCookie(cookies);
                            }
                            context.Response.Write(empstatu);
                            break;
                        case "all":
                            employees = Employee_Dao.selectAllEmployee();
                            json.Serialize(employees, sb);
                            context.Response.Write(sb.ToString());
                            break;
                        case "order":
                            employees = Employee_Dao.selectAllEmployeeOrder();
                            json.Serialize(employees, sb);
                            context.Response.Write(sb.ToString());
                            break;
                        case "iorder":
                            employees = Employee_Dao.selectAllEmployeeIOrder();
                            json.Serialize(employees, sb);
                            context.Response.Write(sb.ToString());
                            break;
                        case "page":
                            employees = Employee_Dao.selectAllEmployeeByPage(pagesize, page);
                            json.Serialize(employees, sb);
                            context.Response.Write(sb.ToString());
                            break;
                        case "delete":
                            int no = Convert.ToInt32(context.Request["no"]);
                            int delstatus = Employee_Dao.deleteEmployee(no);
                            context.Response.Write("{status:"+delstatus + "}");
                            break;
                        case "add":
                            string eno = context.Request["no"];
                            string eusername = context.Request["username"];
                            string epassword = context.Request["password"];
                            int egender = context.Request["gender"] == "man" ? 1 : 0;
                            string eage = context.Request["age"];
                            string eposition = context.Request["position"];
                            string ephone = context.Request["phone"];
                            string eid = context.Request["id"];
                            List<Employee> d = new List<Employee>();
                            bool isexist = (Employee_Dao.selectEmployeeByName(eusername)!=null);
                            Employee emp = new Employee();
                            emp.EmployeeNo = Convert.ToInt32(eno);
                            emp.EmployeeName = eusername;
                            emp.EmployeePassword = epassword;
                            emp.EmployeeGender = egender;
                            emp.EmployeeAge = Convert.ToInt32(eage);
                            emp.EmployeePosition = Convert.ToInt32(eposition);
                            emp.EmployeeTel = ephone;
                            emp.EmployeeId = eid;
                            int addstatus = 0;
                            if (isexist)
                            {
                                addstatus = Employee_Dao.modifyEmployee(Convert.ToInt32(eno), emp);
                            }
                            else
                            {
                                addstatus = Employee_Dao.addEmployee(emp);
                            }
                            context.Response.Write("{status:" + addstatus + "}");
                            break;
                    }
                    break;
                case "guest":
                    if (name != null)
                    {
                        Guest gue = Guest_Dao.selectGusetByName(name);
                        json.Serialize(gue, sb);
                        context.Response.Write(sb.ToString());
                    }
                    List<Guest> guests;
                    switch (type)
                    {
                        case "all":
                            guests = Guest_Dao.selectAllGuest();
                            json.Serialize(guests, sb);
                            context.Response.Write(sb.ToString());
                            break;
                        case "order":
                            guests = Guest_Dao.selectAllGuestOrder();
                            json.Serialize(guests, sb);
                            context.Response.Write(sb.ToString());
                            break;
                        case "iorder":
                            guests = Guest_Dao.selectAllGuestIOrder();
                            json.Serialize(guests, sb);
                            context.Response.Write(sb.ToString());
                            break;
                        case "add":
                            string gno = context.Request["no"];
                            string gusername = context.Request["username"];
                            string gpassword = context.Request["password"];
                            int ggender = context.Request["gender"] == "man" ? 1 : 0;
                            string gage = context.Request["age"];
                            string gphone = context.Request["phone"];
                            string gid = context.Request["id"];
                            bool isexist = (Guest_Dao.selectGusetByName(gusername)!= null);
                            Guest gue = new Guest();
                            gue.GuestNo = Convert.ToInt32(gno);
                            gue.GuestName = gusername;
                            gue.GuestGender = ggender;
                            gue.GuestAge = Convert.ToInt32(gage);
                            gue.GuestTel = gphone;
                            gue.GuestId = gid;
                            int addstatus = 0;
                            if (isexist)
                            {
                                addstatus = Guest_Dao.modifyGuest(Convert.ToInt32(gno), gue);
                            }
                            else
                            {
                                addstatus = Guest_Dao.addGuest(gue);
                            }
                            context.Response.Write("{status:" + addstatus + "}");
                            break;
                        case "delete":
                            int no = Convert.ToInt32(context.Request["no"]);
                            int delstatus = Guest_Dao.deleteGuest(no);
                            context.Response.Write("{status:" + delstatus+"}");
                            break;
                    }
                    break;
                case "object":
                    if (name != null)
                    {
                        RObject obj = Object_Dao.selectObjectByName(name);
                        json.Serialize(obj, sb);
                        context.Response.Write(sb.ToString());
                    }
                    List<RObject> objects;
                    switch (type)
                    {
                        case "all":
                            objects = Object_Dao.selectAllObject();
                            json.Serialize(objects, sb);
                            context.Response.Write(sb.ToString());
                            break;
                        case "order":
                            objects = Object_Dao.selectAllObjectOrder();
                            json.Serialize(objects, sb);
                            context.Response.Write(sb.ToString());
                            break;
                        case "iorder":
                            objects = Object_Dao.selectAllObjectIOrder();
                            json.Serialize(objects, sb);
                            context.Response.Write(sb.ToString());
                            break;
                        case "delete":
                            int ono = Convert.ToInt32(context.Request["no"]);
                            int delstatus = Object_Dao.deleteObject(ono);
                            context.Response.Write("{status:" + delstatus + "}");
                            break;
                        case "add":
                            string ono1 = context.Request["no"];
                            string oname = context.Request["oname"];
                            string onumber = context.Request["number"];
                            string oprice = context.Request["price"];
                            bool isexist = (Object_Dao.selectObjectByName(oname) != null);
                            RObject obj = new RObject();
                            obj.ObjectNo = Convert.ToInt32(ono1);
                            obj.ObjectName = oname;
                            obj.ObjectNumber = Convert.ToInt32(onumber);
                            obj.ObjectPrice = Convert.ToDouble(oprice);
                            int addstatus = 0;
                            if (isexist)
                            {
                                addstatus = Object_Dao.modifymobject(Convert.ToInt32(ono1) ,obj);
                            }
                            else
                            {
                                addstatus = Object_Dao.addObject(obj);
                            }
                            context.Response.Write("{status:"+addstatus+"}");
                            break;
                    }
                    break;
                case "room":
                    if (name != null)
                    {
                        Room room = Room_Dao.selectRoomByNo(name);
                        json.Serialize(room, sb);
                        context.Response.Write(sb.ToString());
                    }
                    List<Room> rooms;
                    switch (type)
                    {
                        case "all":
                            rooms = Room_Dao.selectAllRoom();
                            json.Serialize(rooms, sb);
                            context.Response.Write(sb.ToString());
                            break;
                        case "order":
                            rooms = Room_Dao.selectAllRoomOrder();
                            json.Serialize(rooms, sb);
                            context.Response.Write(sb.ToString());
                            break;
                        case "iorder":
                            rooms = Room_Dao.selectAllRoomIOrder();
                            json.Serialize(rooms, sb);
                            context.Response.Write(sb.ToString());
                            break;
                        case "delete":
                            string rno = context.Request["no"];
                            int status = Room_Dao.deleteRoom(rno);
                            context.Response.Write("{status:" + status + "}");
                            break;
                        case "add":
                            string rrno = context.Request["no"];
                            string rprice = context.Request["price"];
                            string rstatu = context.Request["statu"];
                            string rtype = context.Request["rtype"];
                            bool isexist = (Room_Dao.selectRoomByNo(rrno) != null);
                            Room room = new Room();
                            room.RoomNo = rrno;
                            room.RoomPrice = Convert.ToDouble(rprice);
                            room.RoomStatu = Convert.ToInt32(rstatu);
                            room.RoomType = Convert.ToInt32(rtype);
                            int addtatus = 0;
                            if (isexist)
                            {
                                addtatus = Room_Dao.modifyRoom(rrno, room);
                            }
                            else
                            {
                                addtatus = Room_Dao.addRoom(room);
                            }
                            context.Response.Write("{status:" + addtatus + "}");
                            break;
                    }
                    break;
                default:
                    break;
            }
            
            //context.Response.Write(sb.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}