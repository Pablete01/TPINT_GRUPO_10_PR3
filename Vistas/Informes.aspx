<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="Vistas.Informes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Informes</title>
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
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Informes"></asp:Label>
            <asp:ImageButton ID="btnUsuario" runat="server" ImageUrl="~/Imagenes/user.png" Width="40px" Height="40px" />
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="user-label"></asp:Label>
        </div>
    </div>
</div>


        <div class="container">
            <asp:Label ID="lblTitulo" runat="server" Text="Informes de Asistencia" CssClass="section-title" Font-Size="X-Large" Font-Bold="True"></asp:Label>

            <div class="filters">
                <asp:Label ID="lblDesde" runat="server" Text="Desde: "></asp:Label>
                <asp:TextBox ID="txtDesde" runat="server" TextMode="Date"></asp:TextBox>
                <asp:Label ID="lblHasta" runat="server" Text="Hasta: "></asp:Label>
                <asp:TextBox ID="txtHasta" runat="server" TextMode="Date"></asp:TextBox>
                <asp:Button ID="btnFiltrar" runat="server" Text="Generar Informe" BackColor="#004a8f" ForeColor="White" BorderStyle="None" />
            </div>

            <div class="summary">
                <div class="summary-box">
                    <asp:Label ID="lblPacientesPresentes" runat="server" Text="Pacientes Presentes" CssClass="label-title"></asp:Label><br />
                    <asp:Label ID="lblPorcentajePresentes" runat="server" Text="70%" CssClass="label-data"></asp:Label><br />
                    <asp:Label ID="lblCantidadPresentes" runat="server" Text="84 pacientes" ForeColor="#004a8f"></asp:Label>
                </div>

                <div class="summary-box">
                    <asp:Label ID="lblPacientesAusentes" runat="server" Text="Pacientes Ausentes" CssClass="label-title"></asp:Label><br />
                    <asp:Label ID="lblPorcentajeAusentes" runat="server" Text="30%" CssClass="label-data"></asp:Label><br />
                    <asp:Label ID="lblCantidadAusentes" runat="server" Text="36 pacientes" ForeColor="#004a8f"></asp:Label>
                </div>
            </div>

            <div class="grid-container">
                <h3>Detalle de Pacientes</h3>
                <asp:GridView ID="GridViewPersonas" runat="server" AutoGenerateColumns="False" BorderColor="#99ccff" BorderStyle="Solid" CellPadding="5">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="DNI" HeaderText="DNI" />
                        <asp:BoundField DataField="Estado" HeaderText="Asistencia" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
