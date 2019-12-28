<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UsuarioWeb.aspx.cs" Inherits="UI.Web.UsuarioWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Volver</asp:LinkButton>       
    <div class="formulario">
        <h1>Nuevo Usuario</h1>      
        <table class="tabla">
            <tr>
                <td class="celda1">Tipo </td>
                <td class="celda2">
                    <asp:DropDownList ID="ddlTipo" runat="server"  Width="231px" CssClass="elementoCelda" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" Height="25px" AutoPostBack="True">
                        <asp:ListItem>Alumno</asp:ListItem>
                        <asp:ListItem>Docente</asp:ListItem>
                        <asp:ListItem>Administrador</asp:ListItem>                                    
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="celda1">Nombre</td>
                <td class="celda2">
                    <asp:TextBox ID="txtNombre" runat="server" Width="231px" CssClass="elementoCelda" ></asp:TextBox>                   
                    <asp:RequiredFieldValidator ID="reqNom" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtNombre" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda1">Apellido</td>
                <td class="celda2">
                    <asp:TextBox ID="txtApellido" runat="server" Width="231px" CssClass="elementoCelda"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqAp" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtApellido" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda1">Dirección</td>
                <td class="celda2">
                    <asp:TextBox ID="txtDireccion" runat="server" Width="231px" ForeColor="Black" CssClass="elementoCelda" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqDir" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtDireccion" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda1">Email</td>
                <td class="celda2">
                    <asp:TextBox ID="txtEmail" runat="server" Width="231px" CssClass="elementoCelda"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="valEmail" runat="server" ErrorMessage="Mail Inválido" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="reqEmail" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda1">Teléfono</td>
                <td class="celda2">
                    <asp:TextBox ID="txtTelefono" runat="server" Width="231px" CssClass="elementoCelda" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqTel" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtTelefono" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda1">Fecha de Nacimiento</td>
                <td class="celda2">
                    &nbsp;
                    <asp:DropDownList ID="ddlDia" runat="server" Width="56px" AutoPostBack="True"  Height="23px" OnSelectedIndexChanged="ddlDia_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Label ID="Label1" runat="server" Text="/" Font-Size="Medium" Font-Bold="True"></asp:Label>
                    &nbsp;
                    <asp:DropDownList ID="ddlMes" runat="server" Width="56px" Height="23px" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:Label ID="Label2" runat="server" Text="/" Font-Size="Medium" Font-Bold="True"></asp:Label>
                    &nbsp;     
                    <asp:DropDownList ID="ddlAnio" runat="server" Width="76px" Height="23px" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>                 
                    <asp:CompareValidator ID="valFechas" runat="server" ErrorMessage="Fecha no válida" Type="Date" ControlToValidate="txtFecha" ForeColor="Red" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                    <asp:TextBox ID="txtFecha" runat="server" CssClass="fecha" Width="42px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="celda1">Legajo</td>
                <td class="celda2">
                    <asp:TextBox ID="txtLegajo" runat="server" CssClass="elementoCelda"></asp:TextBox>
                    <asp:CustomValidator ID="reqLegajo" runat="server" ForeColor="Red" OnServerValidate="reqLegajo_ServerValidate"></asp:CustomValidator>
                    <asp:RequiredFieldValidator ID="reqLegajo1" runat="server" ControlToValidate="txtLegajo" ErrorMessage="Campo Requerido" ForeColor="Red" Enabled="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda1">Carrera</td>
                <td class="celda2">
                    <asp:DropDownList ID="ddlCarrera" runat="server"  Width="195px" CssClass="elementoCelda" AutoPostBack="True" OnSelectedIndexChanged="ddlCarrera_SelectedIndexChanged" Height="25px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlPlan" runat="server"  Width="54px" Height="25px">
                    </asp:DropDownList>
                    <asp:CustomValidator ID="reqCarrera" runat="server" OnServerValidate="reqCarrera_ServerValidate"></asp:CustomValidator>
                    <asp:RequiredFieldValidator ID="reqCarrera1" runat="server" ControlToValidate="ddlPlan" InitialValue="Plan" ErrorMessage="Seleccione una Carrera" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda1">&nbsp;</td>
                <td class="celda2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="celda1">Usuario</td>
                <td class="celda2">
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="elementoCelda" Width="231px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqUser" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtUsuario" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda1">Contraseña</td>
                <td class="celda2">
                    <asp:TextBox ID="txtClave" runat="server" Width="231px" CssClass="elementoCelda" TextMode ="Password"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="valClave" runat="server" ControlToValidate="txtClave" Display="Dynamic" ErrorMessage="La contraseña debe tener al menos 8 caracteres" ForeColor="Red" ValidationExpression="^\w{8,}$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="reqClave" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtClave" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda1">Confirmar Cotraseña</td>
                <td class="celda2">
                    <asp:TextBox ID="txtConfirmaClave" runat="server" Width="231px" CssClass="elementoCelda" TextMode ="Password"></asp:TextBox>
                    <asp:CompareValidator ID="valClaves" runat="server" ControlToCompare="txtClave" ControlToValidate="txtConfirmaClave" Display="Dynamic" ErrorMessage="Las contraseñas no coinciden" ForeColor="Red"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="reqCClave" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtConfirmaClave" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda1">Habilitado</td>
                <td class="celda2">
                    <asp:CheckBox ID="chkHabilitado" runat="server" CssClass="elementoCelda" Checked="True" Font-Size="X-Large" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblError" runat="server" Text="Error" Visible="False" ForeColor="Red"></asp:Label> <br />

        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Guardar" Height="35px" Width="122px" CssClass="botonAceptar" />
    </div>
        
    </asp:Content>
