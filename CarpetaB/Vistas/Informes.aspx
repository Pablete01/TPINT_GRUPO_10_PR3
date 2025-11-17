<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="Vistas.Informes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Informes</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f7fc;
            margin: 0;
            padding: 0;
        }

        .container {
            width: 85%;
            margin: 40px auto;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0px 0px 10px rgba(0,0,0,0.1);
            padding: 30px;
        }

        h1, .section-title {
            color: #004a8f;
            text-align: center;
        }

        .summary {
            display: flex;
            justify-content: space-around;
            margin-top: 30px;
            text-align: center;
        }

        .summary-box {
            background-color: #e3f0ff;
            border: 1px solid #99ccff;
            border-radius: 10px;
            width: 30%;
            padding: 15px;
        }

        .summary-box .label-title {
            font-weight: bold;
            color: #004a8f;
            font-size: 18px;
        }

        .summary-box .label-data {
            font-size: 22px;
            color: #003366;
            font-weight: bold;
        }

        .filters {
            text-align: center;
            margin-bottom: 30px;
        }

        .filters input {
            padding: 5px;
            margin: 0 5px;
        }

        .grid-container {
            margin-top: 40px;
        }

        .grid-container h3 {
            color: #004a8f;
        }

        .grid-container table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }

        .grid-container th, .grid-container td {
            border: 1px solid #99ccff;
            padding: 8px;
            text-align: center;
        }

        .grid-container th {
            background-color: #e6f2ff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
