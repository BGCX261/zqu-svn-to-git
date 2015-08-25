﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhuZuo_Evaluate.aspx.cs" Inherits="Web.KaoHe.ZhuZuo_Evaluate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>学术著作评定标准</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/GridView.css" rel="stylesheet" type="text/css" />
    <link href="../css/Table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
    <ajaxToolkit:TabPanel HeaderText="学术著作评定标准列表" ID="TabPanel1" runat="server" TabIndex="0">
    <ContentTemplate><asp:GridView ID="GridView1" runat="server" CssClass="gridviewStyle" 
            AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound" 
            onrowdeleting="GridView1_RowDeleting" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
            <RowStyle CssClass="row" /> 
            <HeaderStyle CssClass="header" />
            <Columns>
                <asp:TemplateField HeaderText="序号"><ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="Type" HeaderText="著作类型" ReadOnly="True" />
                <asp:BoundField DataField="Source" HeaderText="来源" ReadOnly="True" />
                <asp:TemplateField HeaderText="级别分系数">
                    <ItemTemplate><%#Eval("LevelFactor") %></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLevelFactor" runat="server" Text='<%#Eval("LevelFactor") %>' Width="40px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="只能为非负数" ControlToValidate="txtLevelFactor" ValidationExpression="^\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtLevelFactor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="级别">
                    <ItemTemplate><%#Eval("JiBie")%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlJiBie" runat="server">
                            <asp:ListItem Value="-1">请选择...</asp:ListItem>
                            <asp:ListItem Value="A">A</asp:ListItem>
                            <asp:ListItem Value="B">B</asp:ListItem>
                            <asp:ListItem Value="C">C</asp:ListItem>
                            <asp:ListItem Value="D">D</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="ddlJiBie" InitialValue="-1"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnDel" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('确认要删除吗？');" Text="删除">
                        </asp:LinkButton>
                    </ItemTemplate>
               </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>没有数据可操作了~~</EmptyDataTemplate></asp:GridView>
    </ContentTemplate>
    </ajaxToolkit:TabPanel>
    
    <ajaxToolkit:TabPanel HeaderText="学术著作评定标准添加" ID="TabPanel2" runat="server">
    <ContentTemplate>
        <table class="table-box">
            <tr>
                <td class="Table_searchtitle" colspan="2">
                   学术著作评定标准添加表单
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    来源：
                </td>
                <td class="table_none">
                    <asp:TextBox ID="txtSource" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*请填写来源" ControlToValidate="txtSource" ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    著作类型：
                </td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlType" runat="server">
                        <asp:ListItem Value="-1">请选择...</asp:ListItem>
                        <asp:ListItem Value="学术著作">学术著作</asp:ListItem>
                        <asp:ListItem Value="专著">专著</asp:ListItem>
                        <asp:ListItem Value="编著">编著</asp:ListItem>
                        <asp:ListItem Value="译著">译著</asp:ListItem>
                        <asp:ListItem Value="个人论文集">个人论文集</asp:ListItem>
                        <asp:ListItem Value="工具书">工具书</asp:ListItem>
                        <asp:ListItem Value="科普著作">科普著作</asp:ListItem>
                        <asp:ListItem Value="高校教材">高校教材</asp:ListItem>
                        <asp:ListItem Value="广东省高校重点教材">广东省高校重点教材</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*请选择著作类型" ControlToValidate="ddlType" InitialValue="-1" ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    级别分系数：
                </td>
                <td class="table_none">
                    <asp:TextBox ID="txtLevelFactor" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="只能为非负数" ControlToValidate="txtLevelFactor" ValidationExpression="^\d+(\.\d+)?$" ValidationGroup="Add"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请填写级别分系数" ControlToValidate="txtLevelFactor" ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    级别：
                </td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlJiBie" runat="server">
                            <asp:ListItem Value="-1">请选择...</asp:ListItem>
                            <asp:ListItem Value="A">A</asp:ListItem>
                            <asp:ListItem Value="B">B</asp:ListItem>
                            <asp:ListItem Value="C">C</asp:ListItem>
                            <asp:ListItem Value="D">D</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*请选择级别" ControlToValidate="ddlJiBie" InitialValue="-1" ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="Add" onclick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
    </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
    </form>
</body>
</html>
