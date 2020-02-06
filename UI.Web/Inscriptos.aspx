<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Inscriptos.aspx.cs" Inherits="UI.Web.Inscriptos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tabla">
    <h1>Mis Cursos</h1>   
    </div>
    <br />
    <div style ="margin-left:170px">
        <asp:DropDownList runat="server" Width="50%" ID="ddlCurso" AutoPostBack="True" OnSelectedIndexChanged="ddlCurso_SelectedIndexChanged" ></asp:DropDownList>
    </div>
    <br />
    <div class="tabla">   
       <asp:GridView ID="gdvInscriptos" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" Height="100%" Width="75%" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" SelectedIndex="0" ViewStateMode="Enabled" PageSize="8" OnSelectedIndexChanged="gdvInscriptos_SelectedIndexChanged" AutoGenerateEditButton="True" OnRowEditing="gdvInscriptos_RowEditing" OnRowDataBound="gdvInscriptos_RowDataBound" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                 <Columns>
                     <asp:BoundField DataField="Legajo" HeaderText="Legajo" ReadOnly="True" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" ReadOnly="True" />
                     <asp:TemplateField HeaderText="Condición" Visible="False">
                         <EditItemTemplate>
                             <asp:DropDownList ID="ddlCondicion" runat="server" AutoPostBack="True">
                                 <asp:ListItem>Inscripto</asp:ListItem>
                                 <asp:ListItem>Regular</asp:ListItem>
                                 <asp:ListItem>Aprobado</asp:ListItem>
                             </asp:DropDownList>
                         </EditItemTemplate>
                         <ItemTemplate>
                              <asp:DropDownList ID="DropDownList1" runat="server" Enabled="False">
                                 <asp:ListItem>Inscripto</asp:ListItem>
                              </asp:DropDownList>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="Condicion" HeaderText="Condición" />
                    <asp:BoundField DataField="NotaMostrar" HeaderText="Nota" />                   
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
