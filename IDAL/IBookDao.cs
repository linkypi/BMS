using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using BMS.Model;

namespace BMS.IDAL
{
    public interface IBookDao
    {
         Result Search(UserInfo user, SearchModel condition);
        

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
         Result Add(UserInfo user, Book model);
       
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
         Result Update(UserInfo user, Book model);
       
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
         Result Delete(UserInfo user, List<int> bid);
       
        
    }
}
