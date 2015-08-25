<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChuangZuo_Evaluate.aspx.cs" Inherits="Web.KaoHe.ChuangZuo_Evaluate" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>创作类成果评定标准</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/GridView.css" rel="stylesheet" type="text/css" />
    <link href="../css/Table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
    <ajaxToolkit:TabPanel HeaderText="创作类成果评定标准列表" ID="TabPanel1" runat="server" TabIndex="0">
    <ContentTemplate><asp:GridView ID="GridView1" runat="server" CssClass="gridviewStyle" 
            AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound" 
            onrowdeleting="GridView1_RowDeleting" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
            <RowStyle CssClass="row" /> 
            <HeaderStyle CssClass="header" />
            <Columns>
                <asp:TemplateField HeaderText="序号"><ItemTemplate><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="XueKe" HeaderText="学科" ReadOnly="True" />
                <asp:BoundField DataField="Source" HeaderText="类别" ReadOnly="True" />
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
    
    <ajaxToolkit:TabPanel HeaderText="创作类成果评定标准添加" ID="TabPanel2" runat="server">
    <ContentTemplate>
        <table class="table-box">
            <tr>
                <td class="Table_searchtitle" colspan="2">
                   创作类成果评定标准添加表单
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    学科：
                </td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlXueKe" runat="server">
                        <asp:ListItem Value="-1">请选择...</asp:ListItem>
                        <asp:ListItem Value="美术">美术</asp:ListItem>
                        <asp:ListItem Value="音乐">音乐</asp:ListItem>
                        <asp:ListItem Value="体育">体育</asp:ListItem>
                        <asp:ListItem Value="文学">文学</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*请选择学科" ControlToValidate="ddlXueKe" InitialValue="-1" ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    类别：
                </td>
                <td class="table_none">
                    <asp:TextBox ID="txtSource" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*请填写类别" ControlToValidate="txtSource" ValidationGroup="Add"></asp:RequiredFieldValidator>
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
