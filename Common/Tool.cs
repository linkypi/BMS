using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.Model;
using System.Reflection;
using BMS.IDAL;
using BMS.DALFactory;
using BMS.SqlDAL;
using System.Configuration;

namespace BMS.Common
{
    public  class Tool
    {
        public static Result OperateMethod(int methodid, List<object> args)
        {
            try
            {
                Type t = typeof(BookDao);

                ISysMethodInfoDao dao = DalFactory<ISysMethodInfoDao>.CreateDaoObject();
                 
                
                Result res = dao.GetMethodInfo(args[0] as UserInfo, methodid);

                if (!res.ReturnValue)
                {
                    return res;
                }
                SysMethodInfo sminfo = res.Obj as SysMethodInfo;

                //获取当前接口类型
                Type interfaceType = Type.GetType("BMS.IDAL." + sminfo.Dao + ",BMS.IDAL");

                //根据接口名称获取当前访问的dao   此项设置放在BMSServiceHost的web.config的Appsetings中
                string typeName = ConfigurationManager.AppSettings[interfaceType.Name];
                Type Daltype = Type.GetType(typeName);
                
                //获取操作方法
                MethodInfo operateMethod = Daltype.GetMethod(sminfo.MethodName);
                //实例化
                object instance = Activator.CreateInstance(Daltype);

                //调用函数
                Result ret = (Result)operateMethod.Invoke(instance, args.ToArray());

                return ret;
            }
            catch (Exception ex)
            {
                return new Result() { ReturnValue  =false,Message=ex.Message};
            }
        }
    }
}
