using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class DetallesPedidos
    {
        #region Atributos
        private int idDetalles;
        private int idPedido;
        private int idProducto;
        private decimal precioTotal;
        private decimal cuotaIva;
        private decimal precioBruto;
        private int cantidad;
        #endregion

        #region Propiedades
        public int IdDetalles
        {
            get { return idDetalles; }
        }

        public int IdPedido
        {
            get { return idPedido; }
            set { idPedido = value; }
        }

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
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
        public decimal CuotaIva
        {
            get {return cuotaIva; }
            set { cuotaIva = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacío
        /// Pre: Nada
        /// Post: Objeto detalles pedidos sin atributos
        /// </summary>
        public DetallesPedidos() { }

        /// <summary>
        /// Constructor con parámetros
        /// Pre: El usuario añade los atributos del objeto
        /// Post: Se crea un objeto detalles pedidos con sus atributos
        /// </summary>
        /// <param name="idDetalles">Id del detalle de pedido</param>
        /// <param name="idPedido">Id del pedido asociado</param>
        /// <param name="idProducto">Id del producto asociado</param>
        /// <param name="precioTotal">Precio total del detalle del pedido</param>
        /// <param name="precioBruto">Precio bruto del detalle del pedido</param>
        /// <param name="cantidad">Cantidad de productos en el detalle del pedido</param>
        public DetallesPedidos(int idDetalles, int idPedido, int idProducto, decimal precioTotal, decimal cuotaIva, decimal precioBruto, int cantidad)
        {
            
            this.idPedido = idPedido;
            this.idProducto = idProducto;
            this.cuotaIva = cuotaIva;
            this.precioTotal = precioTotal;
            this.precioBruto = precioBruto;
            this.cantidad = cantidad;
        }

        /// <summary>
        /// Constructor con parámetros
        /// Pre: El usuario añade los atributos del objeto
        /// Post: Se crea un objeto detalles pedidos con sus atributos
        /// </summary>
        /// <param name="idPedido">Id del pedido asociado</param>
        /// <param name="idProducto">Id del producto asociado</param>
        /// <param name="precioTotal">Precio total del detalle del pedido</param>
        /// <param name="precioBruto">Precio bruto del detalle del pedido</param>
        /// <param name="cantidad">Cantidad de productos en el detalle del pedido</param>
        public DetallesPedidos(int idPedido, int idProducto, decimal precioTotal, decimal cuotaIva, decimal precioBruto, int cantidad)
        {
            
            this.idPedido = idPedido;
            this.idProducto = idProducto;
            this.cuotaIva = cuotaIva;
            this.precioTotal = precioTotal;
            this.precioBruto = precioBruto;
            this.cantidad = cantidad;
        }
        

        #endregion
    }
}
