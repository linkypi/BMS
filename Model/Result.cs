using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BMS.Model
{
    public class Result
    {
        private bool returnValue;

        public bool ReturnValue
        {
            get { return returnValue; }
            set { returnValue = value; }
        }

        private object obj;

        public object Obj
        {
            get { return obj; }
            set { obj = value; }
        }

        private ArrayList arr;

        public ArrayList Arr
        {
            get { return arr; }
            set { arr = value; }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

    }
}
