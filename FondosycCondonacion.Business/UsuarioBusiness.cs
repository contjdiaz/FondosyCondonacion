using ClosedXML.Excel;
using FondosycCondonacion.Business.Common;
using FondosycCondonacion.Business.Seguridad;
using FondosycCondonacion.DAL;
using FondosycCondonacion.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FondosycCondonacion.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        #region "DECLARACIONES"

        ///// <summary>
        ///// Usuario
        ///// </summary>
        //public UsuarioEntity Usuario { get; set; }

        /// <summary>
        /// Instancia la clase de la capa de datos de usuario
        /// </summary>
        private UsuarioDao usuarioDao;

        /// <summary>
        /// Constructor
        /// </summary>
        public UsuarioBusiness()
        {
            this.usuarioDao = new UsuarioDao();
        }

        /// <summary>
        /// Variable para cargar log4net
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(typeof(UsuarioBusiness));

        #endregion

        #region METODOS DE LA INTERFACE

        /// <summary>
        /// Metodo que valida usuario
        /// </summary>
        /// <param name="email">string de entrada</param>
        /// <param name="password">string de entrada</param>
        /// <param name="convocatoria">string de entrada</param>
        /// <returns>Retorna booleano</returns>
        public UsuarioEntity ValidarUsuario(string email, string password, string convocatoria)
        {
            UsuarioEntity usuario = new UsuarioEntity();
            usuario.SeAutentica = false;
            //bool ingreso = false;

            CRijndael MEncriptar = new CRijndael();
            string contraseniaEncriptada = MEncriptar.Encriptar(password);

            DataTable vobjResultado = this.usuarioDao.ValidarUsuario(email, contraseniaEncriptada, convocatoria);
            List<UsuarioEntity> lstusuario = Utilitario.ConvertTo<UsuarioEntity>(vobjResultado);

            if (lstusuario.Count > 0)
            {
                usuario = lstusuario.FirstOrDefault();
                usuario.SeAutentica = true;
            }

            return usuario;
        }

        /// <summary>
        /// Valida la autenticacion del usuario en el sistema c&ctex
        /// </summary>
        /// <param name="login">string de entrada</param>
        /// <param name="password">string de entrada</param>
        /// <param name="nameFile">string de entrada</param>
        /// <returns>Retorna booleano</returns>
        public bool ValidarUsuarioIcetex(string login, string password, string nameFile)
        {
            //UsuarioDao objUsuario = new UsuarioDao();

            string file = System.Web.Hosting.HostingEnvironment.MapPath("~/" + nameFile);
            string xmlString = System.IO.File.ReadAllText(file);
            List<UsuarioIcetexEntity> lstUsuarioIcetex = Utilitario.Deserialize<List<UsuarioIcetexEntity>>(xmlString);

            if (lstUsuarioIcetex.Exists(u => u.Login.ToUpper().Equals(login.ToUpper())))
            {
                string pass = this.usuarioDao.ValidarUsuarioIcetex(login);
                using (MD5 md5Hash = MD5.Create())
                {
                    return VerificarMd5Hash(md5Hash, password, pass);
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo que consulta beneficiarios registrados
        /// </summary>
        /// <param name="IdSolicitante">int de entrada</param>
        /// <param name="IdProceso">string de entrada</param>
        /// <returns>Retorna entidad UsuarioEntity</returns>
        public UsuarioEntity ObtenerBeneficiario(int IdSolicitante, string IdProceso)
        {
            DataTable vobjResultado = this.usuarioDao.ObtenerBeneficiario(IdSolicitante, IdProceso);
            List<UsuarioEntity> lstUsuario = Utilitario.ConvertTo<UsuarioEntity>(vobjResultado);

            if (lstUsuario.Count > 0)
                return lstUsuario.OrderBy(i => i.Fecha_Registro).Last();
            else
                return null;
        }

        /// <summary>
        /// Metodo que consulta beneficiarios registrados
        /// </summary>
        /// <param name="IdSolicitante">int de entrada</param>
        /// <param name="IdProceso">string de entrada</param>
        /// <returns>Retorna lista UsuarioEntity</returns>
        public List<UsuarioEntity> ObtenerListadoBeneficiario(int IdSolicitante, string IdProceso)
        {
            DataTable vobjResultado = this.usuarioDao.ObtenerBeneficiario(IdSolicitante, IdProceso);
            List<UsuarioEntity> lstUsuario = Utilitario.ConvertTo<UsuarioEntity>(vobjResultado);

            if (lstUsuario.Count > 0)
            {
                if (IdProceso.Equals("C") && lstUsuario.Exists(u => Enumerable.Range(4, 5).Contains(u.IdEstado)))
                {
                    List<UsuarioEntity> lstUsuarioAux = new List<UsuarioEntity>();

                    foreach (UsuarioEntity usuario in lstUsuario)
                    {
                        lstUsuarioAux.Add(usuario);

                        if (Enumerable.Range(4, 5).Contains(usuario.IdEstado))
                            lstUsuarioAux.Add(new UsuarioEntity() { IsRowEmpty = true });
                    }

                    lstUsuario = lstUsuarioAux;
                }

                return lstUsuario;
            }
            else
                return null;
        }

        /// <summary>
        /// Metodo que consulta beneficiarios registrados para una convocatoria en Aval o Condonacion
        /// </summary>
        /// <param name="IdConvocatoria">int de entrada</param>
        /// <param name="IdProceso">string de entrada</param>
        /// <param name="TipoArchivo">int de entrada</param>
        /// <returns></returns>
        public List<UsuarioEntity> ObtenerBeneficiarios(int IdConvocatoria, string IdProceso, int TipoArchivo)
        {
            DataTable vobjResultado = this.usuarioDao.ObtenerBeneficiarios(IdConvocatoria, IdProceso, TipoArchivo);
            List<UsuarioEntity> lstUsuario = Utilitario.ConvertTo<UsuarioEntity>(vobjResultado);

            return lstUsuario;
        }

        /// <summary>
        /// Metodo que consulta puntaje de beneficiarios registrados
        /// </summary
        /// <returns>Retorna listado de objeto UsuarioEntity</returns>
        public List<UsuarioEntity> ObtenerPuntajeBeneficiarios()
        {
            DataTable vobjResultado = this.usuarioDao.ObtenerPuntajeBeneficiarios();
            List<UsuarioEntity> lstUsuario = Utilitario.ConvertTo<UsuarioEntity>(vobjResultado);

            return lstUsuario;
        }

        /// <summary>
        /// Registra beneficiario en aval
        /// </summary>
        /// <param name="usuarioEntity">UsuarioEntity de entrada</param>
        /// <returns>Retorna string</returns>
        public string RegistrarBeneficiarioAval(UsuarioEntity usuarioEntity)
        {
            //UsuarioDao objUsuario = new UsuarioDao();
            DataTable vobjResultado = this.usuarioDao.RegistrarBeneficiarioAval(usuarioEntity.Codsnies_Inst, usuarioEntity.CodSnies_Prog, usuarioEntity.Fecha_Finalizacion_Materias,    Convert.ToInt32(usuarioEntity.IdAval), usuarioEntity.IdSolicitante, usuarioEntity.RutaArchivo1, usuarioEntity.IdEstado, usuarioEntity.IdNivel, usuarioEntity.IdDepartamento, usuarioEntity.IdMunicipio, usuarioEntity.Observacion, Convert.ToInt32(usuarioEntity.IdConvocatoria));
            List<UsuarioEntity> lstUsuario = Utilitario.ConvertTo<UsuarioEntity>(vobjResultado);
            return lstUsuario.FirstOrDefault().IdRadicado;
        }

        /// <summary>
        /// Registra beneficiario en condonacion
        /// </summary>
        /// <param name="usuarioEntity">UsuarioEntity de entrada</param>
        /// <returns>Retorna RespuestaAjax</returns>
        public RespuestaAjax RegistrarBeneficiarioCondonacion(UsuarioEntity usuarioEntity)
        {
            RespuestaAjax Respuesta = new RespuestaAjax();

            //UsuarioDao objUsuario = new UsuarioDao();
            DataTable vobjResultado = this.usuarioDao.RegistrarBeneficiarioCondonacion(usuarioEntity.IdSolicitante,
                usuarioEntity.IdEstado, usuarioEntity.IdNivel, usuarioEntity.Observacion, usuarioEntity.IdConvocatoria,
                usuarioEntity.CertifPermEstado, usuarioEntity.CertifPromNotas, usuarioEntity.CertifProgCursado,
                usuarioEntity.CertifDiploma, usuarioEntity.CertifSoporte, usuarioEntity.VideoYoutube,
                usuarioEntity.CertifVideo, usuarioEntity.CertifFinMateria,
                usuarioEntity.CertifDocsRequeridos, usuarioEntity.CertifDocSubsanacion);

            if (vobjResultado != null)
            {
                List<UsuarioEntity> lstUsuario = Utilitario.ConvertTo<UsuarioEntity>(vobjResultado);
                Respuesta.Mensage = string.Format("La solicitud fue radicada exitosamente con el radicado # {0}",
                                    lstUsuario.FirstOrDefault().IdRadicado);
                Respuesta.Estado = EstadoRespuesta.OK;
            }
            else
            {
                Respuesta.Mensage = "Error al insertar información en el Formulario de Condonación";
                Respuesta.Estado = EstadoRespuesta.ERROR;
            }

            return Respuesta;
        }

        /// <summary>
        /// Actualiza beneficiario en condonacion
        /// </summary>
        /// <param name="usuarioEntity">UsuarioEntity de entrada</param>
        /// <returns>Retorna RespuestaAjax</returns>
        public RespuestaAjax ActualizarBeneficiarioCondonacion(UsuarioEntity usuarioEntity)
        {
            RespuestaAjax Respuesta = new RespuestaAjax();

            //UsuarioDao objUsuario = new UsuarioDao();
            Respuesta.Mensage = this.usuarioDao.ActualizarBeneficiarioCondonacion(usuarioEntity.IdSolicitante,
                usuarioEntity.IdEstado,
                usuarioEntity.IdEstado.Equals(4) ? usuarioEntity.CertifDocsRequeridos : usuarioEntity.CertifDocSubsanacion,
                usuarioEntity.Observacion);

            if (Respuesta.Mensage.Equals("0"))
            {
                Respuesta.Mensage = "Error al actualizar información en el Formulario de Condonación";
                Respuesta.Estado = EstadoRespuesta.ERROR;
            }
            else
            {
                Respuesta.Mensage = string.Format("La solicitud con radicado # {0} fue actualizada exitosamente en el Formulario de Condonación",
                         usuarioEntity.IdRadicado);
                Respuesta.Estado = EstadoRespuesta.OK;
            }

            return Respuesta;
        }

        /// <summary>
        /// Actualiza beneficiario
        /// </summary>
        /// <param name="IdRadicado">string de entrada</param>
        /// <param name="IdEstado">int de entrada</param>
        /// <param name="Observacion">string de entrada</param>
        /// <param name="UsuarioModifica">string de entrada</param>
        /// <returns>Retorna RespuestaAjax</returns>
        public RespuestaAjax ActualizarBeneficiario(string IdRadicado, int IdEstado, string Observacion, string UsuarioModifica)
        {
            RespuestaAjax Respuesta = new RespuestaAjax();

            try
            {
                //UsuarioDao objUsuario = new UsuarioDao();
                this.usuarioDao.ActualizarBeneficiario(IdRadicado, IdEstado, Observacion, UsuarioModifica);
                Respuesta.Estado = EstadoRespuesta.OK;
                Respuesta.Mensage = "Los datos han sido actualizados exitosamente.";
            }
            catch (Exception e)
            {
                Respuesta.Estado = EstadoRespuesta.ERROR;
                Respuesta.Mensage = e.Message;

            }
            return Respuesta;
        }

        /// <summary>
        /// Actualiza puntaje
        /// </summary>
        /// <param name="IdSolicitante">int de entrada</param>
        /// <param name="Puntaje">int de entrada</param>
        /// <param name="Cumplepuntaje">string de entrada</param>
        /// <param name="UsuarioModifica">string de entrada</param>
        /// <returns>Retorna RespuestaAjax</returns>
        public RespuestaAjax ActualizarPuntaje(int IdSolicitante, int Puntaje, string Cumplepuntaje, string UsuarioModifica)
        {
            RespuestaAjax Respuesta = new RespuestaAjax();

            try
            {
                //UsuarioDao objUsuario = new UsuarioDao();
                this.usuarioDao.ActualizarPuntaje(IdSolicitante, Puntaje, Cumplepuntaje, UsuarioModifica);
                Respuesta.Estado = EstadoRespuesta.OK;
                Respuesta.Mensage = "Los datos han sido actualizados exitosamente.";
            }
            catch (Exception ex)
            {
                Respuesta.Estado = EstadoRespuesta.ERROR;
                Respuesta.Mensage = ex.Message;
                log.Error("Error en metodo ActualizarPuntaje - Layer Business", ex);
            }
            return Respuesta;
        }

        /// <summary>
        /// Genera el excel de beneficiarios
        /// </summary>
        /// <param name="plantillaExcel">string de entrada</param>
        /// <param name="IdConvocatoria">int de entrada</param>
        /// <param name="IdProceso">string de entrada</param>
        /// <param name="tipoArchivo">int de entrada</param>
        /// <returns></returns>
        public System.IO.Stream GenerarBeneficiariosExcel(string plantillaExcel, int IdConvocatoria, string IdProceso, int tipoArchivo)
        {
            var archivoExcel = new XLWorkbook(plantillaExcel);
            var HojaExcel = archivoExcel.Worksheet("Plantilla");
            int idfila = 2;

            List<UsuarioEntity> lista = new List<UsuarioEntity>();
            lista = this.ObtenerBeneficiarios(IdConvocatoria, IdProceso, tipoArchivo);

            foreach (UsuarioEntity user in lista)
            {
                HojaExcel.Cell(idfila, 1).Value = user.IdRadicado;
                HojaExcel.Cell(idfila, 1).DataType = XLCellValues.Text;

                HojaExcel.Cell(idfila, 2).Value = user.IdSolicitante;
                HojaExcel.Cell(idfila, 2).DataType = XLCellValues.Number;

                HojaExcel.Cell(idfila, 3).Value = user.NombreCompleto;
                HojaExcel.Cell(idfila, 3).DataType = XLCellValues.Text;

                HojaExcel.Cell(idfila, 4).Value = user.NombreDepartamento;
                HojaExcel.Cell(idfila, 4).DataType = XLCellValues.Text;

                HojaExcel.Cell(idfila, 5).Value = user.NombreMunicipio;
                HojaExcel.Cell(idfila, 5).DataType = XLCellValues.Text;

                HojaExcel.Cell(idfila, 6).Value = user.NombreInstitucion;
                HojaExcel.Cell(idfila, 6).DataType = XLCellValues.Text;

                HojaExcel.Cell(idfila, 7).Value = user.NombrePrograma;
                HojaExcel.Cell(idfila, 7).DataType = XLCellValues.Text;

                HojaExcel.Cell(idfila, 8).Value = user.Fecha_Finalizacion_Materias;
                HojaExcel.Cell(idfila, 8).DataType = XLCellValues.DateTime;

                HojaExcel.Cell(idfila, 9).Value = user.NombreAval;
                HojaExcel.Cell(idfila, 9).DataType = XLCellValues.Text;

                HojaExcel.Cell(idfila, 10).Value = user.RutaArchivo1;
                HojaExcel.Cell(idfila, 10).DataType = XLCellValues.Text;

                HojaExcel.Cell(idfila, 11).Value = user.Fecha_Registro;
                HojaExcel.Cell(idfila, 11).DataType = XLCellValues.DateTime;

                HojaExcel.Cell(idfila, 12).Value = user.NombreEstado;
                HojaExcel.Cell(idfila, 12).DataType = XLCellValues.Text;

                HojaExcel.Cell(idfila, 13).Value = user.Observacion;
                HojaExcel.Cell(idfila, 13).DataType = XLCellValues.Text;

                // Si la descarga es registo de calificacion para condonacion
                if (tipoArchivo.Equals(1) && IdProceso.Equals("C"))
                {
                    HojaExcel.Cell(idfila, 14).Value = user.VideoYoutube;
                    HojaExcel.Cell(idfila, 14).DataType = XLCellValues.Text;
                }
                // Si la descarga es registro de historico
                if (tipoArchivo.Equals(2))
                {
                    HojaExcel.Cell(idfila, 14).Value = user.UsuarioModifica;
                    HojaExcel.Cell(idfila, 14).DataType = XLCellValues.Text;
                }

                idfila++;
            }

            //cargar la informacion al excel (OJO CON LOS FORMATOS DE LA PLANTILLA EJEMPLO QUE ENVIE!!)
            using (System.IO.MemoryStream strmObjetoSerializado = new System.IO.MemoryStream())
            {
                archivoExcel.SaveAs(strmObjetoSerializado);
                return strmObjetoSerializado;
            }
        }

        /// <summary>
        /// Genera el excel de beneficiarios
        /// </summary>
        /// <param name="plantillaExcel">string de entrada</param>
        /// <returns></returns>
        public System.IO.Stream GenerarPuntajeExcel(string plantillaExcel)
        {
            var archivoExcel = new XLWorkbook(plantillaExcel);
            var HojaExcel = archivoExcel.Worksheet("Plantilla");
            int idfila = 2;

            List<UsuarioEntity> lista = new List<UsuarioEntity>();
            lista = this.ObtenerPuntajeBeneficiarios();

            foreach (UsuarioEntity user in lista)
            {
                HojaExcel.Cell(idfila, 1).Value = user.IdSolicitante;
                HojaExcel.Cell(idfila, 1).DataType = XLCellValues.Number;

                HojaExcel.Cell(idfila, 2).Value = user.PuntajeParticipacion;
                HojaExcel.Cell(idfila, 2).DataType = XLCellValues.Number;

                HojaExcel.Cell(idfila, 3).Value = user.CumplePuntaje;
                HojaExcel.Cell(idfila, 3).DataType = XLCellValues.Text;

                idfila++;
            }

            //cargar la informacion al excel (OJO CON LOS FORMATOS DE LA PLANTILLA EJEMPLO QUE ENVIE!!)
            using (System.IO.MemoryStream strmObjetoSerializado = new System.IO.MemoryStream())
            {
                archivoExcel.SaveAs(strmObjetoSerializado);
                return strmObjetoSerializado;
            }
        }

        #endregion

        #region METODOS FUERA DE LA INTERFACE

        /// <summary>
        /// Compara el hash del usuario autenticado contra el passwodr de bd
        /// </summary>
        /// <param name="md5Hash">Hash</param>
        /// <param name="password">Pasword del usuario autenticado</param>
        /// <param name="passwordBD">Password en base de datos</param>
        private static bool VerificarMd5Hash(MD5 md5Hash, string password, string passwordBD)
        {
            string hashPassword = ObtenerMd5Hash(md5Hash, password);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashPassword, passwordBD))
                return true;
            return false;
        }

        /// <summary>
        /// Crea el hast del usuario autenticado
        /// </summary>
        /// <param name="md5Hash">Hash</param>
        /// <param name="password">Password usuario autenticado</param>
        private static string ObtenerMd5Hash(MD5 md5Hash, string password)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        #endregion
    }
}
