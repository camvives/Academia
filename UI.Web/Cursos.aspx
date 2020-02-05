<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" EnableEventValidation="false" %>

<%@ Register Src="~/MenuABM.ascx" TagPrefix="uc1" TagName="MenuABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="tabla">
    <h1>Cursos</h1>   
    </div>
        <br />
    <div>
   
    <table>
        <tr>
            <td>
                <uc1:MenuABM runat="server" ID="MenuABM" />
            </td>
            <td style="padding-left: 10px; padding-bottom:2px" >
                <asp:ImageButton ID="btnDocentes" runat="server" Height="26px" Width="130px" ImageUrl="~/Imagenes/Docentes.png" BorderStyle="Solid" BorderWidth="1px" OnClick="btnDocentes_Click" />
            </td>
        </tr>
    </table>
    </div>
    <div class="tabla">
       <asp:GridView ID="gdvCursos" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" Height="100%" Width="75%" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" SelectedIndex="0" ViewStateMode="Enabled" PageSize="8" OnRowDataBound="gdvComisiones_RowDataBound" OnPageIndexChanging="gdvComisiones_PageIndexChanging" OnSelectedIndexChanged="gdvCursos_SelectedIndexChanged" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                 <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                    <asp:BoundField DataField="DescComision" HeaderText="Comisión" />
                    <asp:BoundField DataField="AnioCalendario" HeaderText="Año Calendario" />
                    <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
                     <asp:BoundField DataField="DescEspecialidad" HeaderText="Carrera" />
                     <asp:BoundField DataField="DescPlan" HeaderText="Plan" />
                     <asp:TemplateField ShowHeader="False" Visible="False">
                         <ItemTemplate>
                             <asp:LinkButton ID="lnkbtnInscribir" runat="server" CausesValidation="False" CommandName="Select" Text="Inscribirse" onclientclick="return confirm('¿Está seguro que desea inscribirse al curso?');"></asp:LinkButton>
                         </ItemTemplate>
                     </asp:TemplateField>
                </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div>
    <br />
    <div style="text-align:center;">
        <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_Click" />
    </div>

</asp:Content>
