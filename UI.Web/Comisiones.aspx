<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" EnableEventValidation="false" %>
<%@ Register src="MenuABM.ascx" tagname="MenuABM" tagprefix="uc2" %>
<%@ Register Src="~/MenuABM.ascx" TagPrefix="uc1" TagName="MenuABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tabla">
    <h1>Comisiones</h1>   
    </div>
    <br />
    <uc1:MenuABM runat="server" ID="MenuABM" />
    <div class="tabla">
       <asp:GridView ID="gdvComisiones" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" Height="100%" Width="75%" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" SelectedIndex="0" ViewStateMode="Enabled" PageSize="8" OnRowDeleting="gdvComisiones_RowDeleting" OnRowDataBound="gdvComisiones_RowDataBound" OnSelectedIndexChanged="gdvComisiones_SelectedIndexChanged" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                 <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Comisión" />
                    <asp:BoundField DataField="Anio" HeaderText="Año" />
                    <asp:BoundField DataField="DescPlan" HeaderText="Plan" />
                    <asp:BoundField DataField="DescEspecialidad" HeaderText="Especialidad" />
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
