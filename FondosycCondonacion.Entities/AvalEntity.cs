
namespace FondosycCondonacion.Entities
{
    /// <summary>
    /// Clase que se utiliza para mapear las columnas de la tabla fondo_condonacionaval
    /// </summary>
    public class AvalEntity
    {
        /// <summary>
        /// Identificador del aval
        /// </summary>
        public string IdAval { get; set; }

        /// <summary>
        /// Nombre del aval
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Ruta del formato de aval a descargar
        /// </summary>
        public string Formato_Aval { get; set; }

        /// <summary>
        /// Ruta del formato de condonacion a descargar
        /// </summary>
        public string Formato_Condonacion { get; set; }
    }
}
