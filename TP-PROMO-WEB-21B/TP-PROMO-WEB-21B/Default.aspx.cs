using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_PROMO_WEB_21B
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            btnCanjear.Text = "Canjear";

        }


        protected void btnCanjear_Click1(object sender, EventArgs e)
        {
            string value = input_voucher.Text.Trim();

            if (value == "" || value == null || value == " ")
            {     // Texto rojo
                txtlabelError.BorderColor = System.Drawing.Color.Red;
                txtlabelError.BackColor = System.Drawing.Color.LightPink; // Fondo
                mensaje("Ingrese un Voucher", System.Drawing.Color.Red);
            }
            else
            {



               
                txtlabelError.Visible = false;
                if (vouchersCodigo(value))
                {
                    Session["voucher"] = value.Trim();
                   DateTime fecha = DateTime.Now;
                   string fechaFormateada = fecha.ToString("yyyy-MM-dd");
                    Session.Add("date", fechaFormateada);
                    Response.Redirect("webSeleccionDePremio.aspx", true);
                }


            }

        }


        protected bool vouchersCodigo(string value)
        {
            negocioVoucher negocio = new negocioVoucher();
            List<Voucher> vouchers = negocio.listar();

            foreach (Voucher voucher in vouchers)
            {

                if (voucher.Codigo.ToUpper().Trim() == value.ToUpper())
                {
                    if ((int)voucher.IdArticulo > 0 || (int)voucher.IdCliente>0)
                    {
                        txtlabelError.BorderColor = System.Drawing.Color.Red;
                        txtlabelError.BackColor = System.Drawing.Color.LightPink; // Fondo
                        mensaje("Voucher usado", System.Drawing.Color.Red);
                        return false;
                    }
                    else
                    {
                        txtlabelError.BorderColor = System.Drawing.Color.Green;
                        txtlabelError.BackColor = System.Drawing.Color.LightGreen; 
                        mensaje("Voucher  valido", System.Drawing.Color.Black);
                        return true;
                    }
                }
                else
                {
                }

            }
                        txtlabelError.BorderColor = System.Drawing.Color.Red;
                        txtlabelError.BackColor = System.Drawing.Color.LightPink; 
                        mensaje("Voucher invalido", System.Drawing.Color.Red);
            return false;
                    
        }



        protected void mensaje(string m, System.Drawing.Color color)
        {
            txtlabelError.BorderStyle = BorderStyle.Solid;
            txtlabelError.BorderWidth = 2;
            txtlabelError.Width = 350;
            txtlabelError.ForeColor = color;   
            txtlabelError.Text = m;
            txtlabelError.Visible = true;

        }


    }
}