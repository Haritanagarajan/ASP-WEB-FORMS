<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ASP_WEB_FORMS.Register" Theme="App_Themes"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Register</h2>
    <div>
        <asp:Label ID="lblID" runat="server" AssociatedControlID="txtID">ID:</asp:Label>
        <asp:TextBox ID="txtID" runat="server" placeholder="Enter ID"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvID" runat="server" ControlToValidate="txtID" ErrorMessage="ID is required" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Label ID="lblName" runat="server" AssociatedControlID="txtName">Name:</asp:Label>
        <asp:TextBox ID="txtName" runat="server" placeholder="Enter Name"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Password:</asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Enter Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
</asp:Content>
