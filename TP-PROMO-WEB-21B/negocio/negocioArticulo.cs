using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesoDatos;
using System.Data.SqlClient;

namespace negocio
{
    public class negocioArticulo
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            negocioImagenes negocioImg = new negocioImagenes();
            List<Imagen> imagenes = negocioImg.listar();


            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.IdMarca, M.Descripcion AS MarcaDescripcion, A.IdCategoria, C.Descripcion AS CategoriaDescripcion FROM ARTICULOS A JOIN MARCAS M ON A.IdMarca = M.Id JOIN CATEGORIAS C ON A.IdCategoria = C.Id ");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)datos.Lector["IdMarca"];
                    articulo.Marca.Descripcion = (string)datos.Lector["MarcaDescripcion"];
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articulo.Categoria.Descripcion = (string)datos.Lector["CategoriaDescripcion"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];

                    articulo.Imagenes = new List<string>();

                    foreach (Imagen img in imagenes)
                    {
                        if (img.IdArticulo == articulo.Id)
                        {
                            articulo.Imagenes.Add(img.UrlImagen);
                        }
                    }


                    lista.Add(articulo);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int agregar(Articulo nuevo)
        {
            if (nuevo.Marca == null || nuevo.Categoria == null)
                throw new Exception("Marca o Categoría no asignadas.");


            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria) OUTPUT INSERTED.Id VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @IdMarca, @IdCategoria)");
                datos.agregarParametros("@Codigo", nuevo.Codigo);
                datos.agregarParametros("@Nombre", nuevo.Nombre);
                datos.agregarParametros("@Descripcion", nuevo.Descripcion);
                datos.agregarParametros("@Precio", nuevo.Precio);
                datos.agregarParametros("@IdMarca", nuevo.Marca.Id);
                datos.agregarParametros("@IdCategoria", nuevo.Categoria.Id);

                return (int)datos.ejecutarLecturaEscalar(); 
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }

        public void modificar(Articulo aModificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, IdMarca = @IdMarca, IdCategoria = @IdCategoria WHERE Id = @Id");
                datos.agregarParametros("@Codigo", aModificar.Codigo);
                datos.agregarParametros("@Nombre", aModificar.Nombre);
                datos.agregarParametros("@Descripcion", aModificar.Descripcion);
                datos.agregarParametros("@Precio", aModificar.Precio);
                datos.agregarParametros("@IdMarca", aModificar.Marca.Id);
                datos.agregarParametros("@IdCategoria", aModificar.Categoria.Id);
                datos.agregarParametros("@Id", aModificar.Id);
                datos.ejecutarAccion();

                if (aModificar.Imagenes != null && aModificar.Imagenes.Count > 0)
                {
                    datos.limpiarParametros();
                    datos.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @Id");
                    datos.agregarParametros("@Id", aModificar.Id);
                    datos.ejecutarAccion();

                    negocioImagenes negocioImg = new negocioImagenes();
                    foreach (string url in aModificar.Imagenes)
                    {
                        negocioImg.agregarImagen(aModificar.Id, url);
                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(int Id)
        {
            AccesoDatos datosArticulo = new AccesoDatos();
            try
            {
                datosArticulo.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @Id");
                datosArticulo.agregarParametros("@Id", Id);
                datosArticulo.ejecutarAccion();

                datosArticulo.limpiarParametros();

                datosArticulo.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                datosArticulo.agregarParametros("@Id", Id );
                datosArticulo.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datosArticulo.cerrarConexion();
            }
        }
    }
}
