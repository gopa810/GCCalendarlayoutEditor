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
    public partial class SearchConditionsView : UserControl
    {
        private static int topId = 1;
        private List<SearchConditionControl> conditionControls = new List<SearchConditionControl>();

        public SearchConditionsView()
        {
            InitializeComponent();

            AddNewSearchRow();
        }


        private void AddNewSearchRow()
        {
            int newId = conditionControls.Count;

            SearchConditionControl nc = new SearchConditionControl();

            nc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            nc.Location = new System.Drawing.Point(3, newId * 37 + 3);
            nc.Name = "searchConditionControl" + topId.ToString();
            nc.Size = new System.Drawing.Size(this.Size.Width-6, 37);
            nc.TabIndex = 0;
            nc.NewConditionRequested += new SearchConditionControl.NewConditionRequestedHandler(this.searchConditionControl_NewConditionRequested);
            nc.UniqueId = topId;

            topId++;

            conditionControls.Add(nc);

            this.Controls.Add(nc);
        }

        private void searchConditionControl_NewConditionRequested(object sender, EventArgs e)
        {

        }
    }
}
