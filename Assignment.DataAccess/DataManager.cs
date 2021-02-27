using Assignment.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DataAccess
{
    public class DataManager
    {
        #region Private Variables

        /// <summary>
        /// Hold the database connection string
        /// </summary>
        private static string _databaseConnectionString;

        #endregion

        #region Private Properties

        /// <summary>
        /// Database connection string
        /// </summary>
        private static string DatabaseConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(_databaseConnectionString))
                {
                    _databaseConnectionString = GetDatabaseConnectionString();
                }
                return _databaseConnectionString;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get database connection string
        /// </summary>
        /// <returns></returns>
        private static string GetDatabaseConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[Constants.DatabaseConnectionStringName].ConnectionString;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Check database connection
        /// </summary>
        /// <returns>Database connected or not</returns>
        public static bool TestConnection()
        {
            try
            {
                bool returnResult = false;
                using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnectionString))
                {
                    sqlConnection.Open();
                    if (sqlConnection.State == ConnectionState.Open)
                        returnResult = true;
                    sqlConnection.Close();
                }
                return returnResult;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        #region Execute

        /// <summary>
        /// Execute query by procedure
        /// </summary>
        /// <param name="procedureName">Procedure name</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Query execute or not by checking the affected rows</returns>
        public static bool ExecuteQuery(string procedureName, List<SqlParameter> parameters)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand(procedureName, sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(new SqlParameter(parameter.ParameterName, parameter.SqlValue));
                        }
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Execute query by query
        /// </summary>
        /// <param name="sqlQuery">Query</param>
        /// <returns>Query execute or not</returns>
        public static bool ExecuteQuery(string sqlQuery)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion

        #region Read

        /// <summary>
        /// Execute reader by procedure
        /// </summary>
        /// <param name="procedureName">procedure name</param>
        /// <param name="parameters">parameters</param>
        /// <returns>Data set</returns>
        public static DataSet ExecuteReader(string procedureName, List<SqlParameter> parameters)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand command = sqlConnection.CreateCommand();
                    command.CommandText = procedureName;
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet returnResult = new DataSet();
                        adapter.Fill(returnResult);
                        return returnResult;
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Execute reader by SQL query
        /// </summary>
        /// <param name="sqlQuery">Query</param>
        /// <returns>Data set</returns>
        public static DataSet ExecuteReader(string sqlQuery)
        {
            try
            {
                DataSet returnResult = new DataSet();
                using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(returnResult);
                            return returnResult;
                        }
                    }
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public static int GetLastRecordIdentity(string tableName)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand($"SELECT IDENT_CURRENT ('{tableName}')", sqlConnection))
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion

        #endregion
    }
}
