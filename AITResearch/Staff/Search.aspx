<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="AITResearch.SearchPage.Search" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:Label ID="LabSearch" runat="server" Font-Bold="True" ForeColor="Black" Text="Search by one Criteria"></asp:Label>
    <br />
    <br />    
      <div class="holder" >
    <asp:TextBox ID="txtBoxFirstName" placeholder="First Name" runat="server"></asp:TextBox>
    <br />
          <asp:Label ID="state" runat="server" Text="State"></asp:Label>
    <br />
  
    <asp:DropDownList ID="dropState" runat="server">

                  <asp:ListItem Selected="false" Value=""></asp:ListItem>
                  <asp:ListItem Value="Western Australia">Western Australia</asp:ListItem>
                  <asp:ListItem Value="Northern Territory">Northern Territory</asp:ListItem>
                  <asp:ListItem Value="Queensland">Queensland</asp:ListItem>
                  <asp:ListItem Value="South Australia">South Australia</asp:ListItem>
                  <asp:ListItem Value="New South Wales">New South Wales</asp:ListItem>
                  <asp:ListItem Value="Victoria">Victoria</asp:ListItem>
                  <asp:ListItem Value="Tasmania">Tasmania</asp:ListItem>

               </asp:DropDownList>
    <br />
          <asp:Label ID="bankName" runat="server" Text="Bank Name"></asp:Label>
    <br />
    <asp:DropDownList ID="dropBankName" runat="server">
        
                  <asp:ListItem Selected="false" Value=""></asp:ListItem>
                  <asp:ListItem Value="Commonwealth">Commonwealth</asp:ListItem>
                  <asp:ListItem Value="NAB">NAB</asp:ListItem>
                  <asp:ListItem Value="ANZ">ANZ</asp:ListItem>
                  <asp:ListItem Value="Wespac">Wespac</asp:ListItem>
    </asp:DropDownList>
    <br />
          <asp:Label ID="bankService" runat="server" Text="Bank Survice"></asp:Label>
    <br />
    <asp:DropDownList ID="dropBankService" runat="server">
                  <asp:ListItem Selected="false" Value=""></asp:ListItem>
                  <asp:ListItem Value="Internet Banking">Internet Banking</asp:ListItem>
                  <asp:ListItem Value="Home Loan">Home Loan</asp:ListItem>
                  <asp:ListItem Value="Credit Card">Credit Card</asp:ListItem>
                  <asp:ListItem Value="Share Investment">Share Investment</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <br />
        </div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button CssClass="button" ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
    <br />
    <br />
    <asp:GridView ID="gvSearchResult" runat="server">
    </asp:GridView>
    <br />
    <br />
</asp:Content>
