using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.Model;

namespace BMS.IDAL
{
    public interface IRoleInfoDao
    {
        Result AddRole(UserInfo user,RoleInfo role,List<int> menus);
        Result UpdateRole(UserInfo user, RoleInfo role, List<int> menus);
        Result Search(Model.UserInfo user, SearchModel condition);
        Result Delete(Model.UserInfo user, int roleid);
    }
}
