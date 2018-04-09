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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            heading.Text = "ADD Item";

            if (!IsPostBack) {

                hdn_fieldID.Value = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(hdn_fieldID.Value))
                {

                    ItemOrProduct dbItm = ItemManager.getItemById(new Guid(hdn_fieldID.Value));
                    
                    if (dbItm != null)
                    {
                        tb_ItemName.Text = dbItm.Name;

                        tb_PurchasePrice.Text = dbItm.PurchasePrice.ToString();

                        tb_SalesPrice.Text = dbItm.SalesPrice.ToString();

                        tb_qty.Text = dbItm.OpeningQty.ToString();

                        if (dbItm.InStock == "Yes")
                        {
                            inStockYes.Checked = true;
                        }
                        else {
                            inStockNo.Checked = true;
                        }

                        btn_save.Text = "Update";
                        heading.Text = "Update Item";
                        btn_clear.Visible = false;
                    }
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(tb_ItemName.Text))
            {
                lbl_forMsg.Text = "Item Name cannot Be Empty!!";
                tb_ItemName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tb_PurchasePrice.Text))
            {

                lbl_forMsg.Text = "Item's purchase price cannot be Empty!!";
                tb_PurchasePrice.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tb_SalesPrice.Text)) {

                lbl_forMsg.Text = "Item's sales price Field cannot be Empty!!";
                tb_SalesPrice.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tb_qty.Text)) {

                lbl_forMsg.Text = "Item's Opening Qty Field cannot be Empty!!";
                tb_qty.Focus();
                return;
            }

            bool isInsert;

            ItemOrProduct item = new ItemOrProduct();

            if (!string.IsNullOrEmpty(hdn_fieldID.Value))
            {
                //update
                isInsert = false;
                item.ItemID = new Guid(hdn_fieldID.Value);
            }
            else
            {
                item.ItemID = Guid.NewGuid();
                isInsert = true;
                //insert
            }

            try
            {
                item.Name = tb_ItemName.Text;
            }
            catch(Exception ex) {
                lbl_forMsg.Text = ex.Message;
            }

            try
            {
                item.PurchasePrice = decimal.Parse(tb_PurchasePrice.Text);
            }
            catch (Exception ex) {
                lbl_forMsg.Text = ex.Message;
            }

            try
            {
                item.SalesPrice = decimal.Parse(tb_SalesPrice.Text);
            }
            catch (Exception ex)
            {
                lbl_forMsg.Text = ex.Message;
            }

            try
            {
                item.OpeningQty = int.Parse(tb_qty.Text);
            }
            catch (Exception ex)
            {
                lbl_forMsg.Text = ex.Message;
            }


            if (inStockYes.Checked)
            {
                item.InStock = "Yes";
            }
            else if (inStockNo.Checked)
            {
                item.InStock = "No";
            }
            else {
                lbl_forMsg.Text = "No Enough Information!! Please Select Availability option (Yes/No)";
                return;
            }

            bool status = ItemManager.insertItem(item, isInsert);

            if (status)
            {
                clearData();
                lbl_forMsg.ForeColor = System.Drawing.Color.Green;

                if (isInsert)
                {
                    lbl_forMsg.Text = "Item Inserted Successfully!!";
                }
                else
                {
                    bool success= true;
                    Response.Redirect("~/Web/Item/ItemList.aspx?status=" + success);
                }
            }

            else
            {
                lbl_forMsg.ForeColor = System.Drawing.Color.Red;
                lbl_forMsg.Text = isInsert ? "Cannot Insert New Record!!" : "Cannot Update Record";
            }

        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            clearData();
        }

        protected void clearData()
        {

            tb_ItemName.Text = " ";
            tb_PurchasePrice.Text = " ";
            tb_qty.Text = " ";
            tb_SalesPrice.Text = " ";
            inStockYes.Checked = true;
            lbl_forMsg.Text = " ";
            tb_ItemName.Focus();
        }
   
    }
}