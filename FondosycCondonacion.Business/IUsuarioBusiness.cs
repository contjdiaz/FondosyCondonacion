using FondosycCondonacion.Business.Common;
using FondosycCondonacion.Entities;
using System.Collections.Generic;
using System.IO;

namespace FondosycCondonacion.Business
{
    /// <summary>
    /// Interfaz de usuariobusiness
    /// </summary>
    public interface IUsuarioBusiness
    {
        /// <summary>
        /// Metodo que valida usuario
        /// </summary>
        /// <param name="email">string de entrada</param>
        /// <param name="password">string de entrada</param>
        /// <param name="convocatoria">string de entrada</param>
        /// <returns>Retorna booleano</returns>
        UsuarioEntity ValidarUsuario(string email, string password, string convocatoria);

        /// <summary>
        /// Valida la autenticacion del usuario en el sistema c&ctex
        /// </summary>
        /// <param name="login">string de entrada</param>
        /// <param name="password">string de entrada</param>
        /// <param name="nameFile">string de entrada</param>
        /// <returns>Retorna booleano</returns>
        bool ValidarUsuarioIcetex(string login, string password, string nameFile);

        /// <summary>
        /// Metodo que consulta beneficiarios registrados
        /// </summary>
        /// <param name="IdSolicitante">int de entrada</param>
        /// <param name="IdProceso">string de entrada</param>
        /// <returns>Retorna entidad UsuarioEntity</returns>
        UsuarioEntity ObtenerBeneficiario(int IdSolicitante, string IdProceso);

        /// <summary>
        /// Metodo que consulta beneficiarios registrados
        /// </summary>
        /// <param name="IdSolicitante">int de entrada</param>
        /// <param name="IdProceso">string de entrada</param>
        /// <returns>Retorna lista UsuarioEntity</returns>
        List<UsuarioEntity> ObtenerListadoBeneficiario(int IdSolicitante, string IdProceso);

        /// <summary>
        /// Metodo que consulta beneficiarios registrados para una convocatoria en Aval o Condonacion
        /// </summary>
        /// <param name="IdConvocatoria">int de entrada</param>
        /// <param name="IdProceso">string de entrada</param>
        /// <param name="TipoArchivo">int de entrada</param>
        /// <returns></returns>
        List<UsuarioEntity> ObtenerBeneficiarios(int IdConvocatoria, string IdProceso, int TipoArchivo);

        /// <summary>
        /// Metodo que consulta puntaje de beneficiarios registrados
        /// </summary
        /// <returns>Retorna listado de objeto UsuarioEntity</returns>
        List<UsuarioEntity> ObtenerPuntajeBeneficiarios();

        /// <summary>
        /// Registra beneficiario en aval
        /// </summary>
        /// <param name="usuarioEntity">UsuarioEntity de entrada</param>
        /// <returns>Retorna string</returns>
        string RegistrarBeneficiarioAval(UsuarioEntity usuarioEntity);

        /// <summary>
        /// Registra beneficiario en condonacion
        /// </summary>
        /// <param name="usuarioEntity">UsuarioEntity de entrada</param>
        /// <returns>Retorna RespuestaAjax</returns>
        RespuestaAjax RegistrarBeneficiarioCondonacion(UsuarioEntity usuarioEntity);

        /// <summary>
        /// Actualiza beneficiario en condonacion
        /// </summary>
        /// <param name="usuarioEntity">UsuarioEntity de entrada</param>
        /// <returns>Retorna RespuestaAjax</returns>
        RespuestaAjax ActualizarBeneficiarioCondonacion(UsuarioEntity usuarioEntity);

        /// <summary>
        /// Actualiza beneficiario
        /// </summary>
        /// <param name="IdRadicado">string de entrada</param>
        /// <param name="IdEstado">int de entrada</param>
        /// <param name="Observacion">string de entrada</param>
        /// <param name="UsuarioModifica">string de entrada</param>
        /// <returns>Retorna RespuestaAjax</returns>
        RespuestaAjax ActualizarBeneficiario(string IdRadicado, int IdEstado, string Observacion, string UsuarioModifica);

        /// <summary>
        /// Actualiza puntaje
        /// </summary>
        /// <param name="IdSolicitante">int de entrada</param>
        /// <param name="Puntaje">int de entrada</param>
        /// <param name="Cumplepuntaje">string de entrada</param>
        /// <param name="UsuarioModifica">string de entrada</param>
        /// <returns>Retorna RespuestaAjax</returns>
        RespuestaAjax ActualizarPuntaje(int IdSolicitante, int Puntaje, string Cumplepuntaje, string UsuarioModifica);

        /// <summary>
        /// Genera el excel de beneficiarios
        /// </summary>
        /// <param name="plantillaExcel">string de entrada</param>
        /// <param name="IdConvocatoria">int de entrada</param>
        /// <param name="IdProceso">string de entrada</param>
        /// <param name="tipoArchivo">int de entrada</param>
        /// <returns></returns>
        Stream GenerarBeneficiariosExcel(string plantillaExcel, int IdConvocatoria, string IdProceso, int tipoArchivo);

        /// <summary>
        /// Genera el excel de beneficiarios
        /// </summary>
        /// <param name="plantillaExcel">string de entrada</param>
        /// <returns></returns>
        Stream GenerarPuntajeExcel(string plantillaExcel);
    }
}
