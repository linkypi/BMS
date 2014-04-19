using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS.Model
{
    public class UserInfo
    {
        private int roleID;

        public int RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }

        private int userID;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string pwd;

        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

    }
}
