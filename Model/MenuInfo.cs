using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS.Model
{
   public class MenuInfo
    {
        private int menuID;

        public int MenuID
        {
            get { return menuID; }
            set { menuID = value; }
        }

        private string menuName;

        public string MenuName
        {
            get { return menuName; }
            set { menuName = value; }
        }

        private string className;

        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        private int parent;

        public int Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        private int order;

        public int Order
        {
            get { return order; }
            set { order = value; }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        private string note;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }
    }
}
