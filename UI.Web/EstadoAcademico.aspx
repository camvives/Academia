<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="UI.Web.EstadoAcademico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tabla">
    <h1>Estado Académico</h1>   
    </div>
    <br />
    <div class="tabla">
       <asp:GridView ID="gdvEstAcademico" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" Height="100%" Width="75%" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" SelectedIndex="0" ViewStateMode="Enabled" PageSize="8">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                 <Columns>
                    <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                    <asp:BoundField DataField="DescComision" HeaderText="Comisión" />
                    <asp:BoundField DataField="AnioCursado" HeaderText="Año de Cursado" />
                    <asp:BoundField DataField="Condicion" HeaderText="Condición" />
                    <asp:BoundField DataField="Nota" HeaderText="Nota" />
                    
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
