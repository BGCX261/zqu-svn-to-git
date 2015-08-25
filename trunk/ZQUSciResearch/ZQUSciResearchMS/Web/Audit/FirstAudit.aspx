<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstAudit.aspx.cs" Inherits="Web.Audit.FirstAudit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>科研成果/业绩一审</title>
    <link href="../css/GridView.css" rel="stylesheet" type="text/css" />
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel HeaderText="科研成果/业绩审核列表" ID="TabPanel1" runat="server">
        <ContentTemplate>
            <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridviewStyle"  
                onrowdatabound="GridView1_RowDataBound" onrowcommand="GridView1_RowCommand" >
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="UserName" HeaderText="姓名" />
                    <asp:BoundField DataField="Title" HeaderText="成果/业绩名称" />
                    <asp:BoundField DataField="Rank" HeaderText="完成成果/业绩排名" />
                    <asp:BoundField DataField="SmallSort" HeaderText="成果/业绩类别" />
                    <asp:BoundField DataField="Unit" HeaderText="出版（鉴定）单位/发表刊物名称" />
                    <asp:BoundField DataField="PublishTime" HeaderText="日期" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:TemplateField HeaderText="级别">
                       <ItemTemplate>
                           <asp:Label ID="lblJiBie" runat="server" Text=""><%#Eval("LevelFactor") %><%#Eval("JiBie") %></asp:Label>
                       </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PerScore" HeaderText="科研得分" />
                    <asp:BoundField DataField="AuditState" HeaderText="审核状态" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnAudit" runat="server" CommandName="Audit" CommandArgument='<%#Eval("PK_AID") %>'>审核</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    没有数据可操作了~~
                </EmptyDataTemplate>
                <HeaderStyle CssClass="header" />
                <RowStyle CssClass="row" /> 
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
