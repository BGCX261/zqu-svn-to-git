﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShenBao_Add.aspx.cs" Inherits="Web.SciResearch.ShenBao_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>项目申报录入</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/Table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <a class="back" href="ShenBao_List.aspx">返回</a>
    
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
    <ajaxToolkit:TabPanel ID="TabPanel" HeaderText="项目申报添加" runat="server">
    <ContentTemplate>
   
    <div>
        <table class="table-box">
           <tr>
              <td class="Table_searchtitle" colspan="2">
                 项目申报编辑表单
              </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    申报项目编号：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtPID" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    申报项目类型：</td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" onselectedindexchanged="ddlType_SelectedIndexChanged">
                        <asp:ListItem Value="-1">请选择...</asp:ListItem>
                        <asp:ListItem Value="科研项目申报">科研项目申报</asp:ListItem>
                        <asp:ListItem Value="教研教改项目申报">教研教改项目申报</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请选择项目类型" ControlToValidate="ddlType" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    项目名称：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtTitle" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*请填写项目名称" ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    项目来源：</td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlSource" runat="server">
                        <asp:ListItem Value="-1">请先选择申报项目类型...</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*请选择项目来源" ControlToValidate="ddlSource" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    项目申报日期：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="txtTime_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTime" Format="yyyy-MM-dd">
                    </ajaxToolkit:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*请选择项目完成日期" ControlToValidate="txtTime"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    申报情况：
                </td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlReviewState" runat="server">
                        <asp:ListItem Value="-1">请选择...</asp:ListItem>
                        <asp:ListItem Value="通讯评审通过学校">通讯评审通过学校</asp:ListItem>
                        <asp:ListItem Value="通过学校审查报送">通过学校审查报送</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*请选择申报情况" ControlToValidate="ddlReviewState" InitialValue="-1" ValidationGroup="Add"></asp:RequiredFieldValidator>
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
                    <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    是否项目主持人：</td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlAnchorperson" runat="server">
                        <asp:ListItem Value="-1">请选择...</asp:ListItem>
                        <asp:ListItem Value="0">是</asp:ListItem>
                        <asp:ListItem Value="1">否</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*请选择是否项目主持人" ControlToValidate="ddlAnchorperson" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="lblPopulation1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    完成人数：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtPopulation" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqPopulation" runat="server" ErrorMessage="*请填写完成人数" ControlToValidate="txtPopulation"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="lblAllAuthor2" runat="server" ForeColor="Red" Text="*" ></asp:Label>
                    参与作者：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtAllAuthor" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqAllAuthor" runat="server" ErrorMessage="*请填写参与作者(多人之间用逗号分隔)" ControlToValidate="txtAllAuthor"></asp:RequiredFieldValidator>  
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
