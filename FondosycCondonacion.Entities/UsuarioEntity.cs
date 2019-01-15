using System;

namespace FondosycCondonacion.Entities
{
    /// <summary>
    /// Clase que mapea la entidad usuario
    /// </summary>
    public class UsuarioEntity
    {
        /// <summary>
        /// Login del usuario
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Password del usuario
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Identificador del usuario
        /// </summary>
        public int IdSolicitante { get; set; }

        /// <summary>
        /// Tipo de documento del usuario
        /// </summary>
        public string TipoDocumento { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string NombreCompleto { get; set; }

        /// <summary>
        /// Identificador del nivel de formacion
        /// </summary>
        public int IdNivel { get; set; }

        /// <summary>
        /// Codigo de la IES
        /// </summary>
        public string Codsnies_Inst { get; set; }

        /// <summary>
        /// Codigo snies del programa
        /// </summary>
        public string CodSnies_Prog { get; set; }

        /// <summary>
        /// Fecha de finalizacion de materias
        /// </summary>
        public DateTime Fecha_Finalizacion_Materias { get; set; }

        /// <summary>
        /// Identificador del aval
        /// </summary>
        public string IdAval { get; set; }

        /// <summary>
        /// Nombre del archivo
        /// </summary>
        public string RutaArchivo1 { get; set; }

        /// <summary>
        /// Identificador del estado
        /// </summary>
        public int IdEstado { get; set; }

        /// <summary>
        /// id del departamento
        /// </summary>
        public string IdDepartamento { get; set; }

        /// <summary>
        /// id del municipio
        /// </summary>
        public string IdMunicipio { get; set; }

        /// <summary>
        /// Fecha del registro
        /// </summary>
        public DateTime? Fecha_Registro { get; set; }

        /// <summary>
        /// Obervacion del resultado
        /// </summary>
        public string Observacion { get; set; }

        /// <summary>
        /// Nombre del estado
        /// </summary>
        public string NombreEstado { get; set; }

        /// <summary>
        /// Nombre de la ies
        /// </summary>
        public string NombreInstitucion { get; set; }

        /// <summary>
        /// Nombre del programa
        /// </summary>
        public string NombrePrograma { get; set; }

        /// <summary>
        /// Nombre del aval
        /// </summary>
        public string NombreAval { get; set; }

        /// <summary>
        /// Nombre del departamento
        /// </summary>
        public string NombreDepartamento { get; set; }

        /// <summary>
        /// Nombre del municipio
        /// </summary>
        public string NombreMunicipio { get; set; }

        /// <summary>
        /// Nombre del municipio
        /// </summary>
        public string IdRadicado { get; set; }

        /// <summary>
        /// Valida si usuario se autentica o no
        /// </summary>
        public bool SeAutentica { get; set; }

        /// <summary>
        /// Nombre de la modalidad de programa
        /// </summary>
        public string TipoPrograma { get; set; }

        /// <summary>
        /// Numero de convocatoria
        /// </summary>
        public string IdConvocatoria { get; set; }

        /// <summary>
        /// Ruta del certificado de permanencia de estado
        /// </summary>
        public string CertifPermEstado { get; set; }

        /// <summary>
        /// Ruta del certificado de promedio de notas
        /// </summary>
        public string CertifPromNotas { get; set; }

        /// <summary>
        /// Ruta del certificado de programa cursado
        /// </summary>
        public string CertifProgCursado { get; set; }

        /// <summary>
        /// Ruta del certificado del diploma
        /// </summary>
        public string CertifDiploma { get; set; }

        /// <summary>
        /// Ruta del certificado de soporte
        /// </summary>
        public string CertifSoporte { get; set; }

        /// <summary>
        /// Enlace de video youtube
        /// </summary>
        public string VideoYoutube { get; set; }

        /// <summary>
        /// Fecha finalizacion de materias
        /// </summary>
        public DateTime FechaFinMaterias { get; set; }

        /// <summary>
        /// Certificado testimonial del video
        /// </summary>
        public string CertifVideo { get; set; }

        /// <summary>
        /// Certificado de terminacion de materias
        /// </summary>
        public string CertifFinMateria { get; set; }

        /// <summary>
        /// Certificado de documentos requeridos
        /// </summary>
        public string CertifDocsRequeridos { get; set; }

        /// <summary>
        /// Certificado de documento de subsanacion
        /// </summary>
        public string CertifDocSubsanacion { get; set; }

        /// <summary>
        /// Usuario que modifica
        /// </summary>
        public string UsuarioModifica { get; set; }

        /// <summary>
        /// Puntaje de participacion en la comunidad
        /// </summary>
        public string PuntajeParticipacion { get; set; }

        /// <summary>
        /// Cumple puntaje de participacion en la comunidad
        /// </summary>
        public string CumplePuntaje { get; set; }

        /// <summary>
        /// Contiene el total de dias del ultimo login
        /// </summary>
        public int DiasUltimoLogin { get; set; }

        /// <summary>
        /// Contiene el total de dias el ultimo cambio del pasword
        /// </summary>
        public int DiasUltimoCambioPass { get; set; }

        /// <summary>
        /// Pinta fila vacia
        /// </summary>
        public bool IsRowEmpty { get; set; }

        /// <summary>
        /// Contiene la fecha del ultimo Ingreso
        /// </summary>
        public string fecha_Ultimo_Ingreso { get; set; }

        /// <summary>
        /// Contiene la fecha del ultimo Cambio de password
        /// </summary>
        public string fecha_Ultimo_Cambio_Pass { get; set; }
    }
}
