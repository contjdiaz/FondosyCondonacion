
namespace FondosycCondonacion.Entities
{
    /// <summary>
    /// Clase que se utiliza para mapear las columnas de la tabla Tipo programa
    /// </summary>
    public class ProgramaEntity
    {
        /// <summary>
        /// Codigo snies del programa
        /// </summary>
        public string CodSnies_Prog { get; set; }

        /// <summary>
        /// Descripcion del programa
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Consecutivo del programa
        /// </summary>
        public string ProConsec { get; set; }
    }
}
