<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YongHuFenPei.aspx.cs" Inherits="Web.YongHuGuanLi.YongHuFenPei" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户分配</title>
    <link href="../css/GridView.css" rel="stylesheet" type="text/css" />
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div >
        <table align="center">
            <tr>
                <td  style="text-align: center">
                    <asp:GridView ID="GridView1" runat="server"  AllowSorting="True" 
                        AutoGenerateColumns="False" AllowPaging="True"  CssClass="gridviewStyle"
                        onrowdatabound="GridView1_RowDataBound" PageSize="9" 
                        onpageindexchanging="GridView1_PageIndexChanging" 
                        onrowcancelingedit="GridView1_RowCancelingEdit" 
                        onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
                        onrowupdating="GridView1_RowUpdating" onsorting="GridView1_Sorting">
                        <RowStyle CssClass="row" /> 
                        <HeaderStyle CssClass="header" />
                        <Columns>
                            <asp:BoundField />
                            <asp:BoundField DataField="PK_UserID" HeaderText="账号"  SortExpression="PK_UserID"/>
                            <%--<asp:BoundField DataField="Password" HeaderText="密码"  SortExpression="Password"/>--%>
                            <asp:BoundField DataField="RoleName" HeaderText="角色"  SortExpression="RoleName" ReadOnly="True" 
                             />
                            <asp:CommandField ShowDeleteButton="True" HeaderText="删除" />
                            <asp:CommandField EditText="修改" HeaderText="修改" ShowEditButton="True" 
                                UpdateText="确定">
                                <FooterStyle Width="100px" />
                                <HeaderStyle Width="150px" />
                                <ItemStyle Width="150px" />
                            </asp:CommandField>
                        </Columns>
                        
                    </asp:GridView>
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Button ID="Btn_addOne" runat="server" Text="逐个分配" onclick="Btn_add_Click" ValidationGroup="one" />
                  
                    &nbsp;&nbsp;&nbsp;
                  
                    <asp:Button ID="Btn_addMore" runat="server" Text="批量分配" 
                        onclick="Btn_addMore_Click" ValidationGroup="more" />
                &nbsp;&nbsp;&nbsp;<%--  请先选择要分配用户的角色：<asp:DropDownList ID="Dr_SelRole" runat="server"  AutoPostBack="true"
                        onselectedindexchanged="Dr_SelRole_SelectedIndexChanged">
                        <asp:ListItem Value="0">请选择角色</asp:ListItem>
                       <asp:ListItem>教师</asp:ListItem>
                        <asp:ListItem>管理员</asp:ListItem>
                        <asp:ListItem>系统管理员</asp:ListItem>
                        <asp:ListItem>超级管理员</asp:ListItem>
                        </asp:DropDownList>--%>
                   <%-- <asp:Label ID="Lb_SelRole" runat="server" Text=" " ForeColor="#FF3399"></asp:Label>--%>
                </td>
            </tr>
            
            
            <tr>
                <td >
                    <asp:Panel ID="Panel3" runat="server" Visible="false"> 
                        用户角色：  
                        <asp:DropDownList ID="Dr_SelRole" runat="server">
                            <asp:ListItem Value="-1">请选择...</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择要分配用户的角色" ControlToValidate="Dr_SelRole" InitialValue="-1"></asp:RequiredFieldValidator>
                        
                         初始密码：<asp:TextBox ID="txtPwd" runat="server" Text="123"></asp:TextBox>(可修改)
                    </asp:Panel>
                    
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <asp:Label ID="Label0" runat="server" Text="账号:"></asp:Label>
                    
                        <asp:TextBox ID="TB_UserID" runat="server"></asp:TextBox>
                        
                        <asp:Label ID="Lb_UserID" runat="server"  Font-Size="14px" ForeColor="Red" 
                            Text=" " Visible="True"></asp:Label>
                        <asp:Button ID="Button1" runat="server" Text="添加" onclick="Button1_Click" />
                    </asp:Panel>
                    
                    
                    <asp:Panel ID="Panel2" runat="server" Visible="False">
                        <asp:Label ID="Label1" runat="server" Text="账号01:"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        
                        <asp:Label ID="Label2" runat="server" Text="账号02:"></asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        
                        <asp:Label ID="Label3" runat="server" Text="账号03:"></asp:Label>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        
                        <asp:Label ID="Label4" runat="server" Text="账号04:"></asp:Label>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            <br />
                        <asp:Label ID="Label5" runat="server" Text="账号05:"></asp:Label>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        
                        <asp:Label ID="Label6" runat="server" Text="账号06:"></asp:Label>
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        
                        <asp:Label ID="Label7" runat="server" Text="账号07:"></asp:Label>
                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                        
                        <asp:Label ID="Label8" runat="server" Text="账号08:"></asp:Label>
                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                            <br />
                        <asp:Label ID="Label9" runat="server" Text="账号09:"></asp:Label>
                        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                        
                        <asp:Label ID="Label10" runat="server" Text="账号10:"></asp:Label>
                        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                        
                        <asp:Label ID="Label11" runat="server" Text="账号11:"></asp:Label>
                        <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                        
                        <asp:Label ID="Label12" runat="server" Text="账号12:"></asp:Label>
                        <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                            <br />
                        <asp:Label ID="Label13" runat="server" Text="账号13:"></asp:Label>
                        <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                        
                        <asp:Label ID="Label14" runat="server" Text="账号14:"></asp:Label>
                        <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                        
                        <asp:Label ID="Label15" runat="server" Text="账号15:"></asp:Label>
                        <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                        
                        <asp:Button ID="Button2" runat="server" Text="添加" onclick="Button2_Click"  />
                        &nbsp;
                        <asp:Button ID="BtCancel" runat="server" Text="取消" onclick="BtCancel_Click" />
                            <br />
                        <asp:Label ID="LbResult" runat="server" Text=" " ForeColor="#FF8080"></asp:Label>
                        
                        
                    </asp:Panel>
                </td>
                 
                <%--<td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ControlToValidate="TB_UserID" runat="server" ErrorMessage="不能空">
                    </asp:RequiredFieldValidator>
               </td>
                --%>
            </tr>
            
            <%--<tr>
                <td >
                    <asp:Label ID="Label2" runat="server" Text="密码:"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="TB_Password" runat="server" TextMode="Password">123</asp:TextBox>
                    <asp:Label ID="Lb_Password"  Font-Size="14px" ForeColor="Red" runat="server" 
                        Text="不能为空" Visible="False"></asp:Label>
                </td>
                <td>
                    
                </td>
                
            </tr>--%>
            <tr>
                <td align="center">
                   
                   
                </td>
                
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
