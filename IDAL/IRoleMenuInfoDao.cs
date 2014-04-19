using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.Model;

namespace BMS.IDAL
{
    public interface IRoleMenuInfoDao
    {
        Result GetRoleMenus(Model.UserInfo user, int roleid);
    }
}
