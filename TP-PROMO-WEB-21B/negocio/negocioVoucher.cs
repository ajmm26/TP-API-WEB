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
    public class negocioVoucher
    {
        public List<Voucher> listar()
        {
            List<Voucher> lista = new List<Voucher>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select CodigoVoucher,Idcliente,IdArticulo from Vouchers");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Voucher voucher = new Voucher();
                    voucher.Codigo = (string)datos.Lector["CodigoVoucher"];
                    voucher.IdCliente = datos.Lector["IdCliente"] != DBNull.Value ? (int)datos.Lector["IdCliente"] : 0;
                    voucher.IdArticulo = datos.Lector["IdArticulo"] != DBNull.Value ? (int)datos.Lector["IdArticulo"] : 0;

                    lista.Add(voucher);
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


        /*public bool updateVoucher(string date, string codigoVoucher, int idCliente, int idArticulo)*/
        public bool updateVoucher(string date, string codigoVoucher, int idCliente, int idArticulo)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
            datos.setearConsulta("Update Vouchers set fechaCanje=@date, idCliente=@idCliente, idArticulo=@idArticulo where CodigoVoucher=@codigoVoucher");
                datos.limpiarParametros();
                datos.agregarParametros("@date", date);
                datos.agregarParametros("@codigoVoucher",codigoVoucher);
                datos.agregarParametros("@idCliente", idCliente);
                datos.agregarParametros("@idArticulo", idArticulo);
                datos.ejecutarAccion();
                return true;
            }catch(Exception ex)
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
