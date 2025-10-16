using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dominio;
using negocio;
using TP_API_WEB.Models;
namespace TP_API_WEB.Controllers
{
    public class ImagenController : ApiController
    {
        // GET: api/Imagen
        public IEnumerable<Imagen> Get()
        {
            negocioImagenes imagenes= new negocioImagenes();
            return imagenes.listar();
        }

        // GET: api/Imagen/5
        public Imagen Get(int id)
        {
            negocioImagenes imagenes = new negocioImagenes();
            List<Imagen> imageneslist = imagenes.listar();
            return imageneslist.Find(x => x.Id==id);


        }

        // POST: api/Imagen
        public void Post([FromBody]ImagenDto img)
        {
            negocioImagenes imagenes = new negocioImagenes();
            imagenes.agregarImagen();
        }

        // PUT: api/Imagen/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Imagen/5
        public void Delete(int id)
        {
        }
    }
}
