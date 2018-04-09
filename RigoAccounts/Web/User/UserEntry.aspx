<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserEntry.aspx.cs" Inherits="RigoAccounts.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />

    <br />
    <br />
    <asp:Label runat="server" Style="color: red; font-weight: 600; font-size: xx-large;" ID="heading" />
    <br />
    <br />
    <br />
    <div class="container-fluid">
        <table class="table-striped" style="padding: 50px;">
            <tr>
                <td>Name: &nbsp;</td>

                <td>
                    <asp:TextBox ID="tb_name" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="req_fullName" ControlToValidate="tb_name" Display="None"
                        runat="server" ErrorMessage="Name Field is required!"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>

            <tr>
                <td style="height: 49px">Username: &nbsp;</td>
                <td style="height: 49px">
                    <asp:TextBox ID="tb_username" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="req_userName" ControlToValidate="tb_username" Display="None"
                        runat="server" ErrorMessage="UserName Field is Required!!"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>

            <tr>

                <td>User Type: &nbsp;</td>

                <td>
                    <asp:DropDownList ID="list_userType" runat="server" Height="36px" Width="280px" OnSelectedIndexChanged="list_userType_SelectedIndexChanged">
                        <asp:ListItem Enabled="true" Text="Select User Type" Value="-1"></asp:ListItem>
                    </asp:DropDownList>

                    <asp:RequiredFieldValidator ID="list_validator" runat="server" ControlToValidate="list_userType"
                        InitialValue="-1" ErrorMessage="UserType is Required!!">
                    </asp:RequiredFieldValidator>

                    <br />

                    <br />

                </td>
            </tr>

            <tr>
                <td>Password &nbsp;</td>
                <td>
                    <asp:TextBox ID="tb_password" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                    <asp:RegularExpressionValidator runat="server" ID="regex_password" ControlToValidate="tb_password"
                        ErrorMessage="Password should be of length atleast 8 with one capital letter and one digit "
                        Display="None" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$"></asp:RegularExpressionValidator>
                    <br />
                    <br />
                </td>
            </tr>

            <tr>
                <td>Re-Type Password:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tb_rePassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="req_rePassword" Display="None" ControlToValidate="tb_rePassword"
                        runat="server" ErrorMessage="Re-Enter Password field is required!!"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:HiddenField runat="server" ID="hdn_fieldID" />

                    <asp:Button ID="btn_save" runat="server" Text="Save" Width="100px" OnClick="btn_save_Click" CssClass="btn btn-success" />

                    <asp:Button ID="btn_clear" runat="server" Text="Clear" Width="100px" CausesValidation="false" OnClick="btn_clear_Click" CssClass="btn btn-alert" />

                </td>
            </tr>

        </table>
        <br />
        <br />

        <asp:ValidationSummary ID="vsInsertUpdate" runat="server" ShowMessageBox="true" ShowSummary="false" />
        <br />
        <asp:Label runat="server" Style="color: red; font-weight: 900; font-size: large;" ID="lblerrormsg" />

    </div>

</asp:Content>
