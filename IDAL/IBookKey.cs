using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.Model;

namespace BMS.IDAL
{
   public interface IBookKey
    {
         Result GetBookKey(UserInfo user, int bid);
       
         Result Add(UserInfo user, List<Model.BookKey> models);

         Result Delete(UserInfo user, List<int> idList);
    }
}
