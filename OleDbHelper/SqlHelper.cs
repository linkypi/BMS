using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using System.Data.OleDb;

namespace BMS.DbHelper
{
    /// <summary>
    /// 该类封装了操作Sql Server数据库的基本方法
    /// </summary>
    public  class SqlHelper
    {
        private static readonly SqlHelper sh = new SqlHelper();

        private static  string DBConnectionString
        {
            get
            {
                try
                {    
                    //return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BMS.accdb;Persist Security Info=False";//
                    return ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                }
                catch (Exception e)
                {
                   // Log.CreateErrorLog(e.ToString());
                    throw e; 
                }
            }
        }


        /// <summary>
        /// 实体插入
        /// </summary>
        /// <param name="sqlStr">插入实体字符串</param>
        /// <param name="paramsDict">要插入的参数字典，即多个参数的键值对（参数名和参数所对应的值）</param>
        /// <returns>运行结果：-2：参数列表为空</returns>
        public static int InsertDataByString(string sqlStr, Dictionary<string, object> paramsDict)
        {
            return ExecuteNonQuery(sqlStr, CommandType.Text, paramsDict);
        }

        /// <summary>
        /// 实体插入，返回受影响的行数
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="paramsDict">要插入的参数字典，即多个参数的键值对（参数名和参数所对应的值）</param>
        /// <returns>运行结果：-2：参数列表为空</returns>
        public static int InsertDataByProc(string procName, Dictionary<string, object> paramsDict)
        {
            return ExecuteNonQuery(procName, CommandType.StoredProcedure, paramsDict);
        }

        /// <summary>
        /// 执行没有返回查询结果的SQL语句，执行成功返回受影响的行数 
        /// </summary>
        /// <param name="cmdText">查询字符串</param>
        /// <param name="paramsDict">参数字典列表</param>
        /// <returns>返回受影响的行数 </returns>
        public static int ExecuteNonQuery(string cmdText, Dictionary<string, object> paramsDict)
        {
            return ExecuteNonQuery(cmdText, CommandType.Text, paramsDict);
        }

        /// <summary>
        /// 查询单条数据 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <param name="paramsValue">查询条件,存储过程参数名--实际要传入的参数值 字典</param>
        /// <param name="returnValueBinding">返回结果里面要对应的存储过程参数, 实体字段名-存储过程返回字段 字典</param>
        /// <returns>要查询的单条数据</returns>
        public static T GetDataModelByProc<T>(string procName, Dictionary<string, object> paramsValue, Dictionary<string, string> returnValueBinding) where T : class, new()
        {
            List<T> list = GetList<T>(procName, CommandType.StoredProcedure, paramsValue, returnValueBinding);
            if (list == null)
                return new T();
            return list[0];
        }

        /// <summary>
        /// 查询单条数据 
        /// </summary>
        /// <typeparam name="T">实体名称</typeparam>
        /// <param name="cmdText">查询字符串</param>
        /// <param name="paramsValue">查询条件,存储过程参数名--实际要传入的参数值 字典</param>
        /// <param name="returnValueBinding">返回结果里面要对应的存储过程参数, 实体字段名-存储过程返回字段 字典</param>
        /// <returns>要查询的单条数据</returns>
        public static T GetDataModelByString<T>(string cmdText, Dictionary<string, object> paramsValue, Dictionary<string, string> returnValueBinding) where T : class, new()
        {
            List<T> list = GetList<T>(cmdText, CommandType.Text, paramsValue, returnValueBinding);
            if (list == null)
                return new T();
            return list[0];
        }

        /// <summary>
        /// 查询数据列表 
        /// </summary>
        /// <typeparam name="T">实体名称</typeparam>
        /// <param name="cmdText">查询字符串</param>
        /// <param name="paramsValue">查询条件,存储过程参数名-实际要传入的参数值 字典</param>
        /// <param name="returnValue">返回结果里面实体字段名，实体字段名-存储过程返回字段  字典</param>
        /// <returns>要查询的列表数据</returns>
        public static List<T> GetDataListByString<T>(string cmdText, Dictionary<string, object> paramsValue, Dictionary<string, string> returnValueBinding) where T : class, new()
        {
            List<T> list = GetList<T>(cmdText, CommandType.Text, paramsValue, returnValueBinding);
            if (list == null)
                return new List<T>();
            return list;
        }

        /// <summary>
        /// 查询数据列表 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <param name="paramsValue">查询条件,存储过程参数名-实际要传入的参数值 字典</param>
        /// <param name="returnValue">返回结果里面要对应的存储过程参数, 实体字段名-存储过程返回字段 字典</param>
        /// <returns>要查询的列表数据</returns>
        public static List<T> GetDataListByProc<T>(string procName, Dictionary<string, object> paramsValue, Dictionary<string, string> returnValueBinding) where T : class, new()
        {
            List<T> list = GetList<T>(procName, CommandType.StoredProcedure, paramsValue, returnValueBinding);
            if (list == null)
                return new List<T>();
            return list;
        }


        /// <summary>
        /// 数据更新 返回受影响的行数
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="paramsDict">要更新的数据, 存储过程参数名<->实际要传入的参数值 字典</param>
        /// <returns>受影响的行数</returns>
        public static int UpdateData(string procName, Dictionary<string, object> paramsDict)
        {
            return ExecuteNonQuery(procName, CommandType.StoredProcedure,paramsDict);
        }

        /// <summary>
        /// 查询返回第一行第一列的查询结果
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="paramsDict"></param>
        /// <returns>返回第一行第一列的结果   </returns>
        public static object ExecuteScalarByProc(string procName, Dictionary<string, object> paramsDict)
        {
            try
            {
                SqlConnection dbConnection = new SqlConnection(DBConnectionString);
                SqlCommand dbCommand = new SqlCommand(procName, dbConnection);
                dbCommand.CommandType = CommandType.StoredProcedure;

                if (paramsDict != null && paramsDict.Count > 0)
                {
                    foreach (KeyValuePair<string, object> kv in paramsDict)
                    {
                        dbCommand.Parameters.AddWithValue(kv.Key, kv.Value);
                    }
                }
                dbCommand.CommandTimeout = 30;
                if (dbConnection.State != ConnectionState.Open)
                    dbConnection.Open();
                object returnObj = dbCommand.ExecuteScalar();
                dbConnection.Close();

                return returnObj;
            }
            catch (System.Exception ex)
            {
                Log.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 执行一条查询语句，返回第一行第一列的结果
        /// </summary>
        /// <param name="cmdText">查询字符串</param>
        /// <param name="paramsDict">参数字典</param>
        /// <returns>返回第一行第一列的结果  否则返回null</returns>
        public static object ExecuteScalarByString(string cmdText, Dictionary<string, object> paramsDict)
        {
            try
            {
                SqlConnection dbConnection = new SqlConnection(DBConnectionString);
                SqlCommand dbCommand = new SqlCommand(cmdText, dbConnection);
                dbCommand.CommandType = CommandType.Text;

                if (paramsDict != null && paramsDict.Count > 0)
                {
                    foreach (KeyValuePair<string, object> kv in paramsDict)
                    {
                        dbCommand.Parameters.AddWithValue(kv.Key, kv.Value);
                    }
                }
                dbCommand.CommandTimeout = 30;
                if (dbConnection.State != ConnectionState.Open)
                    dbConnection.Open();
                object returnObj = dbCommand.ExecuteScalar();
                dbConnection.Close();

                return returnObj;
            }
            catch (System.Exception ex)
            {
                Log.CreateErrorLog(ex.ToString());
                return null;
            }
        }


        /// <summary>
        /// 在一个事务环境中执行一条没有返回查询结果的sql命令
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">一个事务对象</param>
        /// <param name="commandType">命令类型 (存储过程、sql语句等.)</param>
        /// <param name="commandText">存储过程或者sql语句</param>
        /// <param name="commandParameters">查询参数的数组</param>
        /// <returns>执行s成功返回影响的行数 否则返回-1</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, Dictionary<string, object> paramsDict)
        {
            try
            {  
                SqlCommand cmd = new SqlCommand(cmdText, trans.Connection, trans);
                if (trans.Connection.State != ConnectionState.Open)
                {
                    trans.Connection.Open();
                }

                //if (trans != null)
                //{
                //    cmd.Transaction = trans;
                //}

                cmd.CommandType = cmdType;
                if (paramsDict != null && paramsDict.Count > 0)
                {
                    foreach (KeyValuePair<string, object> kv in paramsDict)
                    {
                        cmd.Parameters.AddWithValue(kv.Key, kv.Value);
                    }
                }
          
                int result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return result;
            }
            catch (Exception ex)
            {
                Log.CreateErrorLog(ex.ToString());
                return -1;
            }
          
        }

        /// <summary>
        /// 执行一条查询语句，返回第一行第一列的结果
        /// </summary>
        /// <remarks>
        /// 比如:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">一个事务对象</param>
        /// <param name="commandType">命令类型 (存储过程、sql语句等.)</param>
        /// <param name="commandText">存储过程的名字或者sql语句</param>
        /// <param name="commandParameters">查询参数的数组</param>
        /// <returns>查询结果的对象，需要进行类型转化，使用 Convert.To{Type}</returns>
        public static object ExecuteScalar(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
                object result = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return result;
            }
            catch (Exception ex)
            {
                Log.CreateErrorLog(ex.ToString());
                #if DEBUG
                return null;
                #endif
            }
           
        }


        //**************************************  待用  ******************************************//
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        // 命令参数的缓存，使用了线程同步的Hashtable
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// 将查询参数添加到缓存中，以提高效率
        /// </summary>
        /// <param name="cacheKey">参数数组的键</param>
        /// <param name="cmdParms">要缓存的参数数组</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// 得到缓存中的参数数组
        /// 该数组为克隆数组，不会影响到缓存中的数据
        /// </summary>
        /// <param name="cacheKey">要查找的参数数组的键</param>
        /// <returns>在缓存中的参数数组的克隆对象</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            try
            {
                SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];
                if (cachedParms == null) return null;
                SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];
                // 复制缓存中的数据
                for (int i = 0; i < cachedParms.Length; i++)
                {
                    clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();
                }
                return clonedParms;
            }
            catch (Exception ex)
            {
                Log.CreateErrorLog(ex.ToString());
                return null;
            }
            
        }


          #region 私有方法

        /// <summary>
        /// 执行没有查询的操作，并返回受影响的行数
        /// </summary>
        /// <param name="sqlStr">插入语句或者存储过程名称</param>
        /// <param name="cmdType">CommandType</param>
        /// <param name="paramsDict">传入的数据字典</param>
        /// <returns>执行成功返回受影响的行数  否则返回-1</returns>
        private static int ExecuteNonQuery(string sqlStr, CommandType cmdType, Dictionary<string, object> paramsDict)
        {
            try
            {
                SqlConnection dbConnection = new SqlConnection(DBConnectionString);
                SqlCommand dbCommand = new SqlCommand(sqlStr, dbConnection);
                dbCommand.CommandType = cmdType;

                //if (paramsDict == null || paramsDict.Count <= 0)
                //    return -2;
                if (paramsDict != null)
                {
                    foreach (KeyValuePair<string, object> kv in paramsDict)
                    {
                        //OleDbType dbType = CSharpType2SqlType(kv.Value);
                        dbCommand.Parameters.AddWithValue(kv.Key, kv.Value);
                    }
                }
                //dbCommand.Parameters.Add(new SqlParameter("@return", OleDbType.Int));
                //dbCommand.Parameters["@return"].Direction = ParameterDirection.ReturnValue;
                dbCommand.CommandTimeout = 60;
                if (dbConnection.State != ConnectionState.Open)
                    dbConnection.Open();
                int result = dbCommand.ExecuteNonQuery();
                //Convert.ToInt32(dbCommand.Parameters["@return"].Value);
                dbConnection.Close();
                return result;
            }
            catch (System.Exception ex)
            {
                Log.CreateErrorLog(ex.ToString());
                return -1;
            }
        }

        /// <summary>
        /// 查询数据表
        /// </summary>
        /// <typeparam name="T">数据实体类</typeparam>
        /// <param name="cmdText">查询字符串</param>
        /// <param name="cmdType">CommandType</param>
        /// <param name="paramsValue">实际要传入的参数值 字典</param>
        /// <param name="returnValueBinding">返回结果里面实体字段名  即Reader中的字段  字典</param>
        /// <returns>存在则返回数据列表   否则返回null</returns>
        private static List<T> GetList<T>(string cmdText, CommandType cmdType, Dictionary<string, object> paramsValue, Dictionary<string, string> returnValueBinding) where T : class, new()
        {
            try
            {
                SqlConnection dbConnection = new SqlConnection(DBConnectionString);
                SqlCommand dbCommand = new SqlCommand(cmdText, dbConnection);
                dbCommand.CommandType = cmdType;
                List<T> list = null;
                if (paramsValue != null)
                {
                    foreach (KeyValuePair<string, object> kv in paramsValue)
                    {
                        //OleDbType dbType = CSharpType2SqlType(kv.Value);
                        dbCommand.Parameters.AddWithValue(kv.Key, kv.Value);
                    }
                }
                dbCommand.CommandTimeout = 5 * 60;
                if (dbConnection.State != ConnectionState.Open)
                    dbConnection.Open();
                using (SqlDataReader dataReader = dbCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        try
                        {
                            if (list == null)
                                list = new List<T>();

                            T t = new T();

                            Type type = typeof(T);
                            PropertyInfo[] pi = type.GetProperties();
                            foreach (var item in pi)
                            {
                                Type proType = item.PropertyType;
                                if (!returnValueBinding.ContainsKey(item.Name))
                                {
                                    continue;
                                }
                                string sqlReturnValue = returnValueBinding[item.Name];
                                if (dataReader[sqlReturnValue] != DBNull.Value)
                                        item.SetValue(t, Convert.ChangeType(dataReader[sqlReturnValue], proType), null);
                                //这里的IF也可以改用SWITCH来判断。
                                /*
                                if (proType == typeof(String))
                                {
                                    item.SetValue(t, dataReader[sqlReturnValue], null);
                                }
                                else if (proType == typeof(Int32))
                                {
                                    item.SetValue(t, item == null ? 0 : Convert.ToInt32(dataReader[sqlReturnValue]), null);
                                }
                                else if (proType == typeof(Nullable<int>))// int?
                                {
                                    //所有Nulable<T>的类型以此类推，如double?类型
                                    item.SetValue(t, dataReader[sqlReturnValue] == null ? null : (int?)Convert.ToInt32(dataReader[sqlReturnValue]), null);
                                }
                                else
                                {
                                    //继续用if或者switch/case添加更多的可能。以应对更复杂的自定义类型
                                }
                                */
                            }

                            list.Add(t);
                        }
                        catch (System.Exception ex)
                        {  
                            Log.CreateErrorLog(ex.ToString());
                            return null;
                        }
                    }
                }
                dbConnection.Close();
                return list;
            }
            catch (Exception ex)
            {
                Log.CreateErrorLog(ex.ToString());
                return null;
            }
          
        }

        /// <summary>
        /// 预处理Command对象的参数
        /// </summary>
        /// <param name="cmd">要处理的Command对象</param>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdType">命令类型（存储过程、sql语句等)</param>
        /// <param name="cmdText">存储过程的名字或者sql语句</param>
        /// <param name="cmdParms">要被Command对象使用的参数数组</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.Connection = conn;
                cmd.CommandText = cmdText;


                if (trans != null)
                {
                    cmd.Transaction = trans;
                }

                cmd.CommandType = cmdType;

                if (cmdParms != null)
                {
                    cmd.Parameters.AddRange(cmdParms);
                }
            }
            catch (Exception ex)
            {   
                Log.CreateErrorLog(ex.ToString());
                return ;
            }
        
        }

        /// <summary>
        /// c#数据类型转换为sql数据类型
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private static OleDbType CSharpType2SqlType(object param)
        { 
            OleDbType dbType = OleDbType.Variant;//默认为Object
            try
            {
                string paramType = param.GetType().Name;
                switch (paramType)
                {
                    case "Int16":
                        dbType = OleDbType.SmallInt;
                        break;
                    case "Int32":
                        dbType = OleDbType.Integer;
                        break;
                    case "String":
                        dbType = OleDbType.LongVarWChar;
                        break;
                    case "DateTime":
                        dbType = OleDbType.DBDate;
                        break;
                    case "Single":
                        dbType = OleDbType.Single;
                        break;
                    case "Double":
                        dbType = OleDbType.Double;
                        break;
                    case "Decimal":
                        dbType = OleDbType.Decimal;
                        break;
                    case "Byte":
                        dbType = OleDbType.TinyInt;
                        break;
                    case "Guid":
                        dbType = OleDbType.Guid;
                        break;
                }
                return dbType;
            }
            catch (Exception ex)
            {
                Log.CreateErrorLog(ex.ToString());
                return dbType;
            }
        }

        /// <summary>
        /// sql数据类型转换为c#数据类型
        /// </summary>
        /// <param name="sqlType">sql数据类型</param>
        /// <returns>c#数据类型</returns>
        private static Type SqlTyp2CSharpType(OleDbType sqlType)
        {
            try
            {
                switch (sqlType)
                {
                    case OleDbType.BigInt:
                        return typeof(Int64);
                    case OleDbType.Binary:
                        return typeof(Array);
                    case OleDbType.Boolean:
                        return typeof(Boolean);
                    case OleDbType.Char:
                        return typeof(String);
                    case OleDbType.Date:
                        return typeof(DateTime);
                    case OleDbType.Decimal:
                        return typeof(Decimal);
                    case OleDbType.Double:
                        return typeof(Double);
                    case OleDbType.Integer:
                        return typeof(Int32);
                    case OleDbType.Currency:
                        return typeof(Decimal);
                    case OleDbType.LongVarChar:
                        return typeof(String);
                    case OleDbType.LongVarWChar:
                        return typeof(String);
                    case OleDbType.Numeric:
                        return typeof(Decimal);
                    case OleDbType.Single:
                        return typeof(Single);
                    case OleDbType.DBDate:
                        return typeof(DateTime);
                    case OleDbType.SmallInt:
                        return typeof(Int16);
                    case OleDbType.Guid:
                        return typeof(Guid);
                    case OleDbType.IDispatch:
                        return typeof(Object);
                    case OleDbType.IUnknown:
                        return typeof(Object);
                    case OleDbType.TinyInt:
                        return typeof(Byte);
                    case OleDbType.PropVariant:
                        return typeof(Object);
                    case OleDbType.UnsignedBigInt:
                        return typeof(UInt64);
                    case OleDbType.WChar:
                        return typeof(String);
                    case OleDbType.VarChar:
                        return typeof(String);
                    case OleDbType.Variant:
                        return typeof(Object);
                    case OleDbType.VarWChar:
                        return typeof(String);
                    default:
                        return null;
                }
              }
             catch(Exception ex)
            {
                Log.CreateErrorLog(ex.ToString());
                return null;
            }
        }

       #endregion


    }
}

