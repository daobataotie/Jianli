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
    public partial class RODetailLedger : DevExpress.XtraReports.UI.XtraReport
    {
        IList<Model.DetailLedger> List = null;
        BL.AtSummonDetailManager manager = new Book.BL.AtSummonDetailManager();
        private DateTime startDate;

        public RODetailLedger(ConditionDetailLedger condition)
        {
            InitializeComponent();

            startDate = condition.DateStart.Date;
            List = manager.SelectDetailLedger(condition.DateStart, condition.DateEnd, condition.StartSubId, condition.EndSubId);

            if (List == null || List.Count == 0)
            {
                throw new Exception("無數據");
                //MessageBox.Show("無數據", "提示", MessageBoxButtons.OK);
                //return;
            }

            this.lbl_CompanyName.Text = BL.Settings.CompanyChineseName;
            this.lbl_ReportDate.Text += DateTime.Now.ToString("yyyy-MM-dd");
            this.lbl_DataRange.Text += condition.DateStart.ToString("yyyy-MM-dd") + " ~ " + condition.DateEnd.ToString("yyyy-MM-dd");
            this.lbl_SubRange.Text += condition.StartSubId + " ~ " + condition.EndSubId;

            var group = List.GroupBy(D => D.Subject_Id).Select(S => S.Key).ToList<string>();

            this.DataSource = group;

            this.xrSubreport1.ReportSource = new RODetailLedger_Sub();

        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            RODetailLedger_Sub sub = this.xrSubreport1.ReportSource as RODetailLedger_Sub;

            List<Model.DetailLedger> subList = new List<Book.Model.DetailLedger>();
            var group = List.Where(l => l.Subject_Id == this.GetCurrentRow().ToString());

            group.First().TheBalance = manager.GetQianqiYuE(group.First().Subject_Id, startDate);
            decimal qianqiYuE = group.First().TheBalance;

            foreach (var item in group)
            {
                //和会计科目的期初借贷相同即为+，否则-
                if (item.Lending == item.TheLending)
                    item.Total = qianqiYuE = qianqiYuE + item.AMoney;
                else
                    item.Total = qianqiYuE = qianqiYuE - item.AMoney;


                subList.Add(item);
            }

            sub.list = subList;
        }

    }
}
