<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeRenXinXi.aspx.cs" Inherits="Web.GeRenXinXi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改个人信息</title>
    
    <link href="css/Css.css" rel="stylesheet" type="text/css" />
    <link href="css/Table.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
        <table class="table-box" style=" width:50%;">
                        <tr>
                            <td class="Table_searchtitle" colspan="4">
                               更新个人信息
                            </td>
                        </tr>
                        <tr>
                            <td class="table_body table_body_NoWidth">用户编号：</td>
                            <td class="table_none table_none_NoWidth">
                                &nbsp;<asp:TextBox ID="TB_UserID" runat="server"  Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_body table_body_NoWidth">用户名：</td>
                            <td class="table_none table_none_NoWidth">
                            &nbsp;<asp:TextBox ID="TB_UserName" runat="server" Enabled="False"></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="table_body table_body_NoWidth">性别：</td>
                            <td class="table_none table_none_NoWidth">&nbsp;<asp:DropDownList ID="DropDL_Sex" runat="server"  Enabled="false" Width="154px">
                                    <asp:ListItem>男</asp:ListItem>
                                    <asp:ListItem>女</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                        </tr>
                        <tr>
                            <td class="table_body table_body_NoWidth">单位:</td>
                            <td class="table_none table_none_NoWidth">&nbsp;<asp:DropDownList ID="TB_Unit" runat="server"   Width="154px">
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
                        </tr>
                        <tr>
                            <td class="table_body table_body_NoWidth">学历：</td>
                            <td class="table_none table_none_NoWidth">&nbsp;<asp:DropDownList ID="DropDL_Degree" runat="server" Width="154px" Enabled="false" >
                                    <asp:ListItem>博士</asp:ListItem>
                                    <asp:ListItem>硕士</asp:ListItem>
                                    <asp:ListItem>本科</asp:ListItem>
                                    <asp:ListItem>大专</asp:ListItem>
                                    <asp:ListItem>其他</asp:ListItem>
                                </asp:DropDownList>
                             </td>
                        </tr>
                        <tr>
                            <td class="table_body table_body_NoWidth">职称：</td>
                            <td class="table_none table_none_NoWidth">
                                &nbsp;<asp:DropDownList ID="TB_ZhiCheng" runat="server" Width="154px" Enabled="false">
                                    <asp:ListItem>教授</asp:ListItem>
                                    <asp:ListItem>副教授</asp:ListItem>
                                    <asp:ListItem>讲师</asp:ListItem>
                                    <asp:ListItem>其他</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                        </tr>
                        
                        
                        <tr>
                            <td class="table_body table_body_NoWidth">电话号码：</td>
                            <td class="table_none table_none_NoWidth">&nbsp;<asp:TextBox ID="TB_Telephone" runat="server" 
                                    Width="150px"></asp:TextBox>
                                <asp:RegularExpressionValidator  ControlToValidate="TB_Telephone" 
                                    ID="RegularExpressionValidator1" runat="server" ErrorMessage="格式错" 
                                    ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_body table_body_NoWidth">
                                <asp:Label ID="Job" runat="server" Text="是否在职：" Width="80px"></asp:Label></td>
                            <td class="table_none table_none_NoWidth">
                                &nbsp;<asp:DropDownList ID="DropDL_Job" runat="server" Width="154px" 
                                    TabIndex="1" Enabled="False" >
                                    <asp:ListItem>不在职</asp:ListItem>
                                    <asp:ListItem Selected="True">在职</asp:ListItem>
                                    </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_body table_body_NoWidth">电子邮件：</td>
                            <td class="table_none table_none_NoWidth">&nbsp;<asp:TextBox ID="TB_Email" runat="server" 
                                    Width="150px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="EmailRegular" runat="server"  
                                  ControlToValidate="TB_Email" ErrorMessage="格式错" 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                    </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        
                        <tr>
                            <td height="21" style="text-align: center" colspan="2">&nbsp;&nbsp;
                                <asp:Button ID="Btn_Save" runat="server" Text="提交" onclick="Btn_save_Click" />
                                <asp:Button ID="Btn_Cancel" runat="server" Text="取消"  onclick="Btn_Cancel_Click" />
                            </td>
                        </tr>
                   </table>
                </center>
             </div>
    </form>
</body>
</html>
