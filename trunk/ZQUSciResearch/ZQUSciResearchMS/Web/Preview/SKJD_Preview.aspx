<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SKJD_Preview.aspx.cs" Inherits="Web.Preview.SKJD_Preview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>社科鉴定成果详细信息</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/Table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <a class="back" href="javascript:window.history.go(-1);">返回</a>
    
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
    <ajaxToolkit:TabPanel  HeaderText="社科鉴定成果详细信息" ID="TabPanel1" runat="server">
    <ContentTemplate>
        <div>
        <table class="table-box">
                    <tr>
                        <td class="Table_searchtitle" colspan="4">
                           社科鉴定成果详细表单
                        </td>
                    </tr>
                    <tr>
                        <td class="table_body table_body_NoWidth">姓名：</td>
                        <td class="table_none table_none_NoWidth">
                            <asp:Label ID="lblUserName" runat="server" Text="lblUserName"></asp:Label>
                        </td>
                        <td class="table_body table_body_NoWidth">所在学院:</td>
                        <td class="table_none table_none_NoWidth">
                            <asp:Label ID="lblUserUnit" runat="server" Text="lblUserUnit"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="table_body table_body_NoWidth">性别：</td>
                        <td class="table_none table_none_NoWidth">
                            <asp:Label ID="lblSex" runat="server" Text="lblSex"></asp:Label>
                        </td>
                        <td class="table_body table_body_NoWidth">职称:</td>
                        <td class="table_none table_none_NoWidth">
                            <asp:Label ID="lblZhiCheng" runat="server" Text="lblZhiCheng"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="table_body table_body_NoWidth">成果编号：</td>
                        <td class="table_none table_none_NoWidth">
                            <asp:Label ID="lblSRID" runat="server" Text="lblSRID"></asp:Label></td>
                        <td class="table_body table_body_NoWidth">
                            所在类别：</td>
                        <td class="table_none table_none_NoWidth">
                            <asp:Label ID="lblBigSort" runat="server" Text="lblBigSort"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="table_body table_body_NoWidth">成果名称：</td>
                        <td colspan="3" class="table_none table_none_NoWidth">
                            <asp:Label ID="lblTitle" runat="server" Text="lblTitle"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="table_body table_body_NoWidth">鉴定日期：</td>
                        <td colspan="3" class="table_none table_none_NoWidth">
                            <asp:Label ID="lblTime" runat="server" Text="lblTime"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="table_body table_body_NoWidth">成果来源:</td>
                        <td class="table_none table_none_NoWidth">
                            <asp:Label ID="lblSource" runat="server" Text="lblSource"></asp:Label></td>
                        <td class="table_body table_body_NoWidth">鉴定等级:</td>
                        <td class="table_none table_none_NoWidth">
                            <asp:Label ID="lblGrade" runat="server" Text="lblGrade"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="table_body table_body_NoWidth">学校署名排名：</td>
                        <td class="table_none table_none_NoWidth">
                            <asp:Label ID="lblSchoolSign" runat="server" Text="lblSchoolSign"></asp:Label></td>
                        <td class="table_body table_body_NoWidth">完成成果排名：</td>
                        <td class="table_none table_none_NoWidth">
                            <asp:Label ID="lblRank" runat="server" Text="lblRank"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="table_body table_body_NoWidth">
                            完成人数：</td>
                        <td class="table_none table_none_NoWidth">
                            <asp:Label ID="lblPopulation" runat="server" Text="lblPopulation"></asp:Label></td>
                        <td class="table_body table_body_NoWidth">
                            参与作者：</td>
                        <td class="table_none table_none_NoWidth">
                            <asp:Label ID="lblAllAuthor" runat="server" Text="lblAllAuthor"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="table_body table_body_NoWidth">
                            审核状态：</td>
                        <td colspan="3" class="table_none table_none_NoWidth">
                            <asp:Label ID="lblAuditState" runat="server" Text="lblAuditState"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="table_body table_body_NoWidth">
                            级别：</td>
                        <td class="table_none table_none_NoWidth">
                            <asp:Label ID="lblJiBie" runat="server" Text="lblJiBie"></asp:Label>&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lbtnUpdateJiBie" runat="server" Visible="False" 
                                onclick="lbtnUpdateJiBie_Click" ValidationGroup="Update">修改级别</asp:LinkButton></td>
                        <td class="table_body table_body_NoWidth">
                            科研得分：</td>
                        <td class="table_none table_none_NoWidth">
                            <asp:Label ID="lblPerScore" runat="server" Text="lblPerScore"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="table_body table_body_NoWidth">
                            备注：</td>
                        <td colspan="3" class="table_none table_none_NoWidth">
                            <asp:Label ID="lblRemark" runat="server" Text="lblRemark"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        <asp:Panel ID="PanelReasonVisible" runat="server" Visible="False">
                        <tr>
                            <td class="table_body table_body_NoWidth">
                                审核不通过原因：</td>
                            <td colspan="3" class="table_none table_none_NoWidth">
                                <asp:Label ID="lblReason" runat="server" Text="lblReason"></asp:Label>
                        </tr>
                        </asp:Panel>
                        </td>
                    </tr>
                    
                    <tr>
                        <td colspan="4">
                        <asp:Panel ID="PanelReason" runat="server" Visible="False">
                        <tr>
                            <td class="table_body table_body_NoWidth">
                                审核不通过原因：</td>
                            <td colspan="3" class="table_none table_none_NoWidth">
                                <asp:TextBox ID="txtReason" Rows="7" TextMode="MultiLine" Width="400px" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请填写审核不通过原因" ControlToValidate="txtReason" ValidationGroup="Reason"></asp:RequiredFieldValidator></td>
                        </tr>
                        </asp:Panel>
                        </td>
                    </tr>
                    
                    
                    <tr>
                        <td></td>
                        <td>
                            <!-- 教师事件按钮 -->
                            <asp:Panel ID="Panel1" runat="server" Visible="False">
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="提交" />
                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="修改" />
                            </asp:Panel>
                            <!-- 秘书事件按钮 -->
                            <asp:Panel ID="Panel2" runat="server" Visible="False">
                                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="审核不通过" />
                                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" OnClientClick="return confirm('审核通过将不能再进行此操作!确认要操作吗？');" Text="审核通过" />
                            </asp:Panel>
                            <asp:Panel ID="Panel5" runat="server" Visible="False">
                                <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text=" 确 定 " ValidationGroup="Reason" />
                                <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text=" 取 消 " />
                            </asp:Panel>
                            <!-- 科员事件按钮 -->
                            <asp:Panel ID="Panel3" runat="server" Visible="False">
                                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="审核不通过" />
                                <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" OnClientClick="return confirm('审核通过将不能再进行此操作!确认要操作吗？');" Text="审核通过" />
                            </asp:Panel>
                            <asp:Panel ID="Panel6" runat="server" Visible="False">
                                <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text=" 确 定 " ValidationGroup="Reason" />
                                <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text=" 取 消 " />
                            </asp:Panel>
                            <!-- 处长事件按钮 -->
                            <asp:Panel ID="Panel4" runat="server" Visible="False">
                                <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="审核不通过" />
                                <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" OnClientClick="return confirm('确认要操作吗？');" Text="审核通过" />
                                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">取消终审</asp:LinkButton>
                            </asp:Panel>
                            <asp:Panel ID="Panel7" runat="server" Visible="False">
                                <asp:Button ID="Button13" runat="server" OnClick="Button13_Click" Text=" 确 定 " ValidationGroup="Reason" />
                                <asp:Button ID="Button14" runat="server" OnClick="Button14_Click" Text=" 取 消 " />
                            </asp:Panel>
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Text="启用终审" 
                                oncheckedchanged="CheckBox1_CheckedChanged" Visible="False" />
                        </td>
                    </tr>
            
                 </table>
                 </div>
    </ContentTemplate>   
    </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
    </form>
</body>
</html>
