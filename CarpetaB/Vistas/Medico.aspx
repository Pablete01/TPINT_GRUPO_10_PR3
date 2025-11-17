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

        .auto-style2 {
            height: 79px;
        }

        .auto-style3 {
            width: 194px;
            height: 22px;
        }

        .auto-style8 {
            height: 19px;
        }

        .auto-style9 {
            height: 22px;
            width: 195px;
        }

        .auto-style10 {
            height: 59px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table align="center" class="auto-style1" style="border: 1px solid black; border-collapse: collapse; padding: 20px;">
<tr style="background-color: #66a1ff;">
    <td align="left" class="auto-style2" style="width: 100px;">
        <asp:ImageButton ID="btnInicio" runat="server"
            ImageUrl="~/Imagenes/inicio.png"
            Width="50px" Height="50px"
            ToolTip="Volver al inicio"
            PostBackUrl="~/Medico.aspx"
            Style="margin-left: 10px; border: none;" />
    </td>

    <td align="center" class="auto-style2" colspan="2">
        <asp:Label ID="lblTitulo" runat="server"
            Text="Médico"
            Font-Size="XX-Large"
            Font-Names="Segoe UI"
            Style="padding: 10px;" />
    </td>

    <td class="auto-style2" style="text-align: right;">
        <div style="display: flex; justify-content: flex-end; align-items: center; gap: 8px;" class="auto-style10">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario" Font-Names="Segoe UI"></asp:Label>
            <asp:Image ID="user" runat="server" Height="47px" ImageUrl="~/Imagenes/user.png" Width="50px" />
        </div>
    </td>
</tr>
            <tr>
                <td class="auto-style8" colspan="4"></td>
            </tr>
            <tr>
                <td align="center" class="auto-style3">
                    &nbsp;</td>
                <td align="center" class="auto-style3">
                    <asp:ImageButton ID="btnAgenda" runat="server" Height="100px" ImageUrl="~/Imagenes/agenda.png" Width="150px" style="padding: 10px;" BorderStyle="Solid" ImageAlign="Middle"  />
                </td>
                <td align="center" class="auto-style3">
                    <asp:ImageButton ID="btnMisPacientes" runat="server" Height="100px" ImageUrl="~/Imagenes/patients.png" Width="150px" style="padding: 10px;" BorderStyle="Solid" ImageAlign="Middle" />
                </td>
                <td align="center" class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="auto-style3">
                    &nbsp;</td>
                <td align="center" class="auto-style3">
                    <asp:Label ID="lblAgenda" runat="server" Text="Agenda" Font-Bold="True" Font-Names="Segoe UI"></asp:Label>
                </td>
                <td align="center" class="auto-style3">
                    <asp:Label ID="lblMisPacientes" runat="server" Text="Mis Pacientes" Font-Bold="True" Font-Names="Segoe UI"></asp:Label>
                </td>
                <td align="center" class="auto-style9">
                    &nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
        &nbsp;
    </form>
</body>
</html>
