using Newtonsoft.Json;
using System;

namespace FondosycCondonacion.Business.Common
{
    /// <summary>
    /// Indica el estado de la respuesta cuando se hace una invocación ajax
    /// </summary>
    public enum EstadoRespuesta : int
    {
        /// <remarks>Estado exisitoso</remarks>
        OK = 1,
        /// <remarks>Estado desconocido</remarks>
        UNKNOWN = 0,
        /// <remarks>Un error ha ocurrido mientras se procesaba la solicitud</remarks>
        ERROR = -1,

    }


    [Serializable]
    public class RespuestaAjax
    {
        //Identifica el estado de la operacion a través de la enumeración EstadoRespuesta
        public EstadoRespuesta Estado { get; set; }


        //Contiene el mensaje a mostar producto de la operación
        public string Mensage { get; set; }

        //Contiene la información resultante, por ejemplo un id,  etc.
        public object Data { get; set; }

        //indica el número de filas afectas por la solicitud
        public int FilasAfactadas { get; set; }

        public RespuestaAjax()
        {
            this.Estado = EstadoRespuesta.OK;
            this.Mensage = string.Empty;
        }


        //Método que muesta la represetación en string format json para un objeto de la clase RespuestaAjax
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
