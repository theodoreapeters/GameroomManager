<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GameroomManager.Account.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta charset="utf-8" />
    <style>
        .login-container {
            width: 300px;
            margin: 100px auto;
            font-family: Arial, sans-serif;
        }

        .login-container h2 {
            text-align: center;
        }

        .login-container input {
            width: 100%;
            padding: 8px;
            margin: 5px 0;
        }

        .login-container button {
            width: 100%;
            padding: 10px;
        }

        .error {
            color: red;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="login-container">
        <h2>Login</h2>
        <asp:TextBox ID="UsernameTextBox" runat="server" placeholder="Username" CssClass="input-field" />
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" placeholder="Password" CssClass="input-field" />

        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
        <asp:Label ID="ErrorLabel" runat="server" CssClass="error"></asp:Label>
    </div>
    </form>
</body>
</html>
