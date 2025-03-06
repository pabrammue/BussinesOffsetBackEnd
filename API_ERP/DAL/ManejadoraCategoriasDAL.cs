using ENT;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ManejadoraCategoriasDAL
    {
        #region Funciones
        /// <summary>
        /// Función para devolver un listado de todas las categorías de la base de datos filtradas por idProveedor
        /// </summary>
        /// <param name="idProveedor">ID del proveedor para filtrar las categorías</param>
        /// <returns>Devolverá una lista de Categorias asociadas al proveedor</returns>
        public static List<Categorias> ListadoCompletoCategoriasDAL(int idProveedor)
        {
            SqlConnection miConexion = new SqlConnection();
            List<Categorias> listadoCategorias = new List<Categorias>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            Categorias oCategoria;

            try
            {
                miConexion = clsConexion.getConexion();
                miComando.CommandText = "ObtenerCategoriasPorProveedor"; // Llamada al procedimiento almacenado
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Connection = miConexion;

                // Agregar el parámetro idProveedor
                miComando.Parameters.AddWithValue("@idProveedor", idProveedor);

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oCategoria = new Categorias();
                        oCategoria.IdCategorias = (int)miLector["id"];
                        oCategoria.Nombre = (string)miLector["nombre"];
                        listadoCategorias.Add(oCategoria);
                    }
                }
                miLector.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                miConexion.Close();
            }

            return listadoCategorias;
        }


        #endregion
    }
}
