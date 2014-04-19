using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using BMS.Model;
using BMS.DbHelper;
using BMS.IDAL;

namespace BMS.AccessDAL
{
    public class SysMethodInfoDao : ISysMethodInfoDao
    {
        public Result GetMethodInfo(UserInfo user, int mid)
        {
            try
            {
                string sql = "select * from MethodInfo where methodid=@mid ";
                Dictionary<string, object> indic = new Dictionary<string, object>();
                indic.Add("@mid", mid);

                Dictionary<string, string> outdic = new Dictionary<string, string>();
                outdic.Add("MethodID", "MethodID");
                outdic.Add("MethodName", "MethodName");
                outdic.Add("MenuID", "MenuID");
                outdic.Add("Dao", "Dao");
                outdic.Add("Note", "Note");
                SysMethodInfo smi = AccessHelper.GetDataModelByString<SysMethodInfo>(sql, indic, outdic);
                if (smi == null)
                {
                    return new Result() { ReturnValue = false, Message = "方法不存在！" };
                }
                else
                {
                    return new Result() { ReturnValue = true, Obj = smi };
                }
            }
            catch(Exception ex)
            {
                return new Result() { ReturnValue = true, Obj = ex.Message };
            }
        }
    }
}
