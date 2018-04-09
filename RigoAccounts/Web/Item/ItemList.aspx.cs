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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindData();
            lblMsg.Text = "  ";

            if (!IsPostBack)
            {
                string status = Request.QueryString["status"];
                lblMsg.Text = status=="True" ? "Item Updated Successfully":"";
            }

        }

        protected void bindData()
        {
            ItemList.DataSource = ItemManager.getAllItems();
            ItemList.DataBind();
            
        }

        protected void ItemList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                ItemList.PageIndex = e.NewPageIndex;
                ItemList.DataBind();

            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        protected void ItemList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                hdnUserId.Value = ItemList.DataKeys[e.RowIndex].Values[0].ToString();

            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }


            if (!string.IsNullOrEmpty(hdnUserId.Value))
            {

                ItemOrProduct dbItem = ItemManager.getItemById(new Guid(hdnUserId.Value));

                if (dbItem != null)
                {

                    bool statusOfDelete = ItemManager.deleteItem(dbItem);
                    hdnUserId.Value = "";

                    if (statusOfDelete)
                    {
                        lblMsg.Text = "Item Deleted successfully!!";
                        bindData();
                    }
                    else
                    {

                        lblMsg.Text = "Unable To perform Desired Operation!!";
                    }

                }
            }

        }

        protected void ItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnUserId.Value = ItemList.DataKeys[this.ItemList.SelectedRow.RowIndex].Values[0].ToString();

            if (!string.IsNullOrEmpty(hdnUserId.Value))
            {
                //Using Query String To Redirect Data to Another Page
                Response.Redirect("~/Web/Item/ItemEntry.aspx?id=" + hdnUserId.Value);
            }
        }
    }
}