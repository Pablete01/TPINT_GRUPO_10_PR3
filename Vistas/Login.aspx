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
            width: 232px;
        }

        .auto-style4 {
            width: 277px;
        }
        .auto-style5 {
            height: 208px;
            width: 35%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <table border="1" align="center" class="auto-style5">
            <tr>
                <td align="center" valign="middle" class="auto-style1">

                    <table border="0" cellpadding="5" class="auto-style2" style="border-width: 1px">
                        <tr>
                            <td colspan="2" align="center" class="auto-style4">
                                <asp:Image ID="Image1" runat="server" Height="67px" ImageUrl="~/Imagenes/loginIcon.png" Width="99px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" class="auto-style4">
                                <asp:Label ID="lblClinica" runat="server" Text="Clínica &quot;Grupo 10&quot;" Font-Size="16pt" Font-Names="Segoe UI"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="left" class="auto-style4">
                                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" Font-Names="Segoe UI" />
                                <br />
                                <asp:TextBox ID="tbUsuario" runat="server" Width="200px" />
                                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="tbUsuario" ErrorMessage="Debe ingresar un nombre de usuario" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td align="left" class="auto-style4">
                                <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:" Font-Names="Segoe UI" />
                                <br />
                                <asp:TextBox ID="tbContrasena" runat="server" TextMode="Password" Width="200px" />
                                <asp:RequiredFieldValidator ID="rfvContrasena" runat="server" ControlToValidate="tbContrasena" ErrorMessage="Debe ingresar la contraseña" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>


                        <tr>
                            <td colspan="2" align="center" class="auto-style4">
                                <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión"
                                    BackColor="#99CCFF" Width="120px" OnClick="btnLogin_Click" Font-Bold="True" Font-Names="Segoe UI" />
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" align="center" class="auto-style4">
                                <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="True" Font-Names="Segoe UI" />
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>

    </form>
</body>
</html>
