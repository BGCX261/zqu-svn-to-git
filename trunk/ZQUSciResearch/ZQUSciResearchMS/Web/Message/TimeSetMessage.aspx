<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeSetMessage.aspx.cs" Inherits="Web.Message.TimeSetMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" margin:30px;">
        您当前的操作日期(<span style=" color:Red;"><asp:Label ID="lblNowTime" runat="server" Text="Label"></asp:Label></span>)不在设置的时间内，无法进行此操作！
        <br /><br />
        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>：
        <span style=" color:Red;"><asp:Label ID="lblStartTime" runat="server" Text="Label"></asp:Label></span>
        至 <span style=" color:Red;"><asp:Label ID="lblEndTime" runat="server" Text="Label"></asp:Label></span>
    </div>
    </form>
</body>
</html>
