<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Web.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>登陆</title>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    if(self.location.href!=top.location.href){
       top.location.href="../login.aspx";
    }
    </script>
</head>
<body style="background-color:#CCFFFF;">
    <form id="form1" runat="server">
    <div style="width: 513px;">
    <div id="top"> </div>
    <div id="center_left">
    <div class="user">
        <asp:Label ID="name" Text="用户名：" runat="Server" Width="70px"></asp:Label>&nbsp;
        <asp:TextBox id="user" runat="Server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="user" runat="server" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
      </div>
      <div class="user">
        <asp:Label ID="Label1" Text="密  码：" runat="Server" Width="70px"></asp:Label>&nbsp;
        <asp:TextBox id="password" runat="Server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="password" runat="server" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
      </div>
      
      <div class="chknumber">
        <asp:Label ID="Label2" Text="角  色：" runat="Server" Width="70px"></asp:Label>
        <asp:DropDownList ID="chknumber" runat="Server" class="dropdownlist">
            <asp:ListItem Value="-1">请选择...</asp:ListItem>
            <asp:ListItem>教师</asp:ListItem>
            <asp:ListItem>管理员</asp:ListItem>
            <asp:ListItem>系统管理员</asp:ListItem>
            <asp:ListItem>超级管理员</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请选择角色" ControlToValidate="chknumber" InitialValue="-1"></asp:RequiredFieldValidator>
      </div>
    </div>
    <div id="center_middle">
      <asp:ImageButton ID="login1" ImageUrl="images/login/dl.gif"  runat="Server" 
            Height="20" Width="57" onclick="login1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:ImageButton ID="ImageButton1" ImageUrl="images/login/cz.gif"  runat="Server" Height="20" Width="57" />
    </div>   
<div id="footer"></div>
    </div>
    </form>
</body>
</html>
