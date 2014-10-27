using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCAL.Model
{
    public class CalendarLayout
    {
        List<CalendarLayoutColumn> Columns = new List<CalendarLayoutColumn>();
        public List<CalendarLayoutItem> Items = new List<CalendarLayoutItem>();
        public int SelectedRow = 0;
        public int SelectedCol = 0;

        public int RowCount
        {
            get
            {
                int rows = 0;
                foreach (CalendarLayoutItem it in Items)
                {
                    rows = Math.Max(rows, it.row + it.rowspan);
                }
                return rows;
            }
        }

        public int ColumnCount
        {
            get
            {
                int cols = 0;
                foreach (CalendarLayoutItem it in Items)
                {
                    cols = Math.Max(cols, it.column + it.colspan);
                }
                return cols;
            }
        }

        public CalendarLayoutColumn GetColumn(int i)
        {
            while (Columns.Count <= i)
            {
                Columns.Add(new CalendarLayoutColumn());
            }
            return Columns[i];
        }

        public CalendarLayoutColumn SelectedColumn
        {
            get
            {
                return GetColumn(SelectedCol);
            }
        }

        public CalendarLayoutItem ItemWithOriginAt(int col, int rw)
        {
            foreach (CalendarLayoutItem cli in Items)
            {
                if (cli.column == col && cli.row == rw)
                    return cli;
            }
            return null;
        }

        public CalendarLayoutItem SelectedItem
        {
            get
            {
                return ItemWithOriginAt(SelectedCol, SelectedRow);
            }
        }

        public string TestHtml()
        {
            int ir = this.RowCount;
            int ic = this.ColumnCount;
            CalendarLayoutColumn currCol = null;
            bool[,] alloc = new bool[ir + 1, ic + 1];

            StringBuilder sb = new StringBuilder();
            sb.Append("<html><head><title></title></head><body>");
            sb.Append("<table cellspacing=0 cellpadding=0 style='cursor:default;border-style:solid;border-color:black;border-width:1pt'>");
            for (int r = 0; r <= ir; r++)
            {
                sb.Append("<tr style='background-color:#ffffdd'>");
                for (int c = 0; c <= ic; c++)
                {
                    currCol = GetColumn(c);
                    if (!alloc[r, c])
                    {
                        CalendarLayoutItem item = this.ItemWithOriginAt(c, r);
                        sb.Append("<td ");
                        if (currCol.Width > 0)
                        {
                            sb.AppendFormat(" width={0}pt", currCol.Width);
                        }
                        sb.AppendFormat(" onclick=\"window.external.Test('{0},{1}')\"", r, c);
                        sb.Append(" style='");
                        if (r == SelectedRow && c == SelectedCol)
                        {
                            sb.Append("border-style:solid;border-color:black;border-width:2pt;");
                        }
                        else
                        {
                            sb.Append("border-style:solid;border-color:black;border-width:1pt;");
                        }
                        sb.Append("'");
                        if (item != null)
                        {
                            if (item.align != null && item.align.Length > 0)
                                sb.AppendFormat(" align={0}", item.align);
                            if (item.valign != null && item.valign.Length > 0)
                                sb.AppendFormat(" valign={0}", item.valign);
                            for (int i = c; i < c + item.colspan; i++)
                            {
                                for (int j = r; j < r + item.rowspan; j++)
                                {
                                    alloc[j, i] = true;
                                }
                            }
                            if (item.rowspan > 1)
                            {
                                sb.AppendFormat(" rowspan={0}", item.rowspan);
                            }
                            if (item.colspan > 1)
                            {
                                sb.AppendFormat(" colspan={0}", item.colspan);
                            }
                        }
                        else
                        {
                            alloc[r, c] = true;
                        }
                        sb.Append(">");
                        if (item == null || item.Title.Length == 0)
                        {
                            sb.Append("&nbsp;&nbsp;&nbsp;");
                        }
                        else
                        {
                            sb.Append(item.Title);
                        }
                        sb.Append("</td>");
                    }
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");

            sb.Append("</body></html>");

            return sb.ToString();
        }

    }
}
