using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class Categorias
    {
        #region Atributos
        private int idCategorias;
        private string nombre;
        #endregion

        #region Propiedades
        public int IdCategorias
        {
            get { return idCategorias; }
            set { idCategorias = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacío
        /// Pre: Nada
        /// Post: Objeto categoría sin atributos
        /// </summary>
        public Categorias() { }

        /// <summary>
        /// Constructor con parámetros
        /// Pre: El usuario añade los atributos del objeto
        /// Post: Se crea un objeto categoría con sus atributos
        /// </summary>
        /// <param name="idCategorias">Id de la categoría</param>
        /// <param name="nombre">Nombre de la categoría</param>
        public Categorias(int idCategorias, string nombre)
        {
            this.idCategorias = idCategorias;
            this.nombre = nombre;
        }
        #endregion
    }
}
