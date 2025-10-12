<%@ Page Title="" Language="C#" MasterPageFile="~/promoMaster.Master" AutoEventWireup="true" CodeBehind="webError.aspx.cs" Inherits="TP_PROMO_WEB_21B.webError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h1 {
            text-align: center;
            color: red;
            font-size: 2rem;
        }

        .title {
            text-align: center;
            color: red;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        <h1>&#10060; </h1>
        <h1>ERROR AL CARGAR EL CODIGO!    </h1>
        <h2>EL CODIGO YA HA SIDO USADO   </h2>
        <hr />
        <h4>VUELVE A INTETARLO MAS TARDE </h4>
        <h3>Presione inicio para volver</h3>
        <asp:Button ID="btnInicio" OnClick="btnInicio_Click" runat="server" Text="Inicio" /></div>
</asp:Content>
