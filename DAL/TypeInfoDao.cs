using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.Model;
using System.Data.OleDb;
using System.Data;
using BMS.DbHelper;
using BMS.IDAL;
using System.Transactions;

namespace BMS.AccessDAL
{
    public class TypeInfoDao: ITypeInfoDao
    {
        public Result GetList(UserInfo user)
        {
            try
            {
                string sql = "select * from TypeInfo ";
                Dictionary<string, string> outdic = new  Dictionary<string,string>();
                outdic.Add("TypeID","TypeID");
                outdic.Add("BTypeName", "BTypeName");
                List<TypeInfo> models = AccessHelper.GetDataListByString<Model.TypeInfo>(sql, new Dictionary<string, object>(), outdic);
                return new Result() { ReturnValue = true,Obj=models};
            }
            catch (Exception ex)
            {
                return new Result() { ReturnValue =false,Message=ex.Message};
            }
        }

        /// <summary>
        /// 17
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Result SearchType(UserInfo user, SearchModel condition)
        {
            try
            {
                string sql = " from TypeInfo ";
                if (condition.Conditions.Count != 0)
                {
                    sql += "where BTypeName like '%" + condition.Conditions + "%' ";
                }
                string sql2 = "select top " + condition.PageSize
                    + " * from TypeInfo where TypeID not in (select top " + condition.PageSize * condition.CurrentPage + " TypeID " +
                     sql + ")";

                int count = (int)DbHelper.SqlHelper.ExecuteScalarByString("select count(1) " + sql, new Dictionary<string, object>());

                condition.AllPages = count;
                Dictionary<string, string> outdic = new Dictionary<string, string>();
                outdic.Add("TypeID", "TypeID");
                outdic.Add("BTypeName", "BTypeName");
                List<TypeInfo> models = DbHelper.AccessHelper.GetDataListByString<Model.TypeInfo>(sql2, new Dictionary<string, object>(), outdic);
                condition.Result = models;
                return new Result() { ReturnValue = true, Obj = condition };
            }
            catch (Exception ex)
            {
                return new Result() { ReturnValue = false, Message = ex.Message };
            }
        }

        /// <summary>
        /// 14
        /// </summary>
        /// <param name="user"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public Result Add(UserInfo user, string typeName)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    #region  检测是否已存在

                    string sql = "select * from TypeInfo where BTypeName = '" + typeName + "'";


                    Dictionary<string, string> outdic = new Dictionary<string, string>();
                    outdic.Add("TypeID", "TypeID");
                    outdic.Add("BTypeName", "BTypeName");
                    List<TypeInfo> list = DbHelper.AccessHelper.GetDataListByString<TypeInfo>(sql, new Dictionary<string, object>(), outdic);

                    if (list.Count > 0)
                    {
                        return new Result() { ReturnValue = false, Message = "图书类别：" + list[0].BTypeName + "已存在，添加失败！" };
                    }
                    #endregion

                    #region  添加

                    sql = "insert into TypeInfo(BTypeName) ";

                    Dictionary<string, object> indic = new Dictionary<string, object>();

                    sql += " select @tName";
                    indic.Add("@tName", typeName);

                    sql += "if(@@error=0)begin  select 1 end else begin  select 0 end ";
                    int count = (int)DbHelper.AccessHelper.ExecuteScalarByString(sql, indic);
                    if (count == 1)
                    {
                        ts.Complete();
                        return new Result() { ReturnValue = true, Message = "添加成功！" };
                    }
                    else
                    {
                        return new Result() { ReturnValue = false, Message = "添加失败！" };
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    return new Result() { ReturnValue = false, Message = ex.Message };
                }
            }
        }

        /// <summary>
        /// 16
        /// </summary>
        /// <param name="user"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public Result Update(UserInfo user, TypeInfo model)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    #region  检测是否存在

                    string sql = "select count(1) from TypeInfo where typeid = @tid";
                    Dictionary<string, object> indic = new Dictionary<string, object>();
                    indic.Add("@tid", model.TypeID);
                    int count = DbHelper.AccessHelper.ExecuteNonQuery(sql, indic);
                    if (count == 0)
                    {
                        return new Result() { ReturnValue = false, Message = "该类别已删除！" };
                    }

                    #endregion

                    #region  添加

                    sql = @" update TypeInfo set BTypeName=@tname where TypeID=@tid 
                       if(@@error=0)
                       begin
                            select 1
                       end
                       else
                       begin
                            select 0
                       end ";
                    indic.Add("@tid", model.BTypeName);
                    count = AccessHelper.ExecuteNonQuery(sql, indic);
                    if (count == 1)
                    {
                        ts.Complete();
                        return new Result() { ReturnValue = true, Message = "更新成功！" };
                    }
                    else
                    {
                        return new Result() { ReturnValue = false, Message = "更新失败！" };
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    return new Result() { ReturnValue = false, Message = ex.Message };
                }
            }
        }

        /// <summary>
        /// 15
        /// </summary>
        /// <param name="user"></param>
        /// <param name="tids"></param>
        /// <returns></returns>
        public Result Delete(UserInfo user, List<int> list)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    string tids = "( ";
                    int index = 1;
                    foreach (var item in list)
                    {
                        tids += item;
                        if (list.Count > index)
                        {
                            tids += ",";
                        }
                        index++;
                    }
                    tids += " ) ";
                    string sql = @" declare @count int 
                                select @count=count(1) from TypeInfo where typeid in " + tids + @"
                                if(@count=0) begin select -1 end
                                 delete from TypeInfo where TypeID in " + tids + @"
                                 if(@@error=0) begin  select 1 end 
                                 else begin  select 0 end ";


                    int ret = (int)AccessHelper.ExecuteScalarByString(sql, new Dictionary<string, object>());
                    if (ret == -1)
                    {
                        return new Result() { ReturnValue = false, Message = "该类别已删除！" };
                    }
                    else if (ret == 0)
                    {
                        return new Result() { ReturnValue = false, Message = "删除失败！" };
                    }
                    else
                    {
                        ts.Complete();
                        return new Result() { ReturnValue = true, Message = "删除成功！" };
                    }
                }
                catch (Exception ex)
                {
                    return new Result() { ReturnValue = false, Message = ex.Message };
                }
            }
        }
    }
}
