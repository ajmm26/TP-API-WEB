using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using service;

namespace TP_PROMO_WEB_21B
{
    public partial class WebCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            string documento = txtDocumento.Text.Trim();
            negocioCliente negocio = new negocioCliente();
            Cliente existente = negocio.buscarClientePorDocumento(documento);


            if (!CheckBoxAcepto.Checked)
            {
                lblAcepto.Text = "Debés aceptar los términos y condiciones para continuar.";
                lblAcepto.ForeColor = System.Drawing.Color.Red;
                return;
            }
            emailService emailService = new emailService();
            emailService.armarCorreo(txtEmail.Text);
            try
            {
                emailService.enviarMail();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
            if (existente == null)
            {
                Cliente nuevo = new Cliente();
                nuevo.Documento = txtDocumento.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.Email = txtEmail.Text;
                nuevo.Direccion = txtDireccion.Text;
                nuevo.Ciudad = txtCiudad.Text;
                nuevo.Cp = int.Parse(txtCp.Text);

                negocio.agregar(nuevo);
            }

            int IdCliente;
            if (existente != null)
            {
                IdCliente = existente.Id;
            }
            else
            {
                Cliente nuevo = negocio.buscarClientePorDocumento(documento);
                IdCliente = nuevo.Id;
                
            }
           string fecha = Session["date"].ToString();
            string codigoVoucher = Session["voucher"].ToString();
            int IdArticulo = Convert.ToInt32(Session["idProducto"]);
            Session["idCliente"] = IdCliente;

            negocioVoucher vouchers = new negocioVoucher();
            vouchers.updateVoucher(fecha, codigoVoucher, IdCliente, IdArticulo);
           


            Session.Clear();
            Response.Redirect("webRegistroExitoso.aspx");

        }

        protected void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            string documento = txtDocumento.Text.Trim();
            negocioCliente negocio = new negocioCliente();
            Cliente cliente = negocio.buscarClientePorDocumento(documento);
            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCp.Text = cliente.Cp.ToString();
                lblMensaje.Text = "Ya estas registrado.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;


            }
            else
            {
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEmail.Text = "";
                txtDireccion.Text = "";
                txtCiudad.Text = "";
                txtCp.Text = "";
                lblMensaje.Text = "Documento no registrado.  completa los datos.";
                lblMensaje.ForeColor = System.Drawing.Color.OrangeRed;


            }
        }
    }
}