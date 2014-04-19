using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS.Model
{
    public class SysMethodInfo
    {
        private int methodID;

        public int MethodID
        {
            get { return methodID; }
            set { methodID = value; }
        }

        private string methodName;

        public string MethodName
        {
            get { return methodName; }
            set { methodName = value; }
        }

        private int menuID;

        public int MenuID
        {
            get { return menuID; }
            set { menuID = value; }
        }

        private string dao;

        public string Dao
        {
            get { return dao; }
            set { dao = value; }
        }

        private string note;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

    }
}
