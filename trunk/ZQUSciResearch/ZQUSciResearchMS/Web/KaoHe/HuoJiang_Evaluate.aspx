<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HuoJiang_Evaluate.aspx.cs" Inherits="Web.KaoHe.HuoJiang_Evaluate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>获奖成果（教学成果奖）评定标准</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/GridView.css" rel="stylesheet" type="text/css" />
    <link href="../css/Table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
    <ajaxToolkit:TabPanel HeaderText="获奖成果（教学成果奖）评定标准列表" ID="TabPanel1" runat="server" TabIndex="0">
    <ContentTemplate><asp:GridView ID="GridView1" runat="server" CssClass="gridviewStyle" 
            AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound" 
            onrowdeleting="GridView1_RowDeleting" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
            <RowStyle CssClass="row" /> 
            <HeaderStyle CssClass="header" />
            <Columns>
                <asp:TemplateField HeaderText="序号"><ItemTemplate><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="Type" HeaderText="类别" ReadOnly="True" />
                <asp:BoundField DataField="Grade" HeaderText="奖项名称(级别)" ReadOnly="True" />
                <asp:BoundField DataField="AwardGrade" HeaderText="获奖等级" ReadOnly="True" />
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
    
    <ajaxToolkit:TabPanel HeaderText="获奖成果（教学成果奖）评定标准添加" ID="TabPanel2" runat="server">
    <ContentTemplate>
        <table class="table-box">
            <tr>
                <td class="Table_searchtitle" colspan="2">
                   获奖成果（教学成果奖）评定标准添加表单
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    类别：
                </td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlType" runat="server">
                        <asp:ListItem Value="-1">请选择...</asp:ListItem>
                        <asp:ListItem Value="理工类">理工类</asp:ListItem>
                        <asp:ListItem Value="社科类">社科类</asp:ListItem>
                        <asp:ListItem Value="教学成果类">教学成果类</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*请选择类别" ControlToValidate="ddlType" InitialValue="-1" ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    奖项名称(级别)：
                </td>
                <td class="table_none">
                    <asp:TextBox ID="txtGrade" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*请填写奖项名称(级别)" ControlToValidate="txtGrade" ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    获奖等级：
                </td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlAwardGrade" runat="server">
                        <asp:ListItem Value="-1">请选择...</asp:ListItem>
                        <asp:ListItem Value="特等奖">特等奖</asp:ListItem>
                        <asp:ListItem Value="一等级">一等级</asp:ListItem>
                        <asp:ListItem Value="二等级">二等级</asp:ListItem>
                        <asp:ListItem Value="三等级">三等级</asp:ListItem>
                        <asp:ListItem Value="四等级">四等级</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*请选择获奖等级" ControlToValidate="ddlAwardGrade" InitialValue="-1" ValidationGroup="Add"></asp:RequiredFieldValidator>
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
