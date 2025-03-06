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
                        oPedido = new PedidosConNombreProveedor
                        (
                            (int)miLector["id"],
                            (DateTime)miLector["fecha"],
                            (decimal)miLector["precioTotal"],
                            (decimal)miLector["precioBruto"],
                            (int)miLector["idProveedor"],
                            (bool)miLector["aceptado"],
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
        public static List<DetallesPedidosConNombreProducto> ObtenerDetallesPedidoPorPedido(int idPedido)
        {
            List<DetallesPedidosConNombreProducto> listaDetalles = new List<DetallesPedidosConNombreProducto>();
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
                        DetallesPedidosConNombreProducto detalles = new DetallesPedidosConNombreProducto
                        (
                            idPedido,
                            (int)miLector["idPedido"],
                            (int)miLector["idProducto"],
                            (decimal)miLector["precioTotal"],
                            (decimal)miLector["cuotaDeIVA"],
                            (decimal)miLector["precioBruto"],
                            (int)miLector["cantidad"],
                            miLector["nombreProducto"].ToString(),
                            (decimal)miLector["precioUnidad"],
                            (byte)miLector["porcentajeIVA"]
                        );

                        listaDetalles.Add(detalles);
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


        /// <summary>
        /// Función que inserta un pedido en la base de datos usando el procedimiento almacenado 'InsertarPedido'.
        /// <br></br>
        /// Pre: Objeto pedido con los detalles necesarios.
        /// <br></br>
        /// Post: Retorna el número de filas afectadas tras el insert.
        /// </summary>
        /// <param name="pedido">Objeto pedido con los detalles a insertar en la base de datos.</param>
        /// <returns>Número de filas afectadas tras el insert.</returns>
        public static int creaccionPedidoDAL(Pedidos pedido)
        {
            int idPedidoGenerado = 0;  // Variable para guardar el ID del pedido creado

            using (SqlConnection conexion = clsConexion.getConexion())
            {
                using (SqlCommand miComando = new SqlCommand())
                {
                    miComando.Connection = conexion;
                    miComando.CommandType = CommandType.Text;  // Usar CommandType.Text para consultas directas

                    try
                    {
                        // Insertar solo el idProveedor y obtener el ID generado
                        miComando.CommandText = @"
                    INSERT INTO Pedidos (idProveedor) VALUES (@idProveedor);
                    SELECT SCOPE_IDENTITY();";  // Obtener el ID generado

                        // Parámetro para el idProveedor
                        miComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = pedido.IdProveedor;

                        // Ejecutar y obtener el ID del pedido creado
                        idPedidoGenerado = Convert.ToInt32(miComando.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al crear el pedido: " + ex.Message);
                    }
                }
            }

            return idPedidoGenerado;  // Devuelve el ID del pedido creado
        }


        /// <summary>
        /// Función que desactiva un pedido en la base de datos usando el procedimiento almacenado 'DesactivarPedido'.
        /// <br></br>
        /// Pre: Int para obtener el id del pedido.
        /// <br></br>
        /// Post: Retorna el número de filas afectadas tras la procedure.
        /// </summary>
        /// <param name="idPedido">Int para obtener el id del pedido</param>
        /// <returns>Número de filas afectadas tras la procedure</returns>
        public static int desactivarPedido(int idPedido)
        {
            int numeroFilasAfectadas = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = clsConexion.getConexion();
                miComando.Connection = conexion;
                miComando.CommandType = System.Data.CommandType.StoredProcedure;
                miComando.CommandText = "DesactivarPedido";

                // Parámetro del procedimiento almacenado
                miComando.Parameters.Add("@idPedido", System.Data.SqlDbType.Int).Value = idPedido;

                numeroFilasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return numeroFilasAfectadas;
        }





        #endregion
    }
}
