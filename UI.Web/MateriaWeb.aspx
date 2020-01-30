<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MateriaWeb.aspx.cs" Inherits="UI.Web.MateriaWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="text-align:center">
        <h1>Materia</h1>
    </div>
    <br />
    <div>
        <table class ="tablaAlta">
            <tr>
                <td class="celda01">
                    Descripcion
                </td>
                <td class="celda02">
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="231px"></asp:TextBox> 
                    <br />
                    <asp:RequiredFieldValidator ID="reqDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Campo Requerido" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda01">
                    Carrera
                </td>  
                <td class="celda02">
                     <asp:DropDownList ID="ddlCarrera" runat="server"  Width="195px" AutoPostBack="True"  Height="25px" OnSelectedIndexChanged="ddlCarrera_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlPlan" runat="server"  Width="54px" Height="25px">
                    </asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="reqCarrera1" runat="server" ControlToValidate="ddlPlan" InitialValue="Plan" ErrorMessage="Seleccione una Carrera" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda01">
                    Horas Semanales
                </td>
                <td class="celda02">
                   <asp:TextBox ID="txtHsSem" runat="server" Width="100px"></asp:TextBox> 
                    <br />
                   <asp:RequiredFieldValidator ID="reqHsSem" runat="server" ControlToValidate="txtHsSem" ErrorMessage="Campo Requerido" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
               <td class="celda01">
                    Horas Totales
                </td>
                <td class="celda02">
                   <asp:TextBox ID="txtHsTot" runat="server" Width="100px"></asp:TextBox> 
                    <br />
                   <asp:RequiredFieldValidator ID="reqHsTot" runat="server" ControlToValidate="txtHsTot" ErrorMessage="Campo Requerido" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
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
