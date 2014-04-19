using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS.Common
{
    enum MethodType
    {
        GetUser = 1,
        GetTypeInfoList = 2,
        AddBook,
        SearchBook = 4,
        GetMenuInfoList = 5,
        GetOutLine = 7,
        UpdateBook = 9,
        GetBKeyByBID = 10,
        AddBKeys = 11,
        DeleteBKeys = 12,
        DeleteBook = 13,
        AddBType = 14,
        DeleteBType = 15,
        UpdateBType = 16,
        SearchBType = 17,
        GetAllUsers = 18,
        Borow = 19,
        Return = 20,
        AddRole  =21,
        UpdateRole = 22,
        SearchRoles = 23,
        GetRoleMenus = 24,
        DeleteRole  =25
      
    }
}
