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
        private List<DetallesPedidos> listaProductos;
        #endregion

        #region Propiedades
        public PedidosConNombreProveedor Pedido { get {  return pedido; } set { pedido = value; } }
        public List<DetallesPedidos> ListaProductos { get { return listaProductos; } set {  listaProductos = value; } }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacío
        /// Pre: Nada
        /// Post: Objeto detalles pedidos sin atributos
        /// </summary>
        public PedidosConDetallesProductos() {
        
        }

        public PedidosConDetallesProductos(PedidosConNombreProveedor pedido, List<DetallesPedidos> listaProductos)
        {
            this.pedido = pedido;
            this.listaProductos = listaProductos;
        }

        public PedidosConDetallesProductos(PedidosConDetallesProductos conjunto)
        {
            this.pedido = conjunto.pedido;
            this.listaProductos = conjunto.listaProductos;
        }

        #endregion
    }
}
