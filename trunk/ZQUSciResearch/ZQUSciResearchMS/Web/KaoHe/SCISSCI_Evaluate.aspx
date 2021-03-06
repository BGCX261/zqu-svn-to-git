﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCISSCI_Evaluate.aspx.cs" Inherits="Web.KaoHe.SCISSCI_Evaluate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SCI/SSCI期刊影响因子设置</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/GridView.css" rel="stylesheet" type="text/css" />
    <link href="../css/Table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
    <ajaxToolkit:TabPanel HeaderText="SCI/SSCI期刊影响因子设置列表" ID="TabPanel1" runat="server" TabIndex="0">
    <ContentTemplate><asp:GridView ID="GridView1" runat="server" CssClass="gridviewStyle" 
            AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound" 
            onrowdeleting="GridView1_RowDeleting" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
            <RowStyle CssClass="row" /> 
            <HeaderStyle CssClass="header" />
            <Columns>
                <asp:TemplateField HeaderText="序号"><ItemTemplate><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="QikanKey" HeaderText="期刊索引" ReadOnly="True" />
                <asp:BoundField DataField="QikanName" HeaderText="期刊名称" ReadOnly="True" />
                <asp:TemplateField HeaderText="影响因子">
                    <ItemTemplate><%#Eval("QIF") %></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtQIF" runat="server" Text='<%#Eval("QIF") %>' Width="70px"></asp:TextBox>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="只能为非负数" ControlToValidate="txtLevelFactor" ValidationExpression="^\d+(\.\d+)?$"></asp:RegularExpressionValidator>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtQIF"></asp:RequiredFieldValidator>
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
          <webdiyer:AspNetPager ID="AspNetPager1" runat="server" BackColor="#EEEEEE" 
            CenterCurrentPageButton="True" 
            CustomInfoHTML="当前第<span style='color:Red;'>%CurrentPageIndex%</span>/%PageCount%页 每页<span style='color:Red;'>%PageSize%</span>条共%RecordCount%条记录" 
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
            onpagechanging="AspNetPager1_PageChanging" PageIndexBoxType="DropDownList" 
            PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left" 
            ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" 
            TextBeforePageIndexBox="转到">
        </webdiyer:AspNetPager>
    </ContentTemplate>
    </ajaxToolkit:TabPanel>
    
    <ajaxToolkit:TabPanel HeaderText="SCI/SSCI期刊影响因子设置添加" ID="TabPanel2" runat="server">
    <ContentTemplate>
        <table class="table-box">
            <tr>
                <td class="Table_searchtitle" colspan="2">
                   SCI/SSCI期刊影响因子设置添加表单
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    期刊索引：
                </td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlQikanKey" runat="server">
                        <asp:ListItem Value="-1">请选择...</asp:ListItem>
                        <asp:ListItem Value="SCI">SCI</asp:ListItem>
                        <asp:ListItem Value="SSCI">SSCI</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*请选择期刊索引" ControlToValidate="ddlQikanKey" InitialValue="-1" ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    期刊名称：
                </td>
                <td class="table_none">
                    <asp:TextBox ID="txtQikanName" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*请填写期刊名称" ControlToValidate="txtQikanName" ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    影响因子：
                </td>
                <td class="table_none">
                    <asp:TextBox ID="txtQIF" runat="server"></asp:TextBox>
                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="只能为非负数" ControlToValidate="txtLevelFactor" ValidationExpression="^\d+(\.\d+)?$" ValidationGroup="Add"></asp:RegularExpressionValidator>--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请填写影响因子" ControlToValidate="txtQIF" ValidationGroup="Add"></asp:RequiredFieldValidator>
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
