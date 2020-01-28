<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="UI.Web.Main1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style ="text-align:center">
    <h2>Bienvenido(a)</h2>

            <div class="menu">
            <asp:Menu runat="server"  Orientation="Vertical" Width="100%">
                <Items>
                    <asp:MenuItem Text="Usuarios" Value="Usuario"></asp:MenuItem>
                    <asp:MenuItem Text="Cursos" Value="Cursos"></asp:MenuItem>
                    <asp:MenuItem Text="Especialidades" Value="Especialidades"></asp:MenuItem>
                    <asp:MenuItem Text="Planes" Value="Planes"></asp:MenuItem>
                    <asp:MenuItem Text="Materias" Value="Materias"></asp:MenuItem>
                    <asp:MenuItem Text="Comisiones" Value="Comisiones"></asp:MenuItem>
                </Items>
                <StaticSelectedStyle BackColor="#507CD1" />
                <StaticMenuItemStyle HorizontalPadding="72px" VerticalPadding="7px" ForeColor="Black" BorderStyle="Solid" BorderWidth="1px" BorderColor="Black" />
                <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
                <DynamicMenuStyle BackColor="#B5C7DE" />
                <DynamicSelectedStyle BackColor="#507CD1" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
            </asp:Menu>
            </div> 
    <br />
    <div>
        <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_Click" />
    </div>
   </div>
  
</asp:Content>
