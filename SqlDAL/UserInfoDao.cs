using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.Model;
using BMS.DbHelper;
using BMS.IDAL;

namespace BMS.SqlDAL
{
    public class UserInfoDao : IUserInfoDao
    {
        public Result GetUser(string username)
        {
            string sql = "select * from UserInfo where username=@username ";
            Dictionary<string, object> indic = new Dictionary<string, object>();
            indic.Add("@username", username);

            Dictionary<string, string> outdic = new Dictionary<string, string>();
            outdic.Add("UserName", "UserName");
            outdic.Add("UserID", "UserID");
            outdic.Add("Pwd", "Pwd");
            outdic.Add("RoleID", "RoleID");

            UserInfo user = SqlHelper.GetDataModelByString<UserInfo>(sql, indic, outdic);
            if (user == null)
            {
                return new Result() { ReturnValue = false, Message = "用户不存在！" };
            }
            else if (user.UserName == null)
            {
                return new Result() { ReturnValue = false, Message = "用户不存在！" };
            }

            sql = "select * from RoleInfo where RoleID = @roleid ";
            Dictionary<string, object> indic2 = new Dictionary<string, object>();
            indic2.Add("@roleid", user.RoleID);
            Dictionary<string, string> outdic2 = new Dictionary<string, string>();
            outdic2.Add("RoleName", "RoleName");
            outdic2.Add("RoleID", "RoleID");
            RoleInfo role = SqlHelper.GetDataModelByString<RoleInfo>(sql, indic2, outdic2);
            if (role == null)
            {
                return new Result() { ReturnValue = false, Message = "角色不存在,数据有误！" };
            }
            else if (role.RoleName == null)
            {
                return new Result() { ReturnValue = false, Message = "角色不存在,数据有误！" };
            }


            return new Result() { ReturnValue = true, Obj = user, Arr = new System.Collections.ArrayList() { role } };

        }

        public Result GetAllUsers(Model.UserInfo user)
        {
            try
            {
                string sql = "select * from UserInfo ";
                Dictionary<string, string> outdic = new Dictionary<string, string>();
                outdic.Add("UserID", "UserID");
                outdic.Add("UserName", "UserName");
                outdic.Add("Pwd", "Pwd");
                outdic.Add("RoleID", "RoleID");
                List<Model.UserInfo> list = DbHelper.SqlHelper.GetDataListByString<Model.UserInfo>(sql, new Dictionary<string, object>(), outdic);
                return new Result() { ReturnValue = true, Message = "", Obj = list };
            }
            catch (Exception ez)
            {
                return new Result() { ReturnValue = false, Message = ez.Message };
            }
        }
    }
}
