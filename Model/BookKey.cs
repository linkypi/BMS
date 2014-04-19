using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS.Model
{
   public class BookKey
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int bID;

        public int BID
        {
            get { return bID; }
            set { bID = value; }
        }

        private string bKey;

        public string BKey
        {
            get { return bKey; }
            set { bKey = value; }
        }
    }
}
