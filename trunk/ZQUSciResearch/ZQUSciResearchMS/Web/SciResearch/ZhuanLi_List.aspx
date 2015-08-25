<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhuanLi_List.aspx.cs" Inherits="Web.SciResearch.ZhuanLi_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>专利成果列表</title>
    <link href="../css/GridView.css" rel="stylesheet" type="text/css" />
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.js" type="text/javascript"></script> 
</head>
<body>
    <%--<script type="text/javascript">
    $(document).ready(function() {
    var table = document.getElementById("<%=GridView1.ClientID%>");
            if (table.rows.length > 0) {
                document.getElementById("<%=GridView1.ClientID%>").rows[0].cells[8].colSpan = "3";
                document.getElementById("<%=GridView1.ClientID%>").rows[0].cells[8].innerText = "操 作";
                document.getElementById("<%=GridView1.ClientID%>").rows[0].cells[9].style.display = "none";
                document.getElementById("<%=GridView1.ClientID%>").rows[0].cells[10].style.display = "none";
            }


        });
    </script>--%>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <a class="add" href="ZhuanLi_Add.aspx?cmd=add">添加</a>
    
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
    <ajaxToolkit:TabPanel HeaderText="个人专利成果列表" ID="TabPanel1" runat="server">
    <ContentTemplate>
        <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="gridviewStyle"
                onrowdatabound="GridView1_RowDataBound" 
                onrowdeleting="GridView1_RowDeleting">
                <RowStyle CssClass="row" /> 
                <HeaderStyle CssClass="header" />
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="成果名称" />
                    <asp:BoundField DataField="Rank" HeaderText="完成成果排名" />
                    <asp:TemplateField HeaderText="专利类型">
                        <ItemTemplate>
                            <asp:Label ID="lblType" runat="server" Text=""><%#Eval("Grade") %><%#Eval("Type") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PublishTime" HeaderText="授权日期" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="AuditState" HeaderText="审核状态" />
                   <asp:TemplateField HeaderText="级别">
                       <ItemTemplate>
                           <asp:Label ID="lblJiBie" runat="server" Text=""><%#Eval("LevelFactor") %><%#Eval("JiBie") %></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                    <asp:BoundField DataField="PerScore" HeaderText="科研得分" />
                    <asp:HyperLinkField HeaderText="查看" DataNavigateUrlFields="PK_AID" 
                        DataNavigateUrlFormatString="/Preview/ZhuanLi_Preview.aspx?cmd=preview&srid={0}" Text="查看" />
                    <asp:HyperLinkField DataNavigateUrlFields="PK_AID" 
                        DataNavigateUrlFormatString="ZhuanLi_Add.aspx?cmd=modify&srid={0}" 
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
            </div>
            <div>
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" BackColor="#EEEEEE" 
                    CenterCurrentPageButton="True" 
                    CustomInfoHTML="当前第<span style='color:Red;'>%CurrentPageIndex%</span>/%PageCount%页 每页<span style='color:Red;'>%PageSize%</span>条共%RecordCount%条记录" 
                    FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
                    onpagechanging="AspNetPager1_PageChanging" PageIndexBoxType="DropDownList" 
                    PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left" 
                    ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" 
                    TextBeforePageIndexBox="转到">
                </webdiyer:AspNetPager>
            </div>
    </ContentTemplate>
    </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
    </form>
</body>
</html>
