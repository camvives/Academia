<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin-right: 0px;
        }
        .auto-style3 {
            width: 348px;
        }
        .auto-style4 {
            width: 592px;
        }
        .auto-style5 {
            width: 43%;
        }
        .auto-style6 {
            width: 348px;
            height: 32px;
        }
        .auto-style7 {
            width: 592px;
            height: 32px;
        }
        .auto-style8 {
            width: 348px;
            height: 31px;
        }
        .auto-style9 {
            width: 592px;
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formulario"> 
        <h1>USUARIOS</h1>
        <table style="width:100%;">
            <tr>
                <td>
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns = "False" DataKeyNames="ID" Height="251px" Width="55%" AllowPaging="True" CellPadding="4" CssClass="auto-style2" ForeColor="#333333" GridLines="None" HorizontalAlign="Left" SelectedIndex="0" OnLoad="gridView_SelectedIndexChanged" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:CheckBoxField DataField="Habilitado" HeaderText="Habilitado" />
                <asp:CommandField ButtonType="Image" ShowDeleteButton="True" ShowSelectButton="True" ShowEditButton="True" DeleteImageUrl="~/Imagenes/error.png" EditImageUrl="~/Imagenes/lapiz.png" SelectImageUrl="~/Imagenes/informacion.png" >
                <ControlStyle Height="30px" Width="30px" />
                </asp:CommandField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
                    <table class="auto-style5">
                        <tr>
                            <td class="auto-style3">ID</td>
                            <td class="auto-style4">
                                <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Nombre de Usuario</td>
                            <td class="auto-style4">
                                <asp:Label ID="lblNombreUsuario" runat="server" Text="NombreUsuario"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Habilitado</td>
                            <td class="auto-style4">
                                <asp:Label ID="lblHabilitado" runat="server" Text="Sí"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Nombre</td>
                            <td class="auto-style4">
                                <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Apellido</td>
                            <td class="auto-style4">
                                <asp:Label ID="lblApellido" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Direccion</td>
                            <td class="auto-style4">
                                <asp:Label ID="lblDireccion" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Email</td>
                            <td class="auto-style4">
                                <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Teléfono</td>
                            <td class="auto-style4">
                                <asp:Label ID="lblTelefono" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Fecha de Nacimiento</td>
                            <td class="auto-style4">
                                <asp:Label ID="lblFechaNac" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">Tipo</td>
                            <td class="auto-style7">
                                <asp:Label ID="lblTipo" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Legajo</td>
                            <td class="auto-style4">
                                <asp:Label ID="lblLegajo" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Carrera</td>
                            <td class="auto-style4">
                                <asp:Label ID="lblCarrera" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">Plan</td>
                            <td class="auto-style9">
                                <asp:Label ID="lblPlan" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
