using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class PedidosConProductosYProveedores
    {
        #region Atributos
        private int id;
        private DateTime fecha;
        private double precioTotal;
        private double precioBruto;
        private int proveedorSeleccionado;
        private List<Proveedores> listaProveedores;
        private List<Productos> listaProductos;
        #endregion
        #region Propiedades

        public int Id
        {
            get { return id; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public double PedidosTotal
        {
            get { return precioTotal; }
            set { precioTotal = value; }
        }
        public double PedidosBruto
        {
            get { return precioBruto; }
            set { precioBruto = value; }
        }
        public int ProveedorSeleccionado
        {
            get { return proveedorSeleccionado; }
            set { proveedorSeleccionado = value; }
        }
        public List<Proveedores> ListaProveedores
        {
            get { return listaProveedores; }
            set { listaProveedores = value; }
        }
        public List<Productos> ListaProductos
        {
            get { return listaProductos; }
            set { listaProductos = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Pre: Nada
        /// Post: Objeto PedidosConProductosYProveedores sin atributos
        /// Constructor sin parametros
        /// </summary>
        public PedidosConProductosYProveedores() { }

        /// <summary>
        /// Pre: El usuario añade los atributos del objeto
        /// Post: Objeto PedidosConProductosYProveedores con atributos
        /// Constructor con parametros
        /// </summary>
        /// <param name="id">Id del pedidocon productos y proveedores</param>
        /// <param name="fecha">Fecha del pedido con productos y proveedores</param>
        /// <param name="precioTotal">Campo calculado de la base de datos</param>
        /// <param name="precioBruto">Campo calculado de la base de datos</param>
        /// <param name="proveedorSeleccionado">Id del proveedor seleccionado</param>
        /// <param name="listaProveedores">Listado de proveedores del pedido</param>
        /// <param name="listaProductos">Listado de productos del producto</param>
        public PedidosConProductosYProveedores(int id, DateTime fecha, double precioTotal, double precioBruto, int proveedorSeleccionado, List<Proveedores> listaProveedores, List<Productos> listaProductos)
        {
            this.id = id;
            this.fecha = fecha;
            this.precioTotal = precioTotal;
            this.precioBruto = precioBruto;
            this.proveedorSeleccionado = proveedorSeleccionado;
            this.listaProveedores = listaProveedores;
            this.listaProductos = listaProductos;

        }


        #endregion
    }
}
