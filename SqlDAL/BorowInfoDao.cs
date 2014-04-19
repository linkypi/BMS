using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.Model;
using System.Transactions;
using BMS.IDAL;

namespace BMS.SqlDAL
{
    public class BorowInfoDao:IBorowInfoDao
    {
        public Result Borow(UserInfo user, bool existsUser, object userIN, List<int> list)
        {
            using (TransactionScope tx = new TransactionScope())
            {
                try
                {
                    string sql2 = "select  count(1) from BorowInfo where BID in (";
                    string upd_book_flag = "update Book set isborow  =1 where bid in (";
                    string sql = string.Empty;
                    if (existsUser)
                    {
                        sql = "insert into BorowInfo(UserID,BID,BorowDate,IsReturn) ";
                    }
                    else
                    {
                        sql = "insert into BorowInfo(Borower,BID,BorowDate,IsReturn) ";
                    }
                    int index = 1;
                    foreach (var item in list)
                    {
                        if (existsUser)
                        {
                            sql += "select " + Convert.ToInt32(userIN) + "," + item + ",getdate(),0";
                        }
                        else
                        {
                            sql += "select " + userIN.ToString() + "," + item + ",getdate(),0";
                        }

                        sql2 += item;
                        upd_book_flag += item;
                        if (index < list.Count)
                        {
                            sql += " union ";
                            sql2 += ",";
                            upd_book_flag += ",";
                        }
                    }
                    sql2 += ") ";
                    upd_book_flag += ")";
                    int count = (int)DbHelper.SqlHelper.ExecuteScalarByString(sql2, new Dictionary<string, object>());
                    if (count > 0)
                    {
                        return new Result() { ReturnValue = false, Message = "部分书籍已被借阅，借阅失败!" };
                    }
                    count = (int)DbHelper.SqlHelper.ExecuteNonQuery(sql, new Dictionary<string, object>());
                    if (count == list.Count)
                    {
                        DbHelper.SqlHelper.ExecuteNonQuery(upd_book_flag, new Dictionary<string, object>());
                        tx.Complete();
                        return new Result() { ReturnValue = true, Message = "借阅成功" };
                    }
                    return new Result() { ReturnValue = false, Message = "借阅失败" };
                }
                catch (Exception ex)
                {
                    return new Result() { ReturnValue = false, Message = ex.Message };
                }
            }
        }

        public Result Return(UserInfo user, string returner, List<int> list)
        {
            using (TransactionScope tx = new TransactionScope())
            {
                try
                {
                    string upd_book_flag = "update Book set isborow  =0 where bid in (";
                    string sql = "update  BorowInfo set Returner='" + returner + "',isreturn = 1,ReturnDate=getdate() where bid in ( ";
                    int index = 1;
                    foreach (var item in list)
                    {
                        sql += item;
                        upd_book_flag += item;
                        if (index < list.Count)
                        {
                            sql += ",";
                            upd_book_flag += ",";
                        }
                    }
                    sql += ")";
                    upd_book_flag += ")";
                    int count = (int)DbHelper.SqlHelper.ExecuteNonQuery(sql, new Dictionary<string, object>());
                    if (count == list.Count)
                    {
                        DbHelper.SqlHelper.ExecuteNonQuery(upd_book_flag, new Dictionary<string, object>());
                        tx.Complete();
                        return new Result() { ReturnValue = true, Message = "归还成功" };
                    }
                    return new Result() { ReturnValue = false, Message = "归还失败" };
                }
                catch (Exception ex)
                {
                    return new Result() { ReturnValue = false, Message = ex.Message };
                }
            }
        }
    }
}
