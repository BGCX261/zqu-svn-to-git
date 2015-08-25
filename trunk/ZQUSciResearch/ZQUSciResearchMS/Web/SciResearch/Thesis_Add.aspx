<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Thesis_Add.aspx.cs" Inherits="Web.SciResearch.Thesis_Add" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>学术论文录入</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/Table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <a class="back" href="Thesis_List.aspx">返回</a>
       
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
    <ajaxToolkit:TabPanel ID="TabPanel" HeaderText="学术论文添加" runat="server">
    <ContentTemplate>
   
    <div>
        <table class="table-box">
            <tr>
                <td class="Table_searchtitle" colspan="2">
                 学术论文编辑表单
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>论文编号：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtLZID" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    论文类型：</td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlType" runat="server">
                        <asp:ListItem Value="-1">请选择论文类型...</asp:ListItem>
                        <asp:ListItem Value="0">学术论文</asp:ListItem>
                        <asp:ListItem Value="1">学术期刊论文</asp:ListItem>
                        <asp:ListItem Value="2">学术会议论文</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请选择论文类型" ControlToValidate="ddlType" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    论文题目：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtTitle" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*请填写论文题目" ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%--<tr>
                <td class="table_body">
                    <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    发表刊物期刊号：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtNumber1" runat="server" 
                        ontextchanged="txtNumber1_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*请填写发表刊物期刊号" ControlToValidate="txtNumber1"></asp:RequiredFieldValidator>
                </td>
            </tr>--%>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    发表刊物名称：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtUnit" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*请填写发表刊物名称" ControlToValidate="txtUnit"></asp:RequiredFieldValidator>
                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                        TargetControlID="txtUnit" ServicePath="QikanNameHelper.asmx" 
                        ServiceMethod="GetQikanNameByKey" MinimumPrefixLength="1" 
                        DelimiterCharacters="" Enabled="True"></ajaxToolkit:AutoCompleteExtender>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    发表日期：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtTime" 
                        Format="yyyy-MM-dd" runat="server" Enabled="True"></ajaxToolkit:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*请填写发表日期" ControlToValidate="txtTime"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    收录/转载情况：</td>
                <td class="table_none">
                    <asp:DropDownList ID="ddlState" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*请选择收录/转载情况" ControlToValidate="ddlState" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%--<tr>
                <td class="table_body">
                    <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    收录/转载期刊号：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtNumber2" runat="server" 
                        ontextchanged="txtNumber2_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*请填写收录/转载期刊号" ControlToValidate="txtNumber2"></asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    收录/转载期刊名称：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtStateUnit" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*请填写收录/转载期刊名称" ControlToValidate="txtStateUnit"></asp:RequiredFieldValidator>
                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                        TargetControlID="txtStateUnit" ServicePath="QikanNameHelper.asmx" 
                        ServiceMethod="GetQikanNameByKey" MinimumPrefixLength="1" 
                        DelimiterCharacters="" Enabled="True"></ajaxToolkit:AutoCompleteExtender>
                </td>
            </tr>--%>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label10" runat="server" ForeColor="Red" Text="*"></asp:Label>
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
                    <asp:Label ID="Label11" runat="server" ForeColor="Red" Text="*"></asp:Label>
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
                    <asp:RequiredFieldValidator ID="reqPopulation" runat="server" 
                        ErrorMessage="*请填写完成人数" ControlToValidate="txtPopulation" Visible="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="lblAllAuthor1" runat="server" Text="*" ForeColor="Red" Visible="False"></asp:Label>
                    <asp:Label ID="lblAllAuthor2" runat="server" Text="参与作者：" Visible="False"></asp:Label>
                    </td>
                <td class="table_none">
                    <asp:TextBox ID="txtAllAuthor" runat="server" Visible="False" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqAllAuthor" runat="server" 
                        ErrorMessage="*请填写参与作者(多人之间用逗号分隔)" ControlToValidate="txtAllAuthor" 
                        Visible="False"></asp:RequiredFieldValidator>
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
