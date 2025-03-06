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
        public static int creaccionPedidoDAL(PedidosConNombreProveedor pedido)
        {
            int idPedidoGenerado = 0;  

            using (SqlConnection conexion = clsConexion.getConexion())
            {
                using (SqlCommand miComando = new SqlCommand())
                {
                    miComando.Connection = conexion;
                    miComando.CommandType = CommandType.Text;  

                    try
                    {
                        
                        miComando.CommandText = @"
                    INSERT INTO Pedidos (idProveedor) VALUES (@idProveedor);
                    SELECT SCOPE_IDENTITY();";  

                        
                        miComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = pedido.IdProveedor;

                        
                        idPedidoGenerado = Convert.ToInt32(miComando.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al crear el pedido: " + ex.Message);
                    }
                }
            }

            return idPedidoGenerado;  
        }

        /// <summary>
        /// Función que inserta los productos de un pedido en la base de datos usando el procedimiento almacenado 'InsertarPedido'.
        /// <br></br>
        /// Pre: Lista de productos y el ID del pedido.
        /// <br></br>
        /// Post: Retorna true si todas las inserciones fueron exitosas, false en caso contrario.
        /// </summary>
        /// <param name="listaProductos">Lista de productos a insertar en la base de datos.</param>
        /// <param name="idPedido">ID del pedido al que pertenecen los productos.</param>
        /// <returns>True si las inserciones fueron exitosas, false en caso contrario.</returns>
        public static bool creaccionListaProductosDelPedidoDAL(List<DetallesPedidos> listaProductos, int idPedido)
        {
            bool insercionExitosa = true;

            using (SqlConnection conexion = clsConexion.getConexion())
            {
                

                try
                {
                    foreach (var producto in listaProductos)
                    {
                        // Mover el using aquí para crear un nuevo comando en cada iteración
                        using (SqlCommand miComando = new SqlCommand())
                        {
                            miComando.Connection = conexion;
                            miComando.CommandType = CommandType.Text;
                            miComando.CommandText = @"INSERT INTO Detalles_Pedido (idPedido, idProducto, cantidad) 
                                              VALUES (@idPedido, @idProducto, @cantidad);";

                            miComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = idPedido;
                            miComando.Parameters.Add("@idProducto", SqlDbType.Int).Value = producto.IdProducto;
                            miComando.Parameters.Add("@cantidad", SqlDbType.Int).Value = producto.Cantidad;

                            int filasAfectadas = miComando.ExecuteNonQuery();

                            if (filasAfectadas <= 0)
                            {
                                insercionExitosa = false;
                                break;  // Termina el proceso si alguna inserción falla
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar productos del pedido: " + ex.Message);
                }
            }

            return insercionExitosa;
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
        public static bool desactivarPedido(int idPedido)
        {
            bool borradoCorrectamente = true;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = clsConexion.getConexion();

                // Parámetro del procedimiento almacenado
                miComando.Parameters.AddWithValue("@idPedido", idPedido);

                miComando.Connection = conexion;

                miComando.CommandText = "UPDATE Pedidos SET aceptado = 0 " + "WHERE id = @idPedido";

                miComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                borradoCorrectamente = false;
            }
            finally
            {
                conexion.Close();
            }

            return borradoCorrectamente;
        }
        #endregion
    }
}
