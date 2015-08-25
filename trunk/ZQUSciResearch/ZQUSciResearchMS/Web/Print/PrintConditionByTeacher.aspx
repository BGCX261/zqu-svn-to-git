<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintConditionByTeacher.aspx.cs" Inherits="Web.Print.PrintConditionByTeacher" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>科研成果/业绩打印</title>
    <link href="../css/GridView.css" rel="stylesheet" type="text/css" />
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/Table.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    body{
    	scrollbar-face-color: #add2da;
        scrollbar-highlight-color: #94CAEB;
        scrollbar-arrow-color: #ffffff;
        overflow-x: hidden;
        overflow-y: scroll;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
        <ajaxToolkit:TabPanel HeaderText="科研信息打印" ID="TabPanel1" runat="server">
            <ContentTemplate>
            <div>
                <asp:DropDownList ID="ddl_PrintCondition" runat="server" >
                    <asp:ListItem Value="-1">请选择...</asp:ListItem>
<asp:ListItem Value="0">未提交</asp:ListItem>
<asp:ListItem Value="1">已提交</asp:ListItem>
<asp:ListItem Value="2">一审不通过</asp:ListItem>
<asp:ListItem Value="3">一审通过</asp:ListItem>
<asp:ListItem Value="4">二审不通过</asp:ListItem>
<asp:ListItem Value="5">二审通过</asp:ListItem>
<asp:ListItem Value="6">终审不通过</asp:ListItem>
<asp:ListItem Value="7">终审通过</asp:ListItem>
                </asp:DropDownList>


                    &nbsp; &nbsp;<asp:Label ID="lb_Start" runat="server" Text="从" ></asp:Label>


                    <asp:TextBox ID="Tbox_Start" runat="server" ValidationGroup="Group1"></asp:TextBox>


                    <ajaxToolkit:CalendarExtender ID="Tbox_Start_CalendarExtender" runat="server" 
                        Enabled="True" Format="yyyy-MM-dd" TargetControlID="Tbox_Start"></ajaxToolkit:CalendarExtender>


                <asp:Label ID="lb_End" runat="server" Text="到"></asp:Label>


                <asp:TextBox ID="Tbox_End" runat="server" ValidationGroup="Group1"></asp:TextBox>


                    <ajaxToolkit:CalendarExtender ID="Tbox_End_CalendarExtender" runat="server" 
                        Enabled="True" Format="yyyy-MM-dd" TargetControlID="Tbox_End"></ajaxToolkit:CalendarExtender>


                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="日期格式不正确,应为2011-01-10" ValidationExpression="(19[7-9]\d|20[0-5]\d)\-(0?\d|1[0-2])\-([0-2]?\d|3[01])" 
                ValidationGroup="Group1" ControlToValidate="Tbox_Start" Display="Dynamic"></asp:RegularExpressionValidator>


                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="日期格式不正确,应为2011-01-10" ValidationExpression="(19[7-9]\d|20[0-5]\d)\-(0?\d|1[0-2])\-([0-2]?\d|3[01])"
                ValidationGroup="Group1" ControlToValidate="Tbox_End" Display="Dynamic"></asp:RegularExpressionValidator>


                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="开始日期不能晚于结束日期" Display="Dynamic" ControlToCompare="Tbox_Start" ControlToValidate="Tbox_End" Operator="GreaterThanEqual" ValidationGroup="Group1"></asp:CompareValidator>


                    &nbsp;&nbsp;<asp:Button ID="btn_Print" CssClass="ButtonCss" runat="server" Text="按条件查询" 
                        onclick="btn_Print_Click" ValidationGroup="Group1" />

&#160;
                <asp:Button ID="btn_All" CssClass="ButtonCss" runat="server" Text="全部查询" 
                        onclick="btn_All_Click" />


            </div>
             <div>
                <div style="text-align:right; margin-right:50px">
                    <asp:Label ID="Label2" runat="server" Text="注：可供打印的科研信息只能是二审通过以后的信息。" ForeColor="Red"></asp:Label>


                    <asp:LinkButton ID="LinkButAll" runat="server" Font-Bold="True" Text="打印" href="../Print/PrintByTeacher.aspx" target="_blank" 
                         Font-Overline="False" Font-Underline="True" onclick="btn_Print_Click"></asp:LinkButton>

&#160;&#160;&#160;
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                        Font-Underline="True" onclick="LinkButton1_Click">导出到Excel</asp:LinkButton>


                </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridviewStyle"  
                onrowdatabound="GridView1_RowDataBound" >
                <Columns>
<asp:TemplateField HeaderText="序号">
    <ItemTemplate><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                    
                    </ItemTemplate>
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
