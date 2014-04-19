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
    /// �����װ�˲���Sql Server���ݿ�Ļ�������
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
        /// ʵ�����
        /// </summary>
        /// <param name="sqlStr">����ʵ���ַ���</param>
        /// <param name="paramsDict">Ҫ����Ĳ����ֵ䣬����������ļ�ֵ�ԣ��������Ͳ�������Ӧ��ֵ��</param>
        /// <returns>���н����-2�������б�Ϊ��</returns>
        public static int InsertDataByString(string sqlStr, Dictionary<string, object> paramsDict)
        {
            return ExecuteNonQuery(sqlStr, CommandType.Text, paramsDict);
        }

        /// <summary>
        /// ʵ����룬������Ӱ�������
        /// </summary>
        /// <param name="procName">�洢��������</param>
        /// <param name="paramsDict">Ҫ����Ĳ����ֵ䣬����������ļ�ֵ�ԣ��������Ͳ�������Ӧ��ֵ��</param>
        /// <returns>���н����-2�������б�Ϊ��</returns>
        public static int InsertDataByProc(string procName, Dictionary<string, object> paramsDict)
        {
            return ExecuteNonQuery(procName, CommandType.StoredProcedure, paramsDict);
        }

        /// <summary>
        /// ִ��û�з��ز�ѯ�����SQL��䣬ִ�гɹ�������Ӱ������� 
        /// </summary>
        /// <param name="cmdText">��ѯ�ַ���</param>
        /// <param name="paramsDict">�����ֵ��б�</param>
        /// <returns>������Ӱ������� </returns>
        public static int ExecuteNonQuery(string cmdText, Dictionary<string, object> paramsDict)
        {
            return ExecuteNonQuery(cmdText, CommandType.Text, paramsDict);
        }

        /// <summary>
        /// ��ѯ�������� 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName">�洢��������</param>
        /// <param name="paramsValue">��ѯ����,�洢���̲�����--ʵ��Ҫ����Ĳ���ֵ �ֵ�</param>
        /// <param name="returnValueBinding">���ؽ������Ҫ��Ӧ�Ĵ洢���̲���, ʵ���ֶ���-�洢���̷����ֶ� �ֵ�</param>
        /// <returns>Ҫ��ѯ�ĵ�������</returns>
        public static T GetDataModelByProc<T>(string procName, Dictionary<string, object> paramsValue, Dictionary<string, string> returnValueBinding) where T : class, new()
        {
            List<T> list = GetList<T>(procName, CommandType.StoredProcedure, paramsValue, returnValueBinding);
            if (list == null)
                return new T();
            return list[0];
        }

        /// <summary>
        /// ��ѯ�������� 
        /// </summary>
        /// <typeparam name="T">ʵ������</typeparam>
        /// <param name="cmdText">��ѯ�ַ���</param>
        /// <param name="paramsValue">��ѯ����,�洢���̲�����--ʵ��Ҫ����Ĳ���ֵ �ֵ�</param>
        /// <param name="returnValueBinding">���ؽ������Ҫ��Ӧ�Ĵ洢���̲���, ʵ���ֶ���-�洢���̷����ֶ� �ֵ�</param>
        /// <returns>Ҫ��ѯ�ĵ�������</returns>
        public static T GetDataModelByString<T>(string cmdText, Dictionary<string, object> paramsValue, Dictionary<string, string> returnValueBinding) where T : class, new()
        {
            List<T> list = GetList<T>(cmdText, CommandType.Text, paramsValue, returnValueBinding);
            if (list == null)
                return new T();
            return list[0];
        }

        /// <summary>
        /// ��ѯ�����б� 
        /// </summary>
        /// <typeparam name="T">ʵ������</typeparam>
        /// <param name="cmdText">��ѯ�ַ���</param>
        /// <param name="paramsValue">��ѯ����,�洢���̲�����-ʵ��Ҫ����Ĳ���ֵ �ֵ�</param>
        /// <param name="returnValue">���ؽ������ʵ���ֶ�����ʵ���ֶ���-�洢���̷����ֶ�  �ֵ�</param>
        /// <returns>Ҫ��ѯ���б�����</returns>
        public static List<T> GetDataListByString<T>(string cmdText, Dictionary<string, object> paramsValue, Dictionary<string, string> returnValueBinding) where T : class, new()
        {
            List<T> list = GetList<T>(cmdText, CommandType.Text, paramsValue, returnValueBinding);
            if (list == null)
                return new List<T>();
            return list;
        }

        /// <summary>
        /// ��ѯ�����б� 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName">�洢��������</param>
        /// <param name="paramsValue">��ѯ����,�洢���̲�����-ʵ��Ҫ����Ĳ���ֵ �ֵ�</param>
        /// <param name="returnValue">���ؽ������Ҫ��Ӧ�Ĵ洢���̲���, ʵ���ֶ���-�洢���̷����ֶ� �ֵ�</param>
        /// <returns>Ҫ��ѯ���б�����</returns>
        public static List<T> GetDataListByProc<T>(string procName, Dictionary<string, object> paramsValue, Dictionary<string, string> returnValueBinding) where T : class, new()
        {
            List<T> list = GetList<T>(procName, CommandType.StoredProcedure, paramsValue, returnValueBinding);
            if (list == null)
                return new List<T>();
            return list;
        }


        /// <summary>
        /// ���ݸ��� ������Ӱ�������
        /// </summary>
        /// <param name="procName">�洢��������</param>
        /// <param name="paramsDict">Ҫ���µ�����, �洢���̲�����<->ʵ��Ҫ����Ĳ���ֵ �ֵ�</param>
        /// <returns>��Ӱ�������</returns>
        public static int UpdateData(string procName, Dictionary<string, object> paramsDict)
        {
            return ExecuteNonQuery(procName, CommandType.StoredProcedure,paramsDict);
        }

        /// <summary>
        /// ��ѯ���ص�һ�е�һ�еĲ�ѯ���
        /// </summary>
        /// <param name="procName">�洢��������</param>
        /// <param name="paramsDict"></param>
        /// <returns>���ص�һ�е�һ�еĽ��   </returns>
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
        /// ִ��һ����ѯ��䣬���ص�һ�е�һ�еĽ��
        /// </summary>
        /// <param name="cmdText">��ѯ�ַ���</param>
        /// <param name="paramsDict">�����ֵ�</param>
        /// <returns>���ص�һ�е�һ�еĽ��  ���򷵻�null</returns>
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
        /// ��һ�����񻷾���ִ��һ��û�з��ز�ѯ�����sql����
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">һ���������</param>
        /// <param name="commandType">�������� (�洢���̡�sql����.)</param>
        /// <param name="commandText">�洢���̻���sql���</param>
        /// <param name="commandParameters">��ѯ����������</param>
        /// <returns>ִ��s�ɹ�����Ӱ������� ���򷵻�-1</returns>
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
        /// ִ��һ����ѯ��䣬���ص�һ�е�һ�еĽ��
        /// </summary>
        /// <remarks>
        /// ����:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">һ���������</param>
        /// <param name="commandType">�������� (�洢���̡�sql����.)</param>
        /// <param name="commandText">�洢���̵����ֻ���sql���</param>
        /// <param name="commandParameters">��ѯ����������</param>
        /// <returns>��ѯ����Ķ�����Ҫ��������ת����ʹ�� Convert.To{Type}</returns>
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


        //**************************************  ����  ******************************************//
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        // ��������Ļ��棬ʹ�����߳�ͬ����Hashtable
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// ����ѯ������ӵ������У������Ч��
        /// </summary>
        /// <param name="cacheKey">��������ļ�</param>
        /// <param name="cmdParms">Ҫ����Ĳ�������</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// �õ������еĲ�������
        /// ������Ϊ��¡���飬����Ӱ�쵽�����е�����
        /// </summary>
        /// <param name="cacheKey">Ҫ���ҵĲ�������ļ�</param>
        /// <returns>�ڻ����еĲ�������Ŀ�¡����</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            try
            {
                SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];
                if (cachedParms == null) return null;
                SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];
                // ���ƻ����е�����
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


          #region ˽�з���

        /// <summary>
        /// ִ��û�в�ѯ�Ĳ�������������Ӱ�������
        /// </summary>
        /// <param name="sqlStr">���������ߴ洢��������</param>
        /// <param name="cmdType">CommandType</param>
        /// <param name="paramsDict">����������ֵ�</param>
        /// <returns>ִ�гɹ�������Ӱ�������  ���򷵻�-1</returns>
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
        /// ��ѯ���ݱ�
        /// </summary>
        /// <typeparam name="T">����ʵ����</typeparam>
        /// <param name="cmdText">��ѯ�ַ���</param>
        /// <param name="cmdType">CommandType</param>
        /// <param name="paramsValue">ʵ��Ҫ����Ĳ���ֵ �ֵ�</param>
        /// <param name="returnValueBinding">���ؽ������ʵ���ֶ���  ��Reader�е��ֶ�  �ֵ�</param>
        /// <returns>�����򷵻������б�   ���򷵻�null</returns>
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
                                //�����IFҲ���Ը���SWITCH���жϡ�
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
                                    //����Nulable<T>�������Դ����ƣ���double?����
                                    item.SetValue(t, dataReader[sqlReturnValue] == null ? null : (int?)Convert.ToInt32(dataReader[sqlReturnValue]), null);
                                }
                                else
                                {
                                    //������if����switch/case��Ӹ���Ŀ��ܡ���Ӧ�Ը����ӵ��Զ�������
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
        /// Ԥ����Command����Ĳ���
        /// </summary>
        /// <param name="cmd">Ҫ�����Command����</param>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="trans">�������</param>
        /// <param name="cmdType">�������ͣ��洢���̡�sql����)</param>
        /// <param name="cmdText">�洢���̵����ֻ���sql���</param>
        /// <param name="cmdParms">Ҫ��Command����ʹ�õĲ�������</param>
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
        /// c#��������ת��Ϊsql��������
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private static OleDbType CSharpType2SqlType(object param)
        { 
            OleDbType dbType = OleDbType.Variant;//Ĭ��ΪObject
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
        /// sql��������ת��Ϊc#��������
        /// </summary>
        /// <param name="sqlType">sql��������</param>
        /// <returns>c#��������</returns>
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

