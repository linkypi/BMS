using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using BMS.Model;

namespace BMS.IDAL
{
    public interface ISysMethodInfoDao
    {
         Result GetMethodInfo(UserInfo user, int mid);
     
    }
}
