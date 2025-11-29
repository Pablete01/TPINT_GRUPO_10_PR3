<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionPacientes.aspx.cs" Inherits="Vistas.GestionPacientes" %>

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
                <asp:HyperLink ID="HLVolver" runat="server" NavigateUrl="~/Administrador.aspx" >VOLVER</asp:HyperLink>
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
                <asp:TextBox ID="txtBuscar" runat="server" Width="200px" Placeholder="Buscar paciente..." ></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"  />
                &nbsp;&nbsp; &nbsp;&nbsp;
                <asp:DropDownList ID="ddlFiltro" runat="server">
                    <asp:ListItem Text="Predeterminado" Value="Predeterminado"></asp:ListItem>
                    <asp:ListItem Text="Ordenar alfabéticamente" Value="Ordenar alfabéticamente"></asp:ListItem>
                    <asp:ListItem Text="Ordenar por especialidad" Value="Ordenar por especialidad"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Button ID="btnAgregarPaciente" runat="server" Font-Bold="True" Height="51px" OnClick="btnAgregarPaciente_Click" Text="Agregar Paciente" Width="175px" />
                <br />
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Text="Label"></asp:Label>
            </div>

            <div class="grid-container">
                <asp:GridView ID="grdPacientes" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID_Pacientes" CellPadding="4" CssClass="grid" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grdPacientes_PageIndexChanging" OnRowCancelingEdit="grdPacientes_RowCancelingEdit" OnRowDataBound="grdPacientes_RowDataBound" OnRowEditing="grdPacientes_RowEditing" OnRowUpdating="grdPacientes_RowUpdating" PageSize="5" Width="509px" OnRowDeleting="grdPacientes_RowDeleting" OnRowUpdated="grdPacientes_RowUpdated" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField DeleteText="Eliminar" EditText="Modificar" ShowEditButton="True" ValidationGroup="5" CancelText="Cancelar" ShowDeleteButton="True" />
                        <asp:TemplateField HeaderText="Nombre">
                            <EditItemTemplate>
                                <asp:TextBox ID="lbl_eit_nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido">
                            <EditItemTemplate>
                                <asp:TextBox ID="lbl_eit_apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblApellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dni">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_eit_dni" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDni" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de Nacimiento">
                            <EditItemTemplate>
                                <asp:TextBox ID="lbl_eit_fechaNacimiento" runat="server" Text='<%# Bind("FechaNacimiento") %>' TextMode="Date" ValidationGroup="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvfechana" runat="server" ControlToValidate="lbl_eit_fechaNacimiento" ErrorMessage="*" ForeColor="Red" ValidationGroup="5"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNacimiento" runat="server" Text='<%# Bind("FechaNacimiento") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Direccion">
                            <EditItemTemplate>
                                <asp:TextBox ID="lbl_eit_direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDireccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Correo Electronico">
                            <EditItemTemplate>
                                <asp:TextBox ID="lbl_eit_email" runat="server" Text='<%# Bind("Email") %>' TextMode="Email"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCorreo" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefono">
                            <EditItemTemplate>
                                <asp:TextBox ID="lbl_eit_telefono" runat="server" Text='<%# Bind("Telefono") %>' TextMode="Phone"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTelefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sexo">
                            <EditItemTemplate>
                                <asp:RadioButtonList ID="rbl_eit_sexo" runat="server" AutoPostBack="True" CssClass="radiobt" RepeatDirection="Horizontal" ValidationGroup="5">
                                    <asp:ListItem Value="Masculino">Masculino</asp:ListItem>
                                    <asp:ListItem Value="Femenino">Femenino</asp:ListItem>
                                </asp:RadioButtonList>
                                <div class="auto-style67">
                                    <asp:RequiredFieldValidator ID="rfvsexo" runat="server" ControlToValidate="rbl_eit_sexo" ErrorMessage="*" ForeColor="Red" ValidationGroup="5"></asp:RequiredFieldValidator>
                                </div>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSexo" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nacionalidad">
                            <EditItemTemplate>
                                <asp:TextBox ID="lbl_eit_nacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Provincia">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_eit_provincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" DataTextField="descripcionProvincia_Pr" DataValueField="IdProvincias_Pr">
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

