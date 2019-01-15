using FondosycCondonacion.Business;
using FondosycCondonacion.Business.Common;
using FondosycCondonacion.Entities;
using Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FondosycCondonacion.UI.Controls
{
    public partial class UcCondonacion : System.Web.UI.UserControl
    {
        #region "DECLARACIONES"

        UsuarioEntity usuarioEntity = new UsuarioEntity();

        UsuarioEntity beneficiarioCondonacionEntity = new UsuarioEntity();

        UsuarioEntity beneficiarioAvalEntity = new UsuarioEntity();

        private IUsuarioBusiness usuarioBusiness = new UsuarioBusiness();

        /// <summary>
        /// Instancia la clase Institucion de la entidad
        /// </summary>
        InstitucionEntity entidad = new InstitucionEntity();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }

            try
            {
                // Inicializa sesion
                this.Inicializar();
                // Valida ingreso del usuario
                if (this.ValidarIngreso())
                {
                    // Carga puntaje de la comunidad en practica
                    this.CargarPuntaje();
                    // Oculta todos los campos opcionales
                    this.OcultarCamposOpcionales(0);

                    // Obtiene la informacion registrada en condonacion
                    this.beneficiarioCondonacionEntity = this.ObtenerUsuario(this.usuarioEntity.IdSolicitante, "C");
                    // Obtiene la informacion registrada en aval
                    this.beneficiarioAvalEntity = this.ObtenerUsuario(this.usuarioEntity.IdSolicitante, "A");
                    // Asigna url dinamicas de acuerdo
                    this.ConfigUrlFiles();

                    if (this.beneficiarioCondonacionEntity == null)
                        this.usuarioEntity.IdEstado = 0;
                    else
                        this.usuarioEntity.IdEstado = this.beneficiarioCondonacionEntity.IdEstado == 2 ? 0 : this.beneficiarioCondonacionEntity.IdEstado;

                    //Si la condonacion es: RADICADA o APROBADA o no existe proceso de aval o DOCUMENTACION INCOMPLETA o EN SUBSANACION
                    if (this.usuarioEntity.IdEstado.Equals(1) || this.usuarioEntity.IdEstado.Equals(3)
                        || this.usuarioEntity.IdEstado.Equals(4) || this.usuarioEntity.IdEstado.Equals(5))
                    {
                        this.BloquearControles();
                        this.CargarInformacionRadicada();

                        // Si es DOCUMENTACION INCOMPLETA => Muestra documentos requeridos
                        // Si es EN SUBSANACION, => Muestra documento subsanacion
                        if (Enumerable.Range(4, 5).Contains(this.usuarioEntity.IdEstado))
                        {
                            // Desactiva validadores para solo pedir documento del estado respectivo
                            this.DesactivarValidadores();
                            // Activa controles opcionales
                            this.ActivarControlesOpcionales(this.usuarioEntity.IdEstado);
                        }
                    }

                    //Si no existe aval
                    if (this.beneficiarioAvalEntity == null)
                        this.BloquearControles();
                    //Si existe aval pero no ha sido aprobado
                    else if (!this.beneficiarioAvalEntity.IdEstado.Equals(3))
                        this.BloquearControles();

                    this.CargarResultadoRadicacion();
                }
                else
                {
                    Response.Redirect("AccesoDenegado.aspx", false);
                }
            }
            catch (Exception ex)
            {
                string script = JQueryMensaje.ArmaMensaje("Error Plataforma Condonacion Fondos", ex.Message, JQueryMensaje.TipoMensaje.Error);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error load", script, true);
            }
        }

        /// <summary>
        /// Desactiva todos los validadores de condonacion
        /// </summary>
        private void DesactivarValidadores()
        {
            foreach (var rfv in this.Controls.OfType<RequiredFieldValidator>())
            {
                rfv.Enabled = false;
            }
        }

        private void CargarPuntaje()
        {
            this.txtPuntajeComunidad.Text = this.usuarioEntity.PuntajeParticipacion;

            if (this.usuarioEntity.CumplePuntaje.Equals("0"))
            {
                this.divPuntaje.InnerHtml = ResourceConst.ConstNoPuntaje;
                this.divPuntaje.Attributes["class"] = "my-notify-error";
            }
            else
            {
                this.divPuntaje.InnerHtml = ResourceConst.ConstSiPuntaje;
                this.divPuntaje.Attributes["class"] = "my-notify-success";
            }
        }

        /// <summary>
        /// Muestra url de formatos o anexos que se deben diligenciar
        /// </summary>
        private void ConfigUrlFiles()
        {
            if (this.beneficiarioAvalEntity != null)
            {
                AvalEntity avalEntity = new AvalEntity();
                avalEntity = ((List<AvalEntity>)Session["Avales"]).Find(a => a.IdAval.Equals(this.beneficiarioAvalEntity.IdAval));

                string pathSoporte = Path.Combine(ResourceConst.PathAnexos, avalEntity.Formato_Condonacion);
                this.linkSoporte.HRef = pathSoporte;
                this.linkSoporte.Title = pathSoporte;
                this.linkSoporte.InnerHtml = avalEntity.Formato_Condonacion;
                linkSoporte.Visible = true;

                // Carga el anexo 11 de acuerdo a la convocatoria que se encuentre (8809,9084)
                string nameAnexo11 = usuarioEntity.IdConvocatoria.Equals("8809") ? ResourceConst.File_8809_Anexo11 : ResourceConst.File_9084_Anexo11;
                string pathAnexo11 = Path.Combine(ResourceConst.PathAnexos, nameAnexo11);
                this.linkCertifFormato.HRef = pathAnexo11;
                this.linkCertifFormato.Title = nameAnexo11;
                this.linkCertifFormato.InnerHtml = nameAnexo11;
                this.linkCertifFormato.Visible = true;
            }
        }

        private void CargarResultadoRadicacion()
        {
            if (this.beneficiarioCondonacionEntity == null)
            {
                this.lblEstadoBeneficiario.Text = ResourceConst.ConstNoRegistradoCondonacion;
            }
            else if (this.beneficiarioCondonacionEntity.IdEstado.Equals(1) || this.beneficiarioCondonacionEntity.IdEstado.Equals(3))
            {
                this.lblEstadoBeneficiario.Text = ResourceConst.ConstConfirmacionRegistroCondonacion;
            }
            else if (this.beneficiarioCondonacionEntity.IdEstado.Equals(2))
            {
                this.lblEstadoBeneficiario.Text = ResourceConst.ConstNoRegistradoCondonacion;
            }

            if (this.beneficiarioCondonacionEntity == null)
            {
                this.gvBeneficiario.DataSource = null;
            }
            else
            {
                this.gvBeneficiario.DataSource = this.usuarioBusiness.ObtenerListadoBeneficiario(this.beneficiarioCondonacionEntity.IdSolicitante, "C");
            }

            this.gvBeneficiario.DataBind();
        }

        /// <summary>
        /// Bloquea y/o oculta todos los controles
        /// </summary>
        private void BloquearControles()
        {
            // Oculta campos basicos de condonacion
            this.fulCertifPermEstado.Enabled = false;
            this.fulCertifPromNotas.Enabled = false;
            this.fulCertifProgCursado.Enabled = false;
            this.fulCertifDiploma.Enabled = false;
            this.fulCertifSoporte.Enabled = false;
            this.fulCertifFormato.Enabled = false;
            this.fulCertifFinMaterias.Enabled = false;
            this.txtVideoYoutube.Attributes.Add("disabled", "disabled");

            // Oculta botones de condonacion
            this.btnRadicar.Enabled = false;
            this.btnCancelar.Visible = false;
            this.btnRadicar.Visible = false;
        }

        /// <summary>
        /// Oculta campos opcionales
        /// </summary>
        private void OcultarCamposOpcionales(int estado)
        {
            switch (estado)
            {
                case 0:
                    // Seccion de documentos requeridos
                    this.lblCertifDocRequer.Visible = false;
                    this.fulCertifDocRequer.Visible = false;
                    this.rqfulCertifDocRequer.Enabled = false;
                    // Seccion de documentos de subsanacion
                    this.lblCertifDocSubsanacion.Visible = false;
                    this.fulCertifDocSubsanacion.Visible = false;
                    this.rqfulCertifDocSubsanacion.Enabled = false;
                    // Franja de separacion de campos opcionales
                    this.lblCondonacionEstado.Text = string.Empty;
                    this.divCondonacionEstado.Visible = false;
                    break;
                case 4:
                    // Seccion de documentos requeridos
                    this.lblCertifDocRequer.Visible = true;
                    this.fulCertifDocRequer.Visible = true;
                    this.fulCertifDocRequer.Enabled = false;
                    this.rqfulCertifDocRequer.Enabled = false;
                    // Franja de separacion de campos opcionales
                    this.lblCondonacionEstado.Text = "Estado solicitud: Documentación Incompleta";
                    this.divCondonacionEstado.Visible = true;
                    break;
                case 5:
                    // Seccion de documentos de subsanacion
                    this.lblCertifDocSubsanacion.Visible = true;
                    this.fulCertifDocSubsanacion.Visible = true;
                    this.fulCertifDocSubsanacion.Enabled = false;
                    this.rqfulCertifDocSubsanacion.Enabled = false;
                    // Franja de separacion de campos opcionales
                    this.lblCondonacionEstado.Text = "Estado solicitud: En Subsanación";
                    this.divCondonacionEstado.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Activa y muestra controles de acuerdo a los estados (documentacion incompleta, en subsanacion)
        /// </summary>
        /// <param name="IdEstado">Id numerico del estado</param>
        private void ActivarControlesOpcionales(int IdEstado)
        {
            // Muestra botones de condonacion
            this.btnRadicar.Enabled = true;
            this.btnCancelar.Visible = true;
            this.btnRadicar.Visible = true;

            switch (IdEstado)
            {
                // DOCUMENTACION INCOMPLETA
                case 4:
                    //Seccion de documentos requeridos
                    this.lblCertifDocRequer.Visible = true;
                    this.fulCertifDocRequer.Visible = true;
                    this.rqfulCertifDocRequer.Enabled = true;
                    // Franja de separacion de campos opcionales
                    this.lblCondonacionEstado.Text = "Estado solicitud: Documentación Incompleta";
                    this.divCondonacionEstado.Visible = true;
                    break;
                // EN SUBSANACION
                case 5:
                    //Seccion de documento subsanacion
                    this.lblCertifDocSubsanacion.Visible = true;
                    this.fulCertifDocSubsanacion.Visible = true;
                    this.rqfulCertifDocSubsanacion.Enabled = true;
                    // Franja de separacion de campos opcionales
                    this.lblCondonacionEstado.Text = "Estado solicitud: En Subsanación";
                    this.divCondonacionEstado.Visible = true;
                    break;
            }
        }

        private void CargarInformacionRadicada()
        {
            this.txtVideoYoutube.Text = this.beneficiarioCondonacionEntity.VideoYoutube;
            //this.txtFechaFin.Text = this.beneficiarioCondonacionEntity.FechaFinMaterias.ToString("dd/MM/yyyy");

            if (this.beneficiarioCondonacionEntity == null)
            {
                this.gvBeneficiario.DataSource = null;
            }
            else
            {
                this.gvBeneficiario.DataSource = this.usuarioBusiness.ObtenerListadoBeneficiario(this.beneficiarioCondonacionEntity.IdSolicitante, "C");
            }

            this.gvBeneficiario.DataBind();
        }

        private UsuarioEntity ObtenerUsuario(int IdSolicitante, string IdProceso)
        {
            if (!string.IsNullOrEmpty(usuarioEntity.Login))
                return this.usuarioBusiness.ObtenerBeneficiario(IdSolicitante, IdProceso);
            else
                return null;
        }

        private UsuarioEntity ObtenerUsuarioAval(int IdSolicitante)
        {
            if (!string.IsNullOrEmpty(usuarioEntity.Login))
            {
                return this.usuarioBusiness.ObtenerBeneficiario(IdSolicitante, "A");
            }
            else
                return null;
        }

        /// <summary>
        /// Se utiliza para resetea las varibles siempre que se ingrese 
        /// a la aplicacion o se haga un postback
        /// </summary>
        private void Inicializar()
        {
            if (Session["Usuario"] != null)
                this.usuarioEntity = (UsuarioEntity)Session["Usuario"];
        }

        /// <summary>
        /// Valida el acceso a form
        /// </summary>
        /// <returns>un objeto tipo bool true o false</returns>
        private bool ValidarIngreso()
        {
            if (string.IsNullOrEmpty(usuarioEntity.Login) || string.IsNullOrEmpty(this.usuarioEntity.IdConvocatoria))
                return false;
            else
                return this.usuarioBusiness.ValidarUsuario(usuarioEntity.Login, usuarioEntity.Password, this.usuarioEntity.IdConvocatoria).SeAutentica;
        }

        private string ObtenerArchivo(FileUpload file, bool esCondonacion, int size)
        {
            string data = string.Empty;
            int maxBytes = size;

            if (file.HasFile)
            {
                try
                {
                    if (file.PostedFile.ContentType.Equals(ResourceConst.ConstContentPdf)
                        || file.PostedFile.ContentType.Equals(ResourceConst.ConstContentWord)
                        || file.PostedFile.ContentType.Equals(ResourceConst.ConstContentOpenxmlformats))
                    {
                        if (file.PostedFile.ContentLength < maxBytes)
                        {
                            //Creacion de carpeta fisica para almacenar en archivo pdf
                            string fullFolder = this.CreateFolder(this.usuarioEntity.IdConvocatoria, this.usuarioEntity.IdSolicitante.ToString(), esCondonacion);
                            string codeGuid = Guid.NewGuid().ToString();
                            string fullPath = Path.Combine(fullFolder, codeGuid + file.FileName);
                            file.SaveAs(fullPath);

                            //Asignacion de ruta en el campo de nombre de archivo para el regitro de beneficiario
                            string folderConvocatoria = string.Format(ResourceConst.ConstPathConvocatoria, this.usuarioEntity.IdConvocatoria);
                            string folderBeneficiario = this.usuarioEntity.IdSolicitante.ToString();
                            string pathData = string.Empty;

                            if (esCondonacion)
                            {
                                pathData = string.Format(@"{0}{1}\{2}\{3}", folderConvocatoria, folderBeneficiario, "Certificados", codeGuid + file.FileName);
                            }
                            else
                            {
                                pathData = string.Format(@"{0}{1}\{2}", folderConvocatoria, folderBeneficiario, codeGuid + file.FileName);
                            }

                            data = pathData;
                        }
                        else
                            data = string.Format("Error: El archivo tiene que pesar menos de {0} Kb", maxBytes);
                    }
                    else
                        data = "Error: Unicamente se aceptan archivos PDF";
                }
                catch (Exception)
                {
                    //log.Error("Error: El archivo no pudo ser cargado", ex);
                    data = "Error: El archivo no pudo ser cargado";
                }
            }

            return data;
        }

        private string CreateFolder(string idConvocatoria, string idSolicitante, bool esCondonacion)
        {
            string folderConvocatoria = string.Empty;
            string folderBeneficiario = string.Empty;

            try
            {
                //Carpeta de Convocatoria
                folderConvocatoria = Path.Combine(HttpContext.Current.Server.MapPath(ResourceConst.ConstPathData),
                                                string.Format(ResourceConst.ConstPathConvocatoria, idConvocatoria));
                bool existsConv = Directory.Exists(folderConvocatoria);
                if (!existsConv)
                    Directory.CreateDirectory(folderConvocatoria);

                //Carpeta de Beneficiario en Convocatoria
                folderBeneficiario = Path.Combine(folderConvocatoria, idSolicitante);

                if (esCondonacion)
                {
                    folderBeneficiario = Path.Combine(folderBeneficiario, "Certificados");
                }

                bool existsBenef = Directory.Exists(folderBeneficiario);
                if (existsBenef)
                {
                    return folderBeneficiario;
                }
                else
                {
                    Directory.CreateDirectory(folderBeneficiario);
                    return folderBeneficiario;
                }
            }
            catch (Exception)
            {
                //log.Error("Error creando carpeta que almacena cargue de archivos", ex);
                //this.lbTrace.Text += "Error creando carpeta que almacena cargue de archivos";
                return string.Empty;
            }
        }

        protected void btnRadicar_Click(object sender, EventArgs e)
        {
            if (this.btnRadicar.Visible.Equals(true))
            {
                string script = string.Empty;

                //hjaraba - Si cumple puntaje de comunidad practica, permita guardar
                if (this.usuarioEntity.CumplePuntaje.Equals("1"))
                {
                    this.usuarioEntity.CertifPermEstado = ObtenerArchivo(this.fulCertifPermEstado, true, 2048000);
                    this.usuarioEntity.CertifPromNotas = ObtenerArchivo(this.fulCertifPromNotas, true, 1024000);
                    this.usuarioEntity.CertifProgCursado = ObtenerArchivo(this.fulCertifProgCursado, true, 1024000);
                    this.usuarioEntity.CertifDiploma = ObtenerArchivo(this.fulCertifDiploma, true, 1024000);
                    this.usuarioEntity.CertifSoporte = ObtenerArchivo(this.fulCertifSoporte, true, 1024000);
                    this.usuarioEntity.VideoYoutube = this.txtVideoYoutube.Text;
                    this.usuarioEntity.CertifVideo = ObtenerArchivo(this.fulCertifFormato, true, 1024000);
                    this.usuarioEntity.CertifFinMateria = ObtenerArchivo(this.fulCertifFinMaterias, true, 1024000);
                    this.usuarioEntity.Observacion = ResourceConst.ConstConfirmacionRegistroCondonacion;
                    this.usuarioEntity.IdEstado = this.usuarioEntity.IdEstado == 0 ? 1 : this.usuarioEntity.IdEstado;

                    RespuestaAjax Respuesta = new RespuestaAjax();

                    if (Enumerable.Range(4, 5).Contains(this.usuarioEntity.IdEstado))
                    {
                        this.usuarioEntity.CertifDocsRequeridos = this.usuarioEntity.IdEstado.Equals(4) ? ObtenerArchivo(this.fulCertifDocRequer, true, 4096000) : string.Empty;
                        this.usuarioEntity.CertifDocSubsanacion = this.usuarioEntity.IdEstado.Equals(5) ? ObtenerArchivo(this.fulCertifDocSubsanacion, true, 4096000) : string.Empty;

                        if (this.usuarioEntity.IdEstado.Equals(4))
                            this.usuarioEntity.Observacion = "RADICADO-EN ESTUDIO - DOCUMENTACIÓN INCOMPLETA";
                        else
                            this.usuarioEntity.Observacion = "RADICADO-EN ESTUDIO - EN SUBSANACIÓN";

                        this.usuarioEntity.IdRadicado = this.beneficiarioCondonacionEntity.IdRadicado;
                        Respuesta = this.usuarioBusiness.ActualizarBeneficiarioCondonacion(this.usuarioEntity);
                    }
                    else
                    {
                        Respuesta = this.usuarioBusiness.RegistrarBeneficiarioCondonacion(this.usuarioEntity);
                    }

                    switch (Respuesta.Estado)
                    {
                        case EstadoRespuesta.OK:
                            script = JQueryMensaje.ArmaMensaje("Plataforma de Condonación", Respuesta.Mensage, JQueryMensaje.TipoMensaje.Informativo);
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirmodal", script, true);
                            this.lblEstadoBeneficiario.Text = ResourceConst.ConstConfirmacionRegistroCondonacion;
                            this.gvBeneficiario.DataSource = this.usuarioBusiness.ObtenerListadoBeneficiario(this.usuarioEntity.IdSolicitante, "C");
                            this.gvBeneficiario.DataBind();
                            this.BloquearControles();
                            if (Enumerable.Range(4, 5).Contains(this.usuarioEntity.IdEstado))
                                OcultarCamposOpcionales(usuarioEntity.IdEstado);

                            break;
                        case EstadoRespuesta.ERROR:
                            script = JQueryMensaje.ArmaMensaje("Plataforma de Condonación", Respuesta.Mensage, JQueryMensaje.TipoMensaje.Error);
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirmodal", script, true);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    script = JQueryMensaje.ArmaMensaje("Plataforma de Condonación", "No puede registrar condonacion, ya que no cumple con el puntaje de participación en comunidad de práctica", JQueryMensaje.TipoMensaje.Alerta);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirmodal", script, true);
                }
            }

            this.LoadTabs();
        }

        private void LoadTabs()
        {
            HtmlGenericControl linkTabAval = (HtmlGenericControl)this.Parent.FindControl("linkTabAval");
            HtmlGenericControl linkTabCond = (HtmlGenericControl)this.Parent.FindControl("linkTabCond");
            HtmlGenericControl linkTabCondonacion = (HtmlGenericControl)this.Parent.FindControl("linkTabCondonacion");

            HtmlGenericControl menuCond = (HtmlGenericControl)this.Parent.FindControl("menuCond");
            HtmlGenericControl menuAval = (HtmlGenericControl)this.Parent.FindControl("menuAval");
            HtmlGenericControl menuCondonacion = (HtmlGenericControl)this.Parent.FindControl("menuCondonacion");

            linkTabCond.Attributes["class"] = null;
            linkTabAval.Attributes["class"] = null;
            linkTabCondonacion.Attributes["class"] = "active";
            menuCond.Attributes["class"] = "tab-pane fade";
            menuAval.Attributes["class"] = "tab-pane fade";
            menuCondonacion.Attributes["class"] = "tab-pane fade in active";
        }

        protected void gvBeneficiario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvBeneficiario.PageIndex = e.NewPageIndex;
            this.gvBeneficiario.DataSource = this.usuarioBusiness.ObtenerListadoBeneficiario(this.usuarioEntity.IdSolicitante, "C");
            this.gvBeneficiario.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void gvBeneficiario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            UsuarioEntity user = e.Row.DataItem as UsuarioEntity;

            if (user != null)
                if (user.IsRowEmpty)
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#1251A3");
        }
    }
}