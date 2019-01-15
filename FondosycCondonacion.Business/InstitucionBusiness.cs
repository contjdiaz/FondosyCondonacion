using FondosycCondonacion.Business.Common;
using FondosycCondonacion.DAL;
using FondosycCondonacion.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FondosycCondonacion.Business
{
    public class InstitucionBusiness : IInstitucionBusiness
    {
        #region "DECLARACIONES"

        /// <summary>
        /// Instancia la clase de la capa de datos 
        /// </summary>
        private AdministracionDao administracionDao;

        public InstitucionBusiness()
        {
            this.administracionDao = new AdministracionDao();
        }

        #endregion

        #region "METODOS DE LA INTERFACE"

        /// <summary>
        /// Método que consulta los departamentos en el sistema
        /// </summary>
        /// <returns>objeto tipo list con la informacion de los departamentos</returns>
        public List<DepartamentoEntity> TraerDeptos()
        {
            DataTable vobjResultado = this.administracionDao.TraerDeptos();
            DepartamentoEntity seleccione = new DepartamentoEntity { IdDepto = "", Nombre = "  Seleccione..." };
            List<DepartamentoEntity> lstDeptos = Utilitario.ConvertTo<DepartamentoEntity>(vobjResultado);
            lstDeptos.Add(seleccione);
            return lstDeptos.OrderBy(d => d.Nombre).ToList<DepartamentoEntity>();
        }

        /// <summary>
        /// Método que consulta los municipios en el sistema
        /// </summary>
        /// <returns>objeto tipo List con la infomacion de los municipios</returns>
        public List<MunicipioEntity> TraerMunicipios(string idDepto)
        {
            DataTable vobjResultado = this.administracionDao.TraerMunicipios(idDepto);
            MunicipioEntity seleccione = new MunicipioEntity { IdMunicipio = "", Nombre = " Seleccione..." };
            List<MunicipioEntity> lstMunicipios = Utilitario.ConvertTo<MunicipioEntity>(vobjResultado);
            lstMunicipios.Add(seleccione);
            return lstMunicipios.OrderBy(m => m.Nombre).ToList<MunicipioEntity>();
        }

        /// <summary>
        /// Método que consulta las ies en el sistema
        /// </summary>
        /// <param name="idDepto">Identificador del departamento</param>
        /// <param name="idMunic">Identificador del municipio</param>
        /// <returns>Objeto tipo List con la informacion de las instituciones</returns>
        public List<InstitucionEntity> TraerInstituciones(string idDepto, string idMunic)
        {
            DataTable vobjResultado = this.administracionDao.TraerInstitucion(idDepto, idMunic);
            InstitucionEntity seleccione = new InstitucionEntity { Codsnies_Inst = "", Nombre = " Seleccione..." };
            List<InstitucionEntity> lstinstitucion = Utilitario.ConvertTo<InstitucionEntity>(vobjResultado);
            lstinstitucion.Add(seleccione);
            return lstinstitucion.OrderBy(i => i.Nombre).ToList<InstitucionEntity>();
        }

        /// <summary>
        /// Metodo que consulta los programas de la ies
        /// </summary>
        /// <param name="codSniesInst">Identificador de la ies</param>
        /// <returns>Objeto tipo List con la informacion de los programas</returns>
        public List<ProgramaEntity> TraerProgramas(string codSniesInst, string idDepto, string idMunic)
        {
            DataTable vobjResultado = this.administracionDao.TraerProgramas(codSniesInst, idDepto, idMunic);
            ProgramaEntity seleccione = new ProgramaEntity { CodSnies_Prog = "", Descripcion = " Seleccione..." };
            List<ProgramaEntity> lstprograma = Utilitario.ConvertTo<ProgramaEntity>(vobjResultado);
            lstprograma.Add(seleccione);
            return lstprograma.OrderBy(i => i.Descripcion).ToList<ProgramaEntity>();
        }

        /// <summary>
        /// Metodo que consulta los avales de la convocatoria
        /// </summary>
        /// <param name="idConvocatoria">Identificador de la convocatoria</param>
        /// /// <param name="idNivel">Identificador del nivel de formacion</param>
        /// <returns>Objeto tipo List con la informacion de los avales</returns>
        public List<AvalEntity> TraerAvales(int idConvocatoria, int idNivel)
        {
            DataTable vobjResultado = this.administracionDao.TraerAvales(idConvocatoria, idNivel);
            AvalEntity seleccione = new AvalEntity { IdAval = "", Nombre = " Seleccione..." };
            List<AvalEntity> lstaval = Utilitario.ConvertTo<AvalEntity>(vobjResultado);
            lstaval.Add(seleccione);
            return lstaval.OrderBy(i => i.Nombre).ToList<AvalEntity>();
        }

        #endregion
    }
}
