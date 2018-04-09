using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RigoAccounts.DLL;
using RigoAccounts.BLL.Manager;

namespace RigoAccounts
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            heading.Text = "Add User Type";
            bindData();
            lblerrormsg.Text = "  ";

            if (!IsPostBack) {

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    try
                    {
                        hdn_fieldID.Value = Request.QueryString["id"];
                        if (!string.IsNullOrEmpty(hdn_fieldID.Value))
                        {
                            btn_save.Text = "Update";
                            heading.Text = "Update User Type";
                            tblUserType dbobj = UserTypeManager.getUserTypeById(new Guid(hdn_fieldID.Value));
                            if (dbobj != null)
                            {
                                tb_userType.Text = dbobj.Name;
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        lblerrormsg.Text = ex.Message;
                    }
                }

                if (!string.IsNullOrEmpty(Request.QueryString["stat"]))
                {
                    string message = Request.QueryString["stat"];
                    if (message == "updateSuccess")
                    {
                        lblerrormsg.Text = "User Type Updated Successfully";
                    }
                    else if (message == "updateFail") {

                        lblerrormsg.Text = "Could Not Update User Type";
                    }

                }
            }

        }

        protected void bindData() {

            userTypeList.DataSource = UserTypeManager.getAllUserTypes();
            userTypeList.DataBind();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            //Check if Empty or not
            if (string.IsNullOrEmpty(tb_userType.Text)) {
                lblerrormsg.Text = "UserType Column Cannot be Empty!!";
                tb_userType.Focus();
                return;
            }

            //Check if already Inserted or not
            foreach (tblUserType UserType in UserTypeManager.getAllUserTypes()) {

                if (UserType.Name.ToUpper() == tb_userType.Text.ToUpper()) {
                    lblerrormsg.Text = "UserType Duplicate!! Already Inserted!!";
                    tb_userType.Focus();
                    tb_userType.Text = "";
                    return;
                }
            }

            //To Find if it is a case of Insert or Update
            bool isInsert;

            //Create an Object of Talbe /class tblUserType
            tblUserType userType = new tblUserType();


            if (string.IsNullOrEmpty(hdn_fieldID.Value))
            {
                //Case of Creating a new user Type
                userType.UserTypeID = Guid.NewGuid();
                isInsert = true;
            }
            else {
                //Case of Updating a user type
                userType.UserTypeID = new Guid(hdn_fieldID.Value);
                isInsert = false;
            }

            userType.Name = tb_userType.Text;

            bool status = UserTypeManager.insertUserType(userType, isInsert);

            //Confirmation of Insert/Edit to the User
            if (status)
            {
                bindData();

                if (isInsert)
                {
                    lblerrormsg.Text = "SuccessFully Inserted New UserType!!";
                }
                else {

                    string stat = "updateSuccess";
                    Response.Redirect("~/Web/User/UserTypeList.aspx?stat=" + stat);
                }
     
            }
            else {

                if(isInsert)
                {
                    lblerrormsg.Text = "Cannot Insert New UserType";
                }
                else {

                    string stat = "updateFail";
                    Response.Redirect("~/Web/User/UserTypeList.aspx?stat=" + stat);
                }
            }

        }

        protected void userTypeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try {
                userTypeList.PageIndex = e.NewPageIndex;
                userTypeList.DataBind();
            }
            catch (Exception ex) {
                lblerrormsg.Text = ex.Message;
            }

        }

        protected void userTypeList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Fetch the Id of the Current userType that is we want to delete
            try
            {
                hdn_fieldID.Value = userTypeList.DataKeys[e.RowIndex].Values[0].ToString();

            }
            catch (Exception ex)
            {
                lblerrormsg.Text = ex.Message;
            }

            /*
            //Validate if such Category is being used by any od the users or not!
            //Fetch all userTypes being selected
            //Later to be changed to Guid
            foreach (UserDetail user in UserManager.GetAllUsers()) {
                try
                {
                    if (hdn_fieldID.Value == user.UserType) {
                        lblerrormsg.Text = "Cannot Delete UserType! The userType is being applied to existing Users!!";
                        return;
                    }
                }
                catch (Exception ex) {
                    lblerrormsg.Text = ex.Message;
                }
            }*/

            if (!string.IsNullOrEmpty(hdn_fieldID.Value)) {

                tblUserType dbUserType = UserTypeManager.getUserTypeById(new Guid(hdn_fieldID.Value));

                if (dbUserType != null) {
                    bool statusOfDelete = UserTypeManager.deleteUserType(dbUserType);

                    lblerrormsg.Text = statusOfDelete ? "UserType Deleted Successfully!!" : "Couldnot Delete UserType";
                    hdn_fieldID.Value = "";
                    bindData();
                }
            }

            
        }

        protected void userTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_save.Text = "Update";
            tb_userType.Text = "";
            hdn_fieldID.Value= userTypeList.DataKeys[this.userTypeList.SelectedRow.RowIndex].Values[0].ToString();
            if (!string.IsNullOrEmpty(hdn_fieldID.Value))
            {       
                tblUserType dbobj = UserTypeManager.getUserTypeById(new Guid(hdn_fieldID.Value));
                if (dbobj != null) {
                    tb_userType.Text = dbobj.Name;
                }
            }

        }
    }
}