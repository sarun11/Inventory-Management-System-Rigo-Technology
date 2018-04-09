<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="ItemEntry.aspx.cs" Inherits="RigoAccounts.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />

    <br />
    <asp:Label runat="server" style="color:red; font-weight:600; font-size:xx-large;" ID="heading" />
    <br />
    <br />
    <div class="container-fluid">
        <table class="table-striped" style="padding:50px;">
        <tr>
            <td>Item Name: &nbsp;</td>
            <td>
                <asp:TextBox ID="tb_ItemName" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator id="ItemName_validator" ControlToValidate="tb_ItemName" runat="server"
                    Display="None" ErrorMessage="Item Name is required!!"></asp:RequiredFieldValidator>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>Purchase Price (Rs.): &nbsp;</td>
           
            <td>
                <asp:TextBox ID="tb_PurchasePrice" runat="server" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator id="purchasePrice_validator" ControlToValidate="tb_PurchasePrice" runat="server"
                    Display="None" ErrorMessage="Item's Purchase price is required!!"></asp:RequiredFieldValidator>
                <br />
                <br />
            </td>

        </tr>

        <tr>
            <td>Sales Price (Rs.): &nbsp;</td>
           
            <td>
                <asp:TextBox ID="tb_SalesPrice" runat="server" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator id="SalesPrice_validator" ControlToValidate="tb_SalesPrice" runat="server"
                    Display="None" ErrorMessage="Item's Sales price is required!!"></asp:RequiredFieldValidator>
                <br />
                <br />
            </td>
        </tr>

        <tr>
            <td>Opening Quantity (Units): &nbsp;</td>
           
            <td>
                <asp:TextBox ID="tb_qty" runat="server" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator id="openingQtyValidator" ControlToValidate="tb_qty" runat="server"
                    Display="None" ErrorMessage="Item's Opening Quantity is Required!!"></asp:RequiredFieldValidator>
                <br />
                <br />
            </td>
        </tr>

        <tr>
             <td>In Stock: &nbsp;</td>
             <td>
                 <fieldset style="width:300px">
                     <asp:RadioButton ID="inStockYes" Text="Yes" runat="server" GroupName="Item_stockGroup"/>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:RadioButton ID="inStockNo" Text="No" runat="server" GroupName="Item_stockGroup"/>
                     <br />
                 </fieldset>
             </td>
        </tr>

        <tr>
                <td></td>
                <td>
                    <asp:HiddenField runat="server" ID="hdn_fieldID"/>
                    
                     <asp:Button id="btn_save" runat="server" Text="Save" width="100px" OnClick="btn_save_Click" CssClass="btn btn-success"/>
                        
                     <asp:Button ID="btn_clear" runat="server" Text="Clear" Width="100px" CausesValidation="false" OnClick="btn_clear_Click" CssClass="btn btn-alert"/>
                      
                    <br />
                      
                </td>

                
            </tr>

        </table>
        <br />
        <asp:Label ID="lbl_forMsg" runat="server" style="color:red; font-weight:900; font-size:large;"></asp:Label>
    </div>

</asp:Content>
