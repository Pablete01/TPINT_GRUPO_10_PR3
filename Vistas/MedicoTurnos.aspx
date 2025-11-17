<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MedicoTurnos.aspx.cs" Inherits="Vistas.MedicoTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 29px;
        }
        .auto-style3 {
            background-color: #66a1ff;
        }
        .auto-style4 {
            height: 23px;
            background-color: #66a1ff;
        }
        .auto-style5 {
            width: 412px;
        }
        .auto-style6 {
            width: 1142px;
        }
        .auto-style7 {
            width: 225px;
        }
        .auto-style8 {
            height: 29px;
            width: 225px;
        }
        .auto-style11 {
            width: 225px;
            height: 66px;
        }
        .auto-style12 {
            height: 66px;
        }
        .auto-style13 {
            width: 336px;
        }
        .auto-style14 {
            width: 336px;
            height: 66px;
        }
        .auto-style15 {
            height: 29px;
            width: 336px;
        }
        .auto-style16 {
            margin-left: 0px;
        }
        .auto-style17 {
            width: 144px;
        }
        .auto-style18 {
            height: 66px;
            width: 144px;
        }
        .auto-style19 {
            height: 29px;
            width: 144px;
        }
        .auto-style20 {
            width: 146px;
        }
        .auto-style21 {
            height: 66px;
            width: 146px;
        }
        .auto-style22 {
            height: 29px;
            width: 146px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lbltitulo1" runat="server" Font-Size="XX-Large" ForeColor="Black" Text="TURNOS" Font-Names="Segoe UI"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblUsuario" runat="server" Font-Size="X-Large" ForeColor="Black" Font-Names="Segoe UI"></asp:Label>
                    <asp:Button ID="btnCerrarsesion" runat="server" Text="Cerrar sesión" />
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14"></td>
                <td class="auto-style21">Buscar paciente por DNI:</td>
                <td class="auto-style18">
                    <asp:TextBox ID="txtDNIPaciente" runat="server" CssClass="auto-style16"></asp:TextBox>
                </td>
                <td class="auto-style12">
                    <asp:Button ID="btnBuscarDNI" runat="server" Text="Buscar" Width="83px" />
                </td>
                <td class="auto-style12"></td>
                <td class="auto-style11"></td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style22">Buscar paciente por nombre:</td>
                <td class="auto-style19">
                    <asp:TextBox ID="txtNombrePaciente" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:Button ID="btnBuscarNombre" runat="server" Text="Buscar" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="btnTodos" runat="server" Text="Mostrar todos" />
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">
                    <asp:GridView ID="gvTurnos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#66A1FF" GridLines="None" OnSelectedIndexChanged="gvTurnos_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID TURNO">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblIDTurno" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FECHA TURNO">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HORA ">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblHora" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DNI">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDNI" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NOMBRE">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblNombre" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="APELLIDO">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblApellido" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ASISTENCIA">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="cbAsistencia" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OBSERVACION">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtObservacion" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server"></asp:Label>
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
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
