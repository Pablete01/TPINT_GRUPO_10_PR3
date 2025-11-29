<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MisPacientes.aspx.cs" Inherits="Vistas.MisPacientes" %>

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
                <asp:HyperLink ID="HLVolver" runat="server" NavigateUrl="~/Medico.aspx">VOLVER</asp:HyperLink>
            </div>

            <div class="header-right">
                <div class="user-section">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Gestión Pacientes"></asp:Label>
                    <asp:ImageButton ID="btnUsuario" runat="server" ImageUrl="~/Imagenes/user.png" Width="40px" Height="40px" />
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="user-label"></asp:Label>
                </div>
            </div>
        </div>

        <!-- Contenedor principal -->
        <asp:Panel ID="PanelPrincipal" runat="server" HorizontalAlign="Center">

            <!-- Panel superior con búsqueda y botones -->
            <div class="panel-superior">
                <asp:TextBox ID="txtBuscar" runat="server" Width="200px" Placeholder="Buscar paciente..."></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />

                <asp:DropDownList ID="ddlFiltro" runat="server">
                    <asp:ListItem Text="Predeterminado" Value="Predeterminado"></asp:ListItem>
                    <asp:ListItem Text="Ordenar alfabéticamente" Value="Ordenar alfabéticamente"></asp:ListItem>
                    <asp:ListItem Text="Ordenar por especialidad" Value="Ordenar por especialidad"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="lblNombreMedico" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True"></asp:Label>
            </div>

            <div class="grid-container">
                <asp:GridView ID="gvPacientes" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID_Turno" CellPadding="4" CssClass="grid" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grdPacientes_PageIndexChanging" OnRowCancelingEdit="grdPacientes_RowCancelingEdit" OnRowDataBound="grdPacientes_RowDataBound" OnRowEditing="grdPacientes_RowEditing" OnRowUpdating="grdPacientes_RowUpdating" PageSize="5" Width="1376px" OnRowUpdated="grdPacientes_RowUpdated">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>


                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NombrePaciente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido">
                            <ItemTemplate>
                                <asp:Label ID="lblApellido" runat="server" Text='<%# Bind("ApellidoPaciente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dni">
                            <ItemTemplate>
                                <asp:Label ID="lblDni" runat="server" Text='<%# Bind("DNIPaciente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Nacimiento">
                            <ItemTemplate>
                                <asp:Label ID="lblFechaNacimiento" runat="server" Text='<%# Eval("FechaNacimiento", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sexo">
                            <ItemTemplate>
                                <asp:Label ID="lblSexo" runat="server" Text='<%# Bind("SexoPaciente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nacionalidad">
                            <ItemTemplate>
                                <asp:Label ID="lblNacionalidad" runat="server" Text='<%# Bind("NacionalidadPaciente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Direccion">
                            <ItemTemplate>
                                <asp:Label ID="lblDireccion" runat="server" Text='<%# Bind("DireccionPaciente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefono">
                            <ItemTemplate>
                                <asp:Label ID="lblTelefono" runat="server" Text='<%# Bind("TelefonoPaciente") %>'></asp:Label>
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

