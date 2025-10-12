using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {

        int id;

        int idArticulo;

        string urlImagen;

        public int Id { get => id; set => id = value; }

        public int IdArticulo { get => idArticulo; set => idArticulo = value; }

        public string UrlImagen { get => urlImagen; set => urlImagen = value; }


    }
}
