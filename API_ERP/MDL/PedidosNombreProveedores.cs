using DAL;
using ENT;
namespace MDL
{
    public class PedidosNombreProveedores : Pedidos
    {
        private string nombreProveedor;

        public string NombreProveedor
        {
            get { return nombreProveedor; }
            set { nombreProveedor = value; }
        }

        public PedidosNombreProveedores(Pedidos p)
        {
            this.IdPedidos = p.IdPedidos;
            this.Fecha = p.Fecha;
            this.PrecioTotal = p.PrecioTotal;
            this.PrecioBruto = p.PrecioBruto;
            this.IdProveedor = p.IdProveedor;

            //List<Pedidos> listado = ManejadoraProveedoresDAL.getListadoProveedoresDAL();
            //foreach(Pedidos p in listado){
            //    if(p.IdProveedor == this.IdProveedor){
            //        this.NombreProveedor = p.NombreProveedor;
            //    }

        }
    }
}
