using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;


namespace TP_PROMO_WEB_21B
{
    public partial class Catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            negocioArticulo negocio = new negocioArticulo();
            dgvArticulos.DataSource = negocio.listar();
            dgvArticulos.DataBind();
        }
        
    }
}