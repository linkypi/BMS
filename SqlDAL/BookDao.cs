using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.Model;
using System.Data.OleDb;
using System.Data;
using System.Transactions;
using BMS.IDAL;
using BMS.DbHelper;

namespace BMS.SqlDAL
{
    public class BookDao:IBookDao
    {

        public Result GetOutLine(UserInfo user,int bid)
        {
            try
            {
                string sql = "select outline from book where bid=" + bid;

                string outline = (string)DbHelper.SqlHelper.ExecuteScalarByString(sql, new Dictionary<string, object>());

                return new Result() { ReturnValue = true,Obj = outline};
            }
            catch (Exception ex)
            {
                return new Result() { ReturnValue = false,Message = ex.Message};
            }
        }

        public Result Search(UserInfo user, SearchModel condition)
        {
            string sql = "";
            string sqlCount = "";

            sqlCount = "select count(1) from Book   left join TypeInfo on Book.BTypeID=TypeInfo.TypeID ";
            sql = @"select  top " + condition.PageSize + @"  BookName,SMPosition,BAuthor,BTypeID,BTypeName,IsBorow,
                           Publisher,BPrice,convert(nvarchar(50),PubDate,102) as PubDate,BID,SerialNum  from Book   left join TypeInfo on Book.BTypeID=TypeInfo.TypeID ";

            if (condition.Conditions.ContainsKey("BKey"))
            {
                sql += " left join BookKey on Book.BID = BookKey.BID ";
                sqlCount += " left join BookKey on Book.BID = BookKey.BID ";
            }
            sql += " where 1=1 ";
            sqlCount += " where 1=1 ";
            foreach (var item in condition.Conditions)
            {
                if (item.Key == "BTypeID")
                {
                    sql += " and " + item.Key + " = " + item.Value.ToString();
                    sqlCount += " and " + item.Key + " = " + item.Value.ToString();
                    continue;
                }
                sqlCount += " and " + item.Key + " like '%" + item.Value.ToString() + "%'";
                sql += " and " + item.Key + " like '%" + item.Value.ToString() + "%'";
            }
        
            sql += @" and  BID not in (select distinct top " +
                        condition.PageSize * condition.CurrentPage + " BID from Book ";

              
                if (condition.Conditions.ContainsKey("BKey"))
                {
                    sql += " left join BookKey on Book.BID = BookKey.BID ";
                }
                sql += " where 1=1 ";
                foreach (var item in condition.Conditions)
                {
                    if (item.Key == "BTypeID")
                    {
                        sql += " and " + item.Key + " = " + item.Value.ToString();
                       continue;
                    }
                   sql += " and " + item.Key + " like '%" + item.Value.ToString() + "%'";
                }
                sql += " group by  Book.BID order by BID desc ";

                sql += ")  order by BID desc ";
            Dictionary<string,string> oudic = new Dictionary<string,string>();
            oudic.Add("BookName","BookName");
            oudic.Add("SMPosition","SMPosition");

            oudic.Add("BAuthor","BAuthor");
            oudic.Add("BTypeID","BTypeID");
            oudic.Add("BTypeName", "BTypeName");
            oudic.Add("IsBorow","IsBorow");
            oudic.Add("Publisher","Publisher");

            oudic.Add("BPrice","BPrice");
            oudic.Add("PubDate","PubDate");
            oudic.Add("SerialNum","SerialNum");
            oudic.Add("BID","BID");

            int total = Convert.ToInt32(SqlHelper.ExecuteScalarByString(sqlCount, new Dictionary<string, object>()));
            condition.AllPages =(int) Math.Ceiling((decimal)(total / condition.PageSize));

            List<Book> models = SqlHelper.GetDataListByString<Book>(sql, new Dictionary<string, object>(), oudic);
          
            condition.Result = models;
             return new Result() { ReturnValue = true,Obj=condition};
            
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public Result Add(UserInfo user,Book model)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    // begin  tran
                    string sql = "";

                    int index = 1;
                    Dictionary<string, object> indic = new Dictionary<string, object>();

                    sql += @"  insert into Book([BookName]
                        ,[SMPosition]
                        ,[BAuthor]
                        ,[BTypeID]
                        ,[OutLine]
                        ,[Publisher]
                        ,[BPrice]
                        ,[PubDate]
                        ,[SerialNum])values(  ";
                    sql += " @BookName" + index;
                    sql += ",@BPosition" + index;
                    sql += ",@Author" + index;
                    sql += ",@TypeID" + index;
                    sql += ",@OutLine" + index;
                    sql += ",@Publisher" + index;
                    sql += ",@Price" + index;
                    sql += ",@PubDate" + index;
                    sql += ",@SerialNum" + index + ")";

                    indic.Add("@BookName" + index, model.BookName);
                    indic.Add("@BPosition" + index, model.SMPosition);
                    indic.Add("@Author" + index, model.BAuthor);
                    indic.Add("@TypeID" + index, model.BTypeID);
                    indic.Add("@OutLine" + index, model.OutLine);
                    indic.Add("@Publisher" + index, model.Publisher);
                    indic.Add("@Price" + index, model.BPrice);
                    indic.Add("@PubDate" + index, model.PubDate);
                    indic.Add("@SerialNum" + index, model.SerialNum);



                    // sql += " if(@@error=0) begin commit select 1 end else begin rollback select 0 end ";
                    int count = Convert.ToInt32(DbHelper.SqlHelper.ExecuteScalarByString(sql, indic));
                    if (count >= 0)
                    {
                        ts.Complete();
                        return new Result() { ReturnValue = true, Message = "添加成功！" };
                    }
                    else
                    {
                        return new Result() { ReturnValue = false, Message = "添加失败！" };
                    }
                }
                catch (Exception ex)
                {
                    return new Result() { ReturnValue = false, Message = ex.Message };
                }
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Result Update(UserInfo user, Book model)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Dictionary<string, object> indic = new Dictionary<string, object>();
                    string sql = "select * from Book where BID=@bid ";
                    indic.Add("@bid", model.BID);
                    int count = DbHelper.SqlHelper.ExecuteNonQuery(sql, indic);
                    if (count == 0)
                    {
                        return new Result() { ReturnValue = false, Message = "未能找到指定书籍，或已删除！" };
                    }
                    indic.Clear();
                    sql = @" begin tran
                           UPDATE [BMS].[dbo].[Book]
                           SET [BookName] = @BName
                              ,[SMPosition] = @Position
                              ,[BAuthor] = @Author
                              ,[BTypeID] = @TypeID
                              ,[OutLine] = @OutLine
                              ,[Publisher] = @Publisher
                              ,[BPrice] = @Price
                              ,[PubDate] = @PubDate
                              ,[SerialNum] = @SerialNum
                         WHERE BID=@bid  if(@@error=0)
                         begin  commit select 1 end 
                         else begin rollback select 0 end ";


                    indic.Add("@BName", model.BookName);
                    indic.Add("@Position", model.SMPosition);
                    indic.Add("@Author", model.BAuthor);
                    indic.Add("@TypeID", model.BTypeID);
                    indic.Add("@OutLine", model.OutLine);
                    indic.Add("@Publisher", model.Publisher);
                    indic.Add("@Price", model.BPrice);
                    indic.Add("@PubDate", model.PubDate);
                    indic.Add("@SerialNum", model.SerialNum);
                    indic.Add("@bid", model.BID);

                    count = (int)DbHelper.SqlHelper.ExecuteScalarByString(sql, indic);
                    if (count == 1)
                    {
                        ts.Complete();
                        return new Result() { ReturnValue = true, Message = "修改成功！" };
                    }
                    else
                    {
                        return new Result() { ReturnValue = false, Message = "修改失败！" };
                    }

                }
                catch (Exception ex)
                {
                    return new Result() { ReturnValue = false, Message = ex.Message };
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public Result Delete(UserInfo user, List<int> bids)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    string sql = @" select count(1) from Book
                         WHERE BID in (";

                    string ids_string = "(";
                    int index = 0;

                    foreach (var item in bids)
                    {
                        index++;
                        ids_string+=item;
                        sql += item;
                        if (index < bids.Count)
                        {
                            ids_string += ",";
                            sql += ",";
                        }
                    }
                    ids_string += ") ";
                    sql += ") ";
                

                    int count = (int)DbHelper.SqlHelper.ExecuteScalarByString(sql,new Dictionary<string,object>());
                    if (count != bids.Count)
                    {
                        return new Result() { ReturnValue = false, Message = "部分书籍已删除，删除失败！" };
                    }

                    //先备份后删除
                    sql = @" 
                       insert into Book_bak 
                       select *  from Book a where a.BID in " + ids_string + @"
                       delete from Book where BID in "+ids_string+@"
                       if (@@error=0)   
                        begin 
                            select 1
                        end
                        else
                         begin
                            select 0
                         end ";

                    count = (int)DbHelper.SqlHelper.ExecuteScalarByString(sql,new Dictionary<string,object>());
                    if (count == 1)
                    {
                        ts.Complete();
                        return new Result() { ReturnValue = true, Message = "删除成功！" };
                    }
                    else
                    {
                        return new Result() { ReturnValue = false, Message = "删除失败！" };
                    }

                }
                catch (Exception ex)
                {
                    return new Result() { ReturnValue = false, Message = ex.Message };
                }
            }
        }


        #region  Book_bak

        public Result SearchDeleted(UserInfo user, SearchModel condition)
        {
            string sql = "";
            string sqlCount = "";

            sqlCount = "select count(1) from Book   left join TypeInfo on Book.BTypeID=TypeInfo.TypeID ";
            sql = @"select  top " + condition.PageSize + @"  BookName,SMPosition,BAuthor,BTypeID,BTypeName,
                           Publisher,BPrice,convert(nvarchar(50),PubDate,102) as PubDate,BID,SerialNum  from Book   left join TypeInfo on Book.BTypeID=TypeInfo.TypeID ";

            if (condition.Conditions.ContainsKey("BKey"))
            {
                sql += " left join BookKey on Book.BID = BookKey.BID ";
                sqlCount += " left join BookKey on Book.BID = BookKey.BID ";
            }
            sql += " where 1=1 ";
            sqlCount += " where 1=1 ";
            foreach (var item in condition.Conditions)
            {
                if (item.Key == "BTypeID")
                {
                    sql += " and " + item.Key + " = " + item.Value.ToString();
                    sqlCount += " and " + item.Key + " = " + item.Value.ToString();
                    continue;
                }
                sqlCount += " and " + item.Key + " like '%" + item.Value.ToString() + "%'";
                sql += " and " + item.Key + " like '%" + item.Value.ToString() + "%'";
            }

            sql += @" and  BID not in (select distinct top " +
                        condition.PageSize * condition.CurrentPage + " BID from Book ";


            if (condition.Conditions.ContainsKey("BKey"))
            {
                sql += " left join BookKey on Book.BID = BookKey.BID ";
            }
            sql += " where 1=1 ";
            foreach (var item in condition.Conditions)
            {
                if (item.Key == "BTypeID")
                {
                    sql += " and " + item.Key + " = " + item.Value.ToString();
                    continue;
                }
                sql += " and " + item.Key + " like '%" + item.Value.ToString() + "%'";
            }
            sql += " group by  Book.BID order by BID desc ";

            sql += ")  order by BID desc ";
            Dictionary<string, string> oudic = new Dictionary<string, string>();
            oudic.Add("BookName", "BookName");
            oudic.Add("SMPosition", "SMPosition");

            oudic.Add("BAuthor", "BAuthor");
            oudic.Add("BTypeID", "BTypeID");
            oudic.Add("BTypeName", "BTypeName");
            //oudic.Add("OutLine","OutLine");
            oudic.Add("Publisher", "Publisher");

            oudic.Add("BPrice", "BPrice");
            oudic.Add("PubDate", "PubDate");
            oudic.Add("SerialNum", "SerialNum");
            oudic.Add("BID", "BID");

            int total = Convert.ToInt32(SqlHelper.ExecuteScalarByString(sqlCount, new Dictionary<string, object>()));
            condition.AllPages = total;

            List<Book> models = SqlHelper.GetDataListByString<Book>(sql, new Dictionary<string, object>(), oudic);

            condition.Result = models;
            return new Result() { ReturnValue = true, Obj = condition };

        }

        /// <summary>
        /// huan yuan
        /// </summary>
        /// <param name="user"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public Result Undo(UserInfo user, List<int> list)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    string sql = "";
                    return new Result() { ReturnValue = true, Message = "" };
                }
                catch (Exception ex)
                {
                    return new Result() { ReturnValue = false,Message=ex.Message};
                }
            }
        }

        #endregion 
    }
}
