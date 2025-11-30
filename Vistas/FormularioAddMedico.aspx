<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioAddMedico.aspx.cs" Inherits="Vistas.FormularioAddMedico" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Formulario Médico</title>

    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f4f7f9;
            margin: 0;
            padding: 0;
        }

        .header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            background-color: #66a1ff;
            padding: 10px 20px;
        }

        .header-left, .header-right {
            display: flex;
            align-items: center;
        }

        .user-section {
            text-align: center;
            color: white;
            font-size: 13px;
        }

        .form-container {
            background-color: #fff;
            width: 500px;
            margin: 50px auto;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0px 2px 8px rgba(0, 0, 0, 0.1);
        }

        h2 {
            text-align: center;
            color: #333;
            margin-bottom: 25px;
        }

        table {
            width: 100%;
        }

        td {
            padding: 8px;
        }

        label {
            display: inline-block;
            font-weight: 600;
            color: #444;
            margin-bottom: 5px;
        }

        input[type="text"], select {
            width: 95%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 6px;
            font-size: 14px;
            transition: border-color 0.2s;
        }

            input[type="text"]:focus, select:focus {
                border-color: #007bff;
                outline: none;
            }

        .btn-container {
            text-align: center;
            margin-top: 20px;
        }

        .btn {
            background-color: #007bff;
            color: white;
            font-size: 15px;
            padding: 8px 18px;
            border: none;
            border-radius: 6px;
            cursor: pointer;
        }

            .btn:hover {
                background-color: #0056b3;
            }

        .user-label {
            color: white;
            margin-top: 5px;
            display: block;
            text-align: center;
        }
        .auto-style1 {
            height: 52px;
        }
        .auto-style2 {
            height: 52px;
            width: 233px;
        }
        .auto-style3 {
            width: 233px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <asp:HiddenField ID="hiddenIdMedico" runat="server" />
        <div class="header">
            <div class="header-left">
                <asp:ImageButton ID="btnInicio" runat="server" ImageUrl="~/Imagenes/inicio.png" Width="35px" Height="35px" />
            </div>

            <div class="header-right">
                <div class="user-section">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Gestión Médicos"></asp:Label>
                    <asp:ImageButton ID="btnUsuario" runat="server" ImageUrl="~/Imagenes/user.png" Width="40px" Height="40px" />
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="user-label"></asp:Label>
                </div>
            </div>
        </div>


        <div class="form-container">
            <h2>
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
            </h2>

            <table>
                <tr>
                    <td>
                        <label for="txtNombre">Nombre:</label></td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" Display="Dynamic" ErrorMessage="Ingrese un nombre" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Ingrese solo letras" ForeColor="Red" ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="txtApellido">Apellido:</label></td>
                    <td>
                        <asp:TextBox ID="txtApellido" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" Display="Dynamic" ErrorMessage="Ingrese un apellido" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revApellido" runat="server" ErrorMessage="Ingrese solo letras" ForeColor="Red" ControlToValidate="txtApellido" ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="txtEmail">Email:</label></td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Ingrese un email" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Ingrese un Email valido" ForeColor="Red" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <label for="txtDNI">DNI:</label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtDNI" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ErrorMessage="Ingrese el DNI" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI" Display="Dynamic" ErrorMessage="Ingrese solo números" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="txtTelefono">Teléfono:</label></td>
                    <td>
                        <asp:TextBox ID="txtTelefono" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" Display="Dynamic" ErrorMessage="Ingrese un telefono" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" Display="Dynamic" ErrorMessage="Ingrese solo números" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="txtFechaNac">Fecha de Nacimiento:</label></td>
                    <td>
                        <asp:TextBox ID="txtFechaNac" runat="server" TextMode="Date" />
                        <br />
                        <asp:RequiredFieldValidator ID="rfvNacimiento" runat="server" ControlToValidate="txtFechaNac" Display="Dynamic" ErrorMessage="Seleccione fecha nacimiento" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="txtNacionalidad">Nacionalidad:</label></td>
                    <td>
                        <asp:TextBox ID="txtNacionalidad" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="txtNacionalidad" Display="Dynamic" ErrorMessage="Ingrese nacionalidad" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="txtDireccion">Provincia:</label></td>
                    <td>
                        <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" Display="Dynamic" InitialValue="0" ErrorMessage="Seleccione una provincia" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="txtLocalidad">Localidad:</label></td>
                    <td>
                        <asp:DropDownList ID="ddlLocalidad" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" Display="Dynamic" InitialValue="0" ErrorMessage="Seleccione una localidad" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="txtDireccion">Dirección</label><label for="txtProvincia">:</label></td>
                    <td>
                        <asp:TextBox ID="txtDireccion" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" Display="Dynamic" ErrorMessage="Ingrese dirección" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <label for="ddlSexo">Sexo:</label></td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlSexo" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="ddlSexo" Display="Dynamic" InitialValue="0" ErrorMessage="Seleccione un sexo" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="ddlEspecialidad">Especialidad:</label></td>
                    <td>
                        <asp:DropDownList ID="ddlEspecialidad" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" Display="Dynamic" InitialValue="0" ErrorMessage="Seleccione una especialidad" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td class="auto-style1">
                        <label for="txtDNI">Usuario:</label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtUsuario" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" Display="Dynamic" ErrorMessage="Ingrese un nombre de usuario" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <label for="txtDNI">Contraseña:</label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtContrasena" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvContrasena" runat="server" ControlToValidate="txtContrasena" Display="Dynamic" ErrorMessage="Ingrese una contraseña" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

            </table>

            <table>

                <tr>
                    <td class="auto-style2">
                        <label for="txtDNI">Repetir contraseña:</label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtRepetirContrasena" runat="server" />
                        <br />
                        <asp:RequiredFieldValidator ID="rfvContrasena2" runat="server" ControlToValidate="txtRepetirContrasena" Display="Dynamic" ErrorMessage="Ingrese una contraseña" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style3">
                        <asp:CompareValidator ID="cvContrasena" runat="server" ControlToCompare="txtContrasena" ControlToValidate="txtRepetirContrasena" Display="Dynamic" ErrorMessage="Las contraseñas no coinciden" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>

            </table>

            <div class="btn-container">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn" OnClick="btnAceptar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="false"  CssClass="btn" OnClick="btnCancelar_Click" />
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
