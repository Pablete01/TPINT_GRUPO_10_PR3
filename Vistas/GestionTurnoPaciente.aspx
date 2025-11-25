<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionTurnoPaciente.aspx.cs" Inherits="Vistas.GestionTurnoPaciente" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Gestión Turno del Paciente</title>

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

        .main-panel {
            text-align: center;
            margin: 20px 0;
        }

        .btn-agregar {
            background-color: #28a745;
            color: white;
            border: none;
            padding: 10px 18px;
            border-radius: 6px;
            cursor: pointer;
            font-size: 15px;
            margin-bottom: 15px;
        }

        .btn-agregar:hover {
            background-color: #218838;
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

        .btn-grid {
            background-color: #dc3545;
            color: white;
            border: none;
            padding: 5px 10px;
            border-radius: 4px;
            cursor: pointer;
            font-size: 13px;
        }

        .btn-grid:hover {
            background-color: #c82333;
        }

        .btn-secondary {
            background-color: #ffc107;
            color: black;
        }

        .btn-secondary:hover {
            background-color: #e0a800;
        }

    </style>

</head>

<body>
<form id="form1" runat="server">

    
    <div class="header">
        <div class="header-left">
            <asp:ImageButton ID="btnInicio" runat="server" ImageUrl="~/Imagenes/inicio.png" Width="35px" Height="35px" OnClick="btnInicio_Click" />
        </div>

        <div class="header-right">
            <div class="user-section">
                <asp:ImageButton ID="btnUsuario" runat="server" ImageUrl="~/Imagenes/user.png" Width="40px" Height="40px" />
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="user-label"></asp:Label>
            </div>
        </div>
    </div>

    <asp:Panel ID="PanelPrincipal" runat="server" HorizontalAlign="Center">

        <div class="main-panel">
            <h3>Gestión Turno</h3>

            <asp:Button ID="btnAgregarTurno" runat="server" Text="Agregar Turno" CssClass="btn-agregar" OnClick="btnAgregarTurno_Click" />
        </div>


        
        <div class="grid-container">

            <asp:GridView 
    ID="grdTurnosPaciente"
    runat="server"
    AutoGenerateColumns="False"
    CssClass="grid"
    AllowPaging="True"
    PageSize="7"
    DataKeyNames="ID_Turno"
    OnRowCommand="grdTurnosPaciente_RowCommand">

    <Columns>

        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:LinkButton 
                    ID="btnCancelar"
                    runat="server"
                    Text="Cancelar"
                    CommandName="Cancelar"
                    CommandArgument='<%# Eval("ID_Turno") %>'
                    CssClass="btn-grid" />

                &nbsp;

                <asp:LinkButton 
                    ID="btnReprogramar"
                    runat="server"
                    Text="Reprogramar"
                    CommandName="Reprogramar"
                    CommandArgument='<%# Eval("ID_Turno") %>'
                    CssClass="btn-grid btn-secondary" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="Hora" HeaderText="Hora" />
        <asp:BoundField DataField="Profesional" HeaderText="Profesional" />
        <asp:BoundField DataField="NombreEspecialidad" HeaderText="Especialidad" />
        <asp:BoundField DataField="NombreEstado" HeaderText="Estado" />

    </Columns>
</asp:GridView>


        </div>

    </asp:Panel>

</form>
</body>
</html>
