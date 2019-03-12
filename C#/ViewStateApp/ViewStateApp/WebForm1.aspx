<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ViewStateApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Fun&nbsp; with View State<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
        </div>
        <asp:ListBox ID="myListBox" runat="server"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnPostback" runat="server" Text="Submit" OnClick="btnPostback_Click" />
        <p>
            <asp:Button ID="btnAddToVS" runat="server" OnClick="Button2_Click" Text="Add Value to ViewState" />
        </p>
        <p>
            <asp:Button ID="btnGetValue" runat="server" Text="Get Value from ViewState" OnClick="btnGetValue_Click" />
        </p>
        <asp:Label ID="lblVSValue" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
