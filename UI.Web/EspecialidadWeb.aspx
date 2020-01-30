<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EspecialidadWeb.aspx.cs" Inherits="UI.Web.EspecialidadWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="text-align:center">
        <h1>Especialidad</h1>
    </div>
    <br />
    <div>
        <table class ="tablaAlta">
            <tr>
                <td class="celda01">
                    Descripción
                </td>
                <td class="celda02">
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="300px"></asp:TextBox> 
                    <br />
                    <asp:RequiredFieldValidator ID="reqDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Campo Requerido" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>           
            </table>
    </div>
    <br />
    <div style="text-align:center">
        <asp:Button runat="server" Text="Salir" ID="btnSalir" OnClick="btnSalir_Click" CausesValidation="False" />
        &nbsp&nbsp
        <asp:Button runat="server" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click" />
        
    </div>

</asp:Content>
