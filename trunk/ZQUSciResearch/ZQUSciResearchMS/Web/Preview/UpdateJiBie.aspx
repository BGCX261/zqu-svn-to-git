<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateJiBie.aspx.cs" Inherits="Web.Preview.UpdateJiBie" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>科研成果/业绩级别修改</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/Table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table class="table-box">
                <tr>
                    <td class="Table_searchtitle" colspan="2">
                       科研成果/业绩级别修改表单
                    </td>
                </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>成果/业绩编号：
                </td>
                <td class="table_none">
                    <asp:Label ID="lblSRID" runat="server" Text="lblSRID"></asp:Label>
                </td>
            </tr>
              <tr>
                <td class="table_body">
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>级别分系数：
                </td>
                <td class="table_none">
                    <asp:TextBox ID="txtLevelFactor" runat="server"></asp:TextBox>                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请填写级别分系数" ControlToValidate="txtLevelFactor"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="只能为非负数" ControlToValidate="txtLevelFactor" ValidationExpression="^\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="table_body">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*请选择级别" ControlToValidate="ddlJiBie" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnOK" runat="server" Text="确定修改" onclick="btnOK_Click" />&nbsp;&nbsp;&nbsp;
                        <input id="btnCancel" type="button" value="取消" onclick="window.close();" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
