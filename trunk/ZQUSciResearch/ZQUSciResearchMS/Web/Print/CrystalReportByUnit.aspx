<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrystalReportByUnit.aspx.cs" Inherits="Web.Print.CrystalReportByUnit" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>学院科研信息报表</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CRViewer1" runat="server" AutoDataBind="true" />
        <CR:CrystalReportSource ID="CRSource1" runat="server">
        </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
