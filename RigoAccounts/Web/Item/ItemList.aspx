<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemList.aspx.cs" Inherits="RigoAccounts.WebForm6" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />

    <br />
    <h1 class="">Item List</h1>
    <br />

    <div class="container-fluid">

        <asp:GridView ID="ItemList" runat="server" AutoGenerateSelectButton="False"
            BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" AllowPaging="true" PageSize="4" DataKeyNames="ItemID"
            OnPageIndexChanging="ItemList_PageIndexChanging" OnRowDeleting="ItemList_RowDeleting"
            OnSelectedIndexChanged="ItemList_SelectedIndexChanged" CssClass="table-bordered">

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
                
                <asp:TemplateField HeaderText="Item Name" HeaderStyle-Width="25%" ItemStyle-Font-Bold="True" ItemStyle-ForeColor="White">
                  <ItemTemplate>

                   <asp:HyperLink ID="link_Names" runat="server" 

                       NavigateUrl='<%# "~/Web/Item/ItemEntry.aspx?id=" + Eval("ItemID") %>'
                       Text=<%#Eval("Name")%>>

                   </asp:HyperLink>

                  </ItemTemplate>
                 </asp:TemplateField>


                <asp:BoundField DataField="PurchasePrice" HeaderText="Purchase Price" ItemStyle-Width="100px">
                    <ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="SalesPrice" HeaderText="Sales Price" ItemStyle-Width="100px">
                    <ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="OpeningQty" HeaderText="Opening Qty" ItemStyle-Width="100px">
                    <ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="CreatedOn" DataFormatString="{0:MMM/dd/yyyy }" HeaderText="Created On" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="InStock" HeaderText="In Stock" ItemStyle-Width="100px">
                    <ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>

                <asp:TemplateField ShowHeader="False" ItemStyle-Width="50px">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete" CssClass="btn btn-danger" 
                            OnClientClick="return confirm('Are you sure you want to delete This Item?');"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>

        <asp:HiddenField runat="server" ID="hdnUserId" />
        <br />
        <asp:Label ID="lblMsg" runat="server" Style="color: red; font-weight: 900; font-size: large;"></asp:Label>
        
    </div>
</asp:Content>
