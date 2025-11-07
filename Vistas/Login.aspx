<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 249px;
            width: 848px;
        }
        .auto-style2 {
            width: 338px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <table border="1" align="center" style="height:100vh; width:100%;">
            <tr>
                <td align="center" valign="middle" class="auto-style1">

                    <table border="0" cellpadding="5" class="auto-style2" style="border-width: 1px">
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="lblClinica" runat="server" Text="Clínica &quot;Grupo 10&quot;" Font-Size="16pt"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="right">
                                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" />
                            </td>
                            <td>
                                <asp:TextBox ID="tbUsuario" runat="server" Width="200px" />
                            </td>
                        </tr>

                        <tr>
                            <td align="right">
                                <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:" />
                            </td>
                            <td>
                                <asp:TextBox ID="tbContrasena" runat="server" TextMode="Password" Width="200px" />
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión"
                                    BackColor="#99CCFF" Width="120px" OnClick="btnLogin_Click" />
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="True" />
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>

    </form>
</body>
</html>
