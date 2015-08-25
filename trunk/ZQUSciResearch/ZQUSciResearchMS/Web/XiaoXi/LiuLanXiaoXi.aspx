<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiuLanXiaoXi.aspx.cs" Inherits="Web.XiaoXi.LiuLanXiaoXi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>浏览信息</title>
    <style type="text/css">
        .leftTitle
        {
            padding: 0 0 0 20px;
            width: 80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td colspan="3" style="height: 30px;">
                                您当前所在位置：
                                <asp:Label ID="lblBigSort" runat="server" Text="消息管理"></asp:Label>>>
                                <asp:Label ID="lblSmallSort" runat="server" Text="浏览消息"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" width="100%" bgcolor="#CCCCFF">
                        <tr>
                            <td class="leftTitle">
                                标题：
                            </td>
                            <td>
                                <asp:Label ID="lblMsgTitle" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="leftTitle">
                                发件人：
                            </td>
                            <td>
                                <asp:Label ID="lblSender" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="leftTitle">
                                发送时间：
                            </td>
                            <td>
                                <asp:Label ID="lblSendTime" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="leftTitle">
                                收件人：
                            </td>
                            <td>
                                <asp:Label ID="lblReceiver" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                <%--
                                <asp:TextBox ID="txtMsgContent" runat="server" TextMode="MultiLine" Width="600px"
                                    Height="325px" class="ckeditor"></asp:TextBox>--%>
                                <asp:Label ID="lblMsgContend" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnClose" runat="server" Text="关闭" onclick="btnClose_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
