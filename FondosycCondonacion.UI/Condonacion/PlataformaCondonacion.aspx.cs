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
using System.Web.UI.WebControls;

namespace FondosycCondonacion.UI.Condonacion
{
    public partial class PlataformaCondonacion : System.Web.UI.Page
    {
        #region "DECLARACIONES"

        UsuarioEntity usuarioEntity = new UsuarioEntity();

        UsuarioEntity beneficiarioEntity = new UsuarioEntity();

        /// <summary>
        /// Instancia la clase Institucion de la entidad
        /// </summary>
        InstitucionEntity entidad = new InstitucionEntity();

        private IUsuarioBusiness usuarioBusiness = new UsuarioBusiness();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.Inicializar();
                if (this.ValidarIngreso())
                {
                    if (this.Header.FindControl("StyleDynamic") == null)
                        this.CargarEstilo();
                }
                else
                {
                    Response.Redirect("AccesoDenegado.aspx", false);
                }
            }
            catch (Exception ex)
            {
                string script = JQueryMensaje.ArmaMensaje("Error Plataforma Condonacion Fondos", ex.Message, JQueryMensaje.TipoMensaje.Error);
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "Error load", script, true);
            }
        }

        private void CargarEstilo()
        {
            //Primera convocatoria de Gobierno electronico
            if (this.usuarioEntity.IdConvocatoria.Equals("8809"))
            {
                this.UcEspecializacion2.Visible = false;
                this.UcMaestria2.Visible = false;
                this.lblConvocatoria.Text = "CONDONACIÓN – Primera Convocatoria de Gobierno Electrónico";
                this.urlExplicativoCondonacion.HRef = Path.Combine(ResourceConst.PathPlantillas, "Explicativo Condonacion Primera Convocatoria de Gobierno Electronico.pdf");
                this.urlExplicativoCondonacion.Title = "Descargar archivo 'Explicativo Condonación Primera Convocatoria de Gobierno Electrónico.pdf'";
                this.urlExplicativoCondonacion.InnerHtml = "Descargar archivo 'Explicativo Condonación Primera Convocatoria de Gobierno Electrónico.pdf'";

                //Especializacion
                if (usuarioEntity.IdNivel.Equals(5))
                {
                    this.lblNivel.Text = ResourceConst.ConstEspecializacion;
                    CssAdder.AddCss(ResourceConst.PathStyleEspecializacion, this.Page);
                    this.UcEspecializacion.Visible = true;
                    this.UcMaestria.Visible = false;
                }
                //Maestria
                else
                {
                    this.lblNivel.Text = ResourceConst.ConstMaestria;
                    CssAdder.AddCss(ResourceConst.PathStyleMaestria, this.Page);
                    this.UcMaestria.Visible = true;
                    this.UcEspecializacion.Visible = false;
                }
            }
            //Segunda convocatoria de Gobierno electronico
            else if (this.usuarioEntity.IdConvocatoria.Equals("9084"))
            {
                this.UcEspecializacion.Visible = false;
                this.UcMaestria.Visible = false;
                this.lblConvocatoria.Text = "CONDONACIÓN – Segunda Convocatoria de Gobierno Electrónico";
                this.urlExplicativoCondonacion.HRef = Path.Combine(ResourceConst.PathPlantillas, "Explicativo Condonacion Segunda Convocatoria de Gobierno Electronico.pdf");
                this.urlExplicativoCondonacion.Title = "Descargar archivo 'Explicativo Condonación Segunda Convocatoria de Gobierno Electrónico.pdf'";
                this.urlExplicativoCondonacion.InnerHtml = "Descargar archivo 'Explicativo Condonación Segunda Convocatoria de Gobierno Electrónico.pdf'";

                //Especializacion
                if (usuarioEntity.IdNivel.Equals(5))
                {
                    this.lblNivel.Text = ResourceConst.ConstEspecializacion;
                    CssAdder.AddCss(ResourceConst.PathStyleEspecializacion, this.Page);
                    this.UcEspecializacion2.Visible = true;
                    this.UcMaestria2.Visible = false;
                }
                //Maestria
                else
                {
                    this.lblNivel.Text = ResourceConst.ConstMaestria;
                    CssAdder.AddCss(ResourceConst.PathStyleMaestria, this.Page);
                    this.UcMaestria2.Visible = true;
                    this.UcEspecializacion2.Visible = false;
                }
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
    }
}