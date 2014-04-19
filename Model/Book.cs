using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS.Model
{
    public class Book
    {
        private int bid;

        public int BID
        {
            get { return bid; }
            set { bid = value; }
        }

        private string note;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }


        private bool isBorow;

        public bool IsBorow
        {
            get { return isBorow; }
            set { isBorow = value; }
        }

        private string bookName;

        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }

        private string position;

        public string SMPosition
        {
            get { return position; }
            set { position = value; }
        }


        private string author;

        public string BAuthor
        {
            get { return author; }
            set { author = value; }
        }

        private string typeName;

        public string BTypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        private int typeID;

        public int BTypeID
        {
            get { return typeID; }
            set { typeID = value; }
        }

        private string outLine;

        public string OutLine
        {
            get { return outLine; }
            set { outLine = value; }
        }

        private string publisher;

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        private double price;

        public double BPrice
        {
            get { return price; }
            set { price = value; }
        }

        private DateTime pubDate;

        public DateTime PubDate
        {
            get { return pubDate; }
            set { pubDate = value; }
        }

        private string serialNum;

        public string SerialNum
        {
            get { return serialNum; }
            set { serialNum = value; }
        }
    }
}
