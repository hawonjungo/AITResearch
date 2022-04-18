<%@ Page Language="C#" AutoEventWireup="true"   CodeBehind="Questions.aspx.cs" Inherits="AITResearch.Questions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabStart" runat="server" Text="Survey Start"></asp:Label>

            <br />
            <br />
            <asp:Label ID="LabQuestion" runat="server" Text=""></asp:Label>


            <br />
            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <br />
            <br />
            <br />
            <asp:Button ID="BtnNext" runat="server" OnClick="BtnNext_Click" Text="Next"/>            
            <asp:Button ID="BtnBack" runat="server" OnClick="BtnBack_Click" Text="Back" />
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="dbTableView" runat="server">
            </asp:GridView>
            <br />
            <asp:GridView ID="TbQ_OptionView" runat="server">
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
