using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ZQUSR.BLL;
namespace Web.YongHuGuanLi
{
    public partial class YongHuFenPei : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        sr_User users = new sr_User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)  //如果用户还没登陆跳到登陆页面
                    Response.Redirect("../login.aspx");
                else
                {
                        
                    
                    if (Session["Role"] != null)
                    {
                        if (Session["Role"].ToString() == "系统管理员")
                        {
                            Dr_SelRole.Items.Add(new ListItem("教师", "ZQUSR4000"));
                            Dr_SelRole.Items.Add(new ListItem("管理员", "ZQUSR3000"));
                        }
                        else if (Session["Role"].ToString() == "超级管理员")
                        {
                            Dr_SelRole.Items.Add(new ListItem("系统管理员", "ZQUSR2000"));
                        }
                        ViewState["SortOrder"] = "PK_UserID";        //保存默认表达式和排序顺序
                        ViewState["OrderDire"] = "ASC";
                        //ViewState["SortOrder"] = "Password";
                        ViewState["OrderDire"] = "ASC";
                        bind();
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('您已经与服务器断开连接，请重新登录！');window.location.href='~/../../login.aspx';</script>");
                    }
                }
            }
        }
        void Getdataset()
        {
            //string Roles = Session["Role"].ToString();
            //switch (Roles)
            //{

            //    case "管理员":
            //        ds = users.GetTeachersList();
            //        break;
            //    case "系统管理员":
            //        ds = users.GetGuanliyuanList();
            //        break;
            //    case "超级管理员":
            //        ds = users.GetXitongGuanliyuanList();
            //        break;
            //    default:
            //        break;
            //}
            if (Session["Role"].ToString() == "系统管理员")
            {
                ds = users.GetFeipeiUser(); //所要分配用户为教师或管理员
            }
            else if (Session["Role"].ToString() == "超级管理员")
            {
                ds = users.GetFeipeiUserXiTong();//所要分配用户为系统管理员
            }
            //ds = users.GetFeipeiUser();
        }
        void bind()
        {
            Getdataset();

            DataView view = ds.Tables[0].DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            view.Sort = sort;
            this.GridView1.DataSource = view;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)    //鼠标遇到每一行时更改颜色
            {
                //鼠标移动到每项时颜色交替效果    
                e.Row.Attributes.Add("OnMouseOut", "this.style.backgroundColor='White';");
                e.Row.Attributes.Add("OnMouseOver", "this.style.backgroundColor='#f7f7f7';");

                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    ((LinkButton)(e.Row.Cells[3].Controls[0])).Attributes.Add("onclick", "return confirm('你确定删除吗?')");
                //点击删除时 强制弹出对话框
            }
            if (e.Row.RowIndex != -1)           //实现自动编号
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
            foreach (TableCell tc in e.Row.Cells)               //设置每一行的宽度
            {
                tc.Attributes["style"] = "width:100px;";

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)  //分页
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind();
        }

        protected string GetRolesID()           //获取所要进行操作的用户的角色的ID
        {
            string AddRoleID = "";
            string RoseTemp = "";
            RoseTemp = Dr_SelRole.SelectedValue;
            switch (RoseTemp)
            {
                case "教师":
                    AddRoleID = "ZQUSR4000";
                    break;
                case "管理员":
                    AddRoleID = "ZQUSR3000";
                    break;
                case "系统管理员":
                    AddRoleID = "ZQUSR2000";
                    break;
                case "超级管理员":
                    AddRoleID = "ZQUSR1000";
                    break;
                default:
                    break;
            }
            return AddRoleID;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string AddUserID = TB_UserID.Text.Trim().ToString();
            //string AddPassword = TB_Password.Text.ToString().Trim();

            string AddRoleID = "";
            //AddRoleID = GetRolesID();
            AddRoleID = Dr_SelRole.SelectedValue.ToString();
            try
            {
                if (TB_UserID.Text.Trim().ToString() == "") //如果不加.Trim()函数，那么输入空格也会成为合法输入，这样显然不符合逻辑。
                {
                    this.Lb_UserID.Text = "不能空";
                    return;
                }
                //if (TB_Password.Text == "")
                //{
                //    this.Lb_Password.Visible = true;
                //    return;
                //}
                else
                {
                    this.Lb_UserID.Text = " ";
                    //        this.Lb_Password.Visible = false;
                }
                if (users.Exists(AddUserID))        //此用账号已经存在
                {

                    this.Lb_UserID.Text = "此用账号已被使用";
                    this.TB_UserID.Text = "";
                    TB_UserID.Focus();

                    return;
                }
                else
                {
                    string temp_password = txtPwd.Text.Trim().ToString();
                    string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(temp_password, "MD5");
                    bool flag = false;
                    flag = users.AddUser(AddUserID, pwd, AddRoleID);   //增加用户
                    if (flag == true)
                    {
                        this.Lb_UserID.Text = "添加成功";

                    }
                    bind();
                }

            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('添加失败,系统错误')</script>");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            GridViewRow row = GridView1.Rows[index];
            string uid = row.Cells[1].Text.ToString();
            users.Delete(uid);
            bind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)     //获得要编辑行的索引
        {
            int index = e.NewEditIndex;

            GridViewRow row = GridView1.Rows[index];
            Session["temp"] = row.Cells[1].Text.ToString();     //用于暂时保存一下选中的ID
            Session["tempRole"] = row.Cells[2].Text.ToString(); //用于暂时保存一下选中的准备添加的用户的角色
            GridView1.EditIndex = e.NewEditIndex;
            bind();

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)  //编辑更新
        {
            try
            {
                sr_User users = new sr_User();
                string UserID="";//新的用户ID
                string RoleID="";//用户角色的ID
                string OldID = Session["temp"].ToString();
                Session.Remove("temp");                     //把未更改时 gridview的ID值拿出来后 可以删掉Session["temp"]
                String tempRole = Session["tempRole"].ToString();
                Session.Remove("tempRole");//把gridview的角色Role值拿出来后 可以删掉Session["tempRole"]
                string Password;
                Password = users.GetPassword(OldID);//获得要插进去的密码
                if (tempRole == "教师")
                    RoleID = "ZQUSR4000";
                else if (tempRole == "管理员")
                    RoleID = "ZQUSR3000";
                else if (tempRole == "系统管理员")
                    RoleID = "ZQUSR2000";
                UserID = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();//新的ID
                
                if (users.Exists(UserID))       //此账号已经存在
                {
                    Response.Write("<script>alert('此账号已被使用,请改为另外账号')</script>");
                    return;
                }
                else //更新账号==插进一条新的信息删除旧的信息
                {
                  //  users.UpdateIDPwd(UserID,RoleID, OldID);    //插进一条新的信息删除旧的信息（必须还要插进去密码）！！
                    users.UpdateIDPwd(UserID, Password, RoleID, OldID);    //更新一条新的信息删除、旧的信息
                }

            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('抱歉更改失败，建议删除此记录重新添加')</script>");
            }
            finally
            {
                GridView1.EditIndex = -1;
                bind();
            }

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)//取消编辑
        {
            GridView1.EditIndex = -1;
            bind();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sPage = e.SortExpression;
            if (ViewState["SortOrder"].ToString() == sPage)
            {
                if (ViewState["OrderDire"].ToString() == "Desc")
                    ViewState["OrderDire"] = "ASC";
                else
                    ViewState["OrderDire"] = "Desc";
            }
            else
            {
                ViewState["SortOrder"] = e.SortExpression;
            }
            bind();
        }

        protected void Btn_add_Click(object sender, EventArgs e)
        {
            //if (Dr_SelRole.SelectedValue == "请选择角色")
            //{
            //    Lb_SelRole.Text = "请先选择要分配用户的角色";
            //    Panel1.Visible = false;
            //    Panel2.Visible = false;
            //    return;
            //}
            this.Lb_UserID.Text = "";
            //Lb_SelRole.Text = "";
            this.TB_UserID.Focus();
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = true;
        }

        protected void Btn_addMore_Click(object sender, EventArgs e)
        {
            //if (Dr_SelRole.SelectedValue == "请选择角色")
            //{
            //    Lb_SelRole.Text = "请先选择要分配用户的角色";
            //    Panel1.Visible = false;
            //    Panel2.Visible = false;
            //    return;
            //}

            LbResult.Text = "";
            //Lb_SelRole.Text = "";
            TextBox1.Focus();
            clearTextBox();
            Panel2.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            sr_User users = new sr_User();

            string UserID01 = TextBox1.Text.Trim().ToString();
            string UserID02 = TextBox2.Text.Trim().ToString();
            string UserID03 = TextBox3.Text.Trim().ToString();
            string UserID04 = TextBox4.Text.Trim().ToString();
            string UserID05 = TextBox5.Text.Trim().ToString();
            string UserID06 = TextBox6.Text.Trim().ToString();
            string UserID07 = TextBox7.Text.Trim().ToString();
            string UserID08 = TextBox8.Text.Trim().ToString();
            string UserID09 = TextBox9.Text.Trim().ToString();
            string UserID10 = TextBox10.Text.Trim().ToString();
            string UserID11 = TextBox11.Text.Trim().ToString();
            string UserID12 = TextBox12.Text.Trim().ToString();
            string UserID13 = TextBox13.Text.Trim().ToString();
            string UserID14 = TextBox14.Text.Trim().ToString();
            string UserID15 = TextBox15.Text.Trim().ToString();

            string AddRoleID = "";
            //AddRoleID = GetRolesID();
            AddRoleID = Dr_SelRole.SelectedValue.ToString();

         //   string temp_password = txtPwd.Text.Trim().ToString();
            string temp_Pwd = txtPwd.Text.Trim().ToString();
            string temp_password = FormsAuthentication.HashPasswordForStoringInConfigFile(temp_Pwd, "MD5");

            int lenght = 15;
            string[] strUserIDs = new String[lenght];
            string WrongInputNum = "";
            int count = 0;
            int emptyID = 0;

            strUserIDs[0] = UserID01;
            strUserIDs[1] = UserID02;
            strUserIDs[2] = UserID03;
            strUserIDs[3] = UserID04;
            strUserIDs[4] = UserID05;
            strUserIDs[5] = UserID06;
            strUserIDs[6] = UserID07;
            strUserIDs[7] = UserID08;
            strUserIDs[8] = UserID09;
            strUserIDs[9] = UserID10;
            strUserIDs[10] = UserID11;
            strUserIDs[11] = UserID12;
            strUserIDs[12] = UserID13;
            strUserIDs[13] = UserID14;
            strUserIDs[14] = UserID15;
            this.LbResult.Text = " ";
            for (int i = 0; i < lenght; i++)
            {
                if (strUserIDs[i] != "")
                {
                    if (!users.Exists(strUserIDs[i]))
                    {
                        users.AddUser(strUserIDs[i], temp_password, AddRoleID);   //增加用户
                        count++;
                    }
                    else
                    {
                        WrongInputNum += (i + 1).ToString() + ",";
                    }
                }
                else
                {
                    emptyID++;
                }

                //   this.LbResult.Text +=(i+1).ToString()+":"+ strUserIDs[i]+",";
            }

            if (emptyID == 15)  //输入全为空
            {
                this.LbResult.Text = " 抱歉，输入不能全为空";
                return;
            }
            if (count == 15) //输入不为空 且 输入账号不重复，即添加了全部数据
            {
                this.LbResult.Text = " 恭喜已成功添加全部数据";

                TextBox1.Focus();
                clearTextBox();
            }
            else //添加了少于15条的数据
            {
                this.LbResult.Text = " 总共添加" + count + "条数据";
                if (WrongInputNum != "")           //输入存在重复账号  
                {
                    this.LbResult.Text += " 注意：账号" + WrongInputNum + "的数据已被使用，请重新输入";
                }
                else //有些输入为空，但输入不为空的都没有输入重复账号
                {

                    TextBox1.Focus();
                    clearTextBox();
                }

            }
            bind();

        }
        protected void clearTextBox()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
            TextBox14.Text = "";
            TextBox15.Text = "";
        }
        protected void BtCancel_Click(object sender, EventArgs e)
        {
            TextBox1.Focus();
            clearTextBox();
            LbResult.Text = "";
        }

        //public void Dr_SelRole_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (Dr_SelRole.SelectedValue == "请选择角色")
        //    {
        //        Lb_SelRole.Text = "请先选择要分配用户的角色";
        //        Panel1.Visible = false;
        //        Panel2.Visible = false;

        //    }
        //    else
        //    {
        //        GetRolesID();           //获取所要进行操作的用户的角色的ID
        //        Lb_SelRole.Text = "";
        //        Lb_SelRole.Visible = true;
        //    }
        //}
    }
}
