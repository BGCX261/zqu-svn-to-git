<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Web.YongHuGuanLi.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>更改密码</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/Table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="420" border="0" align="center">
            <tr >
                <td class="table_body table_body_NoWidth"  style="width:30%">
                    用户编号：
                </td>
                <td class="table_none table_none_NoWidth">
                    <asp:TextBox ID="TB_UserID" runat="server" Width="150px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    
                </td>
            </tr>
            <tr >
                <td  class="table_body table_body_NoWidth">
                    旧密码：
                </td>
                <td class="table_none table_none_NoWidth">
                    <asp:TextBox ID="TB_OldPassword" runat="server" Width="150px" 
                        TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ControlToValidate="TB_OldPassword" runat="server" ErrorMessage="不能够为空">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr >
                <td class="table_body table_body_NoWidth">
                    新密码:
                </td>
                <td class="table_none table_none_NoWidth">
                    <asp:TextBox ID="TB_NewPassword1" runat="server" Width="150px" 
                        TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  ControlToValidate="TB_NewPassword1" runat="server" ErrorMessage="不能够为空">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="NewPasswordRev" runat="server" ControlToValidate="TB_NewPassword1"
                        ValidationExpression='[\w| !`~$^&amp;()=\+\-?\*"]*' Display="Static" ErrorMessage="密码不能包含非法字符！">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr >
                <td class="table_body table_body_NoWidth" >
                    再次输入新密码：
                </td>
                <td class="table_none table_none_NoWidth">
                    <asp:TextBox ID="TB_NewPassword2" runat="server" Width="150px" 
                        TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ControlToValidate="TB_NewPassword2" runat="server" ErrorMessage="不能够为空">
                    </asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="ConfirmNewPasswordCv" runat="server" ErrorMessage="两次输入的密码不一致！"
                                            ControlToCompare="TB_NewPassword1" ControlToValidate="TB_NewPassword2">
                    </asp:CompareValidator>
                </td>
            </tr>
            <tr  align="center">
                <td height="24" class="style1" >
                    <asp:Button ID="Button1" runat="server" Text="确定" onclick="Button1_Click" />
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="清空" onclick="Button2_Click" />
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
