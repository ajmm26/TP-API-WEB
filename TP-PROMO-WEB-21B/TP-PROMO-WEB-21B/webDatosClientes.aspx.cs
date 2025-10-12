using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TP_PROMO_WEB_21B
{
    public partial class webDatosClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            negocioCliente negocio = new negocioCliente();
            dgvClientes.DataSource = negocio.listar();
            dgvClientes.DataBind();
        }
    }
}