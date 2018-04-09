<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="CustomerEntry.aspx.cs" Inherits="RigoAccounts.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />

    <br />
    <asp:Label runat="server" style="color:red; font-weight:600; font-size:xx-large;" ID="heading" />
    <br />
    <br />
    <div class="container-fluid">
        <table class="table-striped" style="padding:50px;">
        <tr>
            <td>Customer Name: &nbsp;</td>
            <td>
                <asp:TextBox ID="tb_custName" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator id="custName_validator" ControlToValidate="tb_custName" runat="server"
                    Display="None" ErrorMessage="Customer Name Field is required!!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Customer Address: &nbsp;</td>
            <td>
                <asp:TextBox ID="tb_custAddress" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator id="custAddress_validator" ControlToValidate="tb_custAddress" runat="server"
                    Display="None" ErrorMessage="Customer Address Field is required!!"></asp:RequiredFieldValidator>
            </td>

        </tr>

        <tr>
                <td></td>
                <td>
                    <asp:HiddenField runat="server" ID="hdn_fieldID"/>
                    
                     <asp:Button id="btn_save" runat="server" Text="Save" width="100px" OnClick="btn_save_Click" CssClass="btn btn-success"/>
                        
                     <asp:Button ID="btn_clear" runat="server" Text="Clear" Width="100px" CausesValidation="false" OnClick="btn_clear_Click" CssClass="btn btn-alert"/>
                      
                </td>

                
            </tr>

        </table>
        <br />
        <asp:Label ID="lbl_forMsg" runat="server" style="color:red; font-weight:900; font-size:large;"></asp:Label>
    </div>

</asp:Content>
