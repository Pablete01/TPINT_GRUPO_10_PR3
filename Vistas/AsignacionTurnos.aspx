<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionTurnos.aspx.cs" Inherits="Vistas.AsignacionTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
        <asp:ImageButton ID="btnInicio" runat="server" ImageUrl="~/Imagenes/inicio.png" Width="35px" Height="35px" />
        <asp:HyperLink ID="HLVolver" runat="server" NavigateUrl="~/Administrador.aspx">VOLVER</asp:HyperLink>
    </div>

    <div class="header-right">
        <div class="user-section">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Gestión Turnos"></asp:Label>
            <asp:ImageButton ID="btnUsuario" runat="server" ImageUrl="~/Imagenes/user.png" Width="40px" Height="40px" />
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="user-label"></asp:Label>
        </div>
    </div>
</div>

         <!-- Contenedor principal -->
 <asp:Panel ID="PanelPrincipal" runat="server" HorizontalAlign="Center">

        <div style="background-color:#66a1ff; width: 588px; margin: 6px auto; padding: 18px; border: 1px solid #D7EFE0; box-shadow: 0 1px 2px rgba(0,0,0,0.03); height: 258px;">
            <br />
            <div style="margin: 0 auto;" class="auto-style1">
                <asp:Label ID="Label3" runat="server" ForeColor="Black" Text="Especialidad " Font-Size="Large" Font-Names="Segoe UI"></asp:Label>
                <asp:DropDownList ID="ddlEspecialidad" runat="server">
                    <asp:ListItem Value="0">- Seleccionar -</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="margin: 0 auto;" class="auto-style2">

                <asp:Label ID="Label4" runat="server" Font-Size="Large" ForeColor="Black" Text="Medico " Font-Names="Segoe UI"></asp:Label>
                <asp:DropDownList ID="ddlMedico" runat="server">
                    <asp:ListItem Value="0">- Seleccionar -</asp:ListItem>
                </asp:DropDownList>

            </div>
            <div style="margin: 0 auto;" class="auto-style3">
                <asp:Label ID="Label5" runat="server" ForeColor="Black" Text="Fecha " Font-Size="Large" Font-Names="Segoe UI"></asp:Label>
                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
            </div>

            <div style="margin: 0 auto;" class="auto-style4">
                <asp:Label ID="Label6" runat="server" Font-Size="Large" ForeColor="Black" Text="Horario " Font-Names="Segoe UI"></asp:Label>
                <asp:TextBox ID="txtHora" runat="server" TextMode="Time" Width="70px" Height="17px"></asp:TextBox>
            </div>
            <div style="margin: 0 auto;" class="auto-style5">
                <asp:Label ID="Label7" runat="server" Font-Size="Large" Text="DNI del paciente: " ForeColor="Black" Font-Names="Segoe UI"></asp:Label>
                <asp:TextBox ID="txtDNIPaciente" runat="server" Width="148px"></asp:TextBox>
            </div>
            <br />
            <br />
            <br />
            <div style="width: 89px; margin: 0 auto;">
                <asp:Button ID="btnAceptar" runat="server" Text="ACEPTAR" BorderStyle="None" BackColor="White" />
            </div>
        </div>
     </asp:Panel>
    </form>
</body>
</html>
