using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.Model;

namespace BMS.IDAL
{
    public interface IBorowInfoDao
    {
        Result Borow(UserInfo user, bool existsUser, object userIN, List<int> list);
        Result Return(UserInfo user, string returner, List<int> list);
    }
}
