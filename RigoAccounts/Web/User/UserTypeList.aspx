<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserTypeList.aspx.cs" Inherits="RigoAccounts.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <link href="../Content/bootstrap.min.css" rel="stylesheet" />

    <br />
    <br />
    <asp:Label runat="server" style="color:red; font-weight:600; font-size:xx-large;" ID="heading" />
    <br />
    <br />
    <br />

    <div class="container-fluid">
        <table class="table-striped" style="padding:50px;">
            <tr>
                <td>User Type: &nbsp;</td>
                <td>
                    <asp:TextBox id="tb_userType" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="req_userType" ControlToValidate="tb_userType" Display="None"
                        runat="server" ErrorMessage="UserType Field is required!"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:HiddenField runat="server" ID="hdn_fieldID"/>
                    <br />
                    <asp:Button  ID="btn_save" runat="server" Text="Save" width="100px" CssClass="btn btn-success" OnClick="btn_save_Click"/>
                </td>
            </tr>

        </table>  
        <br />
        <br /> 

        <div class="container-fluid" style="margin-left:85px">

            <asp:GridView ID="userTypeList" runat="server" AutoGenerateSelectButton="False" 
            BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" AllowPaging="true" PageSize="4" DataKeyNames="UserTypeID"
                 OnPageIndexChanging="userTypeList_PageIndexChanging" OnRowDeleting="userTypeList_RowDeleting"
                 OnSelectedIndexChanged="userTypeList_SelectedIndexChanged" CssClass="table-bordered" Width="241px">

            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle Font-Bold="True" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />

            <Columns>
                
                <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="5%">
                    <ItemTemplate>
                         <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="User Type" HeaderStyle-Width="50%" ItemStyle-Font-Bold="True" ItemStyle-ForeColor="White">
                  <ItemTemplate>

                   <asp:HyperLink ID="link_Names" runat="server" 

                       NavigateUrl='<%# "~/Web/User/UserTypeList.aspx?id=" + Eval("UserTypeID") %>'
                       Text=<%#Eval("Name")%>>

                   </asp:HyperLink>

                  </ItemTemplate>
                 </asp:TemplateField>

                  <asp:TemplateField ShowHeader="False" ItemStyle-Width="50px">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete" CssClass="btn btn-danger" 
                            OnClientClick="return confirm('Are you sure you want to delete This Item?');"/>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            </asp:GridView>
        </div>


         <asp:ValidationSummary ID="vsInsertUpdate" runat="server" ShowMessageBox="true" ShowSummary="false" />
         <br />
         <asp:Label runat="server" style="color:red; font-weight:900; font-size:large;" ID="lblerrormsg" />
          
    </div>

    <script type="text/javascript">
        function HideLabel() {
            document.getElementById('<%= lblerrormsg.ClientID %>').style.display = "none";
        }
        setTimeout("HideLabel();", 5000);
    </script>

</asp:Content>
