<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WordsFunds.aspx.cs" Inherits="Web.KaoHe.WordsFunds" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>字数分/经费分设置</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/Table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">   
    <ajaxToolkit:TabPanel HeaderText="字数分（学术著作）/经费分（科研项目）设置" ID="TabPanel1" runat="server">
    <ContentTemplate>
        <table>
            <tr>
                <td class="Table_searchtitle" colspan="2">
                   学术著作字数分设置
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    学术著作字数分设置：</td>
                <td class="table_none">
                    <asp:TextBox ID="txtDigit2" runat="server" CssClass="textbox" ontextchanged="txtDigit2_TextChanged" AutoPostBack="True"></asp:TextBox>万字之内，每万字
                    <asp:TextBox ID="txtDigit1" runat="server" CssClass="textbox"></asp:TextBox>分；字数超过
                    <asp:Label ID="lblDigit2" runat="server" Text="Label"></asp:Label>万字的部分，每万字
                    <asp:TextBox ID="txtDigit3" runat="server" CssClass="textbox"></asp:TextBox>分。
                    <asp:LinkButton ID="LinkButton1" runat="server" 
                        OnClientClick="return confirm('确认要操作吗？');" onclick="LinkButton1_Click">重新设置</asp:LinkButton>(提示：直接修改再点击重新设置即可)</td>
            </tr>
            <tr>
                <td class="table_none" colspan="2">
                </td>
            </tr>
            <tr>
                <td class="Table_searchtitle" colspan="2">
                   科研项目经费分设置
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    科技项目：</td>
                <td class="table_none">经费
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" 
                        ontextchanged="TextBox1_TextChanged" AutoPostBack="True"></asp:TextBox>万元以内（含
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>万元），纵向经费每万元
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox"></asp:TextBox>分，横向经费每万元
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="textbox"></asp:TextBox>分；经费超过
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox>万元至
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="textbox" 
                        ontextchanged="TextBox5_TextChanged" AutoPostBack="True"></asp:TextBox>万元（含
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>万元）的部分，纵向经费每万元
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="textbox"></asp:TextBox>分，横向经费每万元
                    <asp:TextBox ID="TextBox7" runat="server" CssClass="textbox"></asp:TextBox>分；经费超过
                    <asp:TextBox ID="TextBox8" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox>万元至
                    <asp:TextBox ID="TextBox9" runat="server" CssClass="textbox" 
                        ontextchanged="TextBox9_TextChanged" AutoPostBack="True"></asp:TextBox>万元（含
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>万元）的部分，纵向经费每万元
                    <asp:TextBox ID="TextBox10" runat="server" CssClass="textbox"></asp:TextBox>分，横向经费每万元
                    <asp:TextBox ID="TextBox11" runat="server" CssClass="textbox"></asp:TextBox>分；经费超过
                    <asp:TextBox ID="TextBox12" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox>万元以上的，纵向经费每万元
                    <asp:TextBox ID="TextBox13" runat="server" CssClass="textbox"></asp:TextBox>分，横向经费每万元
                    <asp:TextBox ID="TextBox14" runat="server" CssClass="textbox"></asp:TextBox>分。
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('确认要操作吗？');" onclick="LinkButton2_Click">重新设置</asp:LinkButton>(提示：直接修改再点击重新设置即可)</td>
            </tr>
            <tr>
                <td class="table_body">
                    社科项目：</td>
                <td class="table_none">经费
                    <asp:TextBox ID="TextBox15" runat="server" CssClass="textbox" 
                        ontextchanged="TextBox15_TextChanged" AutoPostBack="True"></asp:TextBox>万元以内（含
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>万元），纵向经费每万元
                    <asp:TextBox ID="TextBox16" runat="server" CssClass="textbox"></asp:TextBox>分，横向经费每万元
                    <asp:TextBox ID="TextBox17" runat="server" CssClass="textbox"></asp:TextBox>分；经费超过
                    <asp:TextBox ID="TextBox18" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox>万元至
                    <asp:TextBox ID="TextBox19" runat="server" CssClass="textbox" 
                        ontextchanged="TextBox19_TextChanged" AutoPostBack="True"></asp:TextBox>万元（含
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>万元）的部分，纵向经费每万元
                    <asp:TextBox ID="TextBox20" runat="server" CssClass="textbox"></asp:TextBox>分，横向经费每万元
                    <asp:TextBox ID="TextBox21" runat="server" CssClass="textbox"></asp:TextBox>分；经费超过
                    <asp:TextBox ID="TextBox22" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox>万元至
                    <asp:TextBox ID="TextBox23" runat="server" CssClass="textbox" 
                        ontextchanged="TextBox23_TextChanged" AutoPostBack="True"></asp:TextBox>万元（含
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>万元）的部分，纵向经费每万元
                    <asp:TextBox ID="TextBox24" runat="server" CssClass="textbox"></asp:TextBox>分，横向经费每万元
                    <asp:TextBox ID="TextBox25" runat="server" CssClass="textbox"></asp:TextBox>分；经费超过
                    <asp:TextBox ID="TextBox26" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox>万元以上的，纵向经费每万元
                    <asp:TextBox ID="TextBox27" runat="server" CssClass="textbox"></asp:TextBox>分，横向经费每万元
                    <asp:TextBox ID="TextBox28" runat="server" CssClass="textbox"></asp:TextBox>分。
                    <asp:LinkButton ID="LinkButton3" runat="server" 
                        OnClientClick="return confirm('确认要操作吗？');" onclick="LinkButton3_Click">重新设置</asp:LinkButton>(提示：直接修改再点击重新设置即可)</td>
            </tr>
        </table>
          
    </ContentTemplate>
    </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
