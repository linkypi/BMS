using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace BMS.Common
{
    public class GridViewRowStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item is API.Book)
            {
                API.Book model = item as API.Book;

                if (model.IsBorow)
                {
                    model.Note = "已借";
                    return RedStyle;
                }
                else
                {
                    model.Note = "可借";
                }
                return null;
            }
          
            return null;
        }
        public Style RedStyle { get; set; }
        public Style GreenStyle { get; set; }
        public Style TomatoStyle { get; set; }
    }
}
