﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class Pedidos
    {
        #region Atributos
        private int idPedidos;
        private DateTime fecha;
        private double precioTotal;
        private double precioBruto;
        private int idProveedor;
        #endregion

        #region Propiedades
        public int IdPedidos
        {
            get { return idPedidos; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
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

        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacío
        /// Pre: Nada
        /// Post: Objeto pedidos sin atributos
        /// </summary>
        public Pedidos() { }

        /// <summary>
        /// Constructor con parámetros
        /// Pre: El usuario añade los atributos del objeto
        /// Post: Se crea un objeto pedido con sus atributos
        /// </summary>
        /// <param name="id">Id del pedido a agregar</param>
        /// <param name="fecha">Fecha en la que se realizó el pedido</param>
        /// <param name="precioTotal">Valor total del pedido</param>
        /// <param name="precioBruto">Valor bruto del pedido antes de impuestos o descuentos</param>
        /// <param name="idProveedor">Id del proveedor asociado al pedido</param>
        public Pedidos(int id, DateTime fecha, double precioTotal, double precioBruto, int idProveedor)
        {
            this.idPedidos = id;
            this.fecha = fecha;
            this.precioTotal = precioTotal;
            this.precioBruto = precioBruto;
            this.idProveedor = idProveedor;
        }
        #endregion
    }
}
