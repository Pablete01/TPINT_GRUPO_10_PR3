<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarPaciente.aspx.cs" Inherits="Vistas.GestionPaciente" %>

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

        .auto-style1 {
            margin-left: 240px;
        }
    </style>
</head>

<body>

    <form id="form1" runat="server">
        <!-- Barra superior -->
        <div class="header">
            <div class="header-left">
                <asp:ImageButton ID="btnInicio" runat="server" ImageUrl="~/Imagenes/inicio.png" Width="35px" Height="35px" />
                <asp:HyperLink ID="HLVolver" runat="server" NavigateUrl="~/GestionPacientes.aspx">VOLVER</asp:HyperLink>
            </div>

            <div class="header-right">
                <div class="user-section">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Gestión Pacientes"></asp:Label>
                    <asp:ImageButton ID="btnUsuario" runat="server" ImageUrl="~/Imagenes/user.png" Width="40px" Height="40px" />
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="user-label"></asp:Label>
                </div>
            </div>
        </div>

        <div style="background-color: #66a1ff;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Registrar Paciente"></asp:Label>
        </div>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblDatosPersonales" runat="server" Text="Datos Personales" Font-Size="Larger"></asp:Label>
        </p>
        <div style="background-color: #66a1ff; width: 720px; margin: 6px auto; padding: 18px; border-radius: 8px; border: 1px solid #D7EFE0; box-shadow: 0 1px 2px rgba(0,0,0,0.03);">
            <div style="display: flex; justify-content: space-between; gap: 15px;">
                <div style="display: inline-block; width: 48%;">
                    <asp:Label ID="LabelNombre" runat="server" Text="Nombre:"></asp:Label><br />
                    <asp:TextBox ID="txtNombre" runat="server" Width="80%"></asp:TextBox>
                    <br />

            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" Display="Dynamic" ErrorMessage="Nombre requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div style="display: inline-block; width: 48%;">
                    <asp:Label ID="LabelApellido" runat="server" Text="Apellido:"></asp:Label><br />
                    <asp:TextBox ID="txtApellido" runat="server" Width="80%"></asp:TextBox>
                    <br />
            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" Display="Dynamic" ErrorMessage="Apellido requerido" ForeColor="Red"></asp:RequiredFieldValidator>

                </div>
            </div>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
            <br />
            <div style="display: flex; justify-content: space-between; gap: 15px;">
                <div style="display: inline-block; width: 48%;">
                    <asp:Label ID="lblDni" runat="server" Text="DNI:"></asp:Label><br />
                    <asp:TextBox ID="TxtDni" runat="server" Width="80%"></asp:TextBox>
                    <br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtDni" Display="Dynamic" ErrorMessage="Solo numeros sin puntos" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="TxtDni" Display="Dynamic" ErrorMessage="DNI requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div style="display: inline-block; width: 48%;">
                    <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:"></asp:Label><br />
                    <asp:TextBox ID="TxtNacionalidad" runat="server" Width="80%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="TxtNacionalidad" Display="Dynamic" ErrorMessage="Nacionalidad requerida" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <br />
            <asp:Label ID="lblNacimiento" runat="server" Text="Fecha de Nacimiento"></asp:Label><br />
            <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" Style="margin-top: 5px; padding: 5px;" Width="267px"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvFechaNac" runat="server" ControlToValidate="txtFechaNacimiento" Display="Dynamic" ErrorMessage="Seleccione una fecha de nacimiento" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <br />
            <asp:Label ID="lblGenero" runat="server" Text="Género"></asp:Label>
            <br />
            <br />
            <asp:RadioButtonList ID="rblSexo" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
            </asp:RadioButtonList>

            <br />

            <asp:RequiredFieldValidator
                ID="rfvSexo"
                runat="server"
                ControlToValidate="rblSexo"
                InitialValue=""
                ErrorMessage="Seleccione una opción"
                ForeColor="Red"
                Display="Dynamic"></asp:RequiredFieldValidator>
            <br />

        </div>
        <p></p>
        <p class="auto-style1">
            &nbsp;&nbsp;<asp:Label ID="Label8" runat="server" Text="Datos de Contacto y Domicilio" Font-Size="Larger"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <div style="background-color: #66a1ff; width: 720px; margin: 6px auto; padding: 18px; border-radius: 8px; border: 1px solid #D7EFE0; box-shadow: 0 1px 2px rgba(0,0,0,0.03);">
            <div style="display: flex; justify-content: space-between; gap: 15px;">
                <div style="display: inline-block; width: 48%;">
                    <asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label><br />
                    <asp:TextBox ID="txtDireccion" runat="server" Width="80%"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" Display="Dynamic" ErrorMessage="Ingrese dirección" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div style="display: inline-block; width: 48%;">
                    <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:"></asp:Label>
                    <asp:DropDownList ID="ddlLocalidades" runat="server" Height="21px" Width="282px">
                    </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvLocalidades" runat="server" ControlToValidate="ddlLocalidades" InitialValue="0" ErrorMessage="Seleccione una localidad" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <div style="display: inline-block; width: 48%; height: 66px;">
                <asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDlistProv" runat="server" AutoPostBack="true" Width="80%" OnSelectedIndexChanged="DropDlistProv_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="DropDlistProv" InitialValue="0" Display="Dynamic" ErrorMessage="Seleccione una provincia" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <br />
            <div style="margin-top: 15px;">
                <asp:Label ID="Label12" runat="server" Text="Correo Electrónico"></asp:Label>
                <br />
                <asp:TextBox ID="txtEmail" runat="server" Height="26px" Width="592px"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" EnableViewState="False" ErrorMessage="Ingrese un correo electrónico" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <div style="display: inline-block; width: 48%; height: 66px;">
                <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>&nbsp;(solo números sin guiones)<br />
                <asp:TextBox ID="txtTelefono" runat="server" Width="100%" Style="margin-top: 5px; padding: 5px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" Display="Dynamic" ErrorMessage="Ingrese un teléfono" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" Display="Dynamic" ErrorMessage="Ingrese solo números" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
            </div>
            <br />
            <br />
        </div>
        <div style="width: 700px; margin: 20px auto; text-align: right;">
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtAceptar" runat="server" Text="Aceptar" Width="150px"
                Style="background-color: #66a1ff; color: black; border: none; padding: 8px 0; border-radius: 6px; cursor: pointer; font-weight: bold;"
                OnClick="BtAceptar_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="150px" CausesValidation="false"
                Style="background-color: #66a1ff; color: black; border: none; padding: 8px 0; border-radius: 6px; cursor: pointer; font-weight: bold;"
                OnClick="btnCancelar_Click" />

        </div>
    </form>
</body>
</html>
