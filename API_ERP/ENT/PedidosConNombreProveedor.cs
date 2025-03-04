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
        public string NombreProveedor
        {
            get { return nombreProveedor; }
            set { nombreProveedor = value; }
        }
        #endregion

        #region Constructores

        public PedidosConNombreProveedor() { }
        public PedidosConNombreProveedor(int id, DateTime fecha, decimal precioTotal, decimal precioBruto, int idProveedor, string nombreProveedor)
        {
            this.id = id;
            this.fecha = fecha;
            this.precioTotal = precioTotal;
            this.precioBruto = precioBruto;
            this.idProveedor = idProveedor;
            this.nombreProveedor = nombreProveedor;
        }

        #endregion
    }
}
