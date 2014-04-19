using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BMS.Common;
using BMS.Model;
using System.ServiceModel.Activation;

namespace BMSService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
   // [DataContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceContract(SessionMode = SessionMode.Required)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]

    [ServiceKnownType(typeof(Book))]
    [ServiceKnownType(typeof(BookKey))]
    [ServiceKnownType(typeof(BorowInfo))]
    [ServiceKnownType(typeof(MenuInfo))]
    [ServiceKnownType(typeof(Result))]
    [ServiceKnownType(typeof(RoleInfo))]
    [ServiceKnownType(typeof(RoleMenuInfo))]
    [ServiceKnownType(typeof(TypeInfo))]
    [ServiceKnownType(typeof(UserInfo))]
    [ServiceKnownType(typeof(SysMethodInfo))]
    [ServiceKnownType(typeof(SearchModel))]
    //[ServiceKnownType(typeof(Model.RequestEvent))]  
    [ServiceKnownType(typeof(List<int>))]
    [ServiceKnownType(typeof(List<Book>))]
    [ServiceKnownType(typeof(List<BookKey>))]
    [ServiceKnownType(typeof(List<BorowInfo>))]
    [ServiceKnownType(typeof(List<MenuInfo>))]
    [ServiceKnownType(typeof(List<Result>))]
    [ServiceKnownType(typeof(List<RoleInfo>))]
    [ServiceKnownType(typeof(List<RoleMenuInfo>))]
    [ServiceKnownType(typeof(List<TypeInfo>))]
    [ServiceKnownType(typeof(List<UserInfo>))]
    [ServiceKnownType(typeof(List<SysMethodInfo>))]
    public class BMSService // : IService1
    {
        [OperationContract]
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

   
         [OperationContract]
         public string login()
         {
             return "OK";
         }

         [OperationContract]
         public Result Execute(int methodid,List<object> args)
         {
            return Tool.OperateMethod(methodid, args);
         }

       

    }
}
