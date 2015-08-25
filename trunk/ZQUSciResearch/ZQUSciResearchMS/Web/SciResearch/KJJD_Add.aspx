<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KJJD_Add.aspx.cs" Inherits="Web.SciResearch.KJJD_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>科技鉴定成果录入</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/Table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <a class="back" href="KJJD_List.aspx">返回</a>
    
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
    <ajaxToolkit:TabPanel ID="TabPanel" HeaderText="科技鉴定成果添加" runat="server">
    <ContentTemplate>
   
    <div>
        <table class="table-box">
            <tr>
                <td class="Table_searchtitle" colspan="2">
                   科技鉴定成果编辑表单
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    成果编号：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtAID" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>鉴定类型：</td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlType" runat="server">
                        <asp:ListItem Value="-1">请选择...</asp:ListItem>
                        <asp:ListItem Value="0">检测鉴定</asp:ListItem>
                        <asp:ListItem Value="1">会议鉴定</asp:ListItem>
                        <asp:ListItem Value="2">函审鉴定</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请选择鉴定类型" ControlToValidate="ddlType" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>成果名称：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtTitle" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*请填写成果名称" ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>鉴定部门：</td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlUnit" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*请选择鉴定部门" ControlToValidate="ddlUnit" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>鉴定日期：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="txtTime_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTime" Format="yyyy-MM-dd">
                    </ajaxToolkit:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*请选择鉴定日期" ControlToValidate="txtTime"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    学校署名排名：</td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlSchoolSign" runat="server">
                        <asp:ListItem Value="-1">请选择...</asp:ListItem>
                        <asp:ListItem Value="1">第一</asp:ListItem>
                        <asp:ListItem Value="2">第二</asp:ListItem>
                        <asp:ListItem Value="3">非第一、第二</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*请选择学校署名排名" ControlToValidate="ddlSchoolSign" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*请选择完成成果排名" ControlToValidate="ddlRank" InitialValue="-1"></asp:RequiredFieldValidator>
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

