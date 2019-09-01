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
    public partial class ROJournal : DevExpress.XtraReports.UI.XtraReport
    {
        public ROJournal(ConditionDetailLedger condition)
        {
            InitializeComponent();

            BL.AtSummonDetailManager manager = new Book.BL.AtSummonDetailManager();
            IList<Model.DetailLedger> list = manager.SelectJournal(condition.DateStart, condition.DateEnd, condition.StartId, condition.EndId, condition.Category);

            if (list == null || list.Count == 0)
            {
                MessageBox.Show("無數據", "提示", MessageBoxButtons.OK);
                return;
            }

            this.lbl_CompanyName.Text = BL.Settings.CompanyChineseName;
            this.lbl_ReportDate.Text += DateTime.Now.ToString("yyyy-MM-dd");
            this.lbl_DataRange.Text += condition.DateStart.ToString("yyyy-MM-dd") + " ~ " + condition.DateEnd.ToString("yyyy-MM-dd");
            this.lbl_IdRange.Text += condition.StartId + " ~ " + condition.EndId;

            var group = list.GroupBy(D => new { D.SummonDate, D.Id });

            List<Model.DetailLedger> source = new List<Book.Model.DetailLedger>();
            foreach (var item in group)
            {
                var sublist = item.ToList();
                for (int i = 0; i < sublist.Count; i++)
                {
                    if (i != 0)
                        sublist[i].SummonDate = null;

                    source.Add(sublist[i]);
                }
            }

            xrSubreport1.ReportSource = new ROJournal_Sub(source);

            //this.DataSource = source;

            //this.TCDate.DataBindings.Add("Text", this.DataSource, "SummonDate", "{0:yyyy/MM/dd}");
            //this.TCID.DataBindings.Add("Text", this.DataSource, "Id");
            //this.TCCategory.DataBindings.Add("Text", this.DataSource, "SummonCategory");
            //this.TCSubId.DataBindings.Add("Text", this.DataSource, "Subject_Id");
            //this.TCSubName.DataBindings.Add("Text", this.DataSource, "SubjectName");
            //this.TCSummary.DataBindings.Add("Text", this.DataSource, "Summary");
            //this.TCJMoney.DataBindings.Add("Text", this.DataSource, "JMoney", "{0:0.00}");
            //this.TCDMoney.DataBindings.Add("Text", this.DataSource, "DMoney", "{0:0.00}");
        }

    }
}
