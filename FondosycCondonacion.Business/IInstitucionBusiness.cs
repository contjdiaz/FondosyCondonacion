using FondosycCondonacion.Entities;
using System.Collections.Generic;

namespace FondosycCondonacion.Business
{
    public interface IInstitucionBusiness
    {
        /// <summary>
        /// Método que consulta los departamentos en el sistema
        /// </summary>
        /// <returns>objeto tipo list con la informacion de los departamentos</returns>
        List<DepartamentoEntity> TraerDeptos();

        /// <summary>
        /// Método que consulta los municipios en el sistema
        /// </summary>
        /// <param name="idDepto">string de entrada</param>
        /// <returns>Objeto tipo List con la infomacion de los municipios</returns>
        List<MunicipioEntity> TraerMunicipios(string idDepto);

        /// <summary>
        /// Método que consulta las ies en el sistema
        /// </summary>
        /// <param name="idDepto">Identificador del departamento</param>
        /// <param name="idMunic">Identificador del municipio</param>
        /// <returns>Objeto tipo List con la informacion de las instituciones</returns>
        List<InstitucionEntity> TraerInstituciones(string idDepto, string idMunic);

        /// <summary>
        /// Metodo que consulta los programas de la ies
        /// </summary>
        /// <param name="codSniesInst">Identificador de la ies</param>
        /// <param name="idDepto">Identificador deL departamento</param>
        /// <param name="idMunic">Identificador del municipio</param>
        /// <returns></returns>
        List<ProgramaEntity> TraerProgramas(string codSniesInst, string idDepto, string idMunic);

        /// <summary>
        /// Metodo que consulta los avales de la convocatoria
        /// </summary>
        /// <param name="idConvocatoria">Identificador de la convocatoria</param>
        /// /// <param name="idNivel">Identificador del nivel de formacion</param>
        /// <returns>Objeto tipo List con la informacion de los avales</returns>
        List<AvalEntity> TraerAvales(int idConvocatoria, int idNivel);
    }
}
