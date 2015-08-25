<%--dancy编写--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FaSongXiaoXi.aspx.cs" Inherits="Web.XiaoXi.FaSongXiaoXi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发送消息</title>
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table>
                    <tr>
                        <td colspan="3">
                            您当前所在位置：
                            <asp:Label ID="lblBigSort" runat="server" Text="消息管理"></asp:Label>>>
                            <asp:Label ID="lblSmallSort" runat="server" Text="发送消息"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            信息标题：
                        </td>
                        <td>
                            <asp:TextBox ID="txtMsgTitle" runat="server" Width="229px"></asp:TextBox>
                            <asp:Label ID="lblMsgTitle" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblErrorMsgTitle" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </td>
                    </tr>
                    <%--<tr>
                        <td>
                            消息类型：
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlMsgType" runat="server">
                                <asp:ListItem>系统消息</asp:ListItem>
                                <asp:ListItem>个人信息</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="lblMsgType" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            接收人：
                        </td>
                        <td style="width: 210px">
                            <asp:TextBox ID="txtReceiver" runat="server" Width="119px"></asp:TextBox>
                            <asp:Label ID="lblReceiver" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblErrorReceiver" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            查询：
                        </td>
                        <td style="width: 210px">
                            <asp:Label ID="lblReXueYuan" runat="server" Text="所属单位"></asp:Label>
                            &nbsp;<asp:DropDownList ID="ddlReXueYuan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlReXueYuan_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblReName" runat="server" Text="姓名"></asp:Label>
                            <asp:DropDownList ID="ddlReName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlReName_SelectedIndexChanged">
                                <asp:ListItem Value="-1">请先选择所属单位...</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            内容：
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtMsgContent" runat="server" TextMode="MultiLine" Width="600px"
                                Height="325px" class="ckeditor"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <asp:Label ID="lblErrorMsgContent" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="btnSend" runat="server" Text="发送" OnClick="btnSend_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
