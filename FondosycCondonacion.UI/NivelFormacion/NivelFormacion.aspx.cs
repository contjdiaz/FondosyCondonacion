using FondosycCondonacion.Business;
using FondosycCondonacion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FondosycCondonacion.UI.NivelFormacion
{
    public partial class NivelFormacion : System.Web.UI.Page
    {
        UsuarioEntity usuarioEntity = new UsuarioEntity();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = "Nivel de Formación";

            try
            {
                this.Inicializar();
            }
            catch (Exception ex)
            {
                string script = JQueryMensaje.ArmaMensaje("Error Plataforma Condonacion Fondos", ex.Message, JQueryMensaje.TipoMensaje.Error);
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "Error load", script, true);
            }
        }

        /// <summary>
        /// Se utiliza para resetea las varibles siempre que se ingrese 
        /// a la aplicacion o se haga un postback
        /// </summary>
        private void Inicializar()
        {
            if (Session["Usuario"] != null)
            {
                this.usuarioEntity = (UsuarioEntity)Session["Usuario"];
                if (this.usuarioEntity.TipoPrograma.Equals("E"))
                {
                    this.imgEspecializacion.Visible = true;
                    this.imgMaestria.Visible = false;
                }
                else
                {
                    this.imgEspecializacion.Visible = false;
                    this.imgMaestria.Visible = true;
                }

                if (this.usuarioEntity.IdConvocatoria.Equals("8809"))
                {
                    this.imgBanner.Src = "~/Images/banner_PrimeraConvocatoria.jpg";
                }
                else if (this.usuarioEntity.IdConvocatoria.Equals("9084"))
                {
                    this.imgBanner.Src = "~/Images/banner_SegundaConvocatoria.png";
                }
            }
        }

        protected void imgEspecializacion_Click(object sender, ImageClickEventArgs e)
        {
            ((UsuarioEntity)Session["Usuario"]).IdNivel = 5;
            Response.Redirect("~/Condonacion/PlataformaCondonacion.aspx", false);
        }

        protected void imgMaestria_Click(object sender, ImageClickEventArgs e)
        {
            ((UsuarioEntity)Session["Usuario"]).IdNivel = 6;
            Response.Redirect("~/Condonacion/PlataformaCondonacion.aspx", false);
        }
    }
}