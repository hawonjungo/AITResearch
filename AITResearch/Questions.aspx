<%@ Page Language="C#"  AutoEventWireup="true"   CodeBehind="Questions.aspx.cs" Inherits="AITResearch.Questions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Survey</title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="card">
        <div class="container">

            <br />
            <br />
            <h2><asp:Label ID="LabQuestion" runat="server" Text=""></asp:Label></h2>
            <br />
            <br />
            <div class="padding">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
            <br />
            <br />
            <br /> 
            <div class="btn">
            <asp:Button class="button" ID="BtnBack" runat="server" OnClick="BtnBack_Click" Text="Back" />
            <asp:Button class="button" ID="BtnNext" runat="server" OnClick="BtnNext_Click" Text="Next"/> 
            <br />
            <br />
                </div>
            <br />
            <br />
            <asp:GridView ID="dbTableView" runat="server">
            </asp:GridView>
            <br />
            <asp:GridView ID="TbQ_OptionView" runat="server">
            </asp:GridView>
            <br />
        </div>
            </div>
    </form>
</body>
</html>
