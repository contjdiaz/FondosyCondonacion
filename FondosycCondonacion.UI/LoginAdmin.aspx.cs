using FondosycCondonacion.Business;
using FondosycCondonacion.Entities;
using Resources;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FondosycCondonacion.UI
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        private IUsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        private string text;

        protected void LoginMain_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                TextBox txtCapcha = (TextBox)LoginMain.FindControl("txtCapcha");

                //Valida usuario y password
                if (!this.usuarioBusiness.ValidarUsuarioIcetex(LoginMain.UserName, LoginMain.Password, ResourceConst.PathFileUsers))
                {
                    LoginMain.FailureText = "El nombre de usuario o el password no son validos por favor verifique e intente nuevamente.";
                    text = JQueryMensaje.ArmaMensaje("Error.", "El nombre de usuario o el password no son validos por favor verifique e intente nuevamente.", JQueryMensaje.TipoMensaje.Error);
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "abrirmodal", text, true);
                    return;
                }

                //VALIDACIÓN CÓDIGO CAPTHCHA
                if (txtCapcha.Text.ToUpper() != Session["Captcha"].ToString())
                {
                    text = JQueryMensaje.ArmaMensaje("Error.", "El código de la imagen no corresponde.", JQueryMensaje.TipoMensaje.Error);
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "abrirmodal", text, true);
                    return;
                }

                UsuarioIcetexEntity usuarioIcetexEntity = new UsuarioIcetexEntity() { Login = LoginMain.UserName, Password = LoginMain.Password };
                Session["UsuarioIcetex"] = usuarioIcetexEntity;

                FormsAuthentication.RedirectFromLoginPage(LoginMain.UserName, LoginMain.RememberMeSet);
                Response.Redirect("~/Administracion/CalificarBeneficiario.aspx", false);
            }
            catch (Exception ex)
            {
                string script = JQueryMensaje.ArmaMensaje("Error.", ex.Message, JQueryMensaje.TipoMensaje.Error);
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "abrirmodal", script, true);
            }
        }
    }
}