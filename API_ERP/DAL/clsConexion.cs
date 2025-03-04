using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsConexion
    {
        

            /// <summary>
            /// Funcion para conectarte a la base de datos de azure
            /// </summary>
            /// <returns>Devuelve la conexion abierta</returns>
            public static SqlConnection getConexion()
            {
                SqlConnection miConexion = new SqlConnection();

                try

                {

                    miConexion.ConnectionString = "server=jlmejorada.database.windows.net;database=jlmejoradaBD;uid=usuario;pwd=LaCampana123;trustServerCertificate = true;";

                    miConexion.Open();

                }
                catch (Exception ex)
                {
                    throw;
                }


                return miConexion;


            }
        }
    
}
