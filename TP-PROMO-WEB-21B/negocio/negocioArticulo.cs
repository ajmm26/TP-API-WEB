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
            try
            {
                datos.setearConsulta("SELECT Id, Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria FROM ARTICULOS");
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
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];
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

        public void agregar(Articulo nuevo)
        {
            if (nuevo.Marca == null || nuevo.Categoria == null)
                throw new Exception("Marca o Categoría no asignadas.");


            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria) VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @IdMarca, @IdCategoria)");
                datos.agregarParametros("@Codigo", nuevo.Codigo);
                datos.agregarParametros("@Nombre", nuevo.Nombre);
                datos.agregarParametros("@Descripcion", nuevo.Descripcion);
                datos.agregarParametros("@Precio", nuevo.Precio);
                datos.agregarParametros("@IdMarca", nuevo.Marca.Id);
                datos.agregarParametros("@IdCategoria", nuevo.Categoria.Id);


                datos.ejecutarAccion();

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

        public void modificar(Articulo aModificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, Preccio=@Precio WHERE Id = @Id");
                datos.agregarParametros("@Codigo", aModificar.Codigo);
                datos.agregarParametros("@Nombre", aModificar.Nombre);
                datos.agregarParametros("@Descripcion", aModificar.Descripcion);
                datos.agregarParametros("@Precio", aModificar.Precio);
                datos.ejecutarAccion();
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
