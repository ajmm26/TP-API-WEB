
using accesoDatos;
using dominio;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class negocioImagenes
    {
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id,IdArticulo,ImagenUrl from IMAGENES");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.Id = (int)datos.Lector["Id"];
                    imagen.IdArticulo = (int)datos.Lector["IdArticulo"];
                    imagen.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    lista.Add(imagen);
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

        public void agregarImagen(int idArticulo, string Url)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @Url)");
                datos.limpiarParametros();
                datos.agregarParametros("@IdArticulo", idArticulo);
                datos.agregarParametros("@Url", Url);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



        public bool modificarImagenUrl(int id, string url )
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE IMAGENES SET ImagenUrl=@url WHERE id=@id");
                datos.limpiarParametros();
                datos.agregarParametros("@url", url);
                datos.agregarParametros("@id", id);
               datos.ejecutarAccion();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public bool deleteImagen(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM IMAGENES WHERE id=@id");
                datos.limpiarParametros();
                datos.agregarParametros("@id", id);
                datos.ejecutarAccion();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
