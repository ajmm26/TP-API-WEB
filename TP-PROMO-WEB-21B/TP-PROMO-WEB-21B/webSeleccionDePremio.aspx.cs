using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TP_PROMO_WEB_21B
{
    public partial class webSeleccionDePremio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            crearProductosFront();

        }



        protected void crearProductosFront()
        {
            contenedor.Style.Add("padding", "70px");
            negocioImagenes Nimg = new negocioImagenes();
            List<Imagen> imagenes = Nimg.listar();

            negocioArticulo Nart = new negocioArticulo();
            List<Articulo> Articulos = Nart.listar();
            int numero = Articulos.Count + 1;
            for (int i = 1; i < numero; i++)
            {

                ///////
                Panel panelInicial = getPanelInicial();
                ////////
                Panel panelContenedorCarrusel = getPanelContenedorCarruselImagen(i);
                /////
                Panel panelCarrusel = new Panel();
                panelCarrusel.CssClass = "carousel-inner";
                getContentPanelCarrusel(panelCarrusel, i, imagenes);

                /////
                HtmlGenericControl bnext = getButtonNext(i);

                HtmlGenericControl bantes = getButtonPrev(i);

                // Íconos (igual que Bootstrap)
                HtmlGenericControl iconPrev = getIconPrev();


                HtmlGenericControl iconNext = getIconNext();

                bantes.Controls.Add(iconPrev);
                bnext.Controls.Add(iconNext);
                ////parte de texto
                Panel panelTxt = new Panel();
                panelTxt.CssClass = "d-flex flex-column";
                Label nombreProducto = new Label();
                Label descripcionProducto = new Label();
                nombreProducto.Text = Articulos[i - 1].Codigo;
                descripcionProducto.Text = Articulos[i - 1].Descripcion;
                nombreProducto.CssClass = "text-center fw-bold"; // centrado + negrita opcional
                descripcionProducto.CssClass = "text-center";
                panelTxt.Controls.Add(nombreProducto);
                panelTxt.Attributes.Add("padding", "10px");
                ////

                panelTxt.Controls.Add(descripcionProducto);
                panelTxt.Controls.Add(getButtonChoice(i));
                panelContenedorCarrusel.Controls.Add(bnext);
                panelContenedorCarrusel.Controls.Add(bantes);
                panelContenedorCarrusel.Controls.Add(panelCarrusel);
                panelInicial.Controls.Add(panelContenedorCarrusel);
                panelInicial.Controls.Add(panelTxt);
                contenedor.Controls.Add(panelInicial);
            }
        }

        protected Panel getPanelInicial()
        {
            Panel p = new Panel();
            p.CssClass = "card";
            p.Width = Unit.Pixel(300); // para web Forms se usa Unit
            p.Height = Unit.Pixel(570);
            p.Style.Add("flex", "0 0 auto"); // esto hace que respete ancho y alto
            p.BackColor = System.Drawing.Color.AliceBlue;
            p.BorderStyle = BorderStyle.Solid;
            p.BorderWidth = Unit.Pixel(2);
            p.Style.Add("margin-top", "80px");
            p.Style.Add("margin-bottom", "80px");
            p.Style.Add("margin-left", "25px");
            p.Style.Add("margin-right", "25px");
            return p;
        }

        protected Panel getPanelContenedorCarruselImagen(int i)
        {
            Panel p2 = new Panel();
            p2.CssClass = " carousel slide d-flex justify-content-center align-items-center";
            p2.Attributes["id"] = "carouselExample" + i.ToString(); // id único
            p2.Width = Unit.Pixel(295);
            p2.Height = Unit.Pixel(350);
            return p2;
        }

        protected void getContentPanelCarrusel(Panel panelCarrusel, int i, List<Imagen> imagenes)
        {
            int index = 0;
            foreach (Imagen imagen in imagenes)
            {
                Panel p4 = new Panel();
                p4.Width = Unit.Pixel(295);
                p4.Height = Unit.Pixel(350);
                p4.Attributes.Add("overflow", "hidden");
                Image img = new Image();
                if (index == 0)
                {
                    p4.CssClass = "carousel-item active";
                    index = 1;
                }
                else
                {
                    p4.CssClass = "carousel-item";
                }
                if (imagen.IdArticulo == i)
                {
                    img.ImageUrl = imagen.UrlImagen;

                }
                img.CssClass = "d-block w-100";
                img.Attributes.Add("object-fit", "contain");
                img.Attributes.Add("width", "100%");
                img.Attributes.Add("height", "100%");
                p4.Controls.Add(img);
                panelCarrusel.Controls.Add(p4);

            }
        }

        protected HtmlGenericControl getButtonNext(int i)
        {
            HtmlGenericControl bnext = new HtmlGenericControl("button");
            bnext.Attributes["class"] = "carousel-control-next";
            bnext.Attributes["type"] = "button";
            bnext.Attributes["data-bs-target"] = "#carouselExample" + i.ToString(); // el id de tu carrusel
            bnext.Attributes["data-bs-slide"] = "next";
            return bnext;
        }

        protected HtmlGenericControl getButtonPrev(int i)
        {
            HtmlGenericControl bantes = new HtmlGenericControl("button");
            bantes.Attributes["class"] = "carousel-control-prev";
            bantes.Attributes["type"] = "button";
            bantes.Attributes["data-bs-target"] = "#carouselExample" + i.ToString(); // el mismo id
            bantes.Attributes["data-bs-slide"] = "prev";
            return bantes;
        }

        protected HtmlGenericControl getIconNext()
        {
            HtmlGenericControl iconNext = new HtmlGenericControl("span");
            iconNext.Attributes["class"] = "carousel-control-next-icon";
            iconNext.Attributes["aria-hidden"] = "true";
            return iconNext;
        }

        protected HtmlGenericControl getIconPrev()
        {
            HtmlGenericControl iconPrev = new HtmlGenericControl("span");
            iconPrev.Attributes["class"] = "carousel-control-prev-icon";
            iconPrev.Attributes["aria-hidden"] = "true";
            return iconPrev;
        }
        protected HtmlButton getButtonChoice(int i)
        {
            HtmlButton buttonChoice = new HtmlButton();
            buttonChoice.ID = "btnElegir" + i.ToString();
            buttonChoice.Attributes["class"] = "btn btn-primary mx-auto d-block";
            buttonChoice.Style["width"] = "90px";
            buttonChoice.Style["margin"] = "10px";
            buttonChoice.InnerText = "Elegir";
            buttonChoice.Attributes["value"] = i.ToString(); // set value
            buttonChoice.ServerClick += recuperarIDProducto;
            return buttonChoice;
        }

        protected void recuperarIDProducto(object sender, EventArgs e)
        {
            HtmlButton boton = (HtmlButton)sender;
            string idProducto = boton.Attributes["value"];
            Session.Add("idProducto", idProducto);
            string voucher = (string)Session["voucher"];
            Label lblprod = new Label();
            lblHidden.CssClass = "text-center fw-bold"; // centrado + negrita opcional
            if (string.IsNullOrWhiteSpace(voucher))
            {
                lblHidden.Text = "Error al cargar Voucher, será redirigido para que lo introduzca nuevamente";
                lblHidden.ForeColor = System.Drawing.Color.Red;
                lblHidden.BackColor = System.Drawing.Color.LightPink; // Fondo
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redir",
                    "setTimeout(function(){ window.location='WebForm1.aspx'; }, 3000);", true);
            }
            else
            {
                lblHidden.Text = "Producto elegido: " + idProducto + " por el voucher: " + voucher;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redir",
                    "setTimeout(function(){ window.location='WebCliente.aspx'; }, 3000);", true);
            }
        }

    }
}