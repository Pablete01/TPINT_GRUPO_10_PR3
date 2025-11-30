<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionTurnos_2.aspx.cs" Inherits="Vistas.GestionTurnos_2" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Gestión Turnos Pacientes</title>

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

        .main-panel {
            text-align: center;
            margin: 20px 0;
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

        
        <
          <!-- Barra superior -->
  <div class="header">
      <div class="header-left">
          <asp:ImageButton ID="btnInicio" runat="server" ImageUrl="~/Imagenes/inicio.png" Width="35px" Height="35px" />
          <asp:HyperLink ID="HLVolver" runat="server" NavigateUrl="~/Administrador.aspx" >VOLVER</asp:HyperLink>
      </div>

      <div class="header-right">
          <div class="user-section">
              <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Gestión Turnos"></asp:Label>
              <asp:ImageButton ID="btnUsuario" runat="server" ImageUrl="~/Imagenes/user.png" Width="40px" Height="40px" />
              <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="user-label"></asp:Label>
          </div>
      </div>
  </div>

        
        <asp:Panel ID="PanelPrincipal" runat="server" HorizontalAlign="Center">

            <div class="main-panel">
                <h3>Gestión Turnos Pacientes</h3>
            </div>

            <div class="grid-container">

                <asp:GridView 
                    ID="grdTurnosPacientes"
                    runat="server"
                    AllowPaging="True"
                    AutoGenerateColumns="False"
                    PageSize="7"
                    CssClass="grid"
                    DataKeyNames="ID_Pacientes" OnPageIndexChanging="grdTurnosPacientes_PageIndexChanging" OnRowCommand="grdTurnosPacientes_RowCommand">

                    <Columns>

                        
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:LinkButton 
                                    ID="btnGestionar"
                                    runat="server"
                                    Text="Gestionar"
                                    CommandName="Gestionar"
                                    CommandArgument='<%# Eval("ID_Pacientes") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="DNI" HeaderText="DNI" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />

                    </Columns>

                </asp:GridView>

            </div>

        </asp:Panel>

        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>

    </form>
</body>
</html>

