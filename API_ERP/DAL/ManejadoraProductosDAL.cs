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
        public static List<ProductosPorProveedorYCategorias> ObtenerProductosPorProveedor(int idProveedor)
        {
            List<ProductosPorProveedorYCategorias> listaProductos = new List<ProductosPorProveedorYCategorias>();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                miConexion = clsConexion.getConexion();
                miComando.CommandText = "ObtenerProductosPorProveedorYCategoria"; // Nombre del procedimiento almacenado
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@idProveedor", idProveedor); // Se agrega el parámetro

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        ProductosPorProveedorYCategorias producto = new ProductosPorProveedorYCategorias
                            (
                            (int)miLector["id"],
                            miLector["nombre"].ToString(),
                            (int)miLector["porcentajeIVA"],
                            (int)miLector["stock"],
                            (int)miLector["idCategoria"],
                            (int)miLector["precioUnitario"]
                            );

                        listaProductos.Add(producto);
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

            return listaProductos;
        }

        #endregion
    }
}
