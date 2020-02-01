<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UsuarioDatos.aspx.cs" Inherits="UI.Web.UsuariosDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="text-align:center">
    <h1>Datos del Usuario</h1>
</div>
<br />
<div>
     <table class="tablaDatos" border="1">
       <tr>
         <td class="celda">ID</td>
         <td class="celda">
           <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label>
         </td>
       </tr>
       <tr>
         <td class="celda">Nombre de Usuario</td>
         <td class="celda">
             <asp:Label ID="lblNombreUsuario" runat="server" Text="NombreUsuario"></asp:Label>
         </td>
       </tr>
       <tr>
           <td class="celda">Habilitado</td>
           <td class="celda">
               <asp:Label ID="lblHabilitado" runat="server" Text="Sí"></asp:Label>
           </td>
       </tr>
         <tr>
             <td class="celda">&nbsp;</td>
             <td class="celda">&nbsp;</td>
         </tr>
         <tr>
             <td class="celda">Nombre</td>
             <td class="celda">
                 <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="celda">Apellido</td>
             <td class="celda">
                 <asp:Label ID="lblApellido" runat="server" Text="Label"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="celda">Direccion</td>
             <td class="celda">
                 <asp:Label ID="lblDireccion" runat="server" Text="Label"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="celda">Email</td>
             <td class="celda">
                 <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="celda">Teléfono</td>
             <td class="celda">
                 <asp:Label ID="lblTelefono" runat="server" Text="Label"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="celda">Fecha de Nacimiento</td>
             <td class="celda">
                 <asp:Label ID="lblFechaNac" runat="server" Text="Label"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="celda">Tipo</td>
             <td class="celda">
                 <asp:Label ID="lblTipo" runat="server" Text="Label"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="celda">Legajo</td>
             <td class="celda">
                 <asp:Label ID="lblLegajo" runat="server" Text="Label"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="celda">Carrera</td>
             <td class="celda">
                 <asp:Label ID="lblCarrera" runat="server" Text="Label"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="celda">Plan</td>
             <td class="celda">
                 <asp:Label ID="lblPlan" runat="server" Text="Label"></asp:Label>
             </td>
         </tr>

     </table>
    </div>
    <br />
    <div style="text-align:center;">
        <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_Click" />
    </div>
</asp:Content>
