using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS.Model
{
    public class RoleInfo
    {
        private int roleID;

        public int RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }

        private string roleName;

        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }

        private string note;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }
    }
}
