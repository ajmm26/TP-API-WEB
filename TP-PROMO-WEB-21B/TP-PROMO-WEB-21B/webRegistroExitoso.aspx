<%@ Page Title="" Language="C#" MasterPageFile="~/promoMaster.Master" AutoEventWireup="true" CodeBehind="webRegistroExitoso.aspx.cs" Inherits="TP_PROMO_WEB_21B.webRegistroExitoso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h1 {
            text-align: center;
            color: green;
            font-size: 2rem;
        }

        .title {
            text-align: center;
            color: cornflowerblue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        <h1>&#10004; </h1>
        <h1>MUCHAS GRACIAS!    </h1>
        <h2>TU REGISTRO HA SIDO EXITOSO   </h2>
        <hr />
        <h4>Ya participas del sorteo del producto que elegiste    </h4>
        <h6>Pronto estaremos comunicando los ganadores</h6>
        <asp:Button ID="btnInicio" OnClick="btnInicio_Click" CssClass="btn btn-primary"  runat="server" Text="Inicio" />


    </div>

</asp:Content>
