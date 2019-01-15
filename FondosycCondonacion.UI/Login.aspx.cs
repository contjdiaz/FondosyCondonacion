using FondosycCondonacion.Business;
using FondosycCondonacion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FondosycCondonacion.UI
{
    public partial class Login : System.Web.UI.Page
    {
        private IUsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        private UsuarioEntity usuarioEntity = new UsuarioEntity();
        string script;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["IdConv"]))
            {
                Label lblNombreConvocatoria = (Label)LoginMain.FindControl("lblNombreConvocatoria");

                if (Request.QueryString["IdConv"].Equals("8809"))
                {
                    lblNombreConvocatoria.Text = Resources.ResourceConst.ConstPrimeraConvocatoria;
                }
                else if (Request.QueryString["IdConv"].Equals("9084"))
                {
                    lblNombreConvocatoria.Text = Resources.ResourceConst.ConstSegundaConvocatoria;
                }
            }
        }

        protected void LoginMain_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                TextBox txtCapcha = (TextBox)LoginMain.FindControl("txtCapcha");

                if (Request.QueryString["IdConv"] == null || string.IsNullOrEmpty(Request.QueryString["IdConv"]))
                {
                    script = JQueryMensaje.ArmaMensaje("Error.", "No es una convocatoria valida, por favor ingrese con una convocatoria valida.", JQueryMensaje.TipoMensaje.Error);
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "abrirmodal", script, true);
                }
                else
                {
                    //Valida usuario y password
                    this.usuarioEntity = this.usuarioBusiness.ValidarUsuario(LoginMain.UserName, LoginMain.Password, Request.QueryString["IdConv"]);
                    if (!this.usuarioEntity.SeAutentica)
                    {
                        LoginMain.FailureText = "El nombre de usuario o el password no son validos, por favor verifique e intente nuevamente.";

                        script = JQueryMensaje.ArmaMensaje("Error.", "El nombre de usuario o el password no son validos, por favor verifique e intente nuevamente.", JQueryMensaje.TipoMensaje.Error);
                        ClientScript.RegisterClientScriptBlock(Page.GetType(), "abrirmodal", script, true);
                        return;
                    }
                }

                //VALIDACIÓN CÓDIGO CAPTHCHA
                if (txtCapcha.Text.ToUpper() != Session["Captcha"].ToString())
                {
                    LoginMain.FailureText = "El código de la imagen no corresponde.";
                    return;
                }

                this.usuarioEntity.Login = LoginMain.UserName;
                this.usuarioEntity.Password = LoginMain.Password;
                this.usuarioEntity.IdConvocatoria = Request.QueryString["IdConv"];
                Session["Usuario"] = this.usuarioEntity;

                FormsAuthentication.RedirectFromLoginPage(LoginMain.UserName, LoginMain.RememberMeSet);
                Response.Redirect("~/NivelFormacion/NivelFormacion.aspx", false);
            }
            catch (Exception ex)
            {
                script = JQueryMensaje.ArmaMensaje("Error.", ex.Message, JQueryMensaje.TipoMensaje.Error);
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "abrirmodal", script, true);
            }
        }
    }
}