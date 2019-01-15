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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        /// <summary>
        /// Evento de cargue inicial de la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.form1.DefaultButton = this.Button1.UniqueID;
                if (this.Session["Usuario"] != null)
                    this.lblUsuario.Text = ((UsuarioEntity)(this.Session["Usuario"])).NombreCompleto;

                if (this.Session["UsuarioIcetex"] != null)
                    this.lblUsuario.Text = ((UsuarioIcetexEntity)(this.Session["UsuarioIcetex"])).Login;
            }
        }

        /// <summary>
        /// Evento click del boton cerrar sesion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            this.Session.Abandon();

            if (this.Session["Usuario"] != null)
                this.Response.Redirect("~/Login.aspx?IdConv=" + ((UsuarioEntity)(this.Session["Usuario"])).IdConvocatoria, false);

            if (this.Session["UsuarioIcetex"] != null)
                this.Response.Redirect("~/LoginAdmin.aspx", false);
        }
    }
}