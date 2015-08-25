<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YongHuShanGai.aspx.cs" Inherits="Web.YongHuGuanLi.YongHuShanGai" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户删改</title>
    <link href="../css/GridView.css" rel="stylesheet" type="text/css" />
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True"  RowStyle-HorizontalAlign="Center"
            AutoGenerateColumns="False" PageSize="9" CssClass="gridviewStyle"
            onpageindexchanging="GridView1_PageIndexChanging" 
            onrowdatabound="GridView1_RowDataBound"  
            onselectedindexchanging="GridView1_SelectedIndexChanging">
                <RowStyle CssClass="row" /> 
                <HeaderStyle CssClass="header" />
                <Columns>
                <asp:BoundField DataField="PK_UserID" HeaderText="编号" />
                    
                <asp:BoundField DataField="UserName" HeaderText="姓名"   />
                <asp:BoundField DataField="Sex" HeaderText="性别" />
                <asp:BoundField DataField="Unit" HeaderText="单位"  />
                <asp:BoundField DataField="Education" HeaderText="学历" />
                <asp:BoundField DataField="ZhiCheng" HeaderText="职称" />
                <asp:BoundField DataField="Telephone" HeaderText="电话" />
                <asp:TemplateField HeaderText="是否在职">
                    <ItemTemplate>
                        <%#Eval("InOffice").ToString()=="1"?"在职":"不在职" %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Email" HeaderText="邮件" />
                <asp:BoundField DataField="RoleName" HeaderText="角色"  />
                <asp:TemplateField HeaderText="登录状态">
                    <ItemTemplate>
                        <%#Eval("Status").ToString()=="1"?"可以登录":"不可登录" %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="修改">
                    <ItemTemplate>
                        <asp:Button ID="Bt_Sel" runat="server" Text="修改" CommandName="Select" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Panel ID="Panel1"  Visible="false" runat="server">
            <table  >
                <tr>
                    <td class="table_body table_body_NoWidth">
                        <asp:Label ID="Label1" runat="server" Text="编号"></asp:Label>
                    </td>
                    <td class="table_body table_body_NoWidth">
                        <asp:Label ID="Label2" runat="server" Text="姓名"></asp:Label>
                    </td>
                    <td class="table_body table_body_NoWidth">
                        <asp:Label ID="Label3" runat="server" Text="性别"></asp:Label>
                    </td>
                    <td class="table_body table_body_NoWidth">
                        <asp:Label ID="Label4" runat="server" Text="单位"></asp:Label>
                    </td>
                    <td class="table_body table_body_NoWidth">
                        <asp:Label ID="Label5" runat="server" Text="学历"></asp:Label>
                    </td>
                    <td class="table_body table_body_NoWidth">
                        <asp:Label ID="Label6" runat="server" Text="职称"></asp:Label>
                    </td>
                    <td class="table_body table_body_NoWidth">
                        <asp:Label ID="Label7" runat="server" Text="电话"></asp:Label>
                        <asp:RegularExpressionValidator  ControlToValidate="TB_Telephone" 
                                    ID="RegularExpressionValidator1" runat="server" ErrorMessage="(有错)" 
                                    ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
                    </td>
                    <td class="table_body table_body_NoWidth">
                        <asp:Label ID="Label8" runat="server" Text="是否在职"></asp:Label>
                    </td>
                    <td class="table_body table_body_NoWidth">
                        <asp:Label ID="Label9" runat="server" Text="邮箱"></asp:Label>
                        <asp:RegularExpressionValidator ID="EmailRegular" runat="server"  
                                  ControlToValidate="TB_Email" ErrorMessage="(有错)" 
                                    
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                    <%--<td>
                        <asp:Label ID="Label10" runat="server" Text="登陆次数"></asp:Label>
                    </td>--%>
                    <td class="table_body table_body_NoWidth">
                        <asp:Label ID="Label11" runat="server" Text="登录状态"></asp:Label>
                    </td>
                    <td class="table_body table_body_NoWidth">
                        <asp:Label ID="Label12" runat="server" Text="重设密码?"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_none table_none_NoWidth">
                        <asp:TextBox ID="TB_UserID" runat="server"  Width="100" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="table_none table_none_NoWidth">
                        <asp:TextBox ID="TB_UserName" runat="server"  Width="100"></asp:TextBox>
                    </td>
                    <td class="table_none table_none_NoWidth">
                        <asp:DropDownList ID="DropDL_Sex" runat="server">
                            <asp:ListItem>男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="table_none table_none_NoWidth">
                        <asp:DropDownList ID="TB_Unit" runat="server"   Width="160px">
                                    <asp:ListItem>经济与管理学院</asp:ListItem>
                                    <asp:ListItem>政法学院</asp:ListItem>
                                    <asp:ListItem>教育学院</asp:ListItem>
                                    <asp:ListItem>体育与健康学院</asp:ListItem>
                                    <asp:ListItem>文学院</asp:ListItem>
                                    <asp:ListItem>外国语学院</asp:ListItem>
                                    <asp:ListItem>美术学院</asp:ListItem>
                                    <asp:ListItem>数学与信息科学学院</asp:ListItem>
                                    <asp:ListItem>化学化工学院</asp:ListItem>
                                    <asp:ListItem>生命科学学院</asp:ListItem>
                                    <asp:ListItem>电子信息与机电工程学院</asp:ListItem>
                                    <asp:ListItem>计算机学院</asp:ListItem>
                                    <asp:ListItem>软件学院</asp:ListItem>
                                    <asp:ListItem>旅游学院</asp:ListItem>
                                    <asp:ListItem>思想政治理论教学部</asp:ListItem>
                                    <asp:ListItem>继续教育学院</asp:ListItem>
                                    <asp:ListItem>国际交流学院</asp:ListItem>
                                    <asp:ListItem>应用技术师范学院</asp:ListItem>
                                    <asp:ListItem>音乐学院</asp:ListItem>
                                    <asp:ListItem>科研秘书处</asp:ListItem>
                                    <asp:ListItem>科员处</asp:ListItem>
                                    <asp:ListItem>处长室</asp:ListItem>
                                    <asp:ListItem>其他</asp:ListItem>
                                </asp:DropDownList>
                    </td>
                    <td class="table_none table_none_NoWidth">
                        <asp:DropDownList ID="DropDL_Degree" runat="server" >
                                    <asp:ListItem>博士</asp:ListItem>
                                    <asp:ListItem>硕士</asp:ListItem>
                                    <asp:ListItem>本科</asp:ListItem>
                                    <asp:ListItem>大专</asp:ListItem>
                                    <asp:ListItem>其他</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="table_none table_none_NoWidth" >
                        <asp:DropDownList ID="TB_ZhiCheng" runat="server">
                            <asp:ListItem>教授</asp:ListItem>
                                    <asp:ListItem>副教授</asp:ListItem>
                                    <asp:ListItem>讲师</asp:ListItem>
                                    <asp:ListItem>其他</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="table_none table_none_NoWidth">
                        <asp:TextBox ID="TB_Telephone" runat="server"  Width="100"></asp:TextBox>
                    </td>
                    <td class="table_none table_none_NoWidth">
                        <asp:DropDownList ID="DropDL_Job" runat="server"
                                    TabIndex="1"  >
                                    <asp:ListItem>不在职</asp:ListItem>
                                    <asp:ListItem Selected="True">在职</asp:ListItem>
                       </asp:DropDownList>
                    </td>
                    <td class="table_none table_none_NoWidth">
                        <asp:TextBox ID="TB_Email" runat="server"  Width="154"></asp:TextBox>
                    </td>
                    <%--<td>
                        <asp:TextBox ID="TB_Logins" runat="server"  Width="70"></asp:TextBox>
                    </td>--%>
                    <td class="table_none table_none_NoWidth">
                        <asp:DropDownList ID="DropStatus" runat="server" TabIndex="1">
                            <asp:ListItem>禁止登录</asp:ListItem>
                            <asp:ListItem Selected="True">可以登录</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="table_none table_none_NoWidth">
                        <asp:TextBox ID="RePwd" runat="server"  Text="" Width="154"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="Button1" runat="server" Text="确定修改" onclick="Button1_Click" 
                            Width="65px" />
                    </td>
                    <td align="center">
                        <asp:Button ID="Button2" runat="server" Text="取消修改" Width="65px" 
                            onclick="Button2_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
