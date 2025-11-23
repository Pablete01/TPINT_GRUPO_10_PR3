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

        .auto-style1 {
            margin-bottom: 0px;
            width: 451px;
        }

        .auto-style2 {
            width: 201px;
            height: 1px;
        }

        .auto-style3 {
            width: 454px;
            height: 47px;
        }
        .auto-style4 {
            width: 451px;
        }
        .auto-style5 {
            width: 451px;
            height: 48px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <!-- Barra superior -->
        <div class="header">
            <div class="header-left">
                <asp:ImageButton ID="btnInicio" runat="server" ImageUrl="~/Imagenes/inicio.png" Width="35px" Height="35px" />
                <asp:HyperLink ID="HLVolver" runat="server" NavigateUrl="~/GestionTurnos.aspx">VOLVER</asp:HyperLink>
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
        <asp:Panel ID="PanelPrincipal" runat="server" CssClass="contenedor-principal">

            
                <br />
                <div style="margin: 0 auto;" class="auto-style1">
                    <asp:Label ID="Label3" runat="server" ForeColor="Black" Text="Especialidad " Font-Size="Large" Font-Names="Segoe UI"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" Height="24px" Width="280px" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="0">- Seleccionar -</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="cvEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" ErrorMessage="Debe seleccionar una especialidad" Operator="NotEqual" ValueToCompare="0" ForeColor="Red"></asp:CompareValidator>
                </div>
                <div style="margin: 0 auto;" class="auto-style3">

                    <asp:Label ID="Label4" runat="server" Font-Size="Large" ForeColor="Black" Text="Medico " Font-Names="Segoe UI"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlMedico" runat="server" Height="24px" Width="280px" OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged">
                        <asp:ListItem Value="0">- Seleccionar -</asp:ListItem>
                    </asp:DropDownList>

                    <asp:CompareValidator ID="cvMedicos" runat="server" ControlToValidate="ddlMedico" Display="Dynamic" ErrorMessage="Debe seleccionar un médico" Operator="NotEqual" ValueToCompare="0" ForeColor="Red"></asp:CompareValidator>

                </div>
                <div style="margin: 0 auto;" class="auto-style4">
                    <div class="auto-style5" style="margin: 0 auto;">
                        <asp:Label ID="Label7" runat="server" Font-Names="Segoe UI" Font-Size="Large" ForeColor="Black" Text="DNI del paciente: "></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtDNIPaciente" runat="server" Width="267px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNIPaciente" Display="Dynamic" ErrorMessage="Debe ingresar un DNI" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:Label ID="lblFecha" runat="server" Text="Seleccione una fecha:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtFecha" runat="server" Height="16px" Text='<%# DateTime.Now.ToString("yyyy-MM-dd") %>' TextMode="Date"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCargarHorarios" runat="server" OnClick="btnCargarHorarios_Click" Text="Ver horarios" CausesValidation="false" />
                    </div>
                    <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ControlToValidate="txtFecha" Display="Dynamic" ErrorMessage="Debe seleccionar una fecha" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Table ID="tblHorarios" runat="server" CssClass="horarios-table" Height="55px" Width="449px">
                    </asp:Table>
                    <br />
                    <asp:Label ID="lblSeleccion" runat="server" Font-Bold="True" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="lblHoraSeleccionada" runat="server" Font-Bold="True"></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvHora" runat="server" ErrorMessage="Debe seleccionar una hora" InitialValue="" ControlToValidate="txtHoraSeleccionada" Display="Dynamic"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="txtHoraSeleccionada" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CausesValidation="false"/>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" CausesValidation="true"/>
                    <br />
                    <br />
                    <div class="auto-style2" style="margin: 0 auto;">
                        &nbsp;&nbsp;
                    </div>
                </div>

        </asp:Panel>
    </form>
</body>
</html>
