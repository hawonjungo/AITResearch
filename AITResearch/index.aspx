<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AITResearch.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LbEmail" runat="server" Text="Please enter your Email:"></asp:Label>
    <br />
    <asp:TextBox ID="TxtBoxEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldEmail" runat="server" ErrorMessage="Invalid email" ControlToValidate="TxtBoxEmail" ></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="LabAskRegister" runat="server" Text="Would like to register as a member of this program?"></asp:Label>
    <br />
    <asp:RadioButton ID="Radio1Yes" runat="server" GroupName="MemberRegister" Text="Yes" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="Radio2No" runat="server" GroupName="MemberRegister" Text="No" />
    <br />
    <br />
    <asp:Button ID="BtnStart" runat="server" OnClick="BtnStart_Click" Text="Start Survey" />
    <br />
</asp:Content>
