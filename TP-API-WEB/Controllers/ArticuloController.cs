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
        public void Post([FromBody]ArticuloDto articulo)
        {
            negocioArticulo negocio = new negocioArticulo();
            Articulo nuevo = new Articulo();
            nuevo.Codigo = articulo.Codigo;
            nuevo.Nombre = articulo.Nombre;
            nuevo.Descripcion = articulo.Descripcion;
            nuevo.Marca = new Marca();
            nuevo.Marca.Id = articulo.IdMarca;
            nuevo.Categoria = new Categoria();
            nuevo.Categoria.Id = articulo.IdCategoria;
            nuevo.Precio = articulo.Precio;

            negocio.agregar(nuevo);
        }

        // PUT: api/Articulo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Articulo/5
        public void Delete(int id)
        {
        }
    }
}
