<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Secretary.aspx.cs" Inherits="Web.Secretary" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>秘书</title>
    <style type="text/css">
    <!--
    body {
	    margin-left: 0px;
	    margin-top: 0px;
	    margin-right: 0px;
	    margin-bottom: 0px;
	    overflow:hidden;
    }
    -->
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="border:0px; width:100%; height:100%" cellspacing="0" cellpadding="0">
        <tr><td colspan="5" style="height:57px;">
            <iframe width="100%" 
                style="border-style: none; border-color: inherit; border-width: 0px; height: 127px;" 
                frameborder="0" src="top.aspx" 
            name="topFrame" id="topframe" title="topFrame"></iframe></td></tr>
        <tr>
            <td width="8" bgcolor="#353c44" valign="top">&nbsp;</td>
            <td style="width:159px; height:100%" valign="top"><iframe width="100%"  height="100%"
                    
                    style="border-style: none; border-color: inherit; border-width: 0px;" frameborder="0" 
            src="Sleft.aspx" name="leftFrame" id="leftFrame" title="leftFrame"></iframe></td>
            <!--<td width="10" bgcolor="#add2da" valign="top">&nbsp;</td>-->
            <td valign="top"><iframe width="100%" height="100%"
                    style="border-style: none; border-color: inherit; border-width: 0px;" 
                    frameborder="0" src="right.aspx" 
            name="rightFrame" id="rightFrame" title="rightFrame"></iframe></td>
            <td width="8" bgcolor="#353c44" valign="top">&nbsp;</td>
        </tr>
        <tr><td colspan="5"><iframe width="100%" 
                style="border-style: none; border-color: inherit; border-width: 0px; height: 11px;" 
                frameborder="0" src="down.aspx" 
            name="footFrame" id="footframe" title="footerFrame"></iframe></td></tr>
    </table>
    </div>
    </form>
</body>
</html>
