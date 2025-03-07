using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class PedidosConDetallesProductos
    {
        #region Atributos
        private PedidosConNombreProveedor pedido;
        private List<DetallesPedidosConNombreProducto> listaProductos;
        #endregion

        #region Propiedades
        public PedidosConNombreProveedor Pedido { get {  return pedido; } set { pedido = value; } }
        public List<DetallesPedidosConNombreProducto> ListaProductos { get { return listaProductos; } set {  listaProductos = value; } }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacío
        /// Pre: Nada
        /// Post: Objeto detalles pedidos sin atributos
        /// </summary>
        public PedidosConDetallesProductos() {
        
        }

        /// <summary>
        /// Constructor con id y lista pedidos
        /// Pre: El usuario envia el pedido y la lista de productos
        /// Post: Se crea objeto PedidosConDetallesProductos con atributos
        /// </summary>
        /// <param name="pedido">Pedido con nombre del proveedor</param>
        /// <param name="listaProductos">Listado de detallesPedidos con nombre de los productos</param>
        public PedidosConDetallesProductos(PedidosConNombreProveedor pedido, List<DetallesPedidosConNombreProducto> listaProductos)
        {
            this.pedido = pedido;
            this.listaProductos = listaProductos;
        }

        /// <summary>
        /// Constructor con pedidos 
        /// </summary>
        /// <param name="conjunto">Objeto PedidosConDetallesProductos a copiar.</param>
        public PedidosConDetallesProductos(PedidosConDetallesProductos conjunto)
        {
            this.pedido = conjunto.pedido;
            this.listaProductos = conjunto.listaProductos;
        }

        #endregion
    }
}
