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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            heading.Text = "ADD Customer";

            if (!IsPostBack) {

                hdn_fieldID.Value = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(hdn_fieldID.Value))
                {
                    
                    Customer dbcust = CustomerManager.getCustomerById(int.Parse(Request.QueryString["id"]));

                    if (dbcust != null)
                    {
                        tb_custName.Text = dbcust.Name.ToString();
                        tb_custAddress.Text = dbcust.Address.ToString();
                        btn_save.Text = "Update";
                        heading.Text = "Update Customer";
                        btn_clear.Visible = false;
                    }
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_custName.Text))
            {

                lbl_forMsg.Text = "Name cannot Be Empty!!";
                tb_custName.Focus();

                return;
            }

            if (string.IsNullOrEmpty(tb_custAddress.Text))
            {

                lbl_forMsg.Text = "Customer Address cannot be Empty!!";
                tb_custAddress.Focus();
                return;
            }

            bool isInsert;
            Customer cust = new Customer();

            if (!string.IsNullOrEmpty(hdn_fieldID.Value))
            {
                //update
                isInsert = false;
                cust.CustomerID = int.Parse(hdn_fieldID.Value);
            }
            else
            {
                isInsert = true;
                //insert
            }

            cust.Name = tb_custName.Text;
            cust.Address = tb_custAddress.Text;

            bool status = CustomerManager.insertCustomer(cust, isInsert);

            if (status)
            {
                clearData();
                lbl_forMsg.ForeColor = System.Drawing.Color.Green;

                if (isInsert)
                {
                    lbl_forMsg.Text = "Customer Inserted Successfully!!";
                }
                else
                {
                    string msg = "Customer Updated Successfully!!!";
                    Response.Redirect("~/Web/Customer/CustomerList.aspx?msg=" + msg);
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

            tb_custName.Text = " ";
            tb_custAddress.Text = " ";
            lbl_forMsg.Text = " ";
            tb_custName.Focus();
        }
    }
}