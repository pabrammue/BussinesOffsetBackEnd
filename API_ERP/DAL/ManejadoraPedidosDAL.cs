using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManejadoraPedidosDAL
    {
        #region Funciones

        /// <summary>
        /// Función para devolver un listado de todos los pedidos con el nombre del proveedor
        /// </summary>
        /// <returns>Devolverá una lista completa de todos los Pedidos</returns>
        public static List<PedidosConNombreProveedor> ObtenerPedidosConNombreProveedor()
        {
            SqlConnection miConexion = new SqlConnection();
            List<PedidosConNombreProveedor> listadoPedidos = new List<PedidosConNombreProveedor>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            PedidosConNombreProveedor oPedido;
            int aceptado = 0;

            try
            {
                miConexion = clsConexion.getConexion();
                miComando.CommandText = "ObtenerPedidosConNombreProveedor"; // Nombre del procedimiento almacenado
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        aceptado = (int)miLector["aceptado"];
                        oPedido = new PedidosConNombreProveedor
                        (
                            (int)miLector["id"],
                            (DateTime)miLector["fecha"],
                            (decimal)miLector["precioTotal"],
                            (decimal)miLector["precioBruto"],
                            (int)miLector["idProveedor"],
                            aceptado == 1 ? true : false,
                            miLector["nombre"].ToString()
                        );

                        listadoPedidos.Add(oPedido);
                    }
                }
                miLector.Close();
            }
            catch (Exception ex) //System.InvalidCastException: 'Unable to cast object of type 'System.Decimal' to type 'System.Double'.'
            {
                throw new Exception("Error al obtener los pedidos: " + ex.Message);
            }
            finally
            {
                miConexion.Close();
            }

            return listadoPedidos;
        }




        /// <summary>
        /// Esta Funcion devuelve una lista
        /// </summary>
        /// <param name="idPedido"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<DetallesPedidos> ObtenerDetallesPedidoPorPedido(int idPedido)
        {
            List<DetallesPedidos> listaDetalles = new List<DetallesPedidos>();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                miConexion = clsConexion.getConexion();
                miComando.CommandText = "ObtenerDetallesPedidoPorPedido";
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Connection = miConexion;

                // Agregar el parámetro @idPedido
                miComando.Parameters.AddWithValue("@idPedido", idPedido);

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        DetallesPedidos detalle = new DetallesPedidos
                        (
                            idPedido,
                            (int)miLector["idProducto"],
                            (double)miLector["precioTotal"],
                            (double)miLector["cuotaDelIVA"],
                            (double)miLector["precioBruto"],
                            (int)miLector["cantidad"]
                            

                        );

                        listaDetalles.Add(detalle);
                    }
                }
                miLector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los detalles del pedido: " + ex.Message);
            }
            finally
            {
                miConexion.Close();
            }

            return listaDetalles;
        }


        #endregion
    }
}
