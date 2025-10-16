
using System;
using System.Collections.Generic;
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

        public void agregarImagen(int idArticulo=1, string Url= "https://tse2.mm.bing.net/th/id/OIP._XsKjB2Mva6_tomRtgH7fQHaFi?cb=12&rs=1&pid=ImgDetMain&o=7&rm=3")
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

    }
}
