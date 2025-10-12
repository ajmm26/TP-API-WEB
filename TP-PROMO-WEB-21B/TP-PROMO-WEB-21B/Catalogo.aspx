<%@ Page Title="" Language="C#" MasterPageFile="~/promoMaster.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TP_PROMO_WEB_21B.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col">
            <asp:GridView ID="dgvArticulos" CssClass="table table-dark table-bordered" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                </Columns>
            </asp:GridView>
            <a href="webArticulo.aspx">Agregar</a>
        </div>
    </div>


</asp:Content>
