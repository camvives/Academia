<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CursoWeb.aspx.cs" Inherits="UI.Web.CursoWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="text-align:center">
        <h1>Curso</h1>
    </div>
    <br />
    <div>
        <table class ="tablaAlta">
            <tr>
                <td class="celda01">
                    Carrera
                </td>  
                <td class="celda02">
                     <asp:DropDownList ID="ddlCarrera" runat="server"  Width="195px" AutoPostBack="True"  Height="25px" OnSelectedIndexChanged="ddlCarrera_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlPlan" runat="server"  Width="54px" Height="25px" OnSelectedIndexChanged="ddlPlan_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="reqCarrera1" runat="server" ControlToValidate="ddlPlan" InitialValue="Plan" ErrorMessage="Seleccione una Carrera" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda01">
                    Materia
                </td>
                <td class="celda02">
                    <asp:DropDownList ID="ddlMateria" runat="server"  Width="245px" AutoPostBack="True"  Height="25px" OnSelectedIndexChanged="ddlMateria_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="reqMateria" runat="server" ControlToValidate="ddlMateria"  ErrorMessage="Seleccione una Materia" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda01">
                    Comisión
                </td>
                <td class="celda02">
                    <asp:DropDownList ID="ddlComision" runat="server"  Width="245px" AutoPostBack="True"  Height="25px" OnSelectedIndexChanged="ddlComision_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="reqComision" runat="server" ControlToValidate="ddlComision"  ErrorMessage="Seleccione una Comisión" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda01">
                    Año Calendario
                </td>
                <td class="celda02">
                    <asp:TextBox ID="txtAnio" runat="server" Width="100px"></asp:TextBox> 
                    <br />
                    <asp:RequiredFieldValidator ID="reqAnio" runat="server" ControlToValidate="txtAnio" ErrorMessage="Campo Requerido" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="celda01">
                    Cupo
                </td>
                <td class="celda02">
                    <asp:TextBox ID="TxtCupo" runat="server" Width="100px"></asp:TextBox> 
                    <br />
                    <asp:RequiredFieldValidator ID="reqCupo" runat="server" ControlToValidate="txtCupo" ErrorMessage="Campo Requerido" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
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
