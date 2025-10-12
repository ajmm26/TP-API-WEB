<%@ Page Title="" Language="C#" MasterPageFile="~/promoMaster.Master" AutoEventWireup="true" CodeBehind="webSeleccionDePremio.aspx.cs" Inherits="TP_PROMO_WEB_21B.webSeleccionDePremio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/StyleSheet1.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Premio A elegir</h1>
    <asp:Panel runat="server" CssClass="d-flex flex-wrap justify-content-center">
        <asp:Label ID="lblHidden" runat="server"/> 
    </asp:Panel>
    <asp:Panel runat="server" CssClass="d-flex flex-wrap justify-content-center" ID="contenedor">
    </asp:Panel>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5/dist/js/bootstrap.bundle.min.js"></script>

</asp:Content>
