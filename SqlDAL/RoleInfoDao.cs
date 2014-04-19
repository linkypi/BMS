using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.IDAL;
using System.Transactions;
using BMS.Model;

namespace BMS.SqlDAL
{
    public class RoleInfoDao :IRoleInfoDao
    {
        public Model.Result Search(Model.UserInfo user, SearchModel condition)
        {
            try
            {
                string sqlCount = "select count(1) from RoleInfo where 1=1 ";
                string sql = "select top "+condition.PageSize+" RoleID,RoleName,Note from RoleInfo where RoleID not in(select top   "
                    +condition.CurrentPage*condition.PageSize+" RoleID from RoleInfo where 1=1 ";
                foreach (var item in condition.Conditions)
                {
                    if (item.Key == "RoleName")
                    {
                        sql += " and RoleName like '%" + item.Value + "%'";
                        sqlCount += " and RoleName like '%"+item.Value+"%'";
                    }
                    if (item.Key == "Note")
                    {
                        sqlCount += " and Note like '%"+item.Value+"%'";
                        sql += " and Note like '%" + item.Value + "%'";
                    }
                }
                sql += ") ";
                foreach (var item in condition.Conditions)
                {
                    if (item.Key == "RoleName")
                    {
                        sql += " and RoleName like '%" + item.Value + "%'";
                    }
                    if (item.Key == "Note")
                    {
                        sql += " and Note like '%" + item.Value + "%'";
                    }
                }
                Dictionary<string, string> outdic = new Dictionary<string, string>();
                outdic.Add("RoleID", "RoleID");
                outdic.Add("RoleName", "RoleName");
                outdic.Add("Note", "Note");
                int count = (int)DbHelper.SqlHelper.ExecuteScalarByString(sqlCount,new Dictionary<string,object>());
                condition.AllPages = (int)Math.Ceiling((decimal)(count / condition.PageSize));

                List<Model.RoleInfo> list = DbHelper.SqlHelper.GetDataListByString<RoleInfo>(sql,new Dictionary<string,object>(),outdic);
                condition.Result = list;
                return new Result() { ReturnValue = true ,Obj=condition};
            }
            catch (Exception ex)
            {
                return new Result() { ReturnValue =false };
            }    
        }

        public Model.Result AddRole(Model.UserInfo user, Model.RoleInfo role, List<int> menus)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    string sql = "select count(1) from RoleInfo where RoleName='"+role.RoleName+"'";
                    int count = (int)DbHelper.SqlHelper.ExecuteScalarByString(sql,new Dictionary<string,object>());
                    if (count > 0)
                    {
                        return new Model.Result() { ReturnValue =false,Message="已存在相同名称的角色，保存失败！"};
                    }
                    sql = @"insert into RoleInfo(RoleName,Note)values(@name,@note)
                     if (@@ROWCOUNT=1) begin  select RoleID from RoleInfo where RoleName=@name  end   else  begin  select -1 end";
                    Dictionary<string, object> indic = new Dictionary<string, object>();
                    indic.Add("@name", role.RoleName);
                    indic.Add("@note", role.Note);
                    int roleID =(int) DbHelper.SqlHelper.ExecuteScalarByString(sql,indic);
                    if (roleID == -1)
                    {
                        return new Model.Result() { ReturnValue = false, Message = "保存失败！" };
                    }
                    sql = "insert into RoleMenuInfo(RoleID,MenuID)";
                    int index = 1;
                    foreach (var item in menus)
                    {
                        sql += "select "+roleID+","+item;
                        if (index < menus.Count)
                        {
                            sql += " union ";
                        }
                        index++;
                    }

                    count = DbHelper.SqlHelper.ExecuteNonQuery(sql,new Dictionary<string,object>());
                    if (count == menus.Count)
                    {
                        ts.Complete();
                        return new Model.Result() { ReturnValue = true, Message = "保存成功！" };
                    }
                    return new Model.Result() { ReturnValue = false, Message="保存失败！" };
                }
                catch (Exception ex)
                {
                    return new Model.Result() { ReturnValue =false,Message = ex.Message};
                }
            }
        }

        public Model.Result UpdateRole(Model.UserInfo user, Model.RoleInfo role, List<int> menus)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    string sql = "select count(1) from RoleInfo where RoleName='" + role.RoleName + "' and RoleID !="+role.RoleID;
                    int count = (int)DbHelper.SqlHelper.ExecuteScalarByString(sql, new Dictionary<string, object>());
                    if (count > 0)
                    {
                        return new Model.Result() { ReturnValue = false, Message = "已存在相同名称的角色，修改失败！" };
                    }
                    sql = @" update RoleInfo set roleName ='"+role.RoleName+@"',Note = '"+role.Note+@"'
                             delete from RoleMenuInfo where RoleID="+role.RoleID;

                    sql += "  insert into RoleMenuInfo(RoleID,MenuID)";
                    int index = 1;
                    foreach (var item in menus)
                    {
                        sql += "select " + role.RoleID + "," + item;
                        if (index < menus.Count)
                        {
                            sql += " union ";
                        }
                        index++;
                    }

                    sql += " if(@@error=0) begin select 1 end else begin select -1 end ";
                    count = (int)DbHelper.SqlHelper.ExecuteScalarByString(sql, new Dictionary<string, object>());
                    if (count == 1)
                    {
                        ts.Complete();
                        return new Model.Result() { ReturnValue = true, Message = "修改成功！" };
                    }
                    return new Model.Result() { ReturnValue = false, Message = "修改失败！" };
                }
                catch (Exception ex)
                {
                    return new Model.Result() { ReturnValue = false, Message = ex.Message };
                }
            }
        }

        public Model.Result Delete(Model.UserInfo user,int roleid)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    string sql = "declare @count int  select @count = count(1) from UserInfo where RoleID = "+roleid;
                    sql += "if(@count>0) begin select -1 end else begin delete from RoleInfo where RoleID ="+roleid+" select 1 end";

                    int ret = (int)DbHelper.SqlHelper.ExecuteScalarByString(sql,new Dictionary<string,object>());
                    if (ret == -1)
                    {
                        return new Result() { ReturnValue  =false,Message="角色使用中无法删除，删除失败！"};
                    }
                    ts.Complete();
                    return new Result() { ReturnValue =true,Message="删除成功！"};
                }
                catch (Exception ex)
                {
                    return new Result() { ReturnValue =false,Message=ex.Message};
                }
            }
        }
    }
}
