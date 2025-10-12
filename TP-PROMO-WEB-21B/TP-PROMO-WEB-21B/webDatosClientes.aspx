<%@ Page Title="" Language="C#" MasterPageFile="~/promoMaster.Master" AutoEventWireup="true" CodeBehind="webDatosClientes.aspx.cs" Inherits="TP_PROMO_WEB_21B.webDatosClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvClientes" class="table table-bordered table-dark" runat="server" AutoGenerateColumns="false">
       <Columns>
           <asp:BoundField HeaderText="Id" DataField="Id" />
           <asp:BoundField HeaderText="Documento" DataField="Documento" />
           <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
           <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
           <asp:BoundField HeaderText="E-mail" DataField="Email" />
           <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
           <asp:BoundField HeaderText="Ciudad" DataField="Ciudad" />
           <asp:BoundField HeaderText="Cp" DataField="Cp" />
       </Columns>
    </asp:GridView>
</asp:Content>
