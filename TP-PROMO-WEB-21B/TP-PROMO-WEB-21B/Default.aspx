<%@ Page Title="" Language="C#" MasterPageFile="~/promoMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_PROMO_WEB_21B.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="navbar navbar-expand-lg bg-body-tertiary">
  <!-- ... navbar completo ... -->
</nav>

<main>
  <div class="container mt-5">
    <h2 class="text-center mb-4">Ingresa el voucher</h2>

    <div class="d-flex justify-content-center gap-2">
        <asp:TextBox ID="input_voucher" runat="server" CssClass="form-control w-50" placeholder="x x x x x x x x" />
        <asp:Button ID="btnCanjear" runat="server" Text="Canjear" CssClass="btn btn-primary" OnClick="btnCanjear_Click1" />
    </div>

    <div class="text-center mt-2">
        <asp:Label ID="txtlabelError" runat="server" CssClass="text-danger fw-bold" />
    </div>
  </div>

  <div class="row">
    <div class="col">
        <asp:GridView ID="dgVoucher" CssClass="table table-dark table-bordered" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                <asp:BoundField HeaderText="IdCliente" DataField="idCliente" />
                <asp:BoundField HeaderText="IdArticulo" DataField="idArticulo" />
            </Columns>
        </asp:GridView>
    </div>
  </div>
</main>

<script src="Scripts/JavaScript.js"></script>


</asp:Content>
