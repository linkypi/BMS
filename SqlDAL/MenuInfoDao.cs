using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.Model;
using BMS.DbHelper;
using BMS.IDAL;

namespace BMS.SqlDAL
{
    public class MenuInfoDao : IMenuInfoDao
    {
        public Result GetList(UserInfo user)
        {
            string sql = "select * from MenuInfo ";

            Dictionary<string, string> outdic = new Dictionary<string, string>();
            outdic.Add("MenuID", "MenuID");
            outdic.Add("MenuName", "MenuName");
            outdic.Add("ClassName", "ClassName");
            outdic.Add("Parent", "Parent");
            outdic.Add("Order", "Order");
            outdic.Add("Image", "Image");
            outdic.Add("Note", "Note");

            List<Model.MenuInfo> models = SqlHelper.GetDataListByString<MenuInfo>(sql, new Dictionary<string, object>(), outdic);
            return new Result() { ReturnValue =true,Obj = models};
        }
    }
}
