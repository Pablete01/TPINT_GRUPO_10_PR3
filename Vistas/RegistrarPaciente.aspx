<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarPaciente.aspx.cs" Inherits="Vistas.GestionPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color: #FBFCFE; margin: 0; font-family: Arial;">
    <form id="form1" runat="server">
        <div style="background-color: #66a1ff; ">
            <asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Registrar Paciente"></asp:Label>
        </div>
<p>
            <asp:Label ID="lblDatosPersonales" runat="server" Text="Datos Personales" Font-Size="Larger"></asp:Label>
        </p>
        <div style="background-color: #EAF9EE; width: 720px; margin: 6px auto; padding: 18px; border-radius: 8px; border: 1px solid #D7EFE0; box-shadow: 0 1px 2px rgba(0,0,0,0.03);">
            <div style="display: flex; justify-content: space-between; gap: 15px;">
                <div style="display: inline-block; width: 48%;">
                    <asp:Label ID="LabelNombre" runat="server" Text="Nombre:"></asp:Label><br />
                    <asp:TextBox ID="txtNombre" runat="server" Width="80%"></asp:TextBox>
                </div>
                <div style="display: inline-block; width: 48%;">
                    <asp:Label ID="LabelApellido" runat="server" Text="Apellido:"></asp:Label><br />
                    <asp:TextBox ID="txtApellido" runat="server" Width="80%"></asp:TextBox>
                </div>
            </div>

            <br />
            <div style="display: flex; justify-content: space-between; gap: 15px;">
    <div style="display: inline-block; width: 48%;">
        <asp:Label ID="lblDni" runat="server" Text="DNI:"></asp:Label><br />
        <asp:TextBox ID="TxtDni" runat="server" Width="80%"></asp:TextBox>
    </div>
         <div style="display: inline-block; width: 48%;">
            <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:"></asp:Label><br />
            <asp:TextBox ID="TxtNacionalidad" runat="server" Width="80%"></asp:TextBox>
         </div>
        </div>
            <br />
            <asp:Label ID="lblNacimiento" runat="server" Text="Fecha de Nacimiento"></asp:Label><br />
            <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" style="margin-top: 5px; padding: 5px; " Width="267px"></asp:TextBox>
            <br />
            <br />

            <br />
            <asp:Label ID="lblGenero" runat="server" Text="Género"></asp:Label><br />
            <br />
            <br />
            <asp:RadioButton ID="rbFemenino" runat="server" Text="Femenino" GroupName="Sexo"  style="margin-right: 20px;" />
            <asp:RadioButton ID="rbMasculino" runat="server" Text="Masculino" GroupName="Sexo"  style="margin-right: 20px;" />
            <asp:RadioButton ID="rbOtro" runat="server" Text="Otro" GroupName="Sexo" style="margin-right: 20px;" />
            <br />
            <br />

        </div>
        <p></p>
        <p>
            <asp:Label ID="Label8" runat="server" Text="Datos de Contacto y Domicilio" Font-Size="Larger"></asp:Label>
        </p>
        <div style="background-color: #EAF9EE; width: 720px; margin: 6px auto; padding: 18px; border-radius: 8px; border: 1px solid #D7EFE0; box-shadow: 0 1px 2px rgba(0,0,0,0.03);">
            <div style="display: flex; justify-content: space-between; gap: 15px;">
            <div style="display: inline-block; width: 48%;">
                <asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label><br />
                <asp:TextBox ID="txtDireccion" runat="server" Width="80%"></asp:TextBox>
            </div>
            <div style="display: inline-block; width: 48%;">
                <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:"></asp:Label>
                <asp:DropDownList ID="ddlLocalidades" runat="server" Height="21px" Width="282px">
                </asp:DropDownList>
                <br />
             </div>
         </div>
            <br />
         <div style="display: inline-block; width: 48%; height: 66px;">
            <asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDlistProv" runat="server" AutoPostBack="true" Width="80%" OnSelectedIndexChanged="DropDlistProv_SelectedIndexChanged"></asp:DropDownList>
         </div>
            <br />
         <div style="margin-top: 15px;">  
            <asp:Label ID="Label12" runat="server" Text="Correo Electrónico"></asp:Label>
            <br />
            <asp:TextBox ID="txtEmail" runat="server" Height="26px" Width="592px"></asp:TextBox>
        </div>
            <br />
            <div style="display: inline-block; width: 48%; height: 66px;">
            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label><br />
            <asp:TextBox ID="txtTelefono" runat="server" Width="100%" style="margin-top: 5px; padding: 5px;"></asp:TextBox>
         </div>
            <br />
            <br />
        </div>
        <div style="width: 700px; margin: 20px auto; text-align: right;">
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            <asp:Button ID="BtAceptar" runat="server" Text="Aceptar" Width="150px"
                style="background-color: #81C784; color: white; border: none; 
                padding: 8px 0; border-radius: 6px; cursor: pointer; font-weight: bold;" OnClick="BtAceptar_Click" />
        </div>
    </form>
</body>
</html>
