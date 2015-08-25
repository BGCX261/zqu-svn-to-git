<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChaKanXinXi.aspx.cs" Inherits="Web.YongHuGuanLi.ChaKanXinXi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>查看信息</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/Table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
  <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
    <ajaxToolkit:TabPanel  HeaderText="查看信息" ID="TabPanel1" runat="server">
    <ContentTemplate>--%>
        <div>
        <center>
        <table class="table-box" style=" width:50%;">
                    <tr>
                        <td class="Table_searchtitle" colspan="4">
                           查看个人信息
                        </td>
                    </tr>
            
            
                        <tr>
                            <td class="table_body table_body_NoWidth">用户编号：</td>
                            <td class="table_none table_none_NoWidth">
                                <asp:Label ID="Lb_UserID" runat="server" Enabled="False"></asp:Label>
                            </td>
                         </tr>
                        <tr>
                            
                            <td class="table_body table_body_NoWidth">用户名：</td>
                            <td class="table_none table_none_NoWidth">
                                <asp:Label ID="Lb_UserName" runat="server" Enabled="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_body table_body_NoWidth">性别：</td>
                            <td class="table_none table_none_NoWidth">
                                <asp:Label ID="Lb_UserSex" runat="server" Enabled="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_body table_body_NoWidth">单位:</td>
                            <td class="table_none table_none_NoWidth">
                                <asp:Label ID="Lb_UserUnit" runat="server" Enabled="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_body table_body_NoWidth">学历：</td>
                            <td class="table_none table_none_NoWidth">
                                <asp:Label ID="Lb_UserEducation" runat="server" Enabled="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_body table_body_NoWidth">职称：</td>
                            <td class="table_none table_none_NoWidth">
                                <asp:Label ID="Lb_UserZhiCheng" runat="server" Enabled="False"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="table_body table_body_NoWidth">电话号码：</td>
                            <td class="table_none table_none_NoWidth">
                                <asp:Label ID="Lb_UserTel" runat="server" Enabled="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_body table_body_NoWidth">
                                是否在职：</td>
                            <td class="table_none table_none_NoWidth">
                                <asp:Label ID="Lb_UserInOffice" runat="server" Enabled="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_body table_body_NoWidth">电子邮件：</td>
                            <td class="table_none table_none_NoWidth">
                                <asp:Label ID="Lb_UserEmail" runat="server" Enabled="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_body table_body_NoWidth"> <div align="left">登录次数：</div></td>
                            <td class="table_none table_none_NoWidth">
                                <asp:Label ID="Lb_UserLoginTimes" runat="server" Enabled="False"></asp:Label>
                                </td>
                        </tr>
               
             </tr>
            
        </table>
        </center>
    </div>
    <%--</ContentTemplate>   
    </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>--%>
    </form>
</body>
</html>
