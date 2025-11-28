<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionInforme.aspx.cs" Inherits="Vistas.SeleccionInforme" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Informes Asistencia Turnos</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f4f7f9;
            margin: 0;
            padding: 0;
        }

        .header {
            background-color: #007bff;
            color: white;
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 10px 25px;
        }

        .header-left img, .header-right img {
            cursor: pointer;
        }

        .user-section {
            text-align: center;
        }

        .user-label {
            color: white;
            display: block;
            font-size: 13px;
            margin-top: 5px;
        }

        .panel-superior {
            text-align: center;
            margin: 20px 0;
        }

            .panel-superior input, .panel-superior select, .panel-superior button {
                margin: 5px;
            }

        .grid-container {
            width: 95%;
            margin: 0 auto;
            background-color: #fff;
            border-radius: 10px;
            padding: 15px;
            box-shadow: 0px 2px 8px rgba(0, 0, 0, 0.1);
        }

            .grid-container table {
                width: 100%;
                border-collapse: collapse;
            }

            .grid-container th {
                background-color: #007bff;
                color: white;
                text-align: center;
                padding: 8px;
            }

            .grid-container td {
                text-align: center;
                padding: 6px;
            }

            .grid-container tr:nth-child(even) {
                background-color: #f2f2f2;
            }
        .auto-style2 {
            height: 25px;
        }
        .auto-style3 {
            height: 77px;
        }
        .auto-style4 {
            height: 60px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <!-- Barra superior -->
        <div class="header">
            <div class="header-left">
                <asp:ImageButton ID="btnInicio" runat="server" ImageUrl="~/Imagenes/inicio.png" Width="35px" Height="35px" />
                <asp:HyperLink ID="HLVolver" runat="server" NavigateUrl="~/Administrador.aspx">VOLVER</asp:HyperLink>
            </div>

            <div class="header-right">
                <div class="user-section">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Seleccion de Informe"></asp:Label>
                    <asp:ImageButton ID="btnUsuario" runat="server" ImageUrl="~/Imagenes/user.png" Width="40px" Height="40px" />
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="user-label"></asp:Label>
                </div>
            </div>
        </div>

        <div style="height: 399px">
            <table style="width:100%; text-align:center; table-layout:fixed;">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Informe de turnos (Asistencia)"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Informe de Medicos"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="X-Large" Text="Informe de Turnos (General)"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Image ID="Image1" runat="server" Height="200px" ImageUrl="~/Imagenes/InformeTurnosAsistencia.png" Width="200px" />
                    </td>
                    <td class="auto-style2">
                        <asp:Image ID="Image2" runat="server" Height="200px" ImageUrl="~/Imagenes/InformeMedicos.png" Width="200px" />
                    </td>
                    <td class="auto-style2">
                        <asp:Image ID="Image3" runat="server" Height="200px" ImageUrl="~/Imagenes/InformeTurnosGeneral.png" Width="200px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Button ID="btnInformeTurnosAsistencia" runat="server" OnClick="btnInformeTurnosAsistencia_Click" Text="Ver Informe" />
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="btnInformeMedicos" runat="server" OnClick="btnInformeMedicos_Click" Text="Ver Informe" />
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="btnInformeTurnosGeneral" runat="server" OnClick="btnInformeTurnosGeneral_Click" Text="Ver Informe" />
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
