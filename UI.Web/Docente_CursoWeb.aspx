<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Docente_CursoWeb.aspx.cs" Inherits="UI.Web.Docente_CursoWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div style="text-align:center">
        <h1>Asignar Curso</h1>
    </div>
    <br />
    <div>
        <table class ="tablaAlta">
             <tr>
                <td class="celda01">
                    Docente
                </td>  
                <td class="columna1">
                     <asp:DropDownList ID="ddlDocente" runat="server"  Width="260px" AutoPostBack="True"  Height="25px">
                    </asp:DropDownList>
                    <br />
                     <asp:RequiredFieldValidator ID="reqDocente" runat="server" ControlToValidate="ddlDocente"  ErrorMessage="Seleccione un docente" ForeColor="Red" Display="Dynamic" InitialValue="&quot;Seleccionar Carrera&quot;"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda01">
                    Cargo
                </td>
                <td class="columna1">
                    <asp:TextBox ID="txtCargo" runat="server" Width="260px"></asp:TextBox> 
                    <br />
                    <asp:RequiredFieldValidator ID="reqCargo" runat="server" ControlToValidate="txtCargo" ErrorMessage="Campo Requerido" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
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
