using FondosycCondonacion.Business;
using FondosycCondonacion.Entities;
using Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FondosycCondonacion.UI.Controls
{
    public partial class UcAval : System.Web.UI.UserControl
    {
        #region "DECLARACIONES"

        UsuarioEntity usuarioEntity = new UsuarioEntity();

        UsuarioEntity beneficiarioEntity = new UsuarioEntity();

        private IUsuarioBusiness usuarioBusiness = new UsuarioBusiness();

        private IInstitucionBusiness institucionBusiness = new InstitucionBusiness();

        /// <summary>
        /// Instancia la clase Institucion de la entidad
        /// </summary>
        InstitucionEntity entidad = new InstitucionEntity();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.Inicializar();
                if (this.ValidarIngreso())
                {
                    this.CargarBeneficiario();
                    this.beneficiarioEntity = this.ObtenerUsuario(this.usuarioEntity.IdSolicitante);

                    if (this.beneficiarioEntity == null)
                    {
                        this.usuarioEntity.IdEstado = 0;
                    }
                    else
                    {
                        //Si el aval es rechazado se asigna 0 para que se pueda volver a guardar un nuevo radicado de aval
                        this.usuarioEntity.IdEstado = this.beneficiarioEntity.IdEstado == 2 ? 0 : this.beneficiarioEntity.IdEstado;
                    }

                    if (!IsPostBack)
                    {
                        this.CargarDeptos();
                        this.CargarAvales();
                    }

                    if (this.usuarioEntity.IdEstado.Equals(1) || this.usuarioEntity.IdEstado.Equals(3))
                    {
                        this.BloquearControles();
                        this.CargarInformacionRadicada();
                    }

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

        private void CargarResultadoRadicacion()
        {
            if (this.beneficiarioEntity == null)
            {
                this.lblEstadoBeneficiario.Text = ResourceConst.ConstNoRegistrado;
            }
            else if (this.beneficiarioEntity.IdEstado.Equals(1) || this.beneficiarioEntity.IdEstado.Equals(3))
            {
                this.lblEstadoBeneficiario.Text = ResourceConst.ConstConfirmacionRegistroAval;
            }
            else if (this.beneficiarioEntity.IdEstado.Equals(2))
            {
                this.lblEstadoBeneficiario.Text = ResourceConst.ConstNoRegistrado;
            }

            if (this.beneficiarioEntity == null)
            {
                this.gvBeneficiario.DataSource = null;
            }
            else
            {
                this.gvBeneficiario.DataSource = this.usuarioBusiness.ObtenerListadoBeneficiario(this.beneficiarioEntity.IdSolicitante, "A");
            }

            this.gvBeneficiario.DataBind();
        }

        private void BloquearControles()
        {
            this.ddlDepartamento.Enabled = false;
            this.ddlCiudad.Enabled = false;
            this.ddlUniversidad.Enabled = false;
            this.ddlPrograma.Enabled = false;
            this.txtFecha.Attributes.Add("disabled", "disabled");
            this.ddlTipoAval.Enabled = false;
            this.fulDocumentoAval.Enabled = false;
            this.btnRadicar.Enabled = false;
            this.btnCancelar.Visible = false;
            this.btnRadicar.Visible = false;
        }

        private void CargarInformacionRadicada()
        {
            this.ddlDepartamento.SelectedValue = this.beneficiarioEntity.IdDepartamento;
            this.CargarMunicipios();
            this.ddlCiudad.SelectedValue = this.beneficiarioEntity.IdMunicipio;
            this.CargarInstituciones();
            this.ddlUniversidad.SelectedValue = this.beneficiarioEntity.Codsnies_Inst;
            this.CargarProgramas();
            this.ddlPrograma.SelectedValue = this.beneficiarioEntity.CodSnies_Prog;
            this.txtFecha.Text = this.beneficiarioEntity.Fecha_Finalizacion_Materias.ToString("dd/MM/yyyy");
            this.ddlTipoAval.SelectedValue = this.beneficiarioEntity.IdAval;

            if (this.beneficiarioEntity == null)
            {
                this.gvBeneficiario.DataSource = null;
            }
            else
            {
                this.gvBeneficiario.DataSource = this.usuarioBusiness.ObtenerListadoBeneficiario(this.beneficiarioEntity.IdSolicitante, "A");
            }

            this.gvBeneficiario.DataBind();
        }

        /// <summary>
        /// Obtiene datos de usuario en proceso de aval
        /// </summary>
        /// <param name="IdSolicitante">Solicitante a consultar</param>
        /// <returns>Retorna usuarioentity</returns>
        private UsuarioEntity ObtenerUsuario(int IdSolicitante)
        {
            if (!string.IsNullOrEmpty(usuarioEntity.Login))
            {
                return this.usuarioBusiness.ObtenerBeneficiario(IdSolicitante, "A");
            }
            else
                return null;
        }

        /// <summary>
        /// Metodo que carga los datos de identificacion del usuario
        /// </summary>
        private void CargarBeneficiario()
        {
            this.txtIdentificacion.Text = usuarioEntity.IdSolicitante.ToString();
            this.txtNombre.Text = usuarioEntity.NombreCompleto;
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

        /// <summary>
        /// Trae los departamentos
        /// </summary>
        private void CargarDeptos()
        {
            this.ddlDepartamento.DataTextField = "Nombre";
            this.ddlDepartamento.DataValueField = "IdDepto";
            this.ddlDepartamento.DataSource = this.institucionBusiness.TraerDeptos();
            this.ddlDepartamento.DataBind();
        }

        /// <summary>
        /// Trae el listado de municipios
        /// </summary>
        private void CargarMunicipios()
        {
            this.ddlCiudad.DataTextField = "Nombre";
            this.ddlCiudad.DataValueField = "IdMunicipio";
            this.ddlCiudad.DataSource = this.institucionBusiness.TraerMunicipios(this.ddlDepartamento.SelectedValue);
            this.ddlCiudad.DataBind();
        }

        /// <summary>
        /// Trae el listado de instituciones
        /// </summary>
        private void CargarInstituciones()
        {
            this.ddlUniversidad.DataTextField = "Nombre";
            this.ddlUniversidad.DataValueField = "Codsnies_Inst";
            this.ddlUniversidad.DataSource = this.institucionBusiness.TraerInstituciones(this.ddlDepartamento.SelectedValue, this.ddlCiudad.SelectedValue);
            this.ddlUniversidad.DataBind();
        }

        /// <summary>
        /// Trae el listado de municipios
        /// </summary>
        private void CargarProgramas()
        {
            this.ddlPrograma.DataTextField = "Descripcion";
            this.ddlPrograma.DataValueField = "CodSnies_Prog";
            this.ddlPrograma.DataSource = this.institucionBusiness.TraerProgramas(this.ddlUniversidad.SelectedValue, this.ddlDepartamento.SelectedValue, this.ddlCiudad.SelectedValue);
            this.ddlPrograma.DataBind();
        }

        /// <summary>
        /// Trae el listado de avales
        /// </summary>
        private void CargarAvales()
        {
            this.ddlTipoAval.DataTextField = "Nombre";
            this.ddlTipoAval.DataValueField = "IdAval";
            this.ddlTipoAval.DataSource = this.institucionBusiness.TraerAvales(Convert.ToInt32(usuarioEntity.IdConvocatoria), usuarioEntity.IdNivel);
            this.ddlTipoAval.DataBind();

            Session["Avales"] = null;
            Session["Avales"] = this.ddlTipoAval.DataSource;
        }

        /// <summary>
        /// Se ejecuta una vez se cambie el departamento seleccionado
        /// </summary>
        /// <param name="sender">tipo object</param>
        /// <param name="e">tipo EventArgs</param>
        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarMunicipiosPorDepartamento();
        }

        private void CargarMunicipiosPorDepartamento()
        {
            try
            {
                if (string.IsNullOrEmpty(this.ddlDepartamento.SelectedValue))
                {
                    if (this.ddlCiudad.Items.Count > 1)
                    {
                        this.ddlCiudad.Items.Clear();
                        this.ddlCiudad.Items.Add(" Seleccione...");
                        this.ddlCiudad.DataSource = null;
                        this.ddlCiudad.DataBind();
                    }
                }
                else
                {
                    this.CargarMunicipios();
                }

                if (ddlUniversidad.Items.Count > 1)
                {
                    this.ddlUniversidad.Items.Clear();
                    this.ddlUniversidad.Items.Add(" Seleccione...");
                    this.ddlUniversidad.DataSource = null;
                    this.ddlUniversidad.DataBind();
                }

                if (this.ddlPrograma.Items.Count > 1)
                {
                    this.ddlPrograma.Items.Clear();
                    this.ddlPrograma.Items.Add(" Seleccione...");
                    this.ddlPrograma.DataSource = null;
                    this.ddlPrograma.DataBind();
                }
            }
            catch (Exception ex)
            {
                string script = JQueryMensaje.ArmaMensaje("Error Plataforma Condonacion Fondos", ex.Message, JQueryMensaje.TipoMensaje.Error);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error dbl", script, true);
            }
        }

        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarInstitucionesPorCiudad();
        }

        private void CargarInstitucionesPorCiudad()
        {
            try
            {
                if (string.IsNullOrEmpty(this.ddlCiudad.SelectedValue))
                {
                    if (this.ddlUniversidad.Items.Count > 1)
                    {
                        this.ddlUniversidad.Items.Clear();
                        this.ddlUniversidad.Items.Add(" Seleccione...");
                        this.ddlUniversidad.DataSource = null;
                        this.ddlUniversidad.DataBind();
                    }
                }
                else
                {
                    this.CargarInstituciones();
                }

                if (this.ddlPrograma.Items.Count > 1)
                {
                    this.ddlPrograma.Items.Clear();
                    this.ddlPrograma.Items.Add(" Seleccione...");
                    this.ddlPrograma.DataSource = null;
                    this.ddlPrograma.DataBind();
                }
            }
            catch (Exception ex)
            {
                string script = JQueryMensaje.ArmaMensaje("Error Plataforma Condonacion Fondos", ex.Message, JQueryMensaje.TipoMensaje.Error);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error dbl", script, true);
            }
        }

        protected void ddlUniversidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarProgramasPorIes();
        }

        private void CargarProgramasPorIes()
        {
            try
            {
                if (string.IsNullOrEmpty(this.ddlCiudad.SelectedValue))
                {
                    if (this.ddlPrograma.Items.Count > 1)
                    {
                        this.ddlPrograma.Items.Clear();
                        this.ddlPrograma.Items.Add(" Seleccione...");
                        this.ddlPrograma.DataSource = null;
                        this.ddlPrograma.DataBind();
                    }
                }
                else
                {
                    this.CargarProgramas();
                }
            }
            catch (Exception ex)
            {
                string script = JQueryMensaje.ArmaMensaje("Error Plataforma Condonacion Fondos", ex.Message, JQueryMensaje.TipoMensaje.Error);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error dbl", script, true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
            this.CargarBeneficiario();
        }

        private void LimpiarControles()
        {
            this.ddlDepartamento.Items.Clear();
            this.ddlDepartamento.Items.Add(" Seleccione...");
            this.ddlDepartamento.DataSource = null;
            this.ddlDepartamento.DataBind();
            this.CargarDeptos();

            this.ddlCiudad.Items.Clear();
            this.ddlCiudad.Items.Add(" Seleccione...");
            this.ddlCiudad.DataSource = null;
            this.ddlCiudad.DataBind();

            this.ddlUniversidad.Items.Clear();
            this.ddlUniversidad.Items.Add(" Seleccione...");
            this.ddlUniversidad.DataSource = null;
            this.ddlUniversidad.DataBind();

            this.ddlPrograma.Items.Clear();
            this.ddlPrograma.Items.Add(" Seleccione...");
            this.ddlPrograma.DataSource = null;
            this.ddlPrograma.DataBind();

            this.ddlTipoAval.SelectedIndex = 0;
        }

        protected void btnRadicar_Click(object sender, EventArgs e)
        {
            if (this.btnRadicar.Visible.Equals(true))
            {
                if (this.ddlDepartamento.SelectedIndex > 0)
                    this.usuarioEntity.IdDepartamento = this.ddlDepartamento.SelectedValue;

                if (this.ddlCiudad.SelectedIndex > 0)
                    this.usuarioEntity.IdMunicipio = this.ddlCiudad.SelectedValue;

                if (this.ddlUniversidad.SelectedIndex > 0)
                    this.usuarioEntity.Codsnies_Inst = this.ddlUniversidad.SelectedValue;

                if (this.ddlPrograma.SelectedIndex > 0)
                    this.usuarioEntity.CodSnies_Prog = this.ddlPrograma.SelectedValue;

                if (this.ddlTipoAval.SelectedIndex > 0)
                    this.usuarioEntity.IdAval = this.ddlTipoAval.SelectedValue;

                if (!string.IsNullOrEmpty(this.txtFecha.Text))
                    this.usuarioEntity.Fecha_Finalizacion_Materias = Convert.ToDateTime((this.txtFecha.Text));

                this.usuarioEntity.IdEstado = this.usuarioEntity.IdEstado == 0 ? 1 : this.usuarioEntity.IdEstado;
                this.usuarioEntity.RutaArchivo1 = ObtenerArchivo(this.fulDocumentoAval, false, 1024000);
                this.usuarioEntity.Observacion = ResourceConst.ConstConfirmacionRegistroAval;

                string script = string.Empty;
                string idConfirmacion = this.usuarioBusiness.RegistrarBeneficiarioAval(this.usuarioEntity);

                if (string.IsNullOrEmpty(idConfirmacion))
                {
                    script = JQueryMensaje.ArmaMensaje("Plataforma de Condonación", "Error al Guardar Formulario.", JQueryMensaje.TipoMensaje.Error);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirmodal", script, true);
                }
                else
                {
                    script = JQueryMensaje.ArmaMensaje("Plataforma de Condonación", "La solicitud fue radicada exitosamente con el radicado # " + idConfirmacion, JQueryMensaje.TipoMensaje.Informativo);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirmodal", script, true);
                    this.lblEstadoBeneficiario.Text = ResourceConst.ConstConfirmacionRegistroAval;

                    this.gvBeneficiario.DataSource = this.usuarioBusiness.ObtenerListadoBeneficiario(this.usuarioEntity.IdSolicitante, "A");
                    this.gvBeneficiario.DataBind();
                    this.CargarBeneficiario();
                    this.BloquearControles();
                }

                HtmlGenericControl linkTabAval = (HtmlGenericControl)this.Parent.FindControl("linkTabAval");
                HtmlGenericControl linkTabCond = (HtmlGenericControl)this.Parent.FindControl("linkTabCond");
                HtmlGenericControl linkTabCondonacion = (HtmlGenericControl)this.Parent.FindControl("linkTabCondonacion");

                HtmlGenericControl menuCond = (HtmlGenericControl)this.Parent.FindControl("menuCond");
                HtmlGenericControl menuAval = (HtmlGenericControl)this.Parent.FindControl("menuAval");
                HtmlGenericControl menuCondonacion = (HtmlGenericControl)this.Parent.FindControl("menuCondonacion");

                linkTabCond.Attributes["class"] = null;
                linkTabAval.Attributes["class"] = "active";
                linkTabCondonacion.Attributes["class"] = null;
                menuCond.Attributes["class"] = "tab-pane fade";
                menuAval.Attributes["class"] = "tab-pane fade in active";
                menuCondonacion.Attributes["class"] = "tab-pane fade";
            }
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

        protected void ddlTipoAval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["Avales"] != null && !string.IsNullOrEmpty(this.ddlTipoAval.SelectedValue))
            {
                AvalEntity avalEntity = new AvalEntity();
                avalEntity = ((List<AvalEntity>)Session["Avales"]).Find(a => a.IdAval.Equals(this.ddlTipoAval.SelectedValue));
                string pathAnexo = Path.Combine(ResourceConst.PathAnexos, avalEntity.Formato_Aval);
                this.linkFormato.HRef = pathAnexo;
                this.linkFormato.Title = pathAnexo;
                this.linkFormato.InnerHtml = avalEntity.Formato_Aval;
                linkFormato.Visible = true;
            }
        }

        protected void gvBeneficiario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvBeneficiario.PageIndex = e.NewPageIndex;
            this.gvBeneficiario.DataSource = this.usuarioBusiness.ObtenerListadoBeneficiario(this.usuarioEntity.IdSolicitante, "A");
            this.gvBeneficiario.DataBind();
        }
    }
}