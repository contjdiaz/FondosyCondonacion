using Icetex.ODAL;
using System.Collections.Generic;
using System.Data;

namespace FondosycCondonacion.DAL
{
    public class AdministracionDao
    {
        #region "METDOS PUBLICOS"

        /// <summary>
        /// Trae la lista de departamentos
        /// </summary>
        /// <returns>Retorna un objeto tipo DataTable con la informacion de los departamentos</returns>
        public DataTable TraerDeptos()
        {
            DataTable objDeptos = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CON_UTILIDADES.SP_TRAER_DEPTOS", CommandType.StoredProcedure, null);
            return objDeptos;
        }

        /// <summary>
        /// Trae la lista de municipios
        /// </summary>
        /// <returns>Retorna un objeto tipo DataTable con la informacion de los municipios</returns>
        public DataTable TraerMunicipios(string idDepto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("P_DEPTO", idDepto);
            DataTable objMunicipio = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CON_UTILIDADES.SP_TRAER_MUNICIPIOS", CommandType.StoredProcedure, parametros);
            return objMunicipio;
        }

        /// <summary>
        /// Trae listado de instutuciones que pertenecen al municipio seleccionado
        /// </summary>
        /// <param name="idDepto">Identificador del departamento</param>
        /// <param name="idMunic">Identificador del municipio</param>
        /// <returns>Retorna un objeto tipo DataTable con la informacion de la institucion</returns>
        public DataTable TraerInstitucion(string idDepto, string idMunic)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("P_DEPTO", idDepto);
            parametros.Add("P_MUNIC", idMunic);
            DataTable objInstitucion = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CONDONACION_FONDOS.SP_TRAER_IES", CommandType.StoredProcedure, parametros);
            return objInstitucion;
        }

        /// <summary>
        /// Trae la lista de programas por institucion
        /// </summary>
        /// <returns>Retorna un objeto tipo DataTable con la informacion de los programas</returns>
        public DataTable TraerProgramas(string Codsnies_Inst, string idDepto, string idMunic)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("P_CODSNIES_INST", Codsnies_Inst);
            parametros.Add("P_DEPTO", idDepto);
            parametros.Add("P_MUNIC", idMunic);
            DataTable objPrograma = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CONDONACION_FONDOS.SP_TRAER_PROGRAMAS", CommandType.StoredProcedure, parametros);
            return objPrograma;
        }

        /// <summary>
        /// Trae la lista de avales por convocatoria y nivel de formacion
        /// </summary>
        /// <param name="idConvocatoria">Identificador de la convocatoria</param>
        /// <param name="idNivel">Identificador del nivel de formacion</param>
        /// <returns>Retorna un objeto tipo DataTable con la informacion de los avales</returns>
        public DataTable TraerAvales(int idConvocatoria, int idNivel)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("P_IDCONVOCATORIA", idConvocatoria);
            parametros.Add("P_IDNIVEL", idNivel);
            DataTable objPrograma = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CONDONACION_FONDOS.SP_TRAER_AVALES", CommandType.StoredProcedure, parametros);
            return objPrograma;
        }

        #endregion
    }
}
