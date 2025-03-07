using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class PedidosConNombreProveedor
    {
        #region Atributos
        private int id;
        private DateTime fecha;
        private decimal precioTotal;
        private decimal precioBruto;
        private int idProveedor;
        private bool aceptado;
        private string nombreProveedor;
        #endregion
        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public decimal PrecioTotal
        {
            get { return precioTotal; }
            set { precioTotal = value; }
        }

        public decimal PrecioBruto
        {
            get { return precioBruto; }
            set { precioBruto = value; }
        }

        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }
        public bool Aceptado
        {
            get { return aceptado; }
            set { aceptado = value; }
        }
        public string NombreProveedor
        {
            get { return nombreProveedor; }
            set { nombreProveedor = value; }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor sin parametros
        /// Pre: Nada
        /// Post: Objeto PedidosConNombreProveedor sin atributos
        /// </summary>
        public PedidosConNombreProveedor() { }

        /// <summary>
        /// Constructor con el id del proveedor
        /// Pre: El usuario pasa el id del proveedor
        /// Post: Objeto PedidosConNombreProveedor con id de proveedor
        /// </summary>
        /// <param name="idProveedor">Numero entero que indica el idProveedor</param>
        public PedidosConNombreProveedor(int idProveedor) {
            this.idProveedor=idProveedor;
        }
        /// <summary>
        /// Constructor con parametros
        /// Pre: El usuario envia los atributos para la creacion del objeto
        /// Post: Objeto PedidosConNombreProveedor con todos los atributos
        /// </summary>
        /// <param name="id">Numero entero que indica el id del pedido</param>
        /// <param name="fecha">fecha del pedido</param>
        /// <param name="precioTotal">precio total del pedido</param>
        /// <param name="precioBruto">precio bruto del pedido</param>
        /// <param name="idProveedor">Numero entero que indica el id del proveedor del pedido</param>
        /// <param name="aceptado"></param>
        /// <param name="nombreProveedor">Cadena que indica el nombre del proveedor</param>
        public PedidosConNombreProveedor(int id, DateTime fecha, decimal precioTotal, decimal precioBruto, int idProveedor, bool aceptado, string nombreProveedor)
        {
            this.id = id;
            this.fecha = fecha;
            this.precioTotal = precioTotal;
            this.precioBruto = precioBruto;
            this.idProveedor = idProveedor;
            this.aceptado = aceptado;
            this.nombreProveedor = nombreProveedor;
        }

        #endregion
    }
}
