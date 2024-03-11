<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Reg.aspx.cs" Inherits="ASP_WEB_FORMS.User_Reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <p>User Registration Details</p>

        <asp:GridView ID="userGridView" runat="server" AutoGenerateColumns="true">
        </asp:GridView>

        <br />
        <br />

        <div>
            Email<asp:TextBox ID="emailInput" runat="server"/> <br />
            Password<asp:TextBox ID="passwordInput" runat="server" TextMode="Password" />  
        </div>


        <div>
            <p>Create your Registration</p>
            <asp:Button ID="addButton" Text="ADD" runat="server" OnClick="add_Click" />
            <asp:Button ID="updateButton" Text="UPDATE" runat="server" OnClick="update_Click" />
            <asp:Button ID="deleteButton" Text="DELETE" runat="server" OnClick="delete_Click" />
            <asp:Button ID="readButton" Text="READ" runat="server" OnClick="read_Click" />
        </div>
    </form>


</body>
</html>
