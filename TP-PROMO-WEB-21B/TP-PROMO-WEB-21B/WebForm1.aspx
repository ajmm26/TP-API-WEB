<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TP_PROMO_WEB_21B.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/StyleSheet1.css" rel="stylesheet" />
    
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg bg-body-tertiary">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">Navbar</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="#">Home</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Canjear Voucher</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Ver productos</a>
        </li>
        <li class="nav-item">
          <a class="nav-link disabled" aria-disabled="true">Disabled</a>
        </li>
      </ul>
    </div>
  </div>
</nav>
      <main>
        <div class="container mt-5">
    <h2 class="text-center mb-4">Ingresa el voucher</h2>

    <div class="d-flex justify-content-center gap-2">
        <asp:TextBox 
            ID="input_voucher" 
            runat="server" 
            CssClass="form-control w-50" 
            placeholder="x x x x x x x x" />

        <asp:Button 
            ID="btnCanjear" 
            runat="server" 
            Text="Canjear" 
            CssClass="btn btn-primary" 
            OnClick="btnCanjear_Click1" />
    </div>

    <div class="text-center mt-2">
        <asp:Label 
            ID="txtlabelError" 
            runat="server" 
            CssClass="text-danger fw-bold" />
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
    </form>
    <script src="Scripts/JavaScript.js"></script>
</body>
</html>
