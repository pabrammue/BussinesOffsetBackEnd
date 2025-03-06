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
        public ProductosPorProveedorYCategorias() { }

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
