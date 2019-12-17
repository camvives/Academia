<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="UI.Web.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 1160px;
            height: 303px;
            margin-left: 0px;
        }
        .auto-style5 {
            margin-left: 19px;
        }
        .auto-style6 {
            margin-left: 0px;
        }
        .auto-style7 {
            margin-bottom: 0px;
        }
        .auto-style19 {
            text-align: center;
            height: 551px;
        }
        .auto-style21 {
            width: 100%;
            height: 93px;
        }
        .auto-style24 {
            width: 588px;
            height: 31px;
        }
        .auto-style25 {
            height: 31px;
        }
        .auto-style38 {
            width: 546px;
            text-align: right;
            height: 33px;
        }
        .auto-style39 {
            text-align: justify;
            width: 579px;
            height: 33px;
        }
        .auto-style40 {
            width: 546px;
            text-align: right;
            height: 34px;
        }
        .auto-style41 {
            text-align: justify;
            width: 579px;
            height: 34px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style19">
    <h1>Datos Personales</h1>
        <table class="auto-style1">
            <tr>
                <td class="auto-style38">Tipo </td>
                <td class="auto-style39">
                    <asp:DropDownList ID="ddlTipo" runat="server" Height="24px" Width="242px" CssClass="auto-style7">
                        <asp:ListItem>Administrador</asp:ListItem>
                        <asp:ListItem>Docente</asp:ListItem>
                        <asp:ListItem>Alumno</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style38">Nombre</td>
                <td class="auto-style39">
                    <asp:TextBox ID="txtNombre" runat="server" Width="243px" CssClass="auto-style6"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style38">Apellido</td>
                <td class="auto-style39">
                    <asp:TextBox ID="txtApellido" runat="server" Width="243px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style40">Dirección</td>
                <td class="auto-style41">
                    <asp:TextBox ID="txtDireccion" runat="server" Width="244px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style40">Email</td>
                <td class="auto-style41">
                    <asp:TextBox ID="txtEmail" runat="server" Width="244px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style40">Teléfono</td>
                <td class="auto-style41">
                    <asp:TextBox ID="txtTelefono" runat="server" Width="243px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style40">Fecha de Nacimiento</td>
                <td class="auto-style41">
                    <asp:TextBox ID="txtDia" runat="server" Width="55px"></asp:TextBox> &nbsp;
                    <asp:TextBox ID="txtMes" runat="server" Width="50px" CssClass="auto-style6"></asp:TextBox> &nbsp;
                    <asp:TextBox ID="txtAnio" runat="server" Width="58px"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style40">Legajo</td>
                <td class="auto-style41">
                    <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style40">Carrera</td>
                <td class="auto-style41">
                    <asp:DropDownList ID="ddlCarrera" runat="server" Height="24px" Width="195px" AutoPostBack="True" OnSelectedIndexChanged="ddlCarrera_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlPlan" runat="server" CssClass="auto-style5" Width="91px" Height="24px">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <table class="auto-style21">
            <tr>
                <td class="auto-style24">Usuario</td>
                <td class="auto-style25">
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="auto-style6" Width="247px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style24">Contraseña</td>
                <td class="auto-style25">
                    <asp:TextBox ID="txtClave" runat="server" Width="235px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style24">Confirmar Contraseña</td>
                <td class="auto-style25">
                    <asp:TextBox ID="txtConfirmaClave" runat="server" Width="230px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style24">Habilitado</td>
                <td class="auto-style25">
                    <asp:CheckBox ID="chkHabilitado" runat="server" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
    <br />
    </div>
</asp:Content>
