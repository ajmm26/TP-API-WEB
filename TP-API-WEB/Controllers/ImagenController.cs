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
            Imagen img= new Imagen();
            img = imageneslist.Find(x => x.Id == id);
            if(img == null)
            {
                return null;
            }

            return img;


        }

        // POST: api/Imagen
        public void Post([FromBody]ImagenDto img)
        {
            negocioImagenes imagenes = new negocioImagenes();
            string url = null;
            int idArticulo = 0;
          

            if (!string.IsNullOrEmpty(img.url) && img.IdArticulo > -1)
            {
                url = img.url;
                idArticulo = img.IdArticulo;
                imagenes.agregarImagen(idArticulo, url);
            }
          
        }

        [HttpPut]
        [Route("api/imagen/{id}")]
        public IHttpActionResult Put(int id, [FromBody] ImagenDto img)
        {
            try
            {
                if (id <= 0 || img == null || string.IsNullOrEmpty(img.url))
                    return BadRequest("ID inválido o URL vacía.");

                negocioImagenes imagenN = new negocioImagenes();
                bool res = imagenN.modificarImagenUrl(id, img.url);

                if (res)
                    return Ok("Modificación exitosa");
                else
                    return NotFound(); // No se encontró registro
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Imagen/5
        [HttpDelete]
        [Route("api/imagen/{id}")]
        public IHttpActionResult Delete(int id)
        {

            try
            {
                negocioImagenes imagenN = new negocioImagenes();
                if (id <= 0)
                    return BadRequest("ID inválido o URL vacía.");

                bool res = imagenN.deleteImagen(id);

                if (res)
                    return Ok("Eliminacion exitosa");
                else
                    return NotFound(); // No se encontró registro


            }
            catch (Exception ex)
            {
                return InternalServerError(ex);

            }

        }
    }
}
