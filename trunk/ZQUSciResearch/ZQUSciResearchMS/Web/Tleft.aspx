<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tleft.aspx.cs" Inherits="Web.Tleft" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script src="js/jquery-1.4.4.min.js" type="text/javascript"></script>

    <script src="js/chili-1.7.pack.js" type="text/javascript"></script>

    <script src="js/jquery.accordion.js" type="text/javascript"></script>

    <script src="js/jquery.dimensions.js" type="text/javascript"></script>

    <script src="js/jquery.easing.js" type="text/javascript"></script>
<script src="js/JScript1.js" type="text/javascript"></script>

    <style type="text/css">
        <!--
         body
        {
            margin: 0px;
            padding: 0px;
            font-size: 12px;
            scrollbar-face-color: #add2da;
            scrollbar-highlight-color: #94CAEB;
            scrollbar-arrow-color: #ffffff;
            overflow-x: hidden;
            overflow-y: scroll;
        }
         .main{
	background-image: url(images/Default/main_34.gif);
	background-repeat: repeat-x;
    }
    .main ul {
	display: none;
    }
        #navigation
        {
            margin: 0px;
            padding: 0px;
            width: 147px;
        }
        #navigation a.head
        {
            cursor: pointer;
            background: url(images/Default/main_34.gif) no-repeat scroll;
            display: block;
            font-weight: bold;
            margin: 0px;
            padding: 5px 0 5px;
            text-align: center;
            font-size: 12px;
            text-decoration: none;
        }
        #navigation ul
        {
            border-width: 0px;
            margin: 0px;
            padding: 0px;
            text-indent: 0px;
        }
        #navigation li
        {
            list-style: none;
            display: inline;
        }
        #navigation li li a
        {
            display: block;
            font-size: 12px;
            text-decoration: none;
            text-align: center;
            padding: 3px;
        }
        #navigation li li a:hover
        {
            background: url(images/Default/tab_bg.gif) repeat-x;
            border: solid 1px #adb9c2;
        }
        -- ></style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 100%;">
        <ul id="navigation">
            <li class="main"><a class="head">消息管理</a>
                <ul>
                    <li><a href="#" target="rightFrame">公告通知</a></li>
                    <li><a href="XiaoXi/ShouJianXiang.aspx" target="rightFrame">收件箱</a></li>
                    <li><a href="XiaoXi/FaJianXiang.aspx" target="rightFrame">发件箱</a></li>
                    <li><a href="XiaoXi/FaSongXiaoXi.aspx" target="rightFrame">发送消息</a></li>
                </ul>
            </li>
            <li class="main"><a class="head">科研成果/业绩录入</a>
                <ul>
                    <li><a href="SciResearch/Thesis_List.aspx" target="rightFrame">学术论文</a></li>
                    <li><a href="SciResearch/ZhuZuo_List.aspx" target="rightFrame">学术著作</a></li>
                    <li><a href="SciResearch/ZhuanLi_List.aspx" target="rightFrame">专利成果</a></li>
                    <li><a href="SciResearch/ChuangZuo_List.aspx" target="rightFrame">创作类成果</a></li>
                    <li><a href="SciResearch/KJJD_List.aspx" target="rightFrame">科技鉴定成果</a></li>
                    <li><a href="SciResearch/SKJD_List.aspx" target="rightFrame">社科鉴定成果</a></li>
                    <li><a href="SciResearch/KJYY_List.aspx" target="rightFrame">科技应用成果</a></li>
                    <li><a href="SciResearch/RuanKeXue_List.aspx" target="rightFrame">软科学成果</a></li>
                    <li><a href="SciResearch/HuoJiang_List.aspx" target="rightFrame">获奖成果（教学成果奖）</a></li>
                    <li><a href="SciResearch/Project_List.aspx" target="rightFrame">科研项目</a></li>
                    <li><a href="SciResearch/ShenBao_List.aspx" target="rightFrame">项目申报</a></li>
                </ul>
            </li>
            <li class="main"><a class="head">科研信息情况</a>
                <ul>
                    <li><a href="Audit/Uncommitted.aspx" target="rightFrame">科研信息未提交列表</a></li>
                    <li><a href="Audit/AuditSituation.aspx" target="rightFrame">科研信息审核情况列表</a></li>
                </ul>
            </li>
            <li class="main"><a class="head">科研信息查询</a>
                <ul>
                    <li><a href="Search/SearchByJiaoshi.aspx" target="rightFrame">科研信息查询</a></li>
                    <li><a href="Print/PrintConditionByTeacher.aspx" target="rightFrame">科研信息打印</a></li>
                </ul>
            </li>
            <li class="main"><a class="head">个人设置</a>
                <ul>
                    <li><a href="YongHuGuanLi/ChaKanXinXi.aspx" target="rightFrame">查看信息</a></li>
                    <li><a href="GeRenXinXi.aspx" target="rightFrame">修改信息</a></li>
                    <li><a href="YongHuGuanLi/ChangePassword.aspx" target="rightFrame">修改密码</a></li>
                </ul>
            </li>
            <%--<li class="main"><a class="head">版本信息</a>
                <ul>
                    <li><a href="#" target="_blank">zqu 201009 v1.0</a></li>
                </ul>
            </li>--%>
        </ul>
    </div>
    </form>
</body>
</html>