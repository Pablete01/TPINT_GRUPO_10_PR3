<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaHorarios.aspx.cs" Inherits="Vistas.ListaHorarios" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seleccionar Turno</title>
    <style>
        .horarios-table button {
            width: 80px;
            height: 40px;
            margin: 5px;
            font-weight: bold;
            border-radius: 5px;
            cursor: pointer;
        }

        .ocupado {
            background-color: lightgray;
            cursor: not-allowed;
        }

        .disponible {
            background-color: lightgreen;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblFecha" runat="server" Text="Seleccione una fecha:"></asp:Label>
            <asp:TextBox ID="txtFecha" runat="server" Text='<%# DateTime.Now.ToString("yyyy-MM-dd") %>' TextMode="Date"></asp:TextBox>
            <asp:Button ID="btnCargarHorarios" runat="server" Text="Cargar Horarios" OnClick="btnCargarHorarios_Click" />

        </div>

        <br />

        <asp:Table ID="tblHorarios" runat="server" CssClass="horarios-table"></asp:Table>

        <br />

        <asp:Label ID="lblSeleccion" runat="server" Text="" Font-Bold="True"></asp:Label>
        <asp:Label ID="lblHoraSeleccionada" runat="server" Font-Bold="True"></asp:Label>
    </form>
</body>
</html>
