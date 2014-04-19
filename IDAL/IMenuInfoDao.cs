using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.Model;


namespace BMS.IDAL
{
    public interface IMenuInfoDao
    {
         Result GetList(UserInfo user);
    }
}
