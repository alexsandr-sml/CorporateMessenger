using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Common;
using System.IO;
using System.Data.SQLite;

namespace DAL.Tools
{
    public class SQLTools
    {
        DbProviderFactory _df;
        string _stringConnection = string.Empty;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="DataBaseName">Имя базы данных</param>
        /// <param name="SQLProvider">SQL Provider (по-умолчанию System.Data.SqlClient) </param>
        public SQLTools(string dataBaseName, string SQLProvider = "System.Data.SQLite")
        {
            _df = DbProviderFactories.GetFactory(SQLProvider);
            if (!string.IsNullOrEmpty(dataBaseName))
                _stringConnection = GetConnectionString(dataBaseName);
        }

        /// <summary>
        /// Возвращает DataTable SQL запроса
        /// </summary>
        /// <param name="SQL">SQL запрос</param>
        /// <param name="paramList">Список параметров</param>
        /// <returns>DataTable</returns>
        public DataTable SQLExecuteQuery(string SQL, DbParameter[] paramList = null)
        {
            using (var conn = _df.CreateConnection())
            {
                try
                {
                    conn.ConnectionString = _stringConnection;
                    conn.Open();
                }
                catch
                {
                    return null;
                }

                using (var cmd = _df.CreateCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = SQL;
                    if (paramList != null)
                        cmd.Parameters.AddRange(paramList);

                    using (var adapter = CreateDataAdapter(conn))
                    {
                        adapter.SelectCommand = cmd;
                        var dataset = new DataSet();
                        adapter.Fill(dataset);

                        return dataset.Tables[0];
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает число изменынных записей в результате выполнения SQL запроса
        /// </summary>
        /// <param name="sql">SQL запрос</param>
        /// <param name="paramList">Параметры запроса</param>
        /// <returns>int</returns>
        public int SQLExecuteNonQuery(string sql, DbParameter[] paramList = null)
        {
            using (var conn = _df.CreateConnection())
            {
                conn.ConnectionString = _stringConnection;
                conn.Open();
                using (var cmd = _df.CreateCommand())
                {
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        if (paramList != null)
                            cmd.Parameters.AddRange(paramList);

                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ошибка открытия БД", ex);
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает Id измененной записи
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public int SQLExecuteIdQuery(string sql, DbParameter[] paramList = null)
        {
            using (var conn = _df.CreateConnection())
            {
                conn.ConnectionString = _stringConnection;
                conn.Open();
                using (var cmd = _df.CreateCommand())
                {
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        if (paramList != null)
                            cmd.Parameters.AddRange(paramList);

                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ошибка открытия БД", ex);
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает Id объекта добавленного в БД
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="parameters">Параметры</param>
        /// <returns>int</returns>
        public int InsertIntoTable(string tableName, List<object> parameters)
        {
            var prms = new List<DbParameter>();
            var sqlFields = "";
            var sqlValues = "";

            for (int i = 0; i < parameters.Count; i += 2)
            {
                var fieldName = parameters[i].ToString();
                var value = parameters[i + 1];

                if (fieldName == "Id")
                    continue;

                var dbParam = _df.CreateParameter();
                dbParam.ParameterName = "@" + fieldName;
                dbParam.Value = value ?? DBNull.Value;
                prms.Add(dbParam);

                sqlFields += fieldName;
                sqlValues += "@" + fieldName;

                if (i > 0)
                {
                    sqlFields += ", ";
                    sqlValues += ", ";
                }
            }
            var sql = "Insert Into " + tableName + " (" + sqlFields.Remove(sqlFields.LastIndexOf(','), 1) + ") Values (" + sqlValues.Remove(sqlValues.LastIndexOf(','), 1) + "); select last_insert_rowid();";

            return SQLExecuteIdQuery(sql, prms.ToArray());
        }

        /// <summary>
        /// Возвращает число удаленных записей
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="parameters">Параметры</param>
        /// <returns>int</returns>
        public int DeleteFromTable(string tableName, List<object> parameters)
        {
            var prms = new List<DbParameter>();
            var fieldName = parameters[0].ToString();
            var value = parameters[1];
            var dbParam = _df.CreateParameter();
            dbParam.ParameterName = "@" + fieldName;
            dbParam.Value = value ?? DBNull.Value;
            prms.Add(dbParam);
            var sql = "Delete From " + tableName + " Where " + fieldName + " = " + "@" + fieldName + ";";
            return SQLExecuteNonQuery(sql, prms.ToArray());
        }

        /// <summary>
        /// Возвращает число измененых записей в БД
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="parameters">Список параметров</param>
        /// <returns>int</returns>
        public int EditItems(string tableName, List<object> parameters)
        {
            var prms = new List<DbParameter>();
            var sqlParam = string.Empty;
            var dbParamId = _df.CreateParameter();

            for (int i = 0; i < parameters.Count; i+=2)
            {
                var fieldName = parameters[i].ToString();
                var value = parameters[i + 1];

                if (fieldName == "Id")
                {
                    dbParamId.ParameterName = "@" + fieldName;
                    dbParamId.Value = value ?? DBNull.Value;
                    continue;
                }

                var dbParam = _df.CreateParameter();
                dbParam.ParameterName = "@" + fieldName;
                dbParam.Value = value ?? DBNull.Value;
                prms.Add(dbParam);

                sqlParam += fieldName + " = " + "@" + fieldName + ", ";
            }

            prms.Add(dbParamId);
            var sql = "UPDATE " + tableName + " SET " + sqlParam.Remove(sqlParam.LastIndexOf(','), 1) + " WHERE Id = " + dbParamId.ParameterName + ";";
            return SQLExecuteNonQuery(sql, prms.ToArray());
        }

        /// <summary>
        /// Возвращает DataTable 
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <returns>DataTable</returns>
        public DataTable GetTable(string tableName){
            var sql = "SELECT * FROM " + tableName;
            return SQLExecuteQuery(sql);
        }

        /// <summary>
        /// Возвращает строку подключения к серверу
        /// </summary>
        /// <param name="NameDB">Имя БД</param>
        /// <param name="NameServer">Имя Сервера</param>
        /// <returns></returns>
        private string GetConnectionString(string dataBaseName, int version = 3)
        {
            return string.Format("Data Source={0}; Version={1}", dataBaseName, version);
        }

        private DbDataAdapter CreateDataAdapter(DbConnection connection)
        {
            return DbProviderFactories.GetFactory(connection).CreateDataAdapter();
        }

        /// <summary>
        /// Возвращает true при успешном подключении к SQL Server
        /// </summary>
        /// <returns>bool</returns>
        public bool IsServerConnected()
        {
            using (var conn = _df.CreateConnection())
            {
                try
                {
                    conn.ConnectionString = _stringConnection;
                    conn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
