using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BMS.DALFactory
{
    public class DalFactory<T>
    {
        /// <summary>
        /// 创建数据访问对象
        /// </summary>
        /// <returns></returns>
        public static T CreateDaoObject()
        {
            Type t = typeof(T);
            string typeKey = t.Name;
            string typeName = ConfigurationManager.AppSettings[typeKey];
            Type type = Type.GetType(typeName);
            T dao = (T)Activator.CreateInstance(type);
            return dao;
        }
    }
}
