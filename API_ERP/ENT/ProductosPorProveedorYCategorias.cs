using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ENT
{
    public class ProductosPorProveedorYCategorias
    {
        #region Atributos
        private int idProducto;
        private string nombre;
        private int porcentajeIVA;
        private int stock;
        private int idCategoria;
        private decimal precioUnitario;
        #endregion
        #region Propiedades
        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int PorcentajeIVA
        {
            get { return porcentajeIVA; }
            set { porcentajeIVA = value; }
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

        public decimal PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor sin parametros
        /// Pre: Nada
        /// Post: Objeto ProductosPorProveedorYCategorias con atributos
        /// </summary>
        public ProductosPorProveedorYCategorias() { }

        /// <summary>
        /// Constructor con parametros
        /// Pre: El usuario inserta los atributos
        /// Post: Objeto ProductosPorProveedorYCategorias con todos los atributos
        /// </summary>
        /// <param name="idProducto">Numero entero que indica el id del producto</param>
        /// <param name="nombre">Cadena que contiene el nombre del producto</param>
        /// <param name="porcentajeIVA">Numero entero que indica el porcentaje de IVA</param>
        /// <param name="stock">Numero entero que indica el stock</param>
        /// <param name="idCategoria">Numero entero que indica el id de la categoria</param>
        /// <param name="precioUnitario">Numero decimal que indica el precioUnitario</param>
        public ProductosPorProveedorYCategorias(int idProducto, string nombre, int porcentajeIVA, int stock, int idCategoria, decimal precioUnitario)
        {
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.porcentajeIVA = porcentajeIVA;
            this.stock = stock;
            this.idCategoria = idCategoria;
            this.precioUnitario = precioUnitario;
        }

        #endregion

    }
}
