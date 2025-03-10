﻿using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManejadoraProveedoresDAL
    {
        #region Funciones

        /// <summary>
        /// Función para devolver un listado de proveedores.
        /// </summary>
        /// <returns>Lista de proveedores</returns>
        public static List<Proveedores> ObtenerProveedores()
        {
            List<Proveedores> listadoProveedores = new List<Proveedores>();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                miConexion = clsConexion.getConexion();
                miComando.CommandText = "ObtenerProveedores"; // Nombre del procedimiento almacenado
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Proveedores proveedor = new Proveedores
                        (
                            (int)miLector["id"],
                            miLector["nombre"].ToString(),
                            miLector["direccion"].ToString(),
                            miLector["email"].ToString()
                        );

                        listadoProveedores.Add(proveedor);
                    }
                }
                miLector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los proveedores: " + ex.Message);
            }
            finally
            {
                miConexion.Close();
            }

            return listadoProveedores;
        }

        /// <summary>
        /// Funcion que devuelve un proveedor por su id
        /// Pre: El usuario elige el id del proveedor
        /// Post: Se devuelve un objeto proveedor por su id si existe y si no error
        /// </summary>
        /// <param name="id">Numero entero que indica el id del proveedor</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Proveedores ObtenerProveedoresPorId(int id)
        {
            Proveedores proveedor = new Proveedores();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            try
            {
                miConexion = clsConexion.getConexion();
                miComando.CommandText = "SELECT * FROM Proveedores where id = @id"; 
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        proveedor = new Proveedores
                        (
                            (int)miLector["id"],
                            miLector["nombre"].ToString(),
                            miLector["direccion"].ToString(),
                            miLector["email"].ToString()
                        );
                    }
                }
            } catch (Exception ex)
            {
                throw new Exception("Error al obtener los proveedor: " + ex.Message);
            }
            return proveedor;
        }


        #endregion
    }



}
