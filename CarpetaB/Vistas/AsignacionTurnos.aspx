<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionTurnos.aspx.cs" Inherits="Vistas.AsignacionTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 273px;
        }
        .auto-style2 {
            width: 271px;
        }
        .auto-style3 {
            width: 275px;
        }
        .auto-style4 {
            width: 278px;
        }
        .auto-style5 {
            width: 296px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color:#66a1ff">
            <div style="height: 29px; display: flex; justify-content: space-between; align-items: center; padding: 8px 16px;">
                <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="Black" Text=" ASIGNACION DE TURNOS"></asp:Label>
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar a la pestaña anterior" BackColor="White" BorderStyle="None" Height="30px" />
            </div>
        </div>
        <div style="background-color: #66a1ff; display: flex; justify-content: space-between; align-items: center; padding: 8px 16px;">
            <asp:Label ID="lblUsuario" runat="server" Font-Size="X-Large" ForeColor="Black" Text="Usuario" Font-Names="Segoe UI"></asp:Label>
            <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" BackColor="White" BorderStyle="None" Height="30px" />
        </div>
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
    </form>
</body>
</html>
