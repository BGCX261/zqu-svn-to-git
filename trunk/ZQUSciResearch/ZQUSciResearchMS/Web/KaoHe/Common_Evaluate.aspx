<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Common_Evaluate.aspx.cs" Inherits="Web.KaoHe.Common_Evaluate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>计分通则设置</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/GridView.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
    <ajaxToolkit:TabPanel HeaderText="级别分数设置" ID="TabPanel1" runat="server" TabIndex="0">
    <ContentTemplate><asp:GridView ID="GridView1" runat="server" CssClass="gridviewStyle" 
            AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
            <RowStyle CssClass="row" /> 
            <HeaderStyle CssClass="header" />
            <Columns>
                <asp:TemplateField HeaderText="序号"><ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="JiBie" HeaderText="级别" ReadOnly="True" />
                <asp:TemplateField HeaderText="级别分数">
                    <ItemTemplate><%#Eval("Score")%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtScore" runat="server" Text='<%#Eval("Score") %>' Width="100px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="只能为非负整数" ControlToValidate="txtScore" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtScore"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
          </Columns>
          <EmptyDataTemplate>没有数据可操作了~~</EmptyDataTemplate></asp:GridView>
    </ContentTemplate>
    </ajaxToolkit:TabPanel>
    
    <%--<ajaxToolkit:TabPanel HeaderText="计分通则一设置" ID="TabPanel2" runat="server" TabIndex="1">
    <ContentTemplate><asp:GridView ID="GridView2" runat="server" CssClass="gridviewStyle" 
            AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
            <RowStyle CssClass="row" /> 
            <HeaderStyle CssClass="header" />
            <Columns>
                <asp:TemplateField HeaderText="序号"><ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="专利类型">
                    <ItemTemplate><%#Eval("Grade") %><%#Eval("Type") %></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="级别分系数">
                    <ItemTemplate><%#Eval("LevelFactor") %></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLevelFactor" runat="server" Text='<%#Eval("LevelFactor") %>' Width="40px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="只能为非负数" ControlToValidate="txtLevelFactor" ValidationExpression="^\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtLevelFactor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="级别">
                    <ItemTemplate><%#Eval("JiBie")%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlJiBie" runat="server">
                            <asp:ListItem Value="-1">请选择...</asp:ListItem>
                            <asp:ListItem Value="A">A</asp:ListItem>
                            <asp:ListItem Value="B">B</asp:ListItem>
                            <asp:ListItem Value="C">C</asp:ListItem>
                            <asp:ListItem Value="D">D</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="ddlJiBie" InitialValue="-1"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
          </Columns>
          <EmptyDataTemplate>没有数据可操作了~~</EmptyDataTemplate></asp:GridView>
    </ContentTemplate>
    </ajaxToolkit:TabPanel>--%>
    
    <ajaxToolkit:TabPanel HeaderText="多人合作个人得分比例设置" ID="TabPanel3" runat="server" TabIndex="2">
    <ContentTemplate><asp:GridView ID="GridView3" runat="server" CssClass="gridviewStyle" 
            AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound" 
            onrowcancelingedit="GridView3_RowCancelingEdit" 
            onrowediting="GridView3_RowEditing" onrowupdating="GridView3_RowUpdating">
            <RowStyle CssClass="row" /> 
            <HeaderStyle CssClass="header" />
            <Columns>
                <asp:TemplateField HeaderText="序号"><ItemTemplate><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="Population" HeaderText="完成人数" ReadOnly="True" />
                <asp:BoundField DataField="Rank" HeaderText="作者排名" ReadOnly="True" />
                <asp:TemplateField HeaderText="得分比例">
                    <ItemTemplate><%#Eval("ScoreScale")%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtScoreScale" runat="server" Text='<%#Eval("ScoreScale") %>' Width="40px"></asp:TextBox>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="只能为百分数（格式：5/8）" ControlToValidate="txtScoreScale" ValidationExpression="\d+\.?\%"></asp:RegularExpressionValidator>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtScoreScale"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
          </Columns>
          <EmptyDataTemplate>没有数据可操作了~~</EmptyDataTemplate></asp:GridView>
          <webdiyer:AspNetPager ID="AspNetPager1" runat="server" BackColor="#EEEEEE" 
            CenterCurrentPageButton="True" 
            CustomInfoHTML="当前第<span style='color:Red;'>%CurrentPageIndex%</span>/%PageCount%页 每页<span style='color:Red;'>%PageSize%</span>条共%RecordCount%条记录" 
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
            onpagechanging="AspNetPager1_PageChanging" PageIndexBoxType="DropDownList" 
            PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left" 
            ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" 
            TextBeforePageIndexBox="转到">
        </webdiyer:AspNetPager>
    </ContentTemplate>
    </ajaxToolkit:TabPanel>
    
    <ajaxToolkit:TabPanel HeaderText="项目主持人得分比例设置" ID="TabPanel4" runat="server" TabIndex="3">
    <ContentTemplate><asp:GridView ID="GridView4" runat="server" CssClass="gridviewStyle" 
            AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound" 
            onrowcancelingedit="GridView4_RowCancelingEdit" 
            onrowediting="GridView4_RowEditing" onrowupdating="GridView4_RowUpdating">
            <RowStyle CssClass="row" /> 
            <HeaderStyle CssClass="header" />
            <Columns>
                <asp:TemplateField HeaderText="序号"><ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="Type" HeaderText="是否项目主持人" ReadOnly="True" />
                <asp:TemplateField HeaderText="得分比例">
                    <ItemTemplate><%#Eval("Scale")%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtScale" runat="server" Text='<%#Eval("Scale") %>' Width="40px"></asp:TextBox>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="只能小数（格式：0.7）" ControlToValidate="txtScale" ValidationExpression="[1-9]{0,1}[0-9](\\.[0-9])?"></asp:RegularExpressionValidator>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtScale"></asp:RequiredFieldValidator>
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