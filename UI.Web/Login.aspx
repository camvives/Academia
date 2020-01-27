<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="login-page">
       
        <div>
            <h1>¡Bienvenido al Sistema!</h1>
            <p>Por favor digite su información de ingreso</p>
        </div>
        <br />

        <div class="login">
            <br />
            <table style="width: 100%;">
                <tr>
                    <td style ="text-align:right;">Nombre de Usuario: </td>
                    <td>
                        <asp:TextBox ID="txtUser" runat="server" Width="244px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Contraseña: </td>
                    <td>
                        <asp:TextBox ID="txtPass" runat="server" Width="244px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" />
        </div>
  
    </div>
</asp:Content>
