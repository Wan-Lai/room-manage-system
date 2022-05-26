<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RMS_View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        * {
            padding: 0;
            margin: 0;
            transition: all .5s;
        }


        .loginform {
            height: 250px;
            width: 350px;
            margin: 100px auto;
            display: flow-root;
            border-radius: 20px;
            background-color: black;
        }

        .loginform:hover {
            transform:scale(1.2);
        }

        .logininput {
            height: 50px;
            width: 300px;
            margin: 23px auto;
            text-align: center;
            color: white;
            border: 1px solid white;
            border-radius: 10px;
            background-color: black;
        }

        .logininput:hover .logininput: not-child(3) {
            background-color: white;
        }

        .logininput > label {
            font-size: 20px;
            line-height: 50px;
            margin-left: 15px;
        }

       
       
        .logininput:hover input[lang="input"] {
            height: 100%;
            width: 100%;
            text-align: center;
            font-size: 20px;
            border: 0;
            border-radius: 10px;
        }

        .loginform > .logininput > input[lang="button"] {
            height: 100%;
            width: 49%;
            color: white;
            background-color: black;
            font-size: 20px;
            border: 0;
            border-radius: 10px;
        }

        .loginform > .logininput:hover input[lang="button"] {
            color: black;
            background-color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="loginform">
        <div class="logininput">
            <label>账号</label>
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
        </div>
        <div class="logininput">
            <label>密码</label>
            <asp:TextBox ID="Password" runat="server"></asp:TextBox>
        </div>
        <div class="logininput">
            <asp:Button ID="Button1" runat="server" Text="清空" OnClick="Reset_Click" />
            <asp:Button ID="Button2" runat="server" Text="登录" OnClick="Login_Click" />
        </div>
    </div>
    </form>
</body>
</html>
