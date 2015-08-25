<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FaJianXiang.aspx.cs"
    Inherits="Web.XiaoXi.FaJianXiang" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发件箱</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="3">
                    您当前所在位置：
                    <asp:Label ID="lblBigSort" runat="server" Text="消息管理"></asp:Label>>>
                    <asp:Label ID="lblSmallSort" runat="server" Text="发件箱"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GVMsgListBySender" runat="server" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                        CellPadding="4">
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <Columns>
                            <asp:TemplateField HeaderText="选择">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="FK_RecieverID" HeaderText="接收者">
                                <HeaderStyle Width="70px" />
                                <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="PK_MID" 
                                DataNavigateUrlFormatString="LiuLanXiaoXi.aspx?id={0}" 
                                DataTextField="Title" HeaderText="主题">
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:HyperLinkField>
                            <asp:TemplateField HeaderText="已读">
                                <ItemTemplate>
                                    <%# Eval("IsRead").ToString() == "0" ? "<img src='../images/Msg/mailnew.jpg'>" : "<img src='../images/Msg/mailopened.jpg'>"%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="SendTime" HeaderText="发送时间">
                                <HeaderStyle Width="150px" />
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="lblTishi" runat="server" Text="没有信息！" Height="100px" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Font-Size="9pt" Text="全选"
                        OnCheckedChanged="CheckBox2_CheckedChanged" />
                </td>
                <td>
                    <asp:Button ID="btnCancle" runat="server" Font-Size="9pt" Text="取消" OnClick="btnCancle_Click" />
                </td>
                <td>
                    <asp:Button ID="btnDelete" runat="server" Font-Size="9pt" Text="删除" OnClick="btnDelete_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
