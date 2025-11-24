<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionTurnos.aspx.cs" Inherits="Vistas.GestionTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
 </style>
</head>
<body>
    <form id="form1" runat="server">
                <!-- Barra superior -->
        <div class="header">
    <div class="header-left">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/inicio.png" Width="35px" Height="35px" />
        <asp:HyperLink ID="HLVolver" runat="server" NavigateUrl="~/Administrador.aspx" >VOLVER</asp:HyperLink>
    </div>

    <div class="header-right">
        <div class="user-section">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Gestión Turnos"></asp:Label>
            <asp:ImageButton ID="btnUsuario" runat="server" ImageUrl="~/Imagenes/user.png" Width="40px" Height="40px" />
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="user-label"></asp:Label>
        </div>
    </div>
</div>
        <table align="center" class="auto-style1" style="border: 1px solid black; border-collapse: collapse; padding: 20px;">

            <tr>
                <td class="auto-style8" colspan="4">&nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style8" colspan="4"></td>
            </tr>
            <tr>
                <td align="center" class="auto-style3">
                    &nbsp;</td>
                <td align="center" class="auto-style3">
                    <asp:ImageButton ID="btnAgendados" runat="server" Height="100px" ImageUrl="~/Imagenes/agenda.png" Width="150px" style="padding: 10px;" BorderStyle="Solid" ImageAlign="Middle" OnClick="btnTurnos_Click" />
                </td>
                <td align="center" class="auto-style3">
                    <asp:ImageButton ID="btnNuevoTurno" runat="server" Height="100px" ImageUrl="~/Imagenes/patients.png" Width="150px" style="padding: 10px;" BorderStyle="Solid" ImageAlign="Middle" OnClick="btnNuevoTurno_Click" />
                </td>
                <td align="center" class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="auto-style3">
                    &nbsp;</td>
                <td align="center" class="auto-style3">
                    <asp:Label ID="lblAgenda" runat="server" Text="Turnos agendados" Font-Bold="True" Font-Names="Segoe UI"></asp:Label>
                </td>
                <td align="center" class="auto-style3">
                    <asp:Label ID="lblMisPacientes" runat="server" Text="Agregar Turno" Font-Bold="True" Font-Names="Segoe UI"></asp:Label>
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
