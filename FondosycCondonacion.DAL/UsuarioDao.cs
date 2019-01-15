using Icetex.ODAL;
using log4net;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace FondosycCondonacion.DAL
{
    public class UsuarioDao
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UsuarioDao));

        private Transactions transactions;

        public UsuarioDao()
        {
            //this.transactions = new Transactions();
        }

        ///// <summary>
        ///// Valida credenciales de usuario para verificar login
        ///// </summary>
        ///// <param name="email">Email del usuario</param>
        ///// <param name="password">Password</param>
        ///// <returns>Retorna estado de autenticacion de usuario</returns>
        //public DataTable ValidarUsuario(string email, string password, string convocatoria)
        //{
        //    Dictionary<string, object> parametros = new Dictionary<string, object>();
        //    parametros.Add("P_EMAIL", email);
        //    parametros.Add("P_PASSWORD", password);
        //    parametros.Add("P_CONVOCATORIA", convocatoria);
        //    DataTable objUsuario = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CONDONACION_FONDOS.SP_VALIDAR_USUARIO", CommandType.StoredProcedure, parametros);
        //    return objUsuario;
        //}

        ///// <summary>
        ///// Consulta el pasword del usuario a partir del login
        ///// </summary>
        ///// <param name="login">login del usuario</param>
        ///// <returns>pasword del usuario</returns>
        //public string ValidarUsuarioIcetex(string login)
        //{
        //    Dictionary<string, object> parametros = new Dictionary<string, object>();
        //    string password = string.Empty;
        //    DataTable objUsuario;
        //    parametros.Add("P_USUARIO", login);
        //    objUsuario = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CON_UTILIDADES.TECNO_OPER_VALIDAR_USUARIO", CommandType.StoredProcedure, parametros);

        //    if (objUsuario.Rows.Count != 0)
        //        password = objUsuario.Rows[0]["PASSWORD"].ToString();

        //    return password;
        //}

        ///// <summary>
        ///// Obtiene o validad si existe beneficiario 
        ///// </summary>
        ///// <param name="IdSolicitante">Identificador del solicitante</param>
        ///// <returns>Retorna objeto datatable de informacion del beneficiario</returns>
        //public DataTable ObtenerBeneficiario(int IdSolicitante, string IdProceso)
        //{
        //    Dictionary<string, object> parametros = new Dictionary<string, object>();
        //    parametros.Add("P_IDSOLICITANTE", IdSolicitante);
        //    parametros.Add("P_IDPROCESO", IdProceso);
        //    DataTable objUsuario = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CONDONACION_FONDOS.SP_VALIDAR_BENEFICIARIO", CommandType.StoredProcedure, parametros);
        //    return objUsuario;
        //}

        ///// <summary>
        ///// Obtiene o validad si existe beneficiario 
        ///// </summary>
        ///// <param name="IdConvocatoria">Identificador del beneficiario</param>
        ///// <param name="IdProceso">Identificador del proceso</param>
        ///// <param name="TipoArchivo">Identificador del tipo de archivo</param>
        ///// <returns>Retorna objeto datatable de informacion del beneficiario</returns>
        //public DataTable ObtenerBeneficiarios(int IdConvocatoria, string IdProceso, int TipoArchivo)
        //{
        //    Dictionary<string, object> parametros = new Dictionary<string, object>();
        //    parametros.Add("P_IDCONVOCATORIA", IdConvocatoria);
        //    parametros.Add("P_IDPROCESO", IdProceso);
        //    parametros.Add("P_TIPOARCHIVO", TipoArchivo);
        //    DataTable objUsuario = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CONDONACION_FONDOS.SP_TRAER_BENEFICIARIO", CommandType.StoredProcedure, parametros);
        //    return objUsuario;
        //}

        ///// <summary>
        ///// Obtiene listado de beneficiarios con sus puntajes
        ///// </summary>
        ///// <returns>Retorna objeto datatable de informacion del beneficiario</returns>
        //public DataTable ObtenerPuntajeBeneficiarios()
        //{
        //    DataTable objUsuario = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CONDONACION_FONDOS.SP_TRAER_PUNTAJE_BENEFICIARIO", CommandType.StoredProcedure, null);
        //    return objUsuario;
        //}

        ///// <summary>
        ///// Método que registra o actualiza la informacion bancaria de la institucion
        ///// </summary>
        //public DataTable RegistrarBeneficiarioAval(string Codsnies_Inst, string CodSnies_Prog, DateTime FechaFinalizacion_Materias, string IdAval, int IdSolicitante, string RutaArchivo1, int IdEstado, int IdNivel, string IdDepto, string IdMunicipio, string Observacion, string IdConvocatoria)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parametros = new Dictionary<string, object>();
        //        parametros.Add("P_CODSNIES_INST", Codsnies_Inst);
        //        parametros.Add("P_CODSNIES_PROG", CodSnies_Prog);
        //        parametros.Add("P_FECHA_FINALIZACION_MATERIAS", FechaFinalizacion_Materias);
        //        parametros.Add("P_IDAVAL", IdAval);
        //        parametros.Add("P_IDSOLICITANTE", IdSolicitante);
        //        parametros.Add("P_RUTAARCHIVO1", RutaArchivo1);
        //        parametros.Add("P_IDESTADO", IdEstado);
        //        parametros.Add("P_FECHA_REGISTRO", DateTime.Now);
        //        parametros.Add("P_IDNIVEL", IdNivel);
        //        parametros.Add("P_DEPTO", IdDepto);
        //        parametros.Add("P_MUNIC", IdMunicipio);
        //        parametros.Add("P_OBSERVACION", Observacion);
        //        parametros.Add("P_IDCONVOCATORIA", IdConvocatoria);
        //        parametros.Add("P_IDPROCESO", "A");
        //        DataTable objUsuario = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CONDONACION_FONDOS.SP_CREAR_BENEFICIARIO_AVAL", CommandType.StoredProcedure, parametros);

        //        return objUsuario;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //        //cmd.Transaction.Rollback();
        //        //con.Close();
        //    }
        //}

        /// <summary>
        /// Valida credenciales de usuario para verificar login
        /// </summary>
        /// <param name="email">Email del usuario</param>
        /// <param name="password">Password</param>
        /// <returns>Retorna estado de autenticacion de usuario</returns>
        public DataTable ValidarUsuario(string email, string password, string convocatoria)
        {
            //Dictionary<string, object> parametros = new Dictionary<string, object>();
            //parametros.Add("P_EMAIL", email);
            //parametros.Add("P_PASSWORD", password);
            //parametros.Add("P_CONVOCATORIA", convocatoria);
            //DataTable objUsuario = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CONDONACION_FONDOS.SP_VALIDAR_USUARIO", CommandType.StoredProcedure, parametros);
            //return objUsuario;

            try
            {
                transactions = new Transactions();
                OracleParameter[] parameters = new OracleParameter[] {
                    new OracleParameter("P_EMAIL", email),
                    new OracleParameter("P_PASSWORD", password),
                    new OracleParameter("P_CONVOCATORIA", convocatoria),
                    new OracleParameter("CUR_OUT", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output)};

                return transactions.ExecuteDataTableCMD("PKG_CONDONACION_FONDOS.SP_VALIDAR_USUARIO", parameters);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Consulta el pasword del usuario a partir del login
        /// </summary>
        /// <param name="login">login del usuario</param>
        /// <returns>pasword del usuario</returns>
        public string ValidarUsuarioIcetex(string login)
        {
            //Dictionary<string, object> parametros = new Dictionary<string, object>();
            //string password = string.Empty;
            //DataTable objUsuario;
            //parametros.Add("P_USUARIO", login);
            //objUsuario = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CON_UTILIDADES.TECNO_OPER_VALIDAR_USUARIO", CommandType.StoredProcedure, parametros);

            //if (objUsuario.Rows.Count != 0)
            //    password = objUsuario.Rows[0]["PASSWORD"].ToString();

            //return password;

            try
            {
                transactions = new Transactions();
                string password = string.Empty;

                OracleParameter[] parameters = new OracleParameter[] {
                    new OracleParameter("P_USUARIO", login),
                    new OracleParameter("CUR_OUT", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output)};

                DataTable dt = new DataTable();
                dt = transactions.ExecuteDataTableCMD("PKG_CON_UTILIDADES.TECNO_OPER_VALIDAR_USUARIO", parameters);

                if (dt.Rows.Count != 0)
                {
                    password = dt.Rows[0]["PASSWORD"].ToString();
                }

                return password;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene o validad si existe beneficiario 
        /// </summary>
        /// <param name="IdSolicitante">Identificador del solicitante</param>
        /// <returns>Retorna objeto datatable de informacion del beneficiario</returns>
        public DataTable ObtenerBeneficiario(int IdSolicitante, string IdProceso)
        {
            //Dictionary<string, object> parametros = new Dictionary<string, object>();
            //parametros.Add("P_IDSOLICITANTE", IdSolicitante);
            //parametros.Add("P_IDPROCESO", IdProceso);
            //DataTable objUsuario = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CONDONACION_FONDOS.SP_VALIDAR_BENEFICIARIO", CommandType.StoredProcedure, parametros);
            //return objUsuario;

            try
            {
                transactions = new Transactions();
                OracleParameter[] parameters = new OracleParameter[] {
                    new OracleParameter("P_IDSOLICITANTE", IdSolicitante),
                    new OracleParameter("P_IDPROCESO", IdProceso),
                    new OracleParameter("cur_OUT", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output)};

                return transactions.ExecuteDataTableCMD("PKG_CONDONACION_FONDOS.SP_VALIDAR_BENEFICIARIO", parameters);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene o validad si existe beneficiario 
        /// </summary>
        /// <param name="IdConvocatoria">Identificador del beneficiario</param>
        /// <param name="IdProceso">Identificador del proceso</param>
        /// <param name="TipoArchivo">Identificador del tipo de archivo</param>
        /// <returns>Retorna objeto datatable de informacion del beneficiario</returns>
        public DataTable ObtenerBeneficiarios(int IdConvocatoria, string IdProceso, int TipoArchivo)
        {
            //Dictionary<string, object> parametros = new Dictionary<string, object>();
            //parametros.Add("P_IDCONVOCATORIA", IdConvocatoria);
            //parametros.Add("P_IDPROCESO", IdProceso);
            //parametros.Add("P_TIPOARCHIVO", TipoArchivo);
            //DataTable objUsuario = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CONDONACION_FONDOS.SP_TRAER_BENEFICIARIO", CommandType.StoredProcedure, parametros);
            //return objUsuario;

            try
            {
                transactions = new Transactions();
                OracleParameter[] parameters = new OracleParameter[] {
                    new OracleParameter("P_IDCONVOCATORIA", IdConvocatoria),
                    new OracleParameter("P_IDPROCESO", IdProceso),
                    new OracleParameter("P_TIPOARCHIVO", TipoArchivo),
                    new OracleParameter("CUR_OUT", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output)};

                return transactions.ExecuteDataTableCMD("PKG_CONDONACION_FONDOS.SP_TRAER_BENEFICIARIO", parameters);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene listado de beneficiarios con sus puntajes
        /// </summary>
        /// <returns>Retorna objeto datatable de informacion del beneficiario</returns>
        public DataTable ObtenerPuntajeBeneficiarios()
        {
            //DataTable objUsuario = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CONDONACION_FONDOS.SP_TRAER_PUNTAJE_BENEFICIARIO", CommandType.StoredProcedure, null);
            //return objUsuario;

            try
            {
                transactions = new Transactions();
                OracleParameter[] parameters = new OracleParameter[] {
                    new OracleParameter("CUR_OUT", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output)};

                return transactions.ExecuteDataTableCMD("PKG_CONDONACION_FONDOS.SP_TRAER_PUNTAJE_BENEFICIARIO", parameters);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Método que registra o actualiza la informacion bancaria de la institucion
        /// </summary>
        public DataTable RegistrarBeneficiarioAval(string Codsnies_Inst, string CodSnies_Prog,
            DateTime FechaFinalizacion_Materias,
            int IdAval,
            int IdSolicitante, string RutaArchivo1, int IdEstado,
            int IdNivel, string IdDepto, string IdMunicipio, string Observacion,
            int IdConvocatoria)
        {
            //try
            //{
            //    Dictionary<string, object> parametros = new Dictionary<string, object>();
            //    parametros.Add("P_CODSNIES_INST", Codsnies_Inst);
            //    parametros.Add("P_CODSNIES_PROG", CodSnies_Prog);
            //    parametros.Add("P_FECHA_FINALIZACION_MATERIAS", FechaFinalizacion_Materias);
            //    parametros.Add("P_IDAVAL", IdAval);
            //    parametros.Add("P_IDSOLICITANTE", IdSolicitante);
            //    parametros.Add("P_RUTAARCHIVO1", RutaArchivo1);
            //    parametros.Add("P_IDESTADO", IdEstado);
            //    parametros.Add("P_FECHA_REGISTRO", DateTime.Now);
            //    parametros.Add("P_IDNIVEL", IdNivel);
            //    parametros.Add("P_DEPTO", IdDepto);
            //    parametros.Add("P_MUNIC", IdMunicipio);
            //    parametros.Add("P_OBSERVACION", Observacion);
            //    parametros.Add("P_IDCONVOCATORIA", IdConvocatoria);
            //    parametros.Add("P_IDPROCESO", "A");
            //    DataTable objUsuario = OracleDataProvider.DBInstance.EjecutarADataTable("PKG_CONDONACION_FONDOS.SP_CREAR_BENEFICIARIO_AVAL", CommandType.StoredProcedure, parametros);

            //    return objUsuario;
            //}
            //catch (Exception)
            //{
            //    return null;
            //    //cmd.Transaction.Rollback();
            //    //con.Close();
            //}

            try
            {
                transactions = new Transactions();
                OracleParameter[] parameters = new OracleParameter[] {
                    new OracleParameter("P_CODSNIES_INST", Codsnies_Inst),
                    new OracleParameter("P_CODSNIES_PROG", CodSnies_Prog),
                    new OracleParameter("P_FECHA_FINALIZACION_MATERIAS", FechaFinalizacion_Materias),
                    new OracleParameter("P_IDAVAL", IdAval),
                    new OracleParameter("P_IDSOLICITANTE", IdSolicitante),
                    new OracleParameter("P_RUTAARCHIVO1", RutaArchivo1),
                    new OracleParameter("P_IDESTADO", IdEstado),
                    new OracleParameter("P_FECHA_REGISTRO", DateTime.Now),
                    new OracleParameter("P_IDNIVEL", IdNivel),
                    new OracleParameter("P_DEPTO", IdDepto),
                    new OracleParameter("P_MUNIC", IdMunicipio),
                    new OracleParameter("P_OBSERVACION", Observacion),
                    new OracleParameter("P_IDPROCESO", "A"),
                    new OracleParameter("P_IDCONVOCATORIA", IdConvocatoria),
                    new OracleParameter("cur_OUT", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output)};

                return transactions.ExecuteDataTableCMD("PKG_CONDONACION_FONDOS.SP_CREAR_BENEFICIARIO_AVAL", parameters);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Método que registra la informacion del beneficiario en la etapa de condonacion
        /// </summary>
        public DataTable RegistrarBeneficiarioCondonacion(int IdSolicitante, int IdEstado, int IdNivel, string Observacion,
            string IdConvocatoria, string CertifPermEstado, string CertifPromNotas, string CertifProgCursado,
            string CertifDiploma, string CertifSoporte, string VideoYoutube, string CertifVideo, string CertifFinMateria,
            string CertifDocsRequeridos, string CertifDocSubsanacion)
        {
            transactions = new Transactions();
            OracleParameter[] parameters = new OracleParameter[] {
                    new OracleParameter("P_IDSOLICITANTE", OracleDbType.Int32, IdSolicitante, ParameterDirection.Input),
                    new OracleParameter("P_IDESTADO", OracleDbType.Int32, IdEstado, ParameterDirection.Input),
                    new OracleParameter("P_FECHA_REGISTRO", OracleDbType.Date, DateTime.Now, ParameterDirection.Input),
                    new OracleParameter("P_IDNIVEL", OracleDbType.Int32, IdNivel, ParameterDirection.Input),
                    new OracleParameter("P_OBSERVACION", OracleDbType.Varchar2, Observacion, ParameterDirection.Input),
                    new OracleParameter("P_IDPROCESO", OracleDbType.Varchar2, "C", ParameterDirection.Input),
                    new OracleParameter("P_IDCONVOCATORIA", OracleDbType.Int32, Convert.ToInt32(IdConvocatoria), ParameterDirection.Input),
                    new OracleParameter("P_CERTIFPERMESTADO", OracleDbType.Varchar2, CertifPermEstado, ParameterDirection.Input),
                    new OracleParameter("P_CERTIFPROMNOTAS", OracleDbType.Varchar2, CertifPromNotas, ParameterDirection.Input),
                    new OracleParameter("P_CERTIFPROGCURSADO", OracleDbType.Varchar2, CertifProgCursado, ParameterDirection.Input),
                    new OracleParameter("P_CERTIFDIPLOMA", OracleDbType.Varchar2, CertifDiploma, ParameterDirection.Input),
                    new OracleParameter("P_CERTIFSOPORTE", OracleDbType.Varchar2, CertifSoporte, ParameterDirection.Input),
                    new OracleParameter("P_VIDEOYOUTUBE", OracleDbType.Varchar2, VideoYoutube, ParameterDirection.Input),
                    new OracleParameter("P_CERTIFVIDEO", OracleDbType.Varchar2, CertifVideo, ParameterDirection.Input),
                    new OracleParameter("P_CERTIFFINMATERIA", OracleDbType.Varchar2, CertifFinMateria, ParameterDirection.Input),
                    new OracleParameter("P_CERTIFDOCSREQUERIDOS", OracleDbType.Varchar2, CertifDocsRequeridos, ParameterDirection.Input),
                    new OracleParameter("P_CERTIFDOCSUBSANACION", OracleDbType.Varchar2, CertifDocSubsanacion, ParameterDirection.Input),
                    new OracleParameter("CUR_OUT", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output)};

            return transactions.ExecuteDataTableCMD("PKG_CONDONACION_FONDOS.SP_CREAR_BENEFICIARIO_COND", parameters);
        }

        /// <summary>
        /// Método que actualiza la informacion del beneficiario en la etapa de condonacion
        /// </summary>
        public string ActualizarBeneficiarioCondonacion(int IdSolicitante, int IdEstado, string Certificado, string Observacion)
        {
            transactions = new Transactions();
            OracleParameter[] parameters = new OracleParameter[] {
                    new OracleParameter("P_IDSOLICITANTE", OracleDbType.Int32, IdSolicitante, ParameterDirection.Input),
                    new OracleParameter("P_IDESTADO", OracleDbType.Int32, IdEstado, ParameterDirection.Input),
                    new OracleParameter("P_FECHAMODIFICA", OracleDbType.Date, DateTime.Now, ParameterDirection.Input),
                    new OracleParameter("P_CERTIFICADO", OracleDbType.Varchar2, Certificado, ParameterDirection.Input),
                    new OracleParameter("P_OBSERVACION", OracleDbType.Varchar2, Observacion, ParameterDirection.Input)};

            return transactions.ExecuteCMD("PKG_CONDONACION_FONDOS.SP_ACTUALIZA_DOC_BENEF_COND", parameters).ToString();
        }

        /// <summary>
        /// Método que actualiza la informacion del beneficiario
        /// </summary>
        public void ActualizarBeneficiario(string IdRadicado, int IdEstado, string Observacion, string UsuarioModifica)
        {
            transactions = new Transactions();
            OracleParameter[] parameters = new OracleParameter[] {
             new OracleParameter("P_IDRADICADO", OracleDbType.Varchar2, IdRadicado, ParameterDirection.Input),
             new OracleParameter("P_IDESTADO", OracleDbType.Int32, IdEstado, ParameterDirection.Input),
             new OracleParameter("P_OBSERVACION", OracleDbType.Varchar2, Observacion, ParameterDirection.Input),
             new OracleParameter("P_USUARIOMODIFICA", OracleDbType.Varchar2, UsuarioModifica, ParameterDirection.Input),
             new OracleParameter("P_FECHAMODIFICA", OracleDbType.Date, DateTime.Now, ParameterDirection.Input)};

            transactions.ExecuteCMD("PKG_CONDONACION_FONDOS.SP_ACTUALIZAR_BENEFICIARIO", parameters);
            transactions = null;
        }

        /// <summary>
        /// Metodo que actualiza puntaje de beneficiarios
        /// </summary>
        /// <param name="IdSolicitante"></param>
        /// <param name="Puntaje"></param>
        /// <param name="Cumplepuntaje"></param>
        /// <param name="UsuarioModifica"></param>
        public void ActualizarPuntaje(int IdSolicitante, int Puntaje, string Cumplepuntaje, string UsuarioModifica)
        {
            transactions = new Transactions();
            OracleParameter[] parameters = new OracleParameter[] {
            new OracleParameter("P_IDSOLICITANTE", OracleDbType.Int32, IdSolicitante, ParameterDirection.Input),
            new OracleParameter("P_PUNTAJEPARTICIPACION", OracleDbType.Int32, Puntaje, ParameterDirection.Input),
            new OracleParameter("P_CUMPLEPUNTAJE", OracleDbType.Varchar2, Cumplepuntaje, ParameterDirection.Input),
            new OracleParameter("P_USUARIOMODIFICA", OracleDbType.Varchar2, UsuarioModifica, ParameterDirection.Input),
            new OracleParameter("P_FECHAMODIFICA", OracleDbType.Date, DateTime.Now, ParameterDirection.Input)};

            transactions.ExecuteCMD("PKG_CONDONACION_FONDOS.SP_ACTUALIZAR_PUNTAJE", parameters);
            transactions = null;
        }
    }
}
