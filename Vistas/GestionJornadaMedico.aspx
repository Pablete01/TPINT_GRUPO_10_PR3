<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionJornadaMedico.aspx.cs" Inherits="Vistas.GestionJornadaMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>GestionJornadaMedico</title>
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
                <asp:HyperLink ID="HLVolver" runat="server" NavigateUrl="~/GestionMedico.aspx">VOLVER</asp:HyperLink>
            </div>

            <div class="header-right">
                <div class="user-section">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Jornadas Médicos"></asp:Label>
                    <asp:ImageButton ID="btnUsuario" runat="server" ImageUrl="~/Imagenes/user.png" Width="40px" Height="40px" />
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="user-label"></asp:Label>
                </div>
            </div>
        </div>


        <asp:Panel ID="PanelPrincipal" runat="server" HorizontalAlign="Center">


            <div class="panel-superior">
                &nbsp;&nbsp;
                <asp:Button ID="btnAgregarJornada" runat="server" Text="Agregar Jornada" OnClick="btnAgregarJornada_Click" />
                &nbsp;&nbsp;
            </div>

            <div class="grid-container">
                <asp:GridView
                    ID="grdJornadaMedico"
                    runat="server"
                    AllowPaging="True"
                    AutoGenerateColumns="False"
                    PageSize="5"
                    CssClass="grid"
                    DataKeyNames="ID_Jornada" OnRowCommand="grdJornadaMedico_RowCommand">

                    <AlternatingRowStyle BackColor="White" />

                    <Columns>


                        <asp:BoundField DataField="ID_Jornada" Visible="False" />


                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <%--<asp:LinkButton 
                    ID="btnModificar"
                    runat="server"
                    Text="Modificar"
                    CommandName="Modificar"
                    CommandArgument='<%# Eval("ID_Jornada") %>' />--%>

                                <asp:LinkButton
                                    ID="btnEliminar"
                                    runat="server"
                                    Text="Eliminar"
                                    CommandName="Eliminar"
                                    OnClientClick="return confirm('¿Está seguro que desea cancelar el turno?');" 
                                    CommandArgument='<%# Eval("ID_Jornada") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Día Semana">
                            <ItemTemplate>
                                <%# GetNombreDia(Convert.ToInt32(Eval("DiaSemana"))) %>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:BoundField DataField="HoraEntrada" HeaderText="Hora Entrada" />


                        <asp:BoundField DataField="HoraSalida" HeaderText="Hora Salida" />


                        <asp:BoundField DataField="Duracion" HeaderText="Duración (min)" />

                    </Columns>
                </asp:GridView>

            </div>

            <asp:Panel ID="PanelAgregar" runat="server" Visible="false" CssClass="grid-container" Style="margin-top: 20px;">

                <h3>Agregar Jornada</h3>

                <table style="width: 100%;">
                    <tr>
                        <td>Día de la Semana:</td>
                        <td>
                            <asp:DropDownList ID="ddlDiaSemana" runat="server">
                                <asp:ListItem Value="1">Lunes</asp:ListItem>
                                <asp:ListItem Value="2">Martes</asp:ListItem>
                                <asp:ListItem Value="3">Miércoles</asp:ListItem>
                                <asp:ListItem Value="4">Jueves</asp:ListItem>
                                <asp:ListItem Value="5">Viernes</asp:ListItem>
                                <asp:ListItem Value="6">Sábado</asp:ListItem>
                                <asp:ListItem Value="7">Domingo</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td>Hora Entrada:</td>
                        <td>
                            <asp:TextBox ID="txtEntrada" runat="server" TextMode="Time"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>Hora Salida:</td>
                        <td>
                            <asp:TextBox ID="txtSalida" runat="server" TextMode="Time"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>Duración (minutos):</td>
                        <td>
                            <asp:TextBox ID="txtDuracion" runat="server" Text="60"></asp:TextBox></td>
                    </tr>
                </table>

                <asp:Button ID="btnAceptarNuevaJornada" runat="server" Text="Aceptar" OnClick="btnAceptarNuevaJornada_Click" />
                <asp:Button ID="btnCancelarNuevaJornada" runat="server" Text="Cancelar" OnClick="btnCancelarNuevaJornada_Click" />

            </asp:Panel>

        </asp:Panel>
        <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
