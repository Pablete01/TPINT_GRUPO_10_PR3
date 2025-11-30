<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Medico.aspx.cs" Inherits="Vistas.Medico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 779px;
            height: 318px;
            margin-bottom: 0px;
        }

        .auto-style8 {
            height: 19px;
        }

        .auto-style10 {
            height: 59px;
        }
        .auto-style12 {
            height: 71px;
        }
        .auto-style13 {
            height: 11px;
        }
        .auto-style14 {
            height: 22px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <table align="center" class="auto-style1" style="border: 1px solid black; border-collapse: collapse; padding: 20px;">
    <tr>
        <td align="center" class="auto-style12" style="background-color: #66a1ff">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblTitulo" runat="server" Text="Médico" Font-Size="XX-Large" Style="padding: 10px;" Font-Names="Segoe UI"></asp:Label>
        </td>
        <td class="auto-style12" style="background-color: #66a1ff; text-align: right;">
            <div style="display: flex; justify-content: flex-end; align-items: center; gap: 8px;" class="auto-style10">
                <asp:Button ID="btnCerrarSesion" runat="server" OnClick="btnCerrarSesion_Click" Text="Cerrar sesión" />
                <asp:Image ID="user" runat="server" Height="46px" ImageUrl="~/Imagenes/user.png" Width="50px" />
            </div>
        </td>
    </tr>
    <tr>
        <td align="center" class="auto-style13" style="background-color: #66a1ff"></td>
        <td class="auto-style13" style="background-color: #66a1ff; text-align: right;">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario" Font-Names="Segoe UI"></asp:Label>
        </td>
    </tr>
    <tr>
                <td class="auto-style8" colspan="2"></td>
            </tr>
            <tr>
                <td align="center" class="auto-style14" colspan="2">
                    <asp:ImageButton ID="btnAgenda" runat="server" Height="100px" ImageUrl="~/Imagenes/agenda.png" Width="150px" Style="padding: 10px;" BorderStyle="Solid" ImageAlign="Middle" OnClick="btnAgenda_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" class="auto-style14" colspan="2">
                    <asp:Label ID="lblAgenda" runat="server" Text="Agenda" Font-Bold="True" Font-Names="Segoe UI"></asp:Label>
                </td>
            </tr>
        </table>
        <div>
        </div>
        &nbsp;
    </form>
</body>
</html>
