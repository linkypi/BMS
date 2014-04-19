using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS.Model
{
    public class TypeInfo
    {
        private int typeID;

        public int TypeID
        {
            get { return typeID; }
            set { typeID = value; }
        }

        private string typeName;

        public string BTypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }
    }
}
