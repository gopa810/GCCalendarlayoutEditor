using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCAL.Model
{
    public class CalendarLayoutItem
    {
        public int column = 0;
        public int colspan = 1;
        public int row = 0;
        public int rowspan = 1;
        public string Title = "";
        public string Value = "";
        public string align = "";
        public string valign = "";

        public CalendarLayoutItem()
        {
        }
        public CalendarLayoutItem(int acolumn, int arow, string avalue)
        {
            column = acolumn;
            row = arow;
            Value = avalue;
        }
        public CalendarLayoutItem(int acolumn, int arow, string avalue, string atitle)
        {
            column = acolumn;
            row = arow;
            Value = avalue;
            Title = atitle;
        }
    }
}
