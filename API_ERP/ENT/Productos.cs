using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class Productos
    {
        #region Atributos
        private int idProducto;
        private string nombre;
        private int porcentajeIVA;
        private int stock;
        private int idCategoria;
        #endregion

        #region Propiedades
        public int IdProducto
        {
            get { return idProducto; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int PorcentajeIVA
        {
            get { return porcentajeIVA; }
            set {  porcentajeIVA = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacío
        /// Pre: Nada
        /// Post: Objeto producto sin atributos
        /// </summary>
        public Productos() { }

        /// <summary>
        /// Constructor con parámetros
        /// Pre: El usuario añade los atributos del objeto
        /// Post: Se crea un objeto producto con sus atributos
        /// </summary>
        /// <param name="id">Id del producto a agregar</param>
        /// <param name="nombre">Nombre del producto</param>
        /// <param name="porcentajeIVA"> Numero entero que indica el porcentaje de IVA</param>
        /// <param name="stock">Cantidad disponible en inventario</param>
        /// <param name="idCategoria">Id de la categoría a la que pertenece el producto</param>
        public Productos(int id, string nombre, int stock,int porcentajeIVA , int idCategoria)
        {
            this.idProducto = id;
            this.nombre = nombre;
            this.stock = stock;
            this.porcentajeIVA = porcentajeIVA;
            this.idCategoria = idCategoria;
        }
        #endregion
    }
}
