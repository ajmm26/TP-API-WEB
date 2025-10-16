using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_API_WEB.Models
{
    public class ArticuloDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }
        public List<string> Imagenes { get; set; }


    }
}