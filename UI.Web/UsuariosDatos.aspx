<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UsuariosDatos.aspx.cs" Inherits="UI.Web.UsuariosDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
                    <table class="tablaDatos">
                        <tr>
                            <td>ID</td>
                            <td>
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
</asp:Content>
