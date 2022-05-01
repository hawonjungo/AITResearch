<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AITResearch.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="title">User registration</h3>
    <div class="container">
        <div>
            <div class="field_title">First name:</div> <asp:TextBox class="field" ID="TextBoxFirstName" runat="server" />
        <asp:RequiredFieldValidator ID="First_Name__validator" runat="server" ErrorMessage="Please fill the field." ControlToValidate="TextBoxFirstName"></asp:RequiredFieldValidator>
        </div>
        <div>
            <div class="field_title">Last name:</div> <asp:TextBox class="field" ID="TextBoxLastName" runat="server" />
        <asp:RequiredFieldValidator ID="Last_Name__validator" runat="server" ErrorMessage="Please fill the field." ControlToValidate="TextBoxLastName"></asp:RequiredFieldValidator>
        </div>
        <div>
            <div class="field_title">Phone number:</div> <asp:TextBox class="field" ID="TextBoxPhoneNumber" runat="server" />
        <asp:RequiredFieldValidator ID="Phone__validator" runat="server" ErrorMessage="Please fill the field." ControlToValidate="TextBoxPhoneNumber"></asp:RequiredFieldValidator>
        </div>
        <div>
            <div class="field_title">Date of birth:</div> 
            <asp:TextBox class="field" ID="TextBoxDOB" placeholder="dd/mm/yyyy" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="DOB_validator" runat="server" ErrorMessage="Please fill the field." ControlToValidate="TextBoxDOB"></asp:RequiredFieldValidator>
        
            <br />
        
        </div>
        
    </div>
    <div>
        
        <asp:Label ID="regResult" runat="server"></asp:Label>
        
        <br />
        <asp:Button  CssClass="button" ID="BtnRegister" runat="server" Text="Register" OnClick="BtnRegister_Click" />
        <br />
        
    </div>
    </asp:Content>
