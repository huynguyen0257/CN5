<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebTest.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	Số Thứ 1:&nbsp;&nbsp;&nbsp;
	<asp:TextBox ID="TextBox1" runat="server" Font-Names="txtSo1"></asp:TextBox>
	<br />
	Số Thứ 2:&nbsp;&nbsp;&nbsp;
	<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
	<br />
	Kết quả&nbsp; :&nbsp;&nbsp;&nbsp;
	<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
</asp:Content>
