using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.Model;
using System.Transactions;
using BMS.IDAL;

namespace BMS.SqlDAL
{
    public class BookKeyDao:IBookKey
    {
        public Result GetBookKey(UserInfo user,int bid)
        {
            using (TransactionScope tx = new TransactionScope())
            {
                try
                {
                    string sql = "select * from BookKey where BID = " + bid;
                    Dictionary<string, string> outdic = new Dictionary<string, string>();
                    outdic.Add("ID", "ID");
                    outdic.Add("BID", "BID");
                    outdic.Add("BKey", "BKey");

                    List<Model.BookKey> list = DbHelper.SqlHelper.GetDataListByString<Model.BookKey>(sql, new Dictionary<string, object>(), outdic);
                    tx.Complete();
                    return new Result() { ReturnValue = true, Obj = list };
                }
                catch (Exception ex)
                {
                    return new Result() { ReturnValue = false, Message = ex.Message };
                }
            }
        }

        public Result Add(UserInfo user,List<Model.BookKey> models)
        {
            try
            {
                string sql = "insert into BookKey(BID,BKey) ";
                int index=0;

                foreach (var item in models)
                {
                    index++;
                    sql += "select "+item.BID+",'"+item.BKey+"'";
                    if (index < models.Count)
                    {
                        sql += " union ";
                    }
                }

                int count = (int)DbHelper.SqlHelper.ExecuteNonQuery(sql,new Dictionary<string,object>());
                if (count > 0)
                {
                    return new Result() { ReturnValue = true, Message = "添加成功！" };
                }
                else
                {
                    return new Result() { ReturnValue = false, Message = "添加失败！" };
                }
            }
            catch (Exception ex)
            {
                return new Result() { ReturnValue = false, Message = ex.Message};
            }
         
        }

        public Result Delete(UserInfo user, List<int> idList)
        {
            using (TransactionScope tx = new TransactionScope())
            {
                try
                {
                    string sql = "delete from BookKey where ID in (";
                    int index = 0;
                    foreach (var item in idList)
                    {
                        index++;
                        sql += item;
                        if (index < idList.Count)
                        {
                            sql += ",";
                        }
                    }
                    sql += ")";

                    int count = (int)DbHelper.SqlHelper.ExecuteNonQuery(sql,new Dictionary<string,object>());
                    if (count == idList.Count)
                    {
                        tx.Complete();
                        return new Result() { Message = "删除成功！", ReturnValue = true };
                    }
                    else
                    {
                        return new Result() { Message = "删除失败！", ReturnValue = false };
                    }
                }
                catch (Exception ex)
                {
                    return new Result() { ReturnValue = false,Message=ex.Message};
                }
            }
        }
    }
}
