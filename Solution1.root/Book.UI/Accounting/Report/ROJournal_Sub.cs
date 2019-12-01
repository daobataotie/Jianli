using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Book.UI.Accounting.Report
{
    public partial class ROJournal_Sub : DevExpress.XtraReports.UI.XtraReport
    {
        public ROJournal_Sub(List<Model.DetailLedger> list)
        {
            InitializeComponent();

            this.DataSource = list;

            this.TCDate.DataBindings.Add("Text", this.DataSource, "SummonDate", "{0:yyyy/MM/dd}");
            this.TCID.DataBindings.Add("Text", this.DataSource, "Id");
            this.TCCategory.DataBindings.Add("Text", this.DataSource, "SummonCategory");
            this.TCSubId.DataBindings.Add("Text", this.DataSource, "Subject_Id");
            this.TCSubName.DataBindings.Add("Text", this.DataSource, "SubjectName");
            this.TCSummary.DataBindings.Add("Text", this.DataSource, "Summary");
            //this.TCJMoney.DataBindings.Add("Text", this.DataSource, "JMoney", "{0:0.00}");
            //this.TCDMoney.DataBindings.Add("Text", this.DataSource, "DMoney", "{0:0.00}");
            this.TCJMoney.DataBindings.Add("Text", this.DataSource, "JMoney", "{0:N0}");
            this.TCDMoney.DataBindings.Add("Text", this.DataSource, "DMoney", "{0:N0}");
        }

    }
}
