using System;
using System.Data;
using System.Configuration;
using Oracle.DataAccess.Client;
using System.IO;

namespace NivelAccesDate
{
    public static class SqlDBHelper
    {
        private const int EROARE_LA_EXECUTIE = 0;

        private static string _connectionString = null;
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.AppSettings.Get("StringConectareBD");
                }
                return _connectionString;
            }
        }

        public static bool TestConnection()
        {
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (OracleException)
                {
                    return false;
                }
            }
        }

        public static DataSet ExecuteDataSet(string sql, CommandType cmdType, params OracleParameter[] parameters)
        {
            using (DataSet ds = new DataSet())
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.CommandType = cmdType;
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }

                    try
                    {
                        new OracleDataAdapter(cmd).Fill(ds);
                    }
                    catch (OracleException)
                    {
                        // Salvați excepțiile în fișiere log sau utilizați un mecanism de înregistrare a erorilor
                    }
                    return ds;
                }
            }
        }

        public static bool ExecuteNonQuery(string sql, CommandType cmdType, params OracleParameter[] parameters)
        {
            
                int rezult = EROARE_LA_EXECUTIE;
                using (OracleConnection conn = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.CommandType = cmdType;
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(item);
                        }

                        try
                        {
                            cmd.Connection.Open();
                            rezult = cmd.ExecuteNonQuery();
                        }
                        catch (OracleException ex)
                        {
                            using (StreamWriter streamWriter = new StreamWriter("D:\\UNI\\Anul3\\Sem2\\BD\\ProiectBD\\NivelAccesDate\\SQLOG.txt", true))
                            {
                                streamWriter.WriteLine(ex.ToString());
                            }
                        }
                    }
                }
                return Convert.ToBoolean(rezult);
            
        }
    }
}
