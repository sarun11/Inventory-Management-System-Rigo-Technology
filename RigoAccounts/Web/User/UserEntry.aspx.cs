using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RigoAccounts.DLL;
using System.Text;
using System.Security.Cryptography;
using RigoAccounts.BLL.Manager;


namespace RigoAccounts
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            heading.Text = "ADD User";

            if (!IsPostBack)
            {
                //Populating The Drop-down-list
                FillDataList();

                //Other logic related to QueryStrings in case of Updation
                hdn_fieldID.Value = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(hdn_fieldID.Value.ToString()))
                {

                    UserDetail dbobj = UserManager.GetUserByID(new Guid(hdn_fieldID.Value));

                    if (dbobj != null)
                    {
                        //Now Append values to the TextFields
                        tb_name.Text = dbobj.FullName;
                        tb_username.Text = dbobj.UserName;
                        list_userType.Items.FindByValue(dbobj.UserType_ID.ToString()).Selected = true;
                        btn_save.Text = "Update";
                        heading.Text = "Update User";
                        btn_clear.Visible = false;
                    }

                }
            }

        }

        //Method to Fill Drop-DownList
        protected void FillDataList()
        {

            var userTypes = UserTypeManager.getAllUserTypes();

            foreach (tblUserType userType in userTypes)
            {
                ListItem i = new ListItem(userType.Name, userType.UserTypeID.ToString());
                list_userType.Items.Add(i);
            }
        }


        //Convert password to HaSH
        protected static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            //Validation

            if (string.IsNullOrEmpty(tb_name.Text))
            {
                lblerrormsg.Text = "Name Field Cannot be Empty!!";
                tb_name.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_username.Text))
            {

                lblerrormsg.Text = "UserName cannot be Empty!!";
                tb_username.Focus();
                return;
            }

            string selected = list_userType.SelectedValue.ToString();
            if (selected == "-1")
            {

                lblerrormsg.Text = "Please Enter a User Type";
                list_userType.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tb_password.Text))
            {

                lblerrormsg.Text = "Password Cannot be Empty";
                tb_password.Focus();
                return;
            }

            if (tb_password.Text.Trim() != tb_rePassword.Text.Trim())
            {

                lblerrormsg.Text = "Password and Repassword Mismatch";
                tb_password.Focus();
                return;
            }

            //To Find if it is a case of Insert or Update
            bool isInsert = true;

            //Create a new Object of (Table) Type UserDetail
            UserDetail obj = new UserDetail();

            if (string.IsNullOrEmpty(hdn_fieldID.Value))
            {

                //Case of creating a new User
                obj.UserID = Guid.NewGuid();
                isInsert = true;
            }
            else
            {
                //Case of Updation 
                obj.UserID = new Guid(hdn_fieldID.Value);
                isInsert = false;
            }

            obj.FullName = tb_name.Text;
            obj.UserName = tb_username.Text;
            obj.PasswordAsHash = MD5Hash(tb_password.Text.Trim());

            obj.UserType_ID = new Guid(list_userType.SelectedItem.Value);

            bool status = UserManager.insertUser(obj, isInsert);

            //Successful Insert or Delete
            if (status)
            {
                clearValue();
                lblerrormsg.ForeColor = System.Drawing.Color.Green;

                if (isInsert)
                {
                    lblerrormsg.Text = "User Inserted Successfully!!";

                }
                else
                {

                    string msg = "User Updated Successfully!!!";
                    Response.Redirect("~/Web/User/UserList.aspx?msg=" + msg);
                }

            }

            else
            {

                lblerrormsg.ForeColor = System.Drawing.Color.Red;
                lblerrormsg.Text = isInsert ? "Cannot Insert New Record!!" : "Cannot Update Record";
            }

        }



        protected void btn_clear_Click(object sender, EventArgs e)
        {
            clearValue();
        }

        public void clearValue()
        {

            tb_name.Text = "";
            tb_username.Text = "";
            tb_password.Text = "";
            tb_rePassword.Text = "";
            lblerrormsg.Text = " ";
            tb_name.Focus();
        }

        protected void list_userType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


