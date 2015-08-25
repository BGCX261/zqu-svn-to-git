<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintByTeacher.aspx.cs" Inherits="Web.Print.PrintByTeacher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>科研信息打印</title>
    <link href="../css/GridView.css" rel="stylesheet" type="text/css" />
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/Table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center; height:30px">
        <asp:Label  ID="Label1" runat="server" Text="肇庆学院教师个人科研工作量考核表" Font-Bold="True" 
            Font-Size="Large"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lb_Information" runat="server" Text="Label" Height="20px" 
            Font-Bold="True"></asp:Label>
    </div>
    <div style="text-align:right; margin-right:60px">
        <asp:Label ID="lb_PrintTime" runat="server" Text="Labe2" Height="15px" ></asp:Label>
    </div>
    <div>
    <asp:GridView ID="GV_Print" runat="server" AutoGenerateColumns="False" CssClass="gridviewStyle"  
                onrowdatabound="GV_Print_RowDataBound" >
                <Columns>
                    <asp:TemplateField  HeaderText="序号">
                    <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                </asp:TemplateField>
                    <asp:BoundField DataField="UserName" HeaderText="姓名" />
                    <asp:BoundField DataField="Title" HeaderText="成果/业绩名称" />
                    <asp:BoundField DataField="Rank" HeaderText="完成成果/业绩排名" />
                    <asp:BoundField DataField="SmallSort" HeaderText="成果/业绩类别" />
                    <asp:BoundField DataField="Unit" HeaderText="出版（鉴定）单位/发表刊物名称/项目来源" />
                    <asp:BoundField DataField="PublishTime" HeaderText="日期" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:TemplateField HeaderText="级别">
                       <ItemTemplate>
                           <asp:Label ID="lblJiBie" runat="server" Text=""><%#Eval("LevelFactor") %><%#Eval("JiBie") %></asp:Label>
                       </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PerScore" HeaderText="科研得分" />
                    <asp:BoundField DataField="AuditState" HeaderText="审核状态" />
                </Columns>
                <HeaderStyle CssClass="header" />
                <RowStyle CssClass="row" /> 
            </asp:GridView>
    </div>
    <div style="text-align:center; height:25px">
        <a href=#" onclick="window.close()" style="font-size: medium; font-weight: bold;">关闭窗口</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <a href="#" onclick="window.print()" style="font-size: medium; font-weight: bold;">打印</a>
    </div>
    </form>
</body>
</html>
