<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuABM.ascx.cs" Inherits="UI.Web.WebUserControl2" %>
<div style ="margin-left:155px">
<asp:ImageButton ID="btnNuevo" runat="server" Height="26px" Width="80px" ImageUrl="~/Imagenes/nuevo.png" BorderStyle="Solid" BorderWidth="1px" OnClick="btnNuevo_Click" /> &nbsp&nbsp
<asp:ImageButton ID="btnEditar" runat="server" Height="26px" Width="80px" ImageUrl="~/Imagenes/editar.png" BorderStyle="Solid" BorderWidth="1px" />&nbsp&nbsp
<asp:ImageButton ID="btnEliminar" runat="server" Height="26px" Width="80px" ImageUrl="~/Imagenes/eliminar.png" BorderStyle="Solid" BorderWidth="1px" OnClick="btnEliminar_Click" onclientclick="return confirm('¿Está seguro? Se eliminará definitivamente');" /> 
</div>