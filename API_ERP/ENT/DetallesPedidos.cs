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
        private double precioTotal;
        private double precioBruto;
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

        public double PrecioTotal
        {
            get { return precioTotal; }
            set { precioTotal = value; }
        }

        public double PrecioBruto
        {
            get { return precioBruto; }
            set { precioBruto = value; }
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
        /// Post: Objeto detalles pedidos con atributos predeterminados
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
        public DetallesPedidos(int idDetalles, int idPedido, int idProducto, double precioTotal, double precioBruto, int cantidad)
        {
            this.idDetalles = idDetalles;
            this.idPedido = idPedido;
            this.idProducto = idProducto;
            this.precioTotal = precioTotal;
            this.precioBruto = precioBruto;
            this.cantidad = cantidad;
        }
        #endregion
    }
}
