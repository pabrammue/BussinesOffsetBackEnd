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
        private double precioUnitario;
        private double baseImponible;
        private int stock;
        private int idProveedor;
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

        public double PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }

        public double BaseImponible
        {
            get { return baseImponible; }
            set { baseImponible = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
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
        /// <param name="precioUnitario">Precio unitario del producto</param>
        /// <param name="baseImponible">Base imponible del producto</param>
        /// <param name="stock">Cantidad disponible en inventario</param>
        /// <param name="idProveedor">Id del proveedor asociado al producto</param>
        /// <param name="idCategoria">Id de la categoría a la que pertenece el producto</param>
        public Productos(int id, string nombre, double precioUnitario, double baseImponible, int stock, int idProveedor, int idCategoria)
        {
            this.idProducto = id;
            this.nombre = nombre;
            this.precioUnitario = precioUnitario;
            this.baseImponible = baseImponible;
            this.stock = stock;
            this.idProveedor = idProveedor;
            this.idCategoria = idCategoria;
        }
        #endregion
    }
}
