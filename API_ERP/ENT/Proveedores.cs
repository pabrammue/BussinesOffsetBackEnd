namespace ENT
{
    public class Proveedores
    {
        #region Atributos
        private int idProveedores;
        private string nombre;
        private string direccion;
        private string email;
        #endregion

        #region Propiedades
        public int IdProveedores
        {
            get { return idProveedores; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio
        /// Pre: Nada
        /// Post: Objeto proveedor con atributos
        /// </summary>
        public Proveedores() { }

        /// <summary>
        /// Constructor con parametros
        /// Pre: El usuario añade los atributos del objeto
        /// Post: Se crea un objeto proveedor con sus atributos
        /// </summary>
        /// <param name="idProveedores"></param>
        /// <param name="nombre"></param>
        /// <param name="direccion"></param>
        /// <param name="email"></param>
        public Proveedores(int idProveedores, string nombre, string direccion, string email)
        {
            this.idProveedores = idProveedores;
            this.nombre = nombre;
            this.direccion = direccion;
            this.email = email;
        }


        #endregion
    }
}
