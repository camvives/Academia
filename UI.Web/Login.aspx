<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Academia</title>
    <link rel="stylesheet" type="text/css" href="Estilos.css"/>
</head>
<body>
    <form id="form1" runat="server">
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
                        <asp:TextBox ID="txtUser" runat="server" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqUsr" runat="server" ErrorMessage="*" ControlToValidate="txtUser" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Contraseña: </td>
                    <td>
                        <asp:TextBox ID="txtPass" runat="server" Width="200px" Type="Password"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="reqPass" runat="server" ErrorMessage="*" ControlToValidate="txtPass" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                </tr>
            </table>
            <br />
            <asp:CustomValidator ID="valUser" runat="server" ErrorMessage="Usuario y/o contraseña incorrectos" ForeColor="Red"  OnServerValidate="valUser_ServerValidate" Display="Dynamic"></asp:CustomValidator>
            <asp:CustomValidator ID="valHabilitado" runat="server" ErrorMessage="Usuario no habilitado" ForeColor="Red"  OnServerValidate="valHabilitado_ServerValidate" Display="Dynamic"></asp:CustomValidator>

            <br />
            
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
        </div>
  
    </div>
    </form>
</body>
</html>
