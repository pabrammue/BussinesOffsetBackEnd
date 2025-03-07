using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DetallesPedidosConNombreProducto
    {
        #region Atributos
        private int idDetalles;
        private int idPedido;
        private int idProducto;
        private int cantidad;
        private decimal precioBruto;
        private decimal cuotaIva;
        private decimal precioTotal;
        private int idProveedor;
        private string nombreProducto;
        private decimal precioUnidad;
        private byte porcentajeIVA;
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
            get { return cuotaIva; }
            set { cuotaIva = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public string NombreProducto
        {
            get { return nombreProducto; }
            set { nombreProducto = value; }
        }
        public decimal PrecioUnidad
        {
            get { return precioUnidad; }
            set { precioUnidad = value; }
        }
        public byte PorcentajeIva
        {
            get { return porcentajeIVA; }
            set { porcentajeIVA = value; }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor sin parametros
        /// Pre: Nada
        /// Post: Objeto DetallesPedidosConNombreProducto sin atributos
        /// </summary>
        public DetallesPedidosConNombreProducto() { }

        /// <summary>
        /// Constructor con todos los parámetros
        /// Pre: Usuario manda datos para crear un objeto DetallesPedidosConNombreProducto
        /// Post : Objeto DetallesPedidosConNombreProducto con todos los atributos
        /// </summary>
        /// <param name="idDetalles">Numero entero que indica el id de detalles del pedido</param>
        /// <param name="idPedido">Numero entero que indica el id del pedido del detalle</param>
        /// <param name="idProducto">Numero entero que indica el id del producto</param>
        /// <param name="precioTotal">Decimal que indica el precio total de los productos</param>
        /// <param name="cuotaIva">Numero decimal que indica el porcentaje de IVA</param>
        /// <param name="precioBruto">Numero decimal decimal que indica el precio bruto</param>
        /// <param name="cantidad">Numero entero que indica la cantidad de productos</param>
        /// <param name="nombreProducto">Cadena que indica el nombre del producto</param>
        /// <param name="porcentajeIVA">Numero entero que indica el porcentaje de IVA</param>
        public DetallesPedidosConNombreProducto(int idDetalles, int idPedido, int idProducto, decimal precioTotal, decimal cuotaIva, decimal precioBruto, int cantidad, string nombreProducto, decimal precioUnidad, byte porcentajeIVA)
        {
            this.idDetalles = idDetalles;
            this.idPedido = idPedido;
            this.idProducto = idProducto;
            this.precioTotal = precioTotal;
            this.cuotaIva = cuotaIva;
            this.precioBruto = precioBruto;
            this.cantidad = cantidad;
            this.nombreProducto = nombreProducto;
            this.precioUnidad = precioUnidad;
            this.porcentajeIVA = porcentajeIVA;
        }

        #endregion
    }
}
