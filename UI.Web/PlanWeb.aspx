<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PlanWeb.aspx.cs" Inherits="UI.Web.PlanWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div style="text-align:center">
        <h1>Plan</h1>
    </div>
    <br />
    <div>
        <table class ="tablaAlta">
            <tr>
                <td class="celda01">
                    Descripción
                </td>
                <td class="celda02">
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="260px"></asp:TextBox> 
                    <br />
                    <asp:RequiredFieldValidator ID="reqDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Campo Requerido" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda01">
                    Carrera
                </td>  
                <td class="celda02">
                     <asp:DropDownList ID="ddlCarrera" runat="server"  Width="260px" AutoPostBack="True"  Height="25px" OnSelectedIndexChanged="ddlCarrera_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                     <asp:RequiredFieldValidator ID="reqCarrera1" runat="server" ControlToValidate="ddlCarrera"  ErrorMessage="Seleccione una Carrera" ForeColor="Red" Display="Dynamic" InitialValue="&quot;Seleccionar Carrera&quot;"></asp:RequiredFieldValidator>
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
