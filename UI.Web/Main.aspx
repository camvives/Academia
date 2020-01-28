<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="UI.Web.Main1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 315px;
            text-align: center;
            background-color: rgba(59, 62, 95, 0.30);
            height: auto;
            vertical-align: central;
            margin-top: 50px;
            margin-left: auto;
            margin-right: auto;
            margin-bottom: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style ="text-align:center">
    <h2>¡Bienvenido(a)  <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
        </h2>

            <div class="auto-style1">
            <asp:Menu runat="server"  Orientation="Vertical" ID="mnuPrincipal"  RenderingMode="Table" Width="315px">
                <Items>
                    <asp:MenuItem Text="Usuarios" Value="Usuario"></asp:MenuItem>
                    <asp:MenuItem Text="Cursos" Value="Cursos"></asp:MenuItem>
                    <asp:MenuItem Text="Especialidades" Value="Especialidades"></asp:MenuItem>
                    <asp:MenuItem Text="Planes" Value="Planes"></asp:MenuItem>
                    <asp:MenuItem Text="Materias" Value="Materias"></asp:MenuItem>
                    <asp:MenuItem Text="Comisiones" Value="Comisiones"></asp:MenuItem>
                    <asp:MenuItem Text="Mis Datos" Value="Datos"></asp:MenuItem>
                    <asp:MenuItem Text="Certificado de Inscripción" Value="Certificado"></asp:MenuItem>
                    <asp:MenuItem Text="Inscribirse a Materias" Value="Inscripcion"></asp:MenuItem>
                    <asp:MenuItem Text="Estado Académico" Value="Estado"></asp:MenuItem>
                    <asp:MenuItem Text="Consultar Cursos" Value="ConsultaCur"></asp:MenuItem>
                </Items>
                <StaticSelectedStyle BackColor="#507CD1" />
                <StaticMenuItemStyle HorizontalPadding="72px" VerticalPadding="7px" ForeColor="Black" BorderStyle="Solid" BorderWidth="1px" BorderColor="Black"/>
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
