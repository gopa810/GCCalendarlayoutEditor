using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GCAL.Views
{
    public partial class SearchConditionControl : UserControl
    {
        public delegate void NewConditionRequestedHandler(object sender, EventArgs e);

        public event NewConditionRequestedHandler NewConditionRequested;


        public int UniqueId = 0;

        public SearchConditionControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NewConditionRequested != null)
                NewConditionRequested(this, e);
        }
    }
}
