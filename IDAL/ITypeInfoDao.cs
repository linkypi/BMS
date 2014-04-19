using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using BMS.Model;

namespace BMS.IDAL
{
    public interface ITypeInfoDao
    {
         Result GetList(UserInfo user);


         Result Add(UserInfo user, string typeName);
     

         Result Update(UserInfo user, TypeInfo model);


         Result Delete(UserInfo user, List<int> list);

         Result SearchType(UserInfo user, SearchModel condition);
      
    }
}
