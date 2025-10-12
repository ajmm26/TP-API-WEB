<%@ Page Title="" Language="C#" MasterPageFile="~/promoMaster.Master" AutoEventWireup="true" CodeBehind="WebCliente.aspx.cs" Inherits="TP_PROMO_WEB_21B.WebCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Ingresa tus datos    </h2>
    <div class="row">
        <div class="col-6">

            <div class="mb-3">
                <label for="lblDocumento" class="form-label">Documento</label>
                <asp:TextBox ID="txtDocumento" class="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtDocumento_TextChanged" autocomplete="off" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="revDocumento" runat="server" 
                    ControlToValidate="txtDocumento" ValidationExpression="^\d{7,8}$" ErrorMessage="⚠️ El DNI debe tener entre 7 y 8 dígitos numéricos." CssClass="text-danger" Display="Dynamic" />
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" />
                <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ControlToValidate="txtDocumento" ErrorMessage="El documento es obligatorio." ForeColor="Red" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <label for="lblNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" autocomplete="off" />
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
                    ControlToValidate="txtNombre" ErrorMessage="⚠️ El nombre es obligatorio." ForeColor="Red" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revNombre" runat="server"
                    ControlToValidate="txtNombre" ValidationExpression="^[a-zA-ZÁÉÍÓÚÑáéíóúñ\s]+$" ErrorMessage="Solo se permiten letras en el nombre." ForeColor="Red" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <label for="lblApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" class="form-control" runat="server" autocomplete="off" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvApellido" runat="server" 
                    ControlToValidate="txtApellido" ErrorMessage=" El Apellido es obligatorio." CssClass="text-bg-danger" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revApellido" runat="server"
                    ControlToValidate="txtApellido" ValidationExpression="^[a-zA-ZÁÉÍÓÚÑáéíóúñ\s]+$" ErrorMessage="Solo se permite letras en el Apellido." ForeColor="Red" Display="Dynamic" />    
            </div>

            <div class="mb-3">
                <label for="lblEmail" class="form-label">E-mail</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" autocomplete="off" />
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                    ControlToValidate="txtEmail" ErrorMessage="El email es obligatorio" ForeColor="Red" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server"
                    ControlToValidate="txtEmail" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Formato de email inválido" ForeColor="Red" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <label for="lblDireccion" class="form-label">Direccion</label>
                <asp:TextBox ID="txtDireccion" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" 
                    ControlToValidate="txtDireccion" ErrorMessage="⚠️ La dirección es obligatoria." CssClass="text-danger" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revDireccion" runat="server" 
                    ControlToValidate="txtDireccion" ValidationExpression="^[A-Za-zÁÉÍÓÚÑáéíóúñ0-9\s]+[,]?\s?\d+[a-zA-Z]?$" ErrorMessage="Formato de Direccion Invalido" ForeColor="Red" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <label for="lblCiudad" class="form-label">Ciudad</label>
                <asp:TextBox ID="txtCiudad" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCiudad" runat="server" 
                    ControlToValidate="txtCiudad" ErrorMessage="⚠️ La ciudad es obligatoria." CssClass="text-danger" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revCiudad"  runat="server" 
                    ControlToValidate="txtCiudad" ValidationExpression="^[a-zA-ZÁÉÍÓÚÑáéíóúñ\s]+$" ErrorMessage="Solo se permite letras." ForeColor="Red" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <label for="lblCp" class="form-label">C.postal</label>
                <asp:TextBox ID="txtCp" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCp" runat="server" 
                    ControlToValidate="txtCp" ErrorMessage="El codigo postal es obligatorio." CssClass="text-danger" Display="Dynamic" /> 
                <asp:RegularExpressionValidator ID="revCp" runat="server" 
                    ControlToValidate="txtCp" ValidationExpression="^\d{4}$" ErrorMessage="⚠️ El código postal debe tener 4 dígitos." CssClass="text-danger" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <asp:CheckBox ID="CheckBoxAcepto" runat="server" Text="Acepto los terminos y condiciones" />
                <asp:Label ID="lblAcepto" runat="server" Font-Bold="true"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnParticipar" OnClick="btnParticipar_Click" class="btn btn-primary" runat="server" Text="Participar" />

            </div>

            



        </div>
    </div>
</asp:Content>
