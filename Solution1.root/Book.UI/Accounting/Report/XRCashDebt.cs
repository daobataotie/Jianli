using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
namespace Book.UI.Accounting.Report
{
    public partial class XRCashDebt : DevExpress.XtraReports.UI.XtraReport
    {
        BL.AtSummonDetailManager detailManager = new Book.BL.AtSummonDetailManager();
        IList<Model.AtSummonDetail> oList = new List<Model.AtSummonDetail>();

        public XRCashDebt(ConditionCashDebt condition)
        {
            InitializeComponent();
            decimal? a = 0;
            decimal? b = 0;
            decimal? x = 0;
            this.xrLabelCompanyInfoName.Text = BL.Settings.CompanyChineseName;
            this.xrLabelDataName.Text = "Cash account";
            IList<Model.AtSummonDetail> list = detailManager.SelectByDate(condition.StartDate, condition.EndDate);
            this.xrLabel1.Text = "Print Date：" + DateTime.Now.ToShortDateString();
            this.xrLabel2.Text = "Date range：" + condition.StartDate.ToShortDateString() + "To" + condition.EndDate.ToShortDateString();

            if (list != null)
            {
                foreach (Model.AtSummonDetail at in list)
                {
                    if (at.Lending == "Borrow")
                    {
                        a += at.AMoney;
                        at.E = at.AMoney;
                        at.F = 0;
                        at.G = x + at.E;
                        x = x + at.E;
                    }
                    else
                    {
                        b += at.AMoney;
                        at.E = 0;
                        at.F = at.AMoney;
                        at.G = x - at.F;
                        x = x - at.F;
                    }
                    oList.Add(at);
                }
            }
            this.DataSource = oList;
            this.xrLabel4.Text = "Total Income：" + b.ToString();
            this.xrLabel5.Text = "Total Pay：" + a.ToString();
            this.xrTableCellDate.DataBindings.Add("Text", this.DataSource, "Summon." + Model.AtSummon.PRO_SummonDate, "{0:yyyy-MM-dd}");
            this.xrTableCellSummonId.DataBindings.Add("Text", this.DataSource, "Summon." + Model.AtSummon.PRO_Id);
            this.xrTableCellSubjectId.DataBindings.Add("Text", this.DataSource, "Subject." + Model.AtAccountSubject.PRO_Id);

            this.xrTableCellSubjectName.DataBindings.Add("Text", this.DataSource, "Subject." + Model.AtAccountSubject.PRO_SubjectName);
            this.xrTableCellSummary.DataBindings.Add("Text", this.DataSource, Model.AtSummonDetail.PRO_Summary);

            this.xrTableCellCreditMoney.DataBindings.Add("Text", this.DataSource, "E", "{0:0}");
            this.xrTableCellDebitMoney.DataBindings.Add("Text", this.DataSource, "F", "{0:0}");
            this.xrTableCellYuE.DataBindings.Add("Text", this.DataSource, "G", "{0:0}");
        }
    }
}
