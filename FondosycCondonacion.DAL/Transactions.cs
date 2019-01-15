using log4net;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;

namespace FondosycCondonacion.DAL
{
    /// <summary>
    /// Clase encargada de las transacciones con base de datos
    /// </summary>
    public class Transactions
    {
        #region Atritutos generales

        private static readonly ILog log = LogManager.GetLogger(typeof(Transactions));
        OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["C_CTEXDB"].ToString());

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public Transactions()
        {
            this.Open();
        }

        /// <summary>
        /// Metodo que abre conexion
        /// </summary>
        private void Open()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (OracleException ex)
            {
                log.Error("Error abriendo conexion", ex);
            }
        }

        /// <summary>
        /// Metodo que cierra conexion
        /// </summary>
        private void Close()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error cerrando conexion", ex);
            }
        }

        /// <summary>
        /// Metodo que ejecuta stored procedure
        /// </summary>
        /// <param name="storedProcedure">Nombre del stored procedure</param>
        /// <param name="param">Parametros de entrada</param>
        public int ExecuteCMD(string storedProcedure, OracleParameter[] param)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcedure;
            cmd.Connection = conn;

            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                log.Error("Error ejecutando ExecuteCMD", ex);
                return 0;
            }
            finally
            {
                this.Close();
                cmd.Dispose();
            }
        }

        /// <summary>
        /// Metodo que ejecuta stored procedure retornando datatable
        /// </summary>
        /// <param name="storedProcedure">Nombre del stored procedure</param>
        /// <param name="param">Parametros de entrada</param>
        public DataTable ExecuteDataTableCMD(string storedProcedure, OracleParameter[] param)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcedure;
            cmd.Connection = conn;

            DataTable dt = new DataTable();

            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            try
            {
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (OracleException ex)
            {
                log.Error("Error ejecutando ExecuteDataTableCMD", ex);
                return null;
            }
            finally
            {
                this.Close();
                cmd.Dispose();
            }
        }
    }
}
