using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace BMS.Common
{
    public class Store
    {
        public static API.UserInfo CurrentUser;
        public static API.RoleInfo CurrentRole;
        public static List<API.TypeInfo> TypeInfos = new List<API.TypeInfo>();
        public static List<API.MenuInfo> MenuInfos = new List<API.MenuInfo>();
        public static List<API.UserInfo> UserInfos = new List<API.UserInfo>();
        public static bool IsLogin;
    }
}
