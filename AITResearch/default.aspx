<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AITResearch._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="MainTitle" runat="server" Font-Bold="True" ForeColor="#3399FF" Text="AIT Research"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LabEmail" runat="server" Text="Please Enter your email:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LabAskRegister" runat="server" Text="would like to register as a member of this program?"></asp:Label>
            <br />
            <asp:RadioButton ID="RadioButton1" runat="server" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
