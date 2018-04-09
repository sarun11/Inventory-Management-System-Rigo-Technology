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
    public partial class WebForm4 : System.Web.UI.Page
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

        protected void bindData()
        {
            CustomerList.DataSource = CustomerManager.getAllCustomers();
            CustomerList.DataBind();
            
        }

        protected void CustomerList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                
                CustomerList.PageIndex = e.NewPageIndex;
                CustomerList.DataBind();
               
            }
            catch (Exception ex)
            {
                lbl_forMsg.Text = ex.Message;
            }

        }

        protected void CustomerList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                hdnUserId.Value = CustomerList.DataKeys[e.RowIndex].Values[0].ToString();
                //lbl_forMsg.Text = hdnUserId.Value.ToString();
            }
            catch (Exception ex)
            {
                lbl_forMsg.Text = ex.Message;
            }

            if (!string.IsNullOrEmpty(hdnUserId.Value))
            {

                Customer dbcust = CustomerManager.getCustomerById(int.Parse(hdnUserId.Value));


                if (dbcust != null)
                {

                    bool statusOfDelete = CustomerManager.deleteCustomer(dbcust);
                    hdnUserId.Value = "";

                    if (statusOfDelete)
                    {
                        lbl_forMsg.Text = "Customer Deleted successfully!!";
                        bindData();
                    }
                    else
                    {

                        lbl_forMsg.Text = "Unable To perform Desired Operation!!";
                    }

                }
            }

        }

        protected void CustomerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnUserId.Value = CustomerList.DataKeys[this.CustomerList.SelectedRow.RowIndex].Values[0].ToString();

            if (!string.IsNullOrEmpty(hdnUserId.Value))
            {
                //Using Query String To Redirect Data to Another Page
                Response.Redirect("~/Web/Customer/CustomerEntry.aspx?id=" + hdnUserId.Value);
            }

        }
    }
}