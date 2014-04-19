using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS.Model
{
    public class SearchModel
    {
        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        private int currentPage;

        public int CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        }

        private int allPages;

        public int AllPages
        {
            get { return allPages; }
            set { allPages = value; }
        }

        private Dictionary<string, object> conditions;

        public Dictionary<string, object> Conditions
        {
            get { return conditions; }
            set { conditions = value; }
        }

        private object rasult;

        public object Result
        {
            get { return rasult; }
            set { rasult = value; }
        }
    }
}
