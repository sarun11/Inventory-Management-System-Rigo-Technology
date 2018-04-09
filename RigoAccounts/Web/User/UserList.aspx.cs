using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RigoAccounts.BLL.Manager;
using RigoAccounts.DLL;


namespace RigoAccounts
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindData();
            lbl_forMsg.Text = "  ";

            if (!IsPostBack)
            {
                lbl_forMsg.Text = Request.QueryString["msg"];
            }

        }

        //Make Changes in Database visible in GridView
        protected void bindData()
        {
            string searchText = "";
            userList.DataSource = UserManager.GetAllUsers(searchText);
            userList.DataBind();
        }

        protected void userList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                userList.PageIndex = e.NewPageIndex;
                userList.DataBind();
            }
            catch (Exception ex)
            {
                lbl_forMsg.Text = ex.Message;
            }

        }

        protected void userList_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnUserId.Value = userList.DataKeys[this.userList.SelectedRow.RowIndex].Values[0].ToString();

            if (!string.IsNullOrEmpty(hdnUserId.Value))
            {

                //Using Query String To Redirect Data to Another Page
                Response.Redirect("~/Web/User/UserEntry.aspx?id=" + hdnUserId.Value);
            }
        }


        //Event Triggered when Delete Button is Pressed
        protected void userList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                hdnUserId.Value = userList.DataKeys[e.RowIndex].Values[0].ToString();
                //lbl_forMsg.Text = hdnUserId.Value.ToString();
            }
            catch (Exception ex)
            {
                lbl_forMsg.Text = ex.Message;
            }

            if (!string.IsNullOrEmpty(hdnUserId.Value))
            {

                UserDetail obj = UserManager.GetUserByID(new Guid(hdnUserId.Value));

                if (obj != null)
                {

                    bool statusOfDelete = UserManager.deleteUser(obj);
                    hdnUserId.Value = "";

                    if (statusOfDelete)
                    {
                        lbl_forMsg.Text = "User Deleted successfully!!";
                        bindData();
                    }
                    else
                    {

                        lbl_forMsg.Text = "Unable To perform Desired Operation!!";
                    }

                }


            }
        }
    }
}