using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using dominio;
using negocio;
using TP_API_WEB.Models;

namespace TP_API_WEB.Controllers
{
    public class ArticuloController : ApiController
    {
        // GET: api/Articulo
        public IEnumerable<Articulo> Get()
        {
            negocioArticulo negocio = new negocioArticulo();
            return negocio.listar();
        }

        // GET: api/Articulo/5
        public Articulo Get(int id)
        {
            negocioArticulo negocio = new negocioArticulo();
            List<Articulo> lista = negocio.listar();    
            return lista.Find(x=> x.Id == id);
        }

        // POST: api/Articulo
        public void Post([FromBody] ArticuloDto articulo)
        {
            negocioArticulo negocio = new negocioArticulo();
            Articulo nuevo = new Articulo
            {
                Codigo = articulo.Codigo,
                Nombre = articulo.Nombre,
                Descripcion = articulo.Descripcion,
                Marca = new Marca { Id = articulo.IdMarca },
                Categoria = new Categoria { Id = articulo.IdCategoria },
                Precio = articulo.Precio
            };

            nuevo.Id = negocio.agregar(nuevo); 

            if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
            {
                negocioImagenes negocioImg = new negocioImagenes();
                foreach (string url in articulo.Imagenes)
                {
                    negocioImg.agregarImagen(nuevo.Id, url);
                }
            }
        }



        // PUT: api/Articulo/5
        [HttpPut]
        [Route("api/articulo/{id}")]
        public IHttpActionResult Put(int id, [FromBody]ArticuloDto dto)
        {
            if (dto == null || dto.Id <= 0)
                return BadRequest("Id invalido");
            try
            {
                negocioArticulo negocio = new negocioArticulo();
                Articulo aModificar = new Articulo
                {
                    Id = dto.Id,
                    Codigo = dto.Codigo,
                    Nombre=dto.Nombre,
                    Descripcion=dto.Descripcion,
                    Marca=new Marca { Id = dto.IdMarca},
                    Categoria=new Categoria { Id = dto.IdCategoria},
                    Precio = dto.Precio,
                    Imagenes =dto.Imagenes

                };
                negocio.modificar(aModificar);
                return Ok("Articulo modificado correctamente.");

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Articulo/5
        public void Delete(int id)
        {
            negocioArticulo negocio = new negocioArticulo();
            negocio.eliminar(id);
        }
    }
}
