<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionMedico.aspx.cs" Inherits="Vistas.GestionMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión de Médicos</title>

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
                <asp:HyperLink ID="HLVolver" runat="server" NavigateUrl="~/Administrador.aspx" >VOLVER</asp:HyperLink>
            </div>

            <div class="header-right">
                <div class="user-section">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Gestión Médicos"></asp:Label>
                    <asp:ImageButton ID="btnUsuario" runat="server" ImageUrl="~/Imagenes/user.png" Width="40px" Height="40px" />
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="user-label"></asp:Label>
                </div>
            </div>
        </div>

        <!-- Contenedor principal -->
        <asp:Panel ID="PanelPrincipal" runat="server" HorizontalAlign="Center">

            <!-- Panel superior con búsqueda y botones -->
            <div class="panel-superior">
                <asp:TextBox ID="txtBuscar" runat="server" Width="200px" Placeholder="Buscar médico..."></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnAgregarMedico" runat="server" Text="Agregar Médico" />
                &nbsp;&nbsp;
                <asp:DropDownList ID="ddlFiltro" runat="server">
                    <asp:ListItem Text="Predeterminado" Value="Predeterminado"></asp:ListItem>
                    <asp:ListItem Text="Ordenar alfabéticamente" Value="Ordenar alfabéticamente"></asp:ListItem>
                    <asp:ListItem Text="Ordenar por especialidad" Value="Ordenar por especialidad"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="grid-container">
                <asp:GridView ID="grdMedico" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="grid" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grdMedico_PageIndexChanging" OnRowCancelingEdit="grdMedico_RowCancelingEdit" OnRowDataBound="grdMedico_RowDataBound" OnRowEditing="grdMedico_RowEditing" OnRowUpdating="grdMedico_RowUpdating" PageSize="5" Width="509px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField DeleteText="" EditText="Modificar" ShowEditButton="True" ValidationGroup="5" />
                        <asp:TemplateField HeaderText="Legajo">
                            <EditItemTemplate>
                                <asp:Label ID="lblLegajoE" runat="server" Text='<%# Bind("Legajo") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblLegajo" runat="server" Text='<%# Bind("Legajo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Especialidad">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_eit_especialidad" runat="server" AutoPostBack="True" CssClass="custom-select" DataTextField="descripcion_Esp" DataValueField="IdEspecialidad_Esp">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblIdEspecialidad" runat="server" Text='<%# Bind("NombreEspecialidad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNombreE" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtApellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblApellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dni">
                            <EditItemTemplate>
                                <asp:Label ID="txtDniE" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDni" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de Nacimiento">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNacimientoE" runat="server" Text='<%# Bind("FechaNacimiento") %>' TextMode="Date" ValidationGroup="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvfechana" runat="server" ControlToValidate="txtNacimientoE" ErrorMessage="*" ForeColor="Red" ValidationGroup="5"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNacimiento" runat="server" Text='<%# Bind("FechaNacimiento") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Direccion">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDirecionE" runat="server" Text='<%# Bind("Direccion") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDireccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Correo Electronico">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCorreroEE" runat="server" Text='<%# Bind("Email") %>' TextMode="Email"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCorreo" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefono">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTelefonoE" runat="server" Text='<%# Bind("Telefono") %>' TextMode="Phone"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTelefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sexo">
                            <EditItemTemplate>
                                <asp:RadioButtonList ID="rbsexo" runat="server" AutoPostBack="True" CssClass="radiobt" RepeatDirection="Horizontal" ValidationGroup="5">
                                    <asp:ListItem Value="M">M</asp:ListItem>
                                    <asp:ListItem Value="F">F</asp:ListItem>
                                </asp:RadioButtonList>
                                <div class="auto-style67">
                                    <asp:RequiredFieldValidator ID="rfvsexo" runat="server" ControlToValidate="rbsexo" ErrorMessage="*" ForeColor="Red" ValidationGroup="5"></asp:RequiredFieldValidator>
                                </div>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSexo" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nacionalidad">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNacionalidadE" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Provincia">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_eit_provincia" runat="server" AutoPostBack="True" DataTextField="descripcionProvincia_Pr" DataValueField="IdProvincias_Pr">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblProv" runat="server" Text='<%# Bind("NombreProvincia") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Localidad">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_eit_Localidad" runat="server" DataTextField="descripcionLocalidad_Loc" DataValueField="IdLocalidad_Loc">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblLoc" runat="server" Text='<%# Bind("NombreLocalidad") %>'></asp:Label>
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

