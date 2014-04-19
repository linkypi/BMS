using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.Model;
using BMS.IDAL;

namespace BMS.SqlDAL
{
    public class RoleMenuInfoDao : IRoleMenuInfoDao
    {
       public Result GetRoleMenus(Model.UserInfo user,int roleid)
       {
           try
           {  
               string sql = "select * from RoleMenuInfo where RoleID = "+roleid;
               Dictionary<string, string> outidc = new Dictionary<string, string>();
               outidc.Add("RoleID", "RoleID");
               outidc.Add("MenuID", "MenuID");
               List<RoleMenuInfo> list = DbHelper.SqlHelper.GetDataListByString<RoleMenuInfo>(sql,new Dictionary<string,object>(),outidc);
               return new Result() { ReturnValue = true ,Obj = list };
           }
           catch(Exception ex)
           {
               return new Result() {ReturnValue =false,Message=ex.Message };
           }
       }
    }
}
