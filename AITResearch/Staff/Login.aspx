<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AITResearch.Staff.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        <asp:Label ID="user" runat="server" Text="User Name:"></asp:Label>
        <asp:TextBox ID="txtBoxUerName" runat="server"></asp:TextBox>
    </p>
    <p>
    </p>
    <p>
        <asp:Label ID="password" runat="server" Text="Password : "></asp:Label>
        <asp:TextBox ID="txtBoxPassword" runat="server"></asp:TextBox>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
        <asp:Label ID="LoginStatus" runat="server"></asp:Label>
    </p>
    <p>
    </p>
    <p>
        <asp:Button class="button" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    </p>
</asp:Content>
