using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS.Model
{
    public class RoleMenuInfo
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int roleID;

        public int RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }

        private int menuID;

        public int MenuID
        {
            get { return menuID; }
            set { menuID = value; }
        }
    }
}
