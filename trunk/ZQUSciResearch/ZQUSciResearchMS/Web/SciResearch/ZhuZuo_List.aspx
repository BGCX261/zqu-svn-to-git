<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhuZuo_List.aspx.cs" Inherits="Web.SciResearch.ZhuZuo_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>学术著作列表</title>
    <link href="../css/GridView.css" rel="stylesheet" type="text/css" />
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.js" type="text/javascript"></script> 
</head>
<body>
  <%--  <script type="text/javascript">
    <!--
/*屏蔽所有的js错误*/
function killerrors() {
return true;
}
window.onerror = killerrors;
//-->

    $(document).ready(function() {
    var table = document.getElementById("<%=GridView1.ClientID%>");
            if (table.rows.length > 0) {
                document.getElementById("<%=GridView1.ClientID%>").rows[0].cells[7].colSpan = "3";
                document.getElementById("<%=GridView1.ClientID%>").rows[0].cells[7].innerText = "操 作";
                document.getElementById("<%=GridView1.ClientID%>").rows[0].cells[8].style.display = "none";
                document.getElementById("<%=GridView1.ClientID%>").rows[0].cells[9].style.display = "none";
            }


        });
    </script>--%>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <a class="add" href="ZhuZuo_Add.aspx?cmd=add">添加</a>
    
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
    <ajaxToolkit:TabPanel HeaderText="个人学术著作列表" ID="TabPanel1" runat="server">
    <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="gridviewStyle" 
                onrowdatabound="GridView1_RowDataBound" 
                onrowdeleting="GridView1_RowDeleting">
                <RowStyle CssClass="row" /> 
                <HeaderStyle CssClass="header" />
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="著作题目" />
                    <asp:BoundField DataField="Rank" HeaderText="完成成果排名" />
                    <asp:BoundField DataField="Source" HeaderText="来源" />
                    <asp:BoundField DataField="PublishTime" HeaderText="出版日期" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="AuditState" HeaderText="审核状态" />
                   <asp:TemplateField HeaderText="级别">
                       <ItemTemplate>
                           <asp:Label ID="lblJiBie" runat="server" Text=""><%#Eval("LevelFactor") %><%#Eval("JiBie") %></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                    <asp:BoundField DataField="PerScore" HeaderText="科研得分" />
                    <asp:HyperLinkField HeaderText="查看" DataNavigateUrlFields="PK_LZID" 
                        DataNavigateUrlFormatString="/Preview/ZhuZuo_Preview.aspx?cmd=preview&srid={0}" Text="查看" />
                    <asp:HyperLinkField DataNavigateUrlFields="PK_LZID" 
                        DataNavigateUrlFormatString="ZhuZuo_Add.aspx?cmd=modify&srid={0}" 
                        HeaderText="修改" Text="修改" />
                    <asp:TemplateField HeaderText="删除">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnDel" runat="server" CausesValidation="False" 
                                CommandName="Delete" OnClientClick="return confirm('确认要删除吗？');" Text="删除"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    没有数据可操作了~~
                </EmptyDataTemplate>
            </asp:GridView>
    </ContentTemplate>
    </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
    </form>
</body>
</html>

