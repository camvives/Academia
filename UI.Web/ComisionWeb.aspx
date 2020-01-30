<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ComisionWeb.aspx.cs" Inherits="UI.Web.ComisionWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center">
        <h1>Nueva Comisión</h1>
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
                    Año Especialidad
                </td>
                <td class="celda02">
                    <asp:DropDownList ID="ddlAnio" runat="server"  Width="60px" Height="25px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>
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
