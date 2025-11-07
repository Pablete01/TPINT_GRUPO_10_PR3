<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="Vistas.WebForm1" %>

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

        .auto-style6 {
            margin-top: 0px;
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
            <tr>
                <td align="center" class="auto-style2" colspan="2" style="background-color: #66FF99">
                    <asp:Label ID="lblTitulo" runat="server" Text="Administrador" Font-Size="XX-Large" Style="padding: 10px;"></asp:Label>
                </td>
                <td colspan="2" class="auto-style2" style="background-color: #66FF99; text-align: right;">
                    <div style="display: flex; justify-content: flex-end; align-items: center; gap: 8px;" class="auto-style10">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                        <asp:Image ID="user" runat="server" Height="47px" ImageUrl="~/Imagenes/user.png" Width="50px" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="4"></td>
            </tr>
            <tr>
                <td align="center" class="auto-style3">
                    <asp:ImageButton ID="btnGestionarMedicos" runat="server" Height="100px" ImageUrl="~/Imagenes/medico.png" Width="150px" style="padding: 10px;" BorderStyle="Solid" ImageAlign="Middle"  />
                </td>
                <td align="center" class="auto-style3">
                    <asp:ImageButton ID="btnAltaPaciente" runat="server" Height="100px" ImageUrl="~/Imagenes/alta.png" Width="150px" style="padding: 10px;" BorderStyle="Solid" ImageAlign="Middle" />
                </td>
                <td align="center" class="auto-style3">
                    <asp:ImageButton ID="btnTurnos" runat="server" Height="100px" ImageUrl="~/Imagenes/turno.png" Width="150px" style="padding: 10px;" BorderStyle="Solid" ImageAlign="Middle" />
                </td>
                <td align="center" class="auto-style3">
                    <asp:ImageButton ID="btnInformes" runat="server" Height="100px" ImageUrl="~/Imagenes/informes.png" Width="150px" style="padding: 10px;" BorderStyle="Solid" ImageAlign="Middle" />
                </td>
            </tr>
            <tr>
                <td align="center" class="auto-style3">
                    <asp:Label ID="lblMedico" runat="server" Text="Gestionar Médicos" Font-Bold="True"></asp:Label>
                </td>
                <td align="center" class="auto-style3">
                    <asp:Label ID="lblAltaPacientes" runat="server" Text="Alta Pacientes" Font-Bold="True"></asp:Label>
                </td>
                <td align="center" class="auto-style3">
                    <asp:Label ID="lblTurnos" runat="server" Text="Gestionar Turnos" Font-Bold="True"></asp:Label>
                </td>
                <td align="center" class="auto-style9">
                    <asp:Label ID="lblInformes" runat="server" Text="Informes" Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
        <div>
        </div>
        &nbsp;
    </form>
</body>
</html>
