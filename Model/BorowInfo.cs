using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS.Model
{
    public class BorowInfo
    {
        private int borowID;

        public int BorowID
        {
            get { return borowID; }
            set { borowID = value; }
        }

        private int userID;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private int bID;

        public int BID
        {
            get { return bID; }
            set { bID = value; }
        }

        private DateTime borowDate;

        public DateTime BorowDate
        {
            get { return borowDate; }
            set { borowDate = value; }
        }

        private bool isReturn;

        public bool IsReturn
        {
            get { return isReturn; }
            set { isReturn = value; }
        }

        private DateTime returnDate;

        public DateTime ReturnDate
        {
            get { return returnDate; }
            set { returnDate = value; }
        }
    }
}
