<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Snacks.aspx.cs" Inherits="ASP_WEB_FORMS.Snacks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Snacks Inventory</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Snacks Inventory</h2>
            <hr />
            <table>
                <tr>
                    <td>Snack Name:</td>
                    <td><asp:TextBox ID="txtSnackName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Snack Amount:</td>
                    <td><asp:TextBox ID="txtSnackAmount" runat="server" TextMode="Number"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Snack ID:</td>
                    <td><asp:TextBox ID="txtId" runat="server"></asp:TextBox></td>
                </tr>
            </table>
            <br />
            <asp:Button ID="btnInsert" runat="server" Text="Insert Snack" OnClick="btnInsert_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update Snack" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete Snack" OnClick="btnDelete_Click" />
            <hr />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="snackName" HeaderText="Snack Name" />
                    <asp:BoundField DataField="snackAmount" HeaderText="Snack Amount" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
