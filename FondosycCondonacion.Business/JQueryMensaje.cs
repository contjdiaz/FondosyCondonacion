using System;
using System.Text;

namespace FondosycCondonacion.Business
{
    /// <summary>
    /// Representa un mensaje de JQuery
    /// </summary>
    public class JQueryMensaje
    {
        public enum TipoMensaje
        {
            Alerta = 0,
            Informativo = 1,
            Error = 2,
        }
        /// <summary>
        /// Devuelve el codigo html del mensaje para visualizar
        /// </summary>
        /// <param name="titulo">Titulo del mensaje</param>
        /// <param name="mensaje">mensaje a mostrar</param>
        /// <param name="tipoMsg">tipo de mensaje</param>
        /// <param name="callbackFn">funcion que se ejecuta al cerrar el cuadro de dialogo</param>
        /// <returns>script del mensaje</returns>
        public static string ArmaMensaje(string titulo, string mensaje, TipoMensaje tipoMsg, string callbackFn)
        {
            string strError = String.Format("<div title='{0}'>", titulo);
            strError += TipoMensajeJQ(tipoMsg);
            strError += String.Format("<p style='font-size:10pt; font-family:Arial; color:black'>{0}</p></div>", EncodeJsString(mensaje));
            return ArmaPropiedades(strError, callbackFn);
        }
        /// <summary>
        /// Devuelve el codigo html del mensaje para visualizar
        /// </summary>
        /// <param name="titulo">Titulo del mensaje</param>
        /// <param name="mensaje">mensaje a mostrar</param>
        /// <param name="tipoMsg">tipo de mensaje</param>
        /// <returns>script del mensaje</returns>
        public static string ArmaMensaje(string titulo, string mensaje, TipoMensaje tipoMsg)
        {
            string strError = String.Format("<div title='{0}' style='height: 5px; width:5px;'>", titulo);
            strError += TipoMensajeJQ(tipoMsg);
            strError += String.Format("<p style='font-size:9pt; font-family:Arial; color:black'>{0}</p></div>", EncodeJsString(mensaje));
            return ArmaPropiedades(strError, null);
        }

        /// <summary>
        /// Establece la imagen que se mostrara de acuerdo al tipo de mensaje
        /// </summary>
        /// <param name="enuMensaje">tipo de mensaje</param>
        /// <returns>tag imagen creada</returns>
        private static string TipoMensajeJQ(TipoMensaje enuMensaje)
        {
            switch (enuMensaje)
            {
                case TipoMensaje.Informativo:
                    return String.Format("<img src='{0}/Images/mensaje/info.png' style='height: 60px; width:60;float: left;margin-right: 10px;'/>", System.Web.HttpRuntime.AppDomainAppVirtualPath);
                //return "<img src='~/Images/mensaje/info.png' style='height: 60px; width:60;float: left;margin-right: 10px;'/>";
                case TipoMensaje.Error:
                    return String.Format("<img src='{0}/Images/mensaje/error.png' style='height: 60px; width:60;float: left;margin-right: 10px;'/>", System.Web.HttpRuntime.AppDomainAppVirtualPath);
                //return "<img src='~/Images/mensaje/error.png' style='height: 60px; width:60;float: left;margin-right: 10px;'/>";
                default:
                    return String.Format("<img src='{0}/Images/mensaje/alert.png' style='height: 60px; width:60;float: left;margin-right: 10px;'/>", System.Web.HttpRuntime.AppDomainAppVirtualPath);
                //return "<img src='~/Images/mensaje/alert.png' style='height: 60px; width:60;float: left;margin-right: 10px;'/>";
            }
        }
        /// <summary>
        /// Establece la imagen que se mostrara de acuerdo al tipo de mensaje
        /// </summary>
        /// <param name="enuMensaje">tipo de mensaje</param>
        /// <returns>tag imagen creada</returns>
        private static string TipoMensajeJQFondo(TipoMensaje enuMensaje)
        {
            switch (enuMensaje)
            {
                case TipoMensaje.Informativo:
                    return String.Format("<img src='../../../images/mensaje/info.png' style='height: 60px; width:60;float: left;margin-right: 10px;'/>");
                case TipoMensaje.Error:
                    return String.Format("<img src='../../../images/mensaje/error.png' style='height: 60px; width:60;float: left;margin-right: 10px;'/>");
                default:
                    return String.Format("<img src='../../../images/mensaje/alert.png' style='height: 60px; width:60;float: left;margin-right: 10px;'/>");
            }
        }
        /// <summary>
        /// Arma el JQuery del comportamiento del modal
        /// </summary>
        /// <param name="strError">descripcion del mensaje a mostrar</param>
        /// <param name="callbackFn">funcion que se ejecuta al cerrar el cuadro de dialogo</param>
        /// <returns>string con el objeto creado</returns>
        private static string ArmaPropiedades(string strError, string callbackFn)
        {
            string strReturn = "jQuery(document).ready(function() { ";
            strReturn += "jQuery( \"" + strError + "\").dialog({";
            strReturn += "autoOpen: true,";
            strReturn += "resizable: true,";
            strReturn += "minWidth: 320,";
            strReturn += "minHeight: 120,";
            strReturn += "modal: true,";
            if (!String.IsNullOrEmpty(callbackFn))
                strReturn += "close: function() { " + callbackFn + " },";
            strReturn += "show: { ";
            strReturn += "effect: 'slide',";
            strReturn += "duration: 500";
            strReturn += "},";
            strReturn += "hide: {";
            strReturn += "effect: 'drop',";
            strReturn += "duration: 500}";

            strReturn += "}); });";

            return strReturn;
        }

        /// <summary>
        /// Codifica una cadena en formato de JSON compatible para JavaScript.
        /// </summary>
        /// <param name="strCadena"></param>
        /// <returns>Cadena con codificación JSON</returns>
        private static string EncodeJsString(string strCadena)
        {
            //Código obtenido de http://www.west-wind.com/weblog/posts/2007/Jul/14/Embedding-JavaScript-Strings-from-an-ASPNET-Page
            StringBuilder sb = new StringBuilder();
            foreach (char c in strCadena)
            {
                switch (c)
                {
                    case '\"':
                        sb.Append("'");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        int i = (int)c;
                        if (i < 32 || i > 127)
                        {
                            sb.AppendFormat("\\u{0:X04}", i);
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }

            return sb.ToString();
        }
    }
}