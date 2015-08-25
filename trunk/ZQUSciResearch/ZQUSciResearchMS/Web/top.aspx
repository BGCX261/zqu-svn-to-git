<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="Web.top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script language="javascript" type="text/javascript">
		function clockon(){
		var now=new Date();
		var year=now.getYear();
		var month=now.getMonth();
		var date=now.getDate();
		var day=now.getDay();
		var hour=now.getHours();
		var minu=now.getMinutes();
		var sec=now.getSeconds();
		var week;
		month=month+1;
		if(month<10) month="0"+month;
		if(date<10) date="0"+date;
		if(hour<10) hour="0"+hour;
		if(minu<10) minu="0"+minu;
		if(sec<10) sec="0"+sec;
		switch (day)
		  { case 1:
		        week="星期一";
				break;
			case 2:
		        week="星期二";
				break;
			case 3:
		        week="星期三";
				break;
			case 4:
		        week="星期四";
				break;
			case 5:
		        week="星期五";
				break;
			case 6:
		        week="星期六";
				break;
			default:
		        week="星期日";
				break;
		  }
		var time="";
		time=year+"年"+month+"月"+date+"日 "+week+" "+hour+":"+minu+":"+sec;
		if(document.all){
			bgclock.innerHTML="["+time+"]";
		}
		var timer=setTimeout("clockon()",1000);
	}  

    </script>

    <style type="text/css">
        <!--
         body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            overflow:hidden;
        }
        .STYLE1
        {
            font-size: 12px;
            color: #000000;
        }
        .STYLE5
        {
            font-size: 12;
        }
        .STYLE7
        {
            font-size: 12px;
            color: #FFFFFF;
        }
        .STYLE7 a
        {
            font-size: 12px;
            color: #FFFFFF;
        }
        a img
        {
            border: none;
        }
        -- >

    </style>
</head>
<body onload="clockon()">
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="57" background="images/Default/main_03.gif">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="470" height="57" background="images/Default/main_01.gif">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td width="281" valign="bottom">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="33" height="27">
                                            <img src="images/Default/main_05.gif" width="33" height="27" />
                                        </td>
                                        <td width="248" background="images/Default/main_06.gif">
                                            <table width="225" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="17">
                                                        <div align="right">
                                                            <a href="YongHuGuanLi/ChangePassword.aspx" target="rightFrame">
                                                                <img src="images/Default/pass.gif" width="69" height="17" /></a></div>
                                                    </td>
                                                    <td>
                                                        <div align="right">
                                                            <a href="YongHuGuanLi/ChaKanXinXi.aspx" target="rightFrame">
                                                                <img src="images/Default/user.gif" width="69" height="17" /></a></div>
                                                    </td>
                                                    <td>
                                                        <div align="right">
                                                            <a href="login.aspx" target="_parent">
                                                                <img src="images/Default/quit.gif" alt=" " width="69" height="17" /></a></div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="40" background="images/Default/main_10.gif">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="40" background="images/Default/main_07.gif" class="style1">
                                &nbsp;
                            </td>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="21">
                                            <img src="images/Default/main_13.gif" width="19" height="14" />
                                        </td>
                                        <td width="35" class="STYLE7">
                                            <div align="center">
                                                <a href="main.html" target="rightFrame">首页</a></div>
                                        </td>
                                        <td width="21" class="STYLE7">
                                            <img src="images/Default/main_15.gif" width="19" height="14" />
                                        </td>
                                        <td width="35" class="STYLE7">
                                            <div align="center">
                                                <a href="javascript:history.go(-1);">后退</a></div>
                                        </td>
                                        <td width="21" class="STYLE7">
                                            <img src="images/Default/main_17.gif" width="19" height="14" />
                                        </td>
                                        <td width="35" class="STYLE7">
                                            <div align="center">
                                                <a href="javascript:history.go(1);">前进</a></div>
                                        </td>
                                        <td width="21" class="STYLE7">
                                            <img src="images/Default/main_19.gif" width="19" height="14" />
                                        </td>
                                        <td width="35" class="STYLE7">
                                            <div align="center">
                                                <a href="javascript:window.parent.location.reload();">刷新</a></div>
                                        </td>
                                        <td width="21" class="STYLE7">
                                            <img src="images/Default/main_21.gif" width="19" height="14" />
                                        </td>
                                        <td width="35" class="STYLE7">
                                            <div align="center">
                                                <a href="#" target="_parent">帮助</a></div>
                                        </td>
                                        <td>
                                            <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>--%>
                                                    <div align="center">
                                                        <a href="XiaoXi/ShouJianXiang.aspx" style="font-size: 11pt; color: yellow;" target="rightFrame">
                                                            您有<asp:Label ID="lblCount" runat="server" Text="" AutoPostBack="True"></asp:Label>条新消息！</a></div>
                                                <%--</ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="248" background="images/Default/main_11.gif">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="16%">
                                            <span class="STYLE5"></span>
                                        </td>
                                        <td width="75%">
                                            <div align="center">
                                                <div id="bgclock" style="font-size: 9pt; color: #ffffff;">
                                                </div>
                                            </div>
                                        </td>
                                        <td width="9%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="30" background="images/Default/main_31.gif">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="8" height="30">
                                <img src="images/Default/main_28.gif" width="8" height="30" />
                            </td>
                            <td width="147" background="images/main_29.gif">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="24%">
                                            &nbsp;
                                        </td>
                                        <td width="43%" height="20" valign="bottom" class="STYLE1">
                                            管理菜单
                                        </td>
                                        <td width="33%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="39">
                                <img src="images/Default/main_30.gif" width="39" height="30" />
                            </td>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="20" valign="bottom"><span class="STYLE1">当前登录用户：
                                            <asp:Label ID="Lb_UserName" runat="server" Text=""></asp:Label> &nbsp;用户角色：
                                            <asp:Label ID="Lb_Role" runat="server" Text=""></asp:Label> &nbsp;所在单位：
                                            <asp:Label ID="Lb_Unit" runat="server" Text=""></asp:Label>
                                                </span>
                                        </td>
                                        <td valign="bottom" class="STYLE1"><div align="right"></div></td>
                                    </tr>
                                </table>
                            </td>
                            <td width="17">
                                <img src="images/Default/main_32.gif" width="17" height="30" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
