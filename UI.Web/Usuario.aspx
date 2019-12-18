<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="UI.Web.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            margin-left: 3px;
        }

    </style>

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formulario">
    <h1>Nuevo Usuario</h1>
        <table class="tabla">
            <tr>
                <td class="celda1">Tipo </td>
                <td class="celda2">
                    <asp:DropDownList ID="ddlTipo" runat="server"  Width="231px" CssClass="elementoCelda" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" Height="25px">
                        <asp:ListItem>Administrador</asp:ListItem>
                        <asp:ListItem>Docente</asp:ListItem>
                        <asp:ListItem>Alumno</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="celda1">Nombre</td>
                <td class="celda2">
                    <asp:TextBox ID="txtNombre" runat="server" Width="231px" CssClass="elementoCelda"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="celda1">Apellido</td>
                <td class="celda2">
                    <asp:TextBox ID="txtApellido" runat="server" Width="231px" CssClass="elementoCelda"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="celda1">Dirección</td>
                <td class="celda2">
                    <asp:TextBox ID="txtDireccion" runat="server" Width="143px" ForeColor="Black" CssClass="elementoCelda" ></asp:TextBox>
                    <asp:TextBox ID="txtDireccionNum" runat="server" Width="69px" CssClass="elementoCelda"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="celda1">Email</td>
                <td class="celda2">
                    <asp:TextBox ID="txtEmail" runat="server" Width="231px" CssClass="elementoCelda"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="celda1">Teléfono</td>
                <td class="celda2">
                    <asp:TextBox ID="txtTelefono" runat="server" Width="231px" CssClass="elementoCelda"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="celda1">Fecha de Nacimiento</td>
                <td class="celda2">
                    <asp:TextBox ID="txtDia" runat="server" Width="37px" CssClass="elementoCelda"></asp:TextBox> &nbsp;
                    <asp:Label ID="Label1" runat="server" Text="/" Font-Size="Medium" Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="txtMes" runat="server" Width="31px" CssClass="elementoCelda"></asp:TextBox> &nbsp;
                    <asp:Label ID="Label2" runat="server" Text="/" Font-Size="Medium" Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="txtAnio" runat="server" Width="51px" CssClass="elementoCelda"></asp:TextBox> &nbsp;
                </td>
            </tr>
            <tr>
                <td class="celda1">Legajo</td>
                <td class="celda2">
                    <asp:TextBox ID="txtLegajo" runat="server" CssClass="elementoCelda"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="celda1">Carrera</td>
                <td class="celda2">
                    <asp:DropDownList ID="ddlCarrera" runat="server"  Width="195px" CssClass="elementoCelda" AutoPostBack="True" OnSelectedIndexChanged="ddlCarrera_SelectedIndexChanged" Height="25px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlPlan" runat="server" CssClass="auto-style1" Width="54px" Height="25px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="celda1">&nbsp;</td>
                <td class="auto-style13">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="celda1">Usuario</td>
                <td class="celda2">
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="elementoCelda" Width="231px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="celda1">Contraseña</td>
                <td class="celda2">
                    <asp:TextBox ID="txtClave" runat="server" Width="231px" CssClass="elementoCelda" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="celda1">Confirmar Cotraseña</td>
                <td class="celda2">
                    <asp:TextBox ID="txtConfirmaClave" runat="server" Width="231px" CssClass="elementoCelda"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="celda1">Habilitado</td>
                <td class="celda2">
                    <asp:CheckBox ID="chkHabilitado" runat="server" CssClass="elementoCelda" Checked="True" Font-Size="X-Large" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="lblError" runat="server" Text="Error" Visible="False"></asp:Label>
        <br />
        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Guardar" Height="35px" Width="122px" CssClass="botonAceptar" />
    <br />
    </div>
</asp:Content>
