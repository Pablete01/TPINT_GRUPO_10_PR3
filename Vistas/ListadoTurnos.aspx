<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoTurnos.aspx.cs" Inherits="Vistas.ListadoTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión de Pacientes</title>

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
                <asp:HyperLink ID="HLVolver" runat="server" NavigateUrl="~/GestionTurnos.aspx">VOLVER</asp:HyperLink>
            </div>

            <div class="header-right">
                <div class="user-section">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Listado de turnos"></asp:Label>
                    <asp:ImageButton ID="btnUsuario" runat="server" ImageUrl="~/Imagenes/user.png" Width="40px" Height="40px" />
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="user-label"></asp:Label>
                </div>
            </div>
        </div>

        <!-- Contenedor principal -->
        <asp:Panel ID="PanelPrincipal" runat="server" HorizontalAlign="Center">

            <!-- Panel superior con búsqueda y botones -->
            <div class="panel-superior">
                <asp:TextBox ID="txtBuscar" runat="server" Width="200px" Placeholder="Buscar turno..." ></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                &nbsp;&nbsp; &nbsp;&nbsp;
                <asp:DropDownList ID="ddlFiltro" runat="server">
                    <asp:ListItem Text="Predeterminado" Value="Predeterminado"></asp:ListItem>
                    <asp:ListItem Text="Ordenar alfabéticamente" Value="Ordenar alfabéticamente"></asp:ListItem>
                    <asp:ListItem Text="Ordenar por especialidad" Value="Ordenar por especialidad"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="grid-container">
                <asp:GridView ID="gvTurnos" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID_Turno" CellPadding="4" CssClass="grid" ForeColor="#333333" GridLines="None" PageSize="5" Width="610px" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>

                        <asp:TemplateField HeaderText="Turno N°">
                            <ItemTemplate>
                                <asp:Label ID="lblTurno" runat="server" Text='<%# Bind("ID_Turno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Día">
                            <ItemTemplate>
                                <asp:Label ID="lblDia" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hora">

                            <ItemTemplate>
                                <asp:Label ID="lblHora" runat="server" Text='<%# Bind("Hora") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Especialidad">
                            <ItemTemplate>
                                <asp:Label ID="lblEspecialidad" runat="server" Text='<%# Bind("EspecialidadMedico") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Médico">
                            <ItemTemplate>
                                <asp:Label ID="lblMedico" runat="server" Text='<%# Eval("ApellidoMedico") + ", " + Eval("NombreMedico") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Paciente">
                            <ItemTemplate>
                                <asp:Label ID="lblPaciente" runat="server" Text='<%# Eval("ApellidoPaciente") + ", " + Eval("NombrePaciente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("EstadoTurno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Obervaciones">
                            <ItemTemplate>
                                <asp:Label ID="lblObservaciones" runat="server" Text='<%# Bind("Observaciones") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
        </asp:Panel>
    </form>
</body>
</html>

