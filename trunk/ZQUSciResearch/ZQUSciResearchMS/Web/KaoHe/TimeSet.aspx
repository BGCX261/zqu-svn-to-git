<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeSet.aspx.cs" Inherits="Web.KaoHe.TimeSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>科研信息录入/审核时间段设置</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/GridView.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"  runat="server">
    </asp:ScriptManager> 
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
    <ajaxToolkit:TabPanel HeaderText="科研信息录入/审核时间段设置" ID="TabPanel1" runat="server" TabIndex="0">
    <ContentTemplate><asp:GridView ID="GridView1" runat="server" CssClass="gridviewStyle" 
            AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
            <RowStyle CssClass="row" /> 
            <HeaderStyle CssClass="header" />
            <Columns>
                <asp:TemplateField HeaderText="序号"><ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="PeriName" HeaderText="名称" ReadOnly="True" />
                <asp:TemplateField HeaderText="开始时间">
                    <ItemTemplate><%#Eval("StartTime", "{0:yyyy-MM-dd}").ToString()%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtStartTime" runat="server" Text='<%#Eval("StartTime", "{0:yyyy-MM-dd}").ToString() %>' Width="100px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtStartTime_CalendarExtender" runat="server" 
                            Enabled="True" Format="yyyy-MM-dd" TargetControlID="txtStartTime">
                        </ajaxToolkit:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtStartTime"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="结束时间">
                    <ItemTemplate><%#Eval("EndTime", "{0:yyyy-MM-dd}").ToString()%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEndTime" runat="server" Text='<%#Eval("EndTime", "{0:yyyy-MM-dd}").ToString() %>' Width="100px"></asp:TextBox>        
                        <ajaxToolkit:CalendarExtender ID="txtEndTime_CalendarExtender" runat="server" 
                            Enabled="True" Format="yyyy-MM-dd" TargetControlID="txtEndTime">
                        </ajaxToolkit:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtEndTime"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
          </Columns>
          <EmptyDataTemplate>没有数据可操作了~~</EmptyDataTemplate></asp:GridView>
    </ContentTemplate>
    </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
    </form>
</body>
</html>
