<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfirmaEliminar.ascx.cs" Inherits="UI.Web.WebUserControl1" %>

<asp:Label ID="lblMensaje" runat="server" Text="¿Está seguro que desea eliminarlo?" Font-Size="Large" ForeColor="Red"></asp:Label>
<br />
<asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" Width="110px" />
<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />










