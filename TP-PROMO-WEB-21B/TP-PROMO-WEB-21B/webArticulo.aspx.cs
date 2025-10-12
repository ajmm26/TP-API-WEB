using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TP_PROMO_WEB_21B
{
    public partial class webArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
           
            Articulo nuevo = new Articulo();
            nuevo.Codigo = txtCodigo.Text;
            nuevo.Nombre = txtNombre.Text;
            nuevo.Descripcion = txtDescripcion.Text;
            nuevo.Precio = decimal.Parse(txtPrecio.Text);

            negocioArticulo negocio = new negocioArticulo();
            negocio.agregar(nuevo);

            

            Response.Redirect("Catalogo.aspx");
           
        }
    }
}