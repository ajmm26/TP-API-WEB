using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesoDatos;

namespace negocio
{
    public class negocioCliente
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select id, Documento, Nombre,Apellido, Email, Direccion, Ciudad, CP from Clientes ");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = (int)datos.Lector["id"];
                    cliente.Documento = (string)datos.Lector["Documento"];
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Apellido = (string)datos.Lector["Apellido"];
                    cliente.Email = (string)datos.Lector["Email"];
                    cliente.Direccion = (string)datos.Lector["Direccion"];
                    cliente.Ciudad = (string)datos.Lector["Ciudad"];
                    cliente.Cp = (int)datos.Lector["Cp"];
                    lista.Add(cliente);
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
        public void agregar(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, Cp) VALUES (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @Cp)");
                datos.agregarParametros("@Documento", nuevo.Documento);
                datos.agregarParametros("@Nombre", nuevo.Nombre);
                datos.agregarParametros("@Apellido", nuevo.Apellido);
                datos.agregarParametros("@Email", nuevo.Email);
                datos.agregarParametros("@Direccion", nuevo.Direccion);
                datos.agregarParametros("@Ciudad", nuevo.Ciudad);
                datos.agregarParametros("@Cp", nuevo.Cp);
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
        public void modificar(Cliente aModificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Clientes SET id = @Id, Documento = @Documento, Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Direccion = @Direccion, Ciudad = @Ciudad, Cp =@Cp WHERE id = @Id");
                datos.agregarParametros("@Id", aModificar.Id);
                datos.agregarParametros("@Documento", aModificar.Documento);
                datos.agregarParametros("@Nombre", aModificar.Nombre);
                datos.agregarParametros("@Apellido", aModificar.Apellido);
                datos.agregarParametros("@Email", aModificar.Email);
                datos.agregarParametros("@Direccion", aModificar.Direccion);
                datos.agregarParametros("@Ciudad", aModificar.Ciudad);
                datos.agregarParametros("@Cp", aModificar.Cp);
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
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM Clientes WHERE id = @Id");
                datos.agregarParametros("@Id", Id);
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
        public Cliente buscarClientePorDocumento(string documento)
        {
            Cliente cliente = null;
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("SELECT id,Nombre, Apellido, Email, Direccion,Ciudad, Cp FROM Clientes WHERE Documento = @Documento"); 
            datos.agregarParametros("@Documento",documento);
            datos.ejecutarLectura();
            if (datos.Lector.Read())
            {
                cliente = new Cliente();
                cliente.Id = (int)datos.Lector["id"];
                cliente.Nombre = (string)datos.Lector["Nombre"];
                cliente.Apellido = (string)datos.Lector["Apellido"];
                cliente.Email = (string)datos.Lector["Email"];
                cliente.Direccion = (string)datos.Lector["Direccion"];
                cliente.Ciudad = (string)datos.Lector["Ciudad"];
                cliente.Cp = (int)datos.Lector["Cp"];

            }

            return cliente;
        }

    }
}
