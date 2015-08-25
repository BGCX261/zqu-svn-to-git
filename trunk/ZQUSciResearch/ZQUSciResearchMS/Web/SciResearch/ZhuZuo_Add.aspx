﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhuZuo_Add.aspx.cs" Inherits="Web.SciResearch.ZhuZuo_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>学术著作录入</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/Table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <a class="back" href="ZhuZuo_List.aspx">返回</a>
    
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
    <ajaxToolkit:TabPanel ID="TabPanel" HeaderText="学术著作添加" runat="server">
    <ContentTemplate>
   
    <div>
        <table class="table-box">
           <tr>
              <td class="Table_searchtitle" colspan="2">
                 学术著作编辑表单
              </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    著作编号：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtLZID" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    著作类型：</td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlType" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请选择著作类型" ControlToValidate="ddlType" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    著作名称：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtTitle" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*请填写著作名称" ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    出版单位：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtUnit" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*请填写出版单位" ControlToValidate="txtUnit"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    出版日期：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="txtTime_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTime" Format="yyyy-MM-dd">
                    </ajaxToolkit:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*请填写出版日期" ControlToValidate="txtTime"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    来源：</td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlSource" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*请选择来源" ControlToValidate="ddlSource" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%--<tr>
                <td class="table_body">
                    <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    ISBN号：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtISBN" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*请填写ISBN号" ControlToValidate="txtISBN"></asp:RequiredFieldValidator>
                </td>
            </tr>--%>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label10" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    字数：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtWord" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*请填写字数(以万字为单位)" ControlToValidate="txtWord"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    学校署名排名：</td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlSchoolSign" runat="server">
                            <asp:ListItem Value="-1">请选择...</asp:ListItem>
                            <asp:ListItem Value="1">第一</asp:ListItem>
                            <asp:ListItem Value="2">第二</asp:ListItem>
                            <asp:ListItem Value="3">非第一、第二</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*请选择学校署名排名" ControlToValidate="ddlSchoolSign" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    完成成果排名：</td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlRank" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlRank_SelectedIndexChanged">
                        <asp:ListItem Value="-1">请选择...</asp:ListItem>
                        <asp:ListItem Value="0">独立</asp:ListItem>
                        <asp:ListItem Value="1">第一作者</asp:ListItem>
                        <asp:ListItem Value="2">第二作者</asp:ListItem>
                        <asp:ListItem Value="3">第三作者</asp:ListItem>
                        <asp:ListItem Value="4">第四作者</asp:ListItem>
                        <asp:ListItem Value="5">第五作者</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*请选择完成成果排名" ControlToValidate="ddlRank" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="lblPopulation1" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                    <asp:Label ID="lblPopulation2" runat="server" Text="完成人数：" Visible="False"></asp:Label>
                </td>
                <td class="table_none">
                    <asp:TextBox ID="txtPopulation" runat="server" Visible="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqPopulation" runat="server" ErrorMessage="*请填写完成人数" ControlToValidate="txtPopulation" Visible="false"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="lblAllAuthor1" runat="server" Text="*" ForeColor="Red" Visible="False"></asp:Label>
                    <asp:Label ID="lblAllAuthor2" runat="server" Text="参与作者：" Visible="False"></asp:Label></td>
                <td class="table_none">
                    <asp:TextBox ID="txtAllAuthor" runat="server" Visible="False" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqAllAuthor" runat="server" ErrorMessage="*请填写参与作者(多人之间用逗号分隔)" ControlToValidate="txtAllAuthor" Visible="false"></asp:RequiredFieldValidator>  
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    备注：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtRemark" runat="server" Rows="7" TextMode="MultiLine" 
                        Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" />
                        <asp:Button ID="btnSubmit" runat="server" Text="保存并提交" 
                            onclick="btnSubmit_Click" />
                    </td>
            </tr>
        </table>
    </div>
    
    </ContentTemplate>
    </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>

    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
