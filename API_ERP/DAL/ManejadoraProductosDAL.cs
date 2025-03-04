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
    public class ManejadoraProductosDAL
    {
        #region Funciones

        /// <summary>
        /// Función para devolver un listado de productos por proveedor.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor cuyos productos se desean obtener</param>
        /// <returns>Lista de productos del proveedor especificado</returns>
        public static List<Productos> ObtenerProductosPorProveedor(int idProveedor)
        {
            List<Productos> listadoProductos = new List<Productos>();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                miConexion = clsConexion.getConexion();
                miComando.CommandText = "ObtenerProductosPorProveedor"; // Nombre del procedimiento almacenado
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@idProveedor", idProveedor); // Se agrega el parámetro

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Productos producto = new Productos
                        (
                            (int)miLector["idProducto"],
                            miLector["nombre"].ToString(),
                            (double)miLector["precioUnitario"],
                            (double)miLector["baseImponible"],
                            (int)miLector["stock"],
                            (int)miLector["idProveedor"],
                            (int)miLector["idCategoria"]
                        );

                        listadoProductos.Add(producto);
                    }
                }
                miLector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos por proveedor: " + ex.Message);
            }
            finally
            {
                miConexion.Close();
            }

            return listadoProductos;
        }

        #endregion
    }
}
