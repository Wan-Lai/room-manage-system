var employee_position = 0;
var EMPLOYEE_POSITIONS = ["保洁员", "前台", "服务员", "经理"];
var ROOM_STATUS = ["空闲", "已住人", "预约", "维修"];
var ROOM_TYPES = ["单人房", "标准房", "豪华房", "商务房"];
window.onload = function () {
    var cookies = document.cookie;
    var cookie_employee = document.cookie.split("preemployee=")[1];
    var employee_attrs = cookie_employee.split("&");
    console.log(employee_attrs);
    console.log("employee_attrs:" + employee_attrs);
    var employee_username = employee_attrs[0];
    employee_position = employee_attrs[1];
    var employee_username_length = employee_username.length;
    var employee_position_length = employee_position.length;
    employee_username = employee_username.substr(9, employee_username_length - 1);
    employee_position = employee_position.substr(9, employee_position_length - 1);
    console.log("欢迎" + EMPLOYEE_POSITIONS[employee_position] + ":" + employee_username + "登录");
    console.log("position=" + employee_position);
    document.getElementById("cookie_username").innerHTML = EMPLOYEE_POSITIONS[employee_position] + ":" + employee_username;
    
    myAjax("model=employee&type=page&page=1", "employee");

}

function ocDetail(detail) {
    var main_left = document.getElementsByClassName("main-left")[0];
    var main_right = document.getElementsByClassName("main-right")[0];
    var label_flag = document.getElementById("detail-flag");
    if (label_flag.textContent == "<") {
        main_left.style.width = "0";
        main_left.style.display = "none";
        label_flag.innerHTML = ">";
        detail.style.left = "0";
    } else {
        main_left.style.width = "20%";
        label_flag.innerHTML = "<";
        detail.style.left = "20%";
        main_left.style.display = "block";
    }
}

function result2employee(result, employee_position) {
    result = JSON.parse(result);
    console.log(result);
    var count = 0;
    var str = "";
    str += "<tr>";
    str += "<td></td>";
    str += "<td colspan=2><input type='button' onclick='javascript:document.getElementsByClassName(\"dialog-reginster-employee\")[0].style.display=\"block\"' value='添加'/></td>";
    str += "<td colspan=2><input type='button' value='删除'/></td>";
    str += "<td colspan=5><input type='text' placeholder='请输入姓名' id='searchname'/><input type='button' value='搜索' onclick='searchByName(\"employee\")'/></td>";
    str += "</tr>";
    str += "<tr>";
    str += "<th><input type='checkbox' name='checkname' id='fcheckbox' onclick='checkAll(this)'/></th>";
    str += "<th onclick='changeOrder(this,\"employee\")'>编号</th>";
    str += "<th>姓名</th>";
    str += "<th>密码</th>";
    str += "<th>性别</th>";
    str += "<th>年龄</th>";
    str += "<th>职位</th>";
    str += "<th>电话</th>";
    str += "<th>身份证号</th>";
    str += "<th>操作</th>";
    str += "</tr>";
    if (result != null) {
        if (result.length) {
            for (var i = 0; i < result.length; i++) {
                var emp = result[i];
                var no = emp.EmployeeNo;
                var name = emp.EmployeeName;
                var password = emp.EmployeePassword;
                var gender = emp.EmployeeGender;
                var age = emp.EmployeeAge;
                var position = emp.EmployeePosition;
                var tel = emp.EmployeeTel;
                var id = emp.EmployeeId;
                if (result[i].EmployeePosition <= employee_position) {
                    str += "<tr>";
                    str += "<td><input type='checkbox' name='checkname' class='scheckbox' lang='" + no + "'/></td>"
                    str += "<td>" + no + "</td>";
                    str += "<td>" + name + "</td>";
                    str += "<td>" + password + "</td>";
                    str += "<td>" + gender + "</td>";
                    str += "<td>" + age + "</td>";
                    str += "<td>" + EMPLOYEE_POSITIONS[position] + "</td>";
                    str += "<td>" + tel + "</td>";
                    str += "<td>" + id + "</td>";
                    str += "<td><input type='button' value='删除' onclick='deleteEmployee(" + no + ")'/><input type='button' value='修改' onclick='modifyEmployee(" + name + ")'/></td>";
                    str += "</tr>";
                    count++;
                }
            }
        } else {
            if (result.EmployeePosition <= employee_position) {
                str += "<tr>";
                str += "<td><input type='checkbox' name='checkname'/></td>";
                str += "<td>" + result.EmployeeNo + "</td>";
                str += "<td>" + result.EmployeeName + "</td>";
                str += "<td>" + result.EmployeePassword + "</td>";
                str += "<td>" + result.EmployeeGender + "</td>";
                str += "<td>" + result.EmployeeAge + "</td>";
                str += "<td>" + EMPLOYEE_POSITIONS[result.EmployeePosition] + "</td>";
                str += "<td>" + result.EmployeeTel + "</td>";
                str += "<td>" + result.EmployeeId + "</td>";
                str += "<td><input type='button' value='删除' onclick='deleteEmployee(" + no + ")'/><input type='button' value='修改' onclick='modifyEmployee(" + no + ")'/></td>";
                str += "</tr>";
            } else {
                alert("权限不足，无法查看。");
            }
        }
        str += "<tr>";
        str += "<td colspan=2></td>";
        str += "<td colspan=5>";
        for (var i = 0; i < count / 5; i++) {
            str += "<span style='border:1px solid red;'>" + (i + 1) + "</span>";
        }
        str += "</td>";
        str += "<td colspan=3></td>";
        str += "</tr>";
    }
    return str;
}

// 返回值转guest字符串
function result2guest(result) {
    var count = 0;
    result = JSON.parse(result);
    console.log(result);
    var str = "";
    str += "<tr>";
    str += "<td colspan=2><input type='button' onclick='javascript:document.getElementsByClassName(\"dialog-reginster-guest\")[0].style.display=\"block\"' value='添加'/></td>";
    str += "<td colspan=2></td>";
    str += "<td colspan=4><input type='text' placeholder='请输入姓名' id='searchname'/><input type='button' value='搜索' onclick='searchByName(\"guest\")'/></td>";
    str += "</tr>";
    str += "<tr>";
    str += "<th><input type='checkbox' name='checkname'/></th>";
    str += "<th onclick='changeOrder(this, \"guest\")'>编号</th>";
    str += "<th>姓名</th>";
    str += "<th>性别</th>";
    str += "<th>年龄</th>";
    str += "<th>电话</th>";
    str += "<th>身份证号</th>";
    str += "<th>操作</th>"
    str += "</tr>";
    if (result != null) {
        if (result.length) {
            for (var i = 0; i < result.length; i++) {
                var gue = result[i];
                var no = gue.GuestNo;
                var name = gue.GuestName;
                var gender = gue.GuestGender;
                var age = gue.GuestAge;
                var tel = gue.GuestTel;
                var id = gue.GuestId;
                str += "<tr>";
                str += "<td><input type='checkbox' name='checkname'/></td>"
                str += "<td>" + no + "</td>";
                str += "<td>" + name + "</td>";
                str += "<td>" + gender + "</td>";
                str += "<td>" + age + "</td>";
                str += "<td>" + tel + "</td>";
                str += "<td>" + id + "</td>";
                str += "<td><input type='button' value='删除' onclick='deleteGuest(" + no + ")'/><input type='button' value='修改' onclick='modifyGuest(" + no + ")'/></td>";
                str += "</tr>";
                count++;
            }
        } else {
            str += "<tr>";
            str += "<td><input type='checkbox' name='checkname'/></td>"
            str += "<td>" + result.GuestNo + "</td>";
            str += "<td>" + result.GuestName + "</td>";
            str += "<td>" + result.GuestGender + "</td>";
            str += "<td>" + result.GuestAge + "</td>";
            str += "<td>" + result.GuestTel + "</td>";
            str += "<td>" + result.GuestId + "</td>";
            str += "<td><input type='button' value='删除' onclick='deleteGuest(" + no + ")'/><input type='button' value='修改' onclick='modifyGuest(" + no + ")'/></td>";
            str += "</tr>";
        }
        str += "<tr>";
        str += "<td colspan=2></td>";
        str += "<td colspan=3>";
        for (var i = 0; i < count / 5; i++) {
            str += "<span style='border:1px solid red;'>" + i + "</span>";
        }
        str += "</td>";
        str += "<td colspan=3></td>";
        str += "</tr>";
    }
    return str;
}

// 返回值转room字符串
function result2room(result) {
    var count = 0;
    result = JSON.parse(result);
    console.log(result);
    var str = "";
    str += "<tr>";
    str += "<td colspan=2><input type='button' onclick='javascript:document.getElementsByClassName(\"dialog-reginster-room\")[0].style.display=\"block\"' value='添加'/></td>";
    str += "<td colspan=1></td>";
    str += "<td colspan=3><input type='text' placeholder='请输入房号' id='searchname'/><input type='button' value='搜索' onclick='searchByName(\"room\")'/></td>";
    str += "</tr>";
    str += "<tr>";
    str += "<td><input type='checkbox' name='checkname'/></td>"
    str += "<th onclick='changeOrder(this, \"room\")'>编号</th>";
    str += "<th>价格</th>";
    str += "<th>状态</th>";
    str += "<th>类型</th>";
    str += "<th>操作</th>";
    str += "</tr>";
    if (result != null) {
        if (result.length) {
            for (var i = 0; i < result.length; i++) {
                var room = result[i];
                var no = room.RoomNo;
                var price = room.RoomPrice;
                var state = room.RoomStatu;
                var type = room.RoomType;
                str += "<tr>";
                str += "<td><input type='checkbox' name='checkname'/></td>"
                str += "<td>" + no + "</td>";
                str += "<td>" + price + "</td>";
                str += "<td>" + ROOM_STATUS[state] + "</td>";
                str += "<td>" + ROOM_TYPES[type] + "</td>";
                str += "<td><input type='button' value='删除' onclick='deleteRoom(" + no + ")'/><input type='button' value='修改' onclick='modifyRoom(" + no + ")'/></td>";
                str += "</tr>";
                count++;
            }
        } else {
            str += "<tr>";
            str += "<td><input type='checkbox' name='checkname'/></td>"
            str += "<td>" + result.RoomNo + "</td>";
            str += "<td>" + result.RoomPrice + "</td>";
            str += "<td>" + ROOM_STATUS[result.RoomStatu] + "</td>";
            str += "<td>" + ROOM_TYPES[result.RoomType] + "</td>";
            str += "<td><input type='button' value='删除' onclick='deleteRoom(" + no + ")'/><input type='button' value='修改' onclick='modifyRoom(" + no + ")'/></td>";
            str += "</tr>";
        }
    }
    str += "<tr>";
    str += "<td colspan=1></td>";
    str += "<td colspan=3>";
    for (var i = 0; i < count / 5; i++) {
        str += "<span style='border:1px solid red;'>" + i + "</span>";
    }
    str += "</td>";
    str += "<td colspan=2></td>";
    str += "</tr>";
    return str;
}

// 返回值转object字符串
function result2object(result) {
    var count = 0;
    result = JSON.parse(result);
    console.log(result);
    var str = "";
    str += "<tr>";
    str += "<td colspan=1></td>";
    str += "<td colspan=1></td>";
    str += "<td colspan=4><input type='text' placeholder='请输入物品名称' id='searchname'/><input type='button' value='搜索' onclick='searchByName(\"room\")'/></td>";
    str += "</tr>";
    str += "<tr>";
    str += "<td><input type='checkbox' name='checkname'/></td>"
    str += "<th onclick='changeOrder(this, \"object\")'>编号</th>";
    str += "<th>名称</th>";
    str += "<th>数量</th>";
    str += "<th>价格</th>";
    str += "<th>操作</th>";
    str += "</tr>";
    if (result != null) {
        if (result.length) {
            for (var i = 0; i < result.length; i++) {
                // 编号 姓名 数量 价格
                var object = result[i];
                var no = object.ObjectNo;
                var name = object.ObjectName;
                var number = object.ObjectNumber;
                var price = object.ObjectPrice;
                str += "<tr>";
                str += "<td><input type='checkbox' name='checkname'/></td>"
                str += "<td>" + no + "</td>";
                str += "<td>" + name + "</td>";
                str += "<td>" + number + "</td>";
                str += "<td>" + price + "</td>";
                str += "<td><input type='button' value='删除' onclick='deleteObject(" + no + ")'/><input type='button' value='修改' onclick='modifyObject(" + no + ")'/></td>";
                str += "</tr>";
                count++;
            }
        } else {
            str += "<tr>";
            str += "<td><input type='checkbox' name='checkname'/></td>"
            str += "<td>" + result.ObjectNo + "</td>";
            str += "<td>" + result.ObjectName + "</td>";
            str += "<td>" + result.ObjectNumber + "</td>";
            str += "<td>" + result.ObjectPrice + "</td>";
            str += "<td><input type='button' value='删除' onclick='deleteObject(" + no + ")'/><input type='button' value='修改' onclick='modifyObject(" + no + ")'/></td>";
            str += "</tr>";
        }
        str += "<tr>";
        str += "<td colspan=1></td>";
        str += "<td colspan=3>";
        for (var i = 0; i < count / 5; i++) {
            str += "<span style='border:1px solid red;'>" + i + "</span>";
        }
        str += "</td>";
        str += "<td colspan=2></td>";
        str += "</tr>";
    }
    return str;
}

function changeOrder(ispan, model) {
    var flag = 1;
    switch (model) {
        case "employee":
            switch (flag) {
                case 1:
                    myAjax("model=employee&type=order", "employee");
                    flag = 2;
                    break;
                case 2:
                    myAjax("model=employee&type=iorder", "employee");
                    flag = 3;
                    break;
                case 3:
                    myAjax("model=employee&type=all", "employee");
                    flag = 1;
                    break;
            }
            break;
        case "guest":
            switch (flag) {
                case 1:
                    myAjax("model=guest&type=order", "guest");
                    flag = 2;
                    break;
                case 2:
                    myAjax("model=guest&type=iorder", "guest");
                    flag = 3;
                    break;
                case 3:
                    myAjax("model=guest&type=all", "guest");
                    flag = 1;
                    break;
            }
            break;
        case "room":
            switch (flag) {
                case 1:
                    myAjax("model=room&type=order", "room");
                    flag = 2;
                    break;
                case 2:
                    myAjax("model=room&type=iorder", "room");
                    flag = 3;
                    break;
                case 3:
                    myAjax("model=room&type=all", "room");
                    flag = 1;
                    break;
            }
            break;
        case "object":
            switch (flag) {
                case 1:
                    myAjax("model=object&type=order", "object");
                    flag = 2;
                    break;
                case 2:
                    myAjax("model=object&type=iorder", "object");
                    flag = 3;
                    break;
                case 3:
                    myAjax("model=object&type=all", "object");
                    flag = 1;
                    break;
            }
            break;
    }
}

function myAjax(url, model) {
    var show_table = document.getElementById("data_table");
    $.ajax({
        method: "post",
        url: "/GetInfo.ashx?" + url,
        success: function (result) {
            switch (model) {
                case "employee":
                    show_table.innerHTML = result2employee(result, employee_position);
                    break;
                case "guest":
                    show_table.innerHTML = result2guest(result);
                    break;
                case "room":
                    show_table.innerHTML = result2room(result);
                    break;
                case "object":
                    show_table.innerHTML = result2object(result);
                    break;


                case "addemployee":
                    var rst = eval("(" + result + ")");
                    if (rst.status == 1) {
                        alert("添加成功");
                        myAjax("model=employee&type=page&page=1", "employee");
                    } else {
                        alert("添加失败");
                    }
                    break;
                case "deleteemployee":
                    var rst = eval("(" + result + ")");
                    if (rst.status == 1) {
                        alert("删除成功");
                        myAjax("model=employee&type=page&page=1", "employee");
                    } else {
                        alert("删除失败:" + result);
                    }
                    break;
                case "modifyemployee":
                    break;


                case "addguest":
                    var rst = eval("(" + result + ")");
                    if (rst.status == 1) {
                        alert("添加成功");
                        myAjax("model=guest&type=all", "guest");
                    } else {
                        alert("添加失败:" + result);
                    }
                    break;
                case "deleteguest":
                    var rst = eval("(" + result + ")");
                    if (rst.status == 1) {
                        alert("删除成功");
                        myAjax("model=guest&type=all", "guest");
                    } else {
                        alert("删除失败:" + result);
                    }
                    break;

                
                case "addroom":
                    var rst = eval("(" + result + ")");
                    if (rst.status == 1) {
                        alert("添加成功");
                        myAjax("model=room&type=all", "room");
                    } else {
                        alert("添加失败:" + result);
                    }
                    break;
                case "deleteroom":
                    var rst = eval("(" + result + ")");
                    if (rst.status == 1) {
                        alert("删除成功");
                        myAjax("model=room&type=all", "room");
                    } else {
                        alert("删除失败:" + result);
                    }
                    break;
                

                case "deleteobject":
                    var rst = eval("(" + result + ")");
                    if (rst.status == 1) {
                        alert("删除成功");
                        myAjax("model=object&type=all", "object");
                    } else {
                        alert("删除失败:" + result);
                    }
                    break;
            }
            console.log(result);
        }
    });
}
function searchByName(model) {
    switch (model) {
        case "employee":
            var req_name = document.getElementById("searchname").value;
            myAjax('model=employee&name=' + req_name, "employee");
            break;
        case "guest":
            var req_name = document.getElementById("searchname").value;
            myAjax('model=guest&name=' + req_name, "guest");
            break;
        case "room":
            var req_name = document.getElementById("searchname").value;
            myAjax('model=room&name=' + req_name, "room");
            break;
        case "object":
            var req_name = document.getElementById("searchname").value;
            myAjax('model=object&name=' + req_name, "object");
            break;
    }
}

function changeEmployee() {
    myAjax("model=employee&type=all", "employee");
}

function changeGuest() {
    myAjax("model=guest&type=all", "guest");
}

function changeRoom() {
    myAjax("model=room&type=all", "room");
}

function changeObject() {
    myAjax("model=object&type=all", "object");
}

function insertEmployee() {
    var show_table = document.getElementById("data_table");
    var precode = show_table.innerHTML;
    console.log("" + precode);
}

function checkAll(box) {
    if (box.checked) {
        $(".scheckbox").attr("checked", true);
        var scheckbox = document.getElementsByClassName("scheckbox");
        var check_box = "{";
        for (var i = 0; i < scheckbox.length - 1; i++) {
            var mbox = scheckbox[i];
            check_box += mbox.getAttribute("lang");
            check_box += ",";
        }
        check_box += scheckbox[scheckbox.length - 1].getAttribute("lang");
        check_box += "}";
        console.log(check_box);
    } else {
        $(".scheckbox").attr("checked", false);
    }
}

function deleteEmployee(no) {
    myAjax("model=employee&type=delete&no=" + no, "deleteemployee");
}

function addEmployee() {
    var mform = document.getElementById("dialog-login-employee");
    var no = mform.no.value;
    var username = mform.username.value;
    var password = mform.password.value;
    var gender = mform.gender.value;
    var age = mform.age.value;
    var position = mform.position.value;
    var phone = mform.phone.value;
    var id = mform.id.value;
    if((no=="")||(username=="")||(password=="")||(gender=="")||(age=="")||(position=="")||(phone=="")||(id=="")){
        alert("内容不全，请补全后再注册。");
    }else{
        myAjax("model=employee&type=add&no=" + no + "&username=" + username + "&password=" + password + "&gender=" + gender + "&age=" + age + "&position" + position + "&phone=" + phone + "&id=" + id, "addemployee")
    }
}

function modifyEmployee(pname) {
    document.getElementsByClassName("dialog-reginster-employee")[0].style.display = "block";
    $.ajax({
        method: "post",
        url: "/GetInfo.ashx?model=employee&name="+ pname,
        success: function (result) {
            console.log(result);
            /*var mform = document.getElementById("dialog-login");
            mform.no.style.enable = "false";
            var no = mform.no.value;
            var username = mform.username.value;
            var password = mform.password.value;
            var gender = mform.gender.value;
            var age = mform.age.value;
            var position = mform.position.value;
            var phone = mform.phone.value;
            var id = mform.id.value;
            if ((no == "") || (username == "") || (password == "") || (gender == "") || (age == "") || (position == "") || (phone == "") || (id == "")) {
                alert("内容不全，请补全后再注册。");
            } else {
                myAjax("model=employee&type=add&no=" + no + "&username=" + username + "&password=" + password + "&gender=" + gender + "&age=" + age + "&position" + position + "&phone=" + phone + "&id=" + id, "addemployee")
            }*/
        }
    });
};

function addGuest() {
    var mform = document.getElementById("dialog-login-guest");
    var no = mform.no.value;
    var username = mform.username.value;
    var gender = mform.gender.value;
    var age = mform.age.value;
    var phone = mform.phone.value;
    var id = mform.id.value;
    console.log("model=guest&type=add&no=" + no + "&username=" + username + "&gender=" + gender + "&age=" + age + "&phone=" + phone + "&id=" + id);

    if ((no == "") || (username == "") || (gender == "") || (age == "") || (phone == "") || (id == "")) {
        alert("内容不全，请补全后再注册。");
    } else {
        myAjax("model=guest&type=add&no=" + no + "&username=" + username  + "&gender=" + gender + "&age=" + age + "&phone=" + phone + "&id=" + id, "addguest")
    }
}

function addRoom() {
    var mform = document.getElementById("dialog-login-room");
    var no = mform.no.value;
    var price = mform.price.value;
    var statu = mform.statu.value;
    var type = mform.type.value;
    console.log(no+":"+price+":"+statu+":"+type);
    if ((no == "") || (price == "") || (statu == "") || (type == "")) {
        alert("内容不全，请补全后再注册。");
    } else {
        myAjax("model=room&type=add&no=" + no + "&price=" + price + "&statu=" + statu + "&type=" + type, "addroom")
    }
}

function deleteGuest(no) {
    myAjax("model=guest&type=delete&no=" + no, "deleteguest");
}

function deleteRoom(no) {
    myAjax("model=room&type=delete&no=" + no, "deleteroom");
}

function deleteObject(no) {
    myAjax("model=object&type=delete&no=" + no, "deleteobject");
}
