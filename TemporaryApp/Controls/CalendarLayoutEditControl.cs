using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GCAL.Model;

namespace GCAL.Controls
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class CalendarLayoutEditControl : UserControl
    {
        private CalendarLayout p_layout = null;
        private CalendarLayoutColumn selectedColumn = null;
        private CalendarLayoutItem selectedItem = null;

        public CalendarLayoutItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                if (selectedItem != null)
                {
                    numericUpDown2.Value = selectedItem.colspan;
                    numericUpDown3.Value = selectedItem.rowspan;
                    textBox1.Text = selectedItem.Title;
                    textBox2.Text = selectedItem.Value;
                    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(selectedItem.align);
                    comboBox2.SelectedIndex = comboBox2.Items.IndexOf(selectedItem.valign);
                }
                else
                {
                    numericUpDown2.Value = 1;
                    numericUpDown3.Value = 1;
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
        }

        public CalendarLayoutColumn SelectedColumn
        {
            get
            {
                return selectedColumn;
            }
            set
            {
                selectedColumn = value;
                if (selectedColumn != null)
                {
                    numericUpDown1.Value = selectedColumn.Width;
                }
            }
        }

        public CalendarLayoutEditControl()
        {
            InitializeComponent();
            webBrowser1.ObjectForScripting = this;
        }

        public CalendarLayout LayoutObject
        {
            get
            {
                return p_layout;
            }
            set
            {
                p_layout = value;
                if (p_layout != null)
                    webBrowser1.DocumentText = p_layout.TestHtml();
            }
        }

        public void RefreshText()
        {
            webBrowser1.DocumentText = p_layout.TestHtml();
        }

        public void Test(string arg)
        {
            string[] poss = arg.Split(',');
            if (poss.Length >= 2)
            {
                int.TryParse(poss[1], out p_layout.SelectedCol);
                int.TryParse(poss[0], out p_layout.SelectedRow);
                RefreshText();
                this.SelectedColumn = p_layout.SelectedColumn;
                this.SelectedItem = p_layout.SelectedItem;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (selectedColumn != null)
            {
                selectedColumn.Width = Convert.ToInt32(numericUpDown1.Value);
                RefreshText();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (selectedItem == null)
            {
                selectedItem = new CalendarLayoutItem(p_layout.SelectedCol, p_layout.SelectedRow, "");
                p_layout.Items.Add(selectedItem);
            }
            if (selectedItem != null)
            {
                selectedItem.Title = textBox1.Text;
                RefreshText();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (selectedItem == null)
            {
                selectedItem = new CalendarLayoutItem(p_layout.SelectedCol, p_layout.SelectedRow, "");
                p_layout.Items.Add(selectedItem);
            }
            if (selectedItem != null)
            {
                selectedItem.Value = textBox2.Text;
                RefreshText();
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (selectedItem == null)
            {
                selectedItem = new CalendarLayoutItem(p_layout.SelectedCol, p_layout.SelectedRow, "");
                p_layout.Items.Add(selectedItem);
            }
            if (selectedItem != null)
            {
                selectedItem.colspan = Convert.ToInt32(numericUpDown2.Value);
                RefreshText();
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (selectedItem == null)
            {
                selectedItem = new CalendarLayoutItem(p_layout.SelectedCol, p_layout.SelectedRow, "");
                p_layout.Items.Add(selectedItem);
            }
            if (selectedItem != null)
            {
                selectedItem.rowspan = Convert.ToInt32(numericUpDown3.Value);
                RefreshText();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                selectedItem.align = comboBox1.SelectedItem.ToString();
                RefreshText();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                selectedItem.valign = comboBox2.SelectedItem.ToString();
                RefreshText();
            }
        }
    }
}
