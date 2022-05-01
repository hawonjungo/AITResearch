<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AITResearch.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:Button CssClass="button" ID="btnStaff" runat="server" Text="Staff" OnClick="btnStaff_Click" />
    <br />
    <br />
    <asp:Label ID="LabAskRegister" runat="server" Text="Would like to register as a member of this program?"></asp:Label>
    <br />
    <div class ="btn">
    <asp:RadioButton ID="Radio1Yes" runat="server" GroupName="MemberRegister" Text="Yes" />

    <asp:RadioButton ID="Radio2No" runat="server" GroupName="MemberRegister" Text="No" />
        </div>
    <br />
    <br />
    <asp:Button CssClass="button" ID="BtnStart" runat="server" OnClick="BtnStart_Click" Text="Start Survey" />
    <br />
</asp:Content>
