﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="RigoAccounts.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />

    <br />
    <h1 class="">User List</h1>
    <br />

    <div class="container-fluid">

         <asp:GridView ID="userList" runat="server" AutoGenerateSelectButton="False" 
        BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" AllowPaging="true" PageSize="4" DataKeyNames="UserID"
        OnPageIndexChanging="userList_PageIndexChanging" OnRowDeleting="userList_RowDeleting"
             OnSelectedIndexChanged="userList_SelectedIndexChanged" CssClass="table-bordered">
       
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle Font-Bold="True" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
        <Columns>
            <asp:TemplateField ShowHeader="False" ItemStyle-Width="50px">
                <ItemTemplate>
                    <asp:LinkButton ID="btnSelect" runat="server" CausesValidation="false" CommandName="Select" Text="Select" CssClass="btn btn-success" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FullName" HeaderText="Name" ItemStyle-Width="200px">
                <ItemStyle Width="200px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="UserName" HeaderText="Username" ItemStyle-Width="100px">
                <ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="UserType" HeaderText="User Type" ItemStyle-Width="100px">
                <ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="CreatedOn" DataFormatString="{0:MMM/dd/yyyy }" HeaderText="Created On" ItemStyle-Width="150px">
                <ItemStyle Width="150px"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField ShowHeader="False" ItemStyle-Width="50px">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete" CssClass="btn btn-danger"
                        OnClientClick="return confirm('Are you sure you want to delete This User?');"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    
         <asp:HiddenField runat="server" ID="hdnUserId" />
        <asp:Label ID="lbl_forMsg" runat="server" style="color:red; font-weight:900; font-size:large;"></asp:Label>
         <br />
         
        
    </div>
</asp:Content>
