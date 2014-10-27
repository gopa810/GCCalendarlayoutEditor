using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using GCAL.Forms;
using GCAL.Model;

namespace GCAL
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class MainForm : Form
    {
        private string nextContent = null;
        public CalendarLayout layout = new CalendarLayout();

        public MainForm()
        {
            InitializeComponent();

            layout.Items.Add(new CalendarLayoutItem(0, 0, "{DateShort}", "Date"));
            layout.Items.Add(new CalendarLayoutItem(1, 0, "{WeekdayShort}", ""));
            layout.Items.Add(new CalendarLayoutItem(2, 0, "{TithiNameExt}", "Tithi"));
            //webBrowser1.ObjectForScripting = this;
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NavigatorForm form = new NavigatorForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //webBrowser1.Document.ExecCommand("Print", true, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calendarLayoutEditControl1.LayoutObject = layout;
            //webBrowser1.DocumentText = layout.TestHtml();
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string address = e.Url.ToString();
            if (address == "about:blank")
                return;
            e.Cancel = true;
            if (address == "gcal://nextmonth/")
            {
                MessageBox.Show("Have this");
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy,
            UInt32 dwData, uint dwExtraInfo);

        private void timer1_Tick(object sender, EventArgs e)
        {
            mouse_event(0, 1, 1, 0, 0);
        }
    }
}
