using Excel;
using FondosycCondonacion.Business;
using FondosycCondonacion.Business.Common;
using FondosycCondonacion.Entities;
using log4net;
using Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FondosycCondonacion.UI.Administracion
{
    public partial class CalificarBeneficiario : System.Web.UI.Page
    {
        #region "DECLARACIONES"

        UsuarioIcetexEntity usuarioEntity = new UsuarioIcetexEntity();

        /// <summary>
        /// Instancia la clase Institucion de la entidad
        /// </summary>
        InstitucionEntity entidad = new InstitucionEntity();

        private static readonly ILog log = LogManager.GetLogger(typeof(CalificarBeneficiario));

        private IUsuarioBusiness usuarioBusiness = new UsuarioBusiness();

        #endregion

        /// <summary>
        /// Evento de cargue inicial de la pagina
        /// </summary>
        /// <param name="sender">Objeto page</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.Form.Enctype = "multipart/form-data";
                this.Inicializar();
                if (this.ValidarIngreso())
                {
                    this.lblUsuario.Text = this.usuarioEntity.Login;
                }
                else
                {
                    Response.Redirect("~/AccesoDenegado.aspx", false);
                }
            }
            catch (Exception ex)
            {
                string script = JQueryMensaje.ArmaMensaje("Error Plataforma Condonacion Fondos", ex.Message, JQueryMensaje.TipoMensaje.Error);
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "Error load", script, true);
                log.Error("Error en evento Page_Load", ex);
            }
        }

        /// <summary>
        /// Se utiliza para resetea las varibles siempre que se ingrese 
        /// a la aplicacion o se haga un postback
        /// </summary>
        private void Inicializar()
        {
            this.LbError.Text = string.Empty;
            this.LbError.Visible = false;

            if (Session["UsuarioIcetex"] != null)
            {
                this.usuarioEntity = (UsuarioIcetexEntity)Session["UsuarioIcetex"];
                this.hdUsuario.Value = this.usuarioEntity.Login;
            }
        }

        /// <summary>
        /// Valida el acceso a form
        /// </summary>
        /// <returns>un objeto tipo bool true o false</returns>
        private bool ValidarIngreso()
        {
            if (!string.IsNullOrEmpty(usuarioEntity.Login))
                return this.usuarioBusiness.ValidarUsuarioIcetex(usuarioEntity.Login, usuarioEntity.Password, ResourceConst.PathFileUsers);
            else
                return false;
        }

        /// <summary>
        /// Evento click para descargar puntaje de beneficiarios
        /// </summary>
        /// <param name="sender">Objeto linkbutton</param>
        /// <param name="e">Argumentos del evento</param>
        protected void lnkDescargarPuntaje_Click(object sender, EventArgs e)
        {
            this.DescargarArchivo(0);
            this.LoadCurrentTab();
        }

        /// <summary>
        /// Evento click para descargar registro de inscritos
        /// </summary>
        /// <param name="sender">Objeto linkbutton</param>
        /// <param name="e">Argumentos del evento</param>
        protected void lnkDescargar_Click(object sender, EventArgs e)
        {
            this.DescargarArchivo(1);
        }

        /// <summary>
        /// Evento click para descargar historico de inscritos
        /// </summary>
        /// <param name="sender">Objeto linkbutton</param>
        /// <param name="e">Argumentos del evento</param>
        protected void lnkDescargarHistorico_Click(object sender, EventArgs e)
        {
            this.DescargarArchivo(2);
        }

        /// <summary>
        /// Metodo para Descargar archivo excel de acuerdo al tipo de archivo
        /// </summary>
        /// <param name="tipoArchivo">0: Calificacion puntaje, 1: Beneficiario, parametro 2: Historico estados beneficiario</param>
        private void DescargarArchivo(int tipoArchivo)
        {
            try
            {
                string nameFile = string.Empty;
                //Asigna nombre de archivo de acuerdo al tipo de registro que se descargue
                if (tipoArchivo.Equals(0))
                    nameFile = ResourceConst.FilePuntajeInscritos;
                // Si es calificacion de beneficiario
                else if (tipoArchivo.Equals(1))
                {
                    // Si es calificacion de Aval
                    if (this.ddlCalificacion.SelectedValue.Equals("A"))
                    {
                        nameFile = ResourceConst.FileRegistroInscritos;
                    }
                    // Si es calificacion de Condonacion
                    else if (this.ddlCalificacion.SelectedValue.Equals("C"))
                    {
                        nameFile = ResourceConst.FileRegistroInscritosCond;
                    }
                }
                else if (tipoArchivo.Equals(2))
                    nameFile = ResourceConst.FileRegistroInscritosHistorico;

                string rutaArchivo = System.Web.Hosting.HostingEnvironment.MapPath("~/Plantillas/" + nameFile);
                Stream archivo;

                //Descarga puntaje de beneficiarios
                if (tipoArchivo.Equals(0))
                    archivo = this.usuarioBusiness.GenerarPuntajeExcel(rutaArchivo);
                //Descarga registro de incritos o historial
                else
                    archivo = this.usuarioBusiness.GenerarBeneficiariosExcel(rutaArchivo, Convert.ToInt32(this.ddlConvocatoria.Text), this.ddlCalificacion.SelectedValue, tipoArchivo);

                Response.AddHeader("content-disposition", "attachment;filename=" + nameFile);
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.Private);
                Response.ContentType = "aapplication/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                StringWriter stringWrite = new StringWriter();
                HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                MemoryStream fs = new MemoryStream();
                fs = (MemoryStream)archivo;
                fs.Flush();
                byte[] bytes = fs.ToArray();
                Response.Flush();
                Response.BinaryWrite(bytes);
            }
            catch (Exception ex)
            {
                log.Error("Error en metodo DescargarArchivo - Layer UI", ex);
            }
            finally
            {
                Response.End();
            }
        }

        /// <summary>
        /// Evento click
        /// </summary>
        /// <param name="sender">Objeto linkbutton</param>
        /// <param name="e">Argumentos del evento</param>
        protected void lnkCargar_Click(object sender, EventArgs e)
        {
            this.CargarArchivo("fulDocumento");
        }

        /// <summary>
        /// Evento click
        /// </summary>
        /// <param name="sender">Objeto linkbutton</param>
        /// <param name="e">Argumentos del evento</param>
        protected void lnkCargarPuntaje_Click(object sender, EventArgs e)
        {
            this.CargarArchivo("fulDocumentoPuntaje");
            this.LoadCurrentTab();
        }

        /// <summary>
        /// Metodo para cargar archivo
        /// </summary>
        /// <param name="nameFile">"fulDocumento" es para cargar registro de inscritos, "fulDocumentoPuntaje" es para cargar puntaje de inscritos</param>
        private void CargarArchivo(string nameFile)
        {
            try
            {
                HttpPostedFile file = ObtenerContenidoArchivo(nameFile);
                string archivo_valido = "0";
                string error_msg = "";
                bool extencion_valida = false;
                IExcelDataReader excelReader = null;
                List<UsuarioEntity> usuariosArchivo = new List<UsuarioEntity>();

                excelReader = LeerExcelFile(file, ref extencion_valida, ref error_msg, ref archivo_valido);
                if (extencion_valida && excelReader != null && excelReader.IsValid) // si el archivo fue leido correctamente inicia la lectura de registros
                {
                    //Cargue de calificacion de beneficiarios
                    if (nameFile.Equals("fulDocumento"))
                    {
                        usuariosArchivo = CargarUsuariosArchivo(excelReader);

                        //Si existen usuarios en el acrhivo cargado y cumplen con el formato de Aval(13) o Condonacion(14)
                        if (usuariosArchivo.Count.Equals(0)
                            || (excelReader.FieldCount < 13 || excelReader.FieldCount > 14))
                        {
                            string script = JQueryMensaje.ArmaMensaje("Calificación de Beneficiario", "El archivo no tiene registros o posee formato incorrecto.", JQueryMensaje.TipoMensaje.Error);
                            ClientScript.RegisterClientScriptBlock(Page.GetType(), "abrirmodal", script, true);
                            resumen_archivo_valido.Value = "0";
                            this.lb_err_detalle.Text = "Error al procesar archivo excel";
                        }
                        else
                        {
                            for (int i = 0; i < usuariosArchivo.Count; i++)
                            {
                                this.usuarioBusiness.ActualizarBeneficiario(usuariosArchivo[i].IdRadicado,
                                usuariosArchivo[i].IdEstado, usuariosArchivo[i].Observacion, this.usuarioEntity.Login);

                                double progreso = Math.Round((((double)i + (double)1) / (double)usuariosArchivo.Count()) * 100);
                                this.lblLoading.Text = string.Format("{0}{1}%", "Procesando Archivo ... ", progreso.ToString());
                            }

                            resumen_archivo_valido.Value = "1";

                            string script = JQueryMensaje.ArmaMensaje("Calificación de Beneficiario", "El archivo fue procesado exitosamente.", JQueryMensaje.TipoMensaje.Informativo);
                            ClientScript.RegisterClientScriptBlock(Page.GetType(), "abrirmodal", script, true);
                        }
                    }
                    //Cargue de puntaje de beneficiarios
                    else
                    {
                        usuariosArchivo = CargarPuntajesArchivo(excelReader);

                        if (usuariosArchivo.Count.Equals(0) || excelReader.FieldCount != 3)
                        {
                            string script = JQueryMensaje.ArmaMensaje("Asignación de Puntaje", "El archivo no tiene registros o posee formato incorrecto.", JQueryMensaje.TipoMensaje.Error);
                            ClientScript.RegisterClientScriptBlock(Page.GetType(), "abrirmodal", script, true);
                            resumen_archivo_valido.Value = "0";
                            this.lb_err_detalle.Text = "Error al procesar archivo excel";
                        }
                        else
                        {
                            for (int i = 0; i < usuariosArchivo.Count; i++)
                            {
                                this.usuarioBusiness.ActualizarPuntaje(Convert.ToInt32(usuariosArchivo[i].IdSolicitante),
                                    Convert.ToInt32(usuariosArchivo[i].PuntajeParticipacion),
                                    usuariosArchivo[i].CumplePuntaje, this.usuarioEntity.Login);

                                double progreso = Math.Round((((double)i + (double)1) / (double)usuariosArchivo.Count()) * 100);
                                this.lblLoading.Text = string.Format("{0}{1}%", "Procesando Archivo ... ", progreso.ToString());
                            }

                            resumen_archivo_valido.Value = "1";

                            string script = JQueryMensaje.ArmaMensaje("Asignación de Puntaje", "El archivo fue procesado exitosamente.", JQueryMensaje.TipoMensaje.Informativo);
                            ClientScript.RegisterClientScriptBlock(Page.GetType(), "abrirmodal", script, true);
                        }
                    }

                    excelReader.Close(); // cerrando el lector de excel
                }
                else
                {
                    resumen_archivo_valido.Value = "0";
                    this.lb_err_detalle.Text = "El archivo <strong>" + file.FileName + "</strong> no es v&aacute;lido o esta da&ntilde;ado, por favor verifiquelo e intente nuevamente";
                }

                resumen_activo.Value = "1";

            }
            catch (Exception ex)
            {
                resumen_archivo_valido.Value = "0";
                this.lb_err_detalle.Text = "Error al generar archivo xls";

                string script = JQueryMensaje.ArmaMensaje("Cargue de archivo", "Error al procesar archivo.", JQueryMensaje.TipoMensaje.Error);
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "abrirmodal", script, true);

                log.Error("Error en metodo CargarArchivo - Layer UI", ex);
            }
        }

        /// <summary>
        /// Carga los usuarios desde el archivo excel
        /// </summary>
        /// <param name="excelReader">Componente encargado de deserializar el archivo excel</param>
        /// <returns>Retorna lista de beneficiarios pertenecientes al archivo</returns>
        private List<UsuarioEntity> CargarUsuariosArchivo(IExcelDataReader excelReader)
        {
            List<UsuarioEntity> lista = new List<UsuarioEntity>();

            while (excelReader.Read())
            {
                if (excelReader.Depth > 1 && excelReader.GetString(0) != null) // ignorar la fila 1 de cabeceras
                {
                    UsuarioEntity registroArchivo = new UsuarioEntity();
                    registroArchivo.IdRadicado = excelReader.GetString(0);

                    if (excelReader.GetString(11).Trim().ToUpper().Equals("RADICADO-EN ESTUDIO"))
                        registroArchivo.IdEstado = 1;
                    else if (excelReader.GetString(11).Trim().ToUpper().Equals("RECHAZADO"))
                        registroArchivo.IdEstado = 2;
                    else if (excelReader.GetString(11).Trim().ToUpper().Equals("APROBADO"))
                        registroArchivo.IdEstado = 3;
                    else if (excelReader.GetString(11).Trim().ToUpper().Equals("DOCUMENTACION INCOMPLETA"))
                        registroArchivo.IdEstado = 4;
                    else if (excelReader.GetString(11).Trim().ToUpper().Equals("EN SUBSANACION"))
                        registroArchivo.IdEstado = 5;

                    registroArchivo.Observacion = excelReader.GetString(12);
                    lista.Add(registroArchivo);
                }
            }

            return lista;
        }

        /// <summary>
        /// Carga los puntajes de los usuarios desde el archivo excel
        /// </summary>
        /// <param name="excelReader">Componente encargado de deserializar el archivo excel</param>
        /// <returns>Retorna lista de beneficiarios con sus puntajes pertenecientes al archivo</returns>
        private List<UsuarioEntity> CargarPuntajesArchivo(IExcelDataReader excelReader)
        {
            List<UsuarioEntity> lista = new List<UsuarioEntity>();

            while (excelReader.Read())
            {
                if (excelReader.Depth > 1 && excelReader.GetString(0) != null) // ignorar la fila 1 de cabeceras
                {
                    UsuarioEntity registroArchivo = new UsuarioEntity();
                    registroArchivo.IdSolicitante = Convert.ToInt32(excelReader.GetString(0));
                    registroArchivo.PuntajeParticipacion = excelReader.GetString(1);
                    registroArchivo.CumplePuntaje = excelReader.GetString(2).Equals("NO") ? "0" : "1";
                    lista.Add(registroArchivo);
                }
            }

            return lista;
        }

        /// <summary>
        /// Lee el archivo excel cargado
        /// </summary>
        /// <param name="file">Archivo cargado</param>
        /// <param name="extencion_valida">True o false si es valida la extension</param>
        /// <param name="error_msg">Mensaje de error</param>
        /// <param name="archivo_valido">Archivo valido en su estructura</param>
        /// <returns>Retorna una interfaz que contiene la coleccion de objetos para obtener solicitudes</returns>
        private IExcelDataReader LeerExcelFile(HttpPostedFile file, ref bool extencion_valida, ref string error_msg, ref string archivo_valido)
        {
            IExcelDataReader excelReader = null;

            // Verificar tipo de archivo xls o xlsx
            if (file.FileName.ToLower().IndexOf(".xlsx") != -1) //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            {
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(file.InputStream);
                extencion_valida = true;
            }
            else if (file.FileName.ToLower().IndexOf(".xls") != -1) //1. Reading from a binary Excel file ('97-2003 format; *.xls)
            {
                excelReader = ExcelReaderFactory.CreateBinaryReader(file.InputStream);
                extencion_valida = true;
            }
            else
            { // archivo no valido por la extencion
                archivo_valido = "0";
                extencion_valida = false;
                error_msg = "La extenci&oacute;n del archivo " + file.FileName + " no es valida, por favor revise el archivo e intente nuevamente";
            }

            return excelReader;
        }

        /// <summary>
        /// Obtiene el contenido del archivo cargado
        /// </summary>
        /// <returns>Retorna el control que almacena el fichero</returns>
        private HttpPostedFile ObtenerContenidoArchivo(string nameFile)
        {
            HttpPostedFile file = Request.Files[nameFile];

            if (file != null && file.ContentLength > 0)
            {
                string fname = Path.GetFileName(file.FileName);
                file.SaveAs(Server.MapPath(Path.Combine("~/Plantillas/Temp/", fname)));
            }

            return file;
        }

        /// <summary>
        /// Metodo que permite cargar tab actual al momento de hacer postback
        /// </summary>
        private void LoadCurrentTab()
        {
            this.linkInscritos.Attributes["class"] = null;
            this.linkPuntaje.Attributes["class"] = "active";
            this.menuInscritos.Attributes["class"] = "tab-pane fade";
            this.menuPuntaje.Attributes["class"] = "tab-pane fade in active";
        }
    }
}