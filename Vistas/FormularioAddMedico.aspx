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
                        <asp:TextBox ID="txtNombre" runat="server" /></td>
                </tr>

                <tr>
                    <td>
                        <label for="txtApellido">Apellido:</label></td>
                    <td>
                        <asp:TextBox ID="txtApellido" runat="server" /></td>
                </tr>

                <tr>
                    <td>
                        <label for="txtEmail">Email:</label></td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" /></td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <label for="txtDNI">DNI:</label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtDNI" runat="server" /></td>
                </tr>

                <tr>
                    <td>
                        <label for="txtTelefono">Teléfono:</label></td>
                    <td>
                        <asp:TextBox ID="txtTelefono" runat="server" /></td>
                </tr>

                <tr>
                    <td>
                        <label for="txtFechaNac">Fecha de Nacimiento:</label></td>
                    <td>
                        <asp:TextBox ID="txtFechaNac" runat="server" TextMode="Date" /></td>
                </tr>

                <tr>
                    <td>
                        <label for="txtNacionalidad">Nacionalidad:</label></td>
                    <td>
                        <asp:TextBox ID="txtNacionalidad" runat="server" /></td>
                </tr>

                <tr>
                    <td>
                        <label for="txtDireccion">Provincia:</label></td>
                    <td>
                        <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="txtLocalidad">Localidad:</label></td>
                    <td>
                        <asp:DropDownList ID="ddlLocalidad" runat="server"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="txtDireccion">Dirección</label><label for="txtProvincia">:</label></td>
                    <td>
                        <asp:TextBox ID="txtDireccion" runat="server" /></td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <label for="ddlSexo">Sexo:</label></td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlSexo" runat="server"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="ddlEspecialidad">Especialidad:</label></td>
                    <td>
                        <asp:DropDownList ID="ddlEspecialidad" runat="server"></asp:DropDownList>
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td class="auto-style1">
                        <label for="txtDNI">USUARIO:</label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtUsuario" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" Display="Dynamic" ErrorMessage="Ingrese un nombre de usuario" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <label for="txtDNI">CONTRASEÑA:</label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtContrasena" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvContrasena" runat="server" ControlToValidate="txtContrasena" Display="Dynamic" ErrorMessage="Ingrese una contraseña" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

            </table>

            <table>

                <tr>
                    <td class="auto-style2">
                        <label for="txtDNI">REPETIR CONTRASEÑA:</label></td>
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
