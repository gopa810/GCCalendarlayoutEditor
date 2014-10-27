using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GCAL.Dialogs
{
    public partial class DlgGetYearRange : Form
    {
        public DlgGetYearRange()
        {
            InitializeComponent();

            DateTime dt = new DateTime();

            for (int i = 0; i < 20; i++)
            {
                comboBox1.Items.Add((dt.Year + i).ToString());
            }

            for (int i = 1; i < 100; i++)
            {
                comboBox2.Items.Add(i.ToString());
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        public int SelectedYear
        {
            get
            {
                int r = 2013;
                int.TryParse(comboBox1.SelectedItem.ToString(), out r);
                return r;
            }
        }

        public int SelectedCount
        {
            get
            {
                int r = 1;
                int.TryParse(comboBox2.SelectedItem.ToString(), out r);
                return r;
            }
        }

    }
}
