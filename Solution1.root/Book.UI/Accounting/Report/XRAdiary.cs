using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
namespace Book.UI.Accounting.Report
{
    public partial class XRAdiary : DevExpress.XtraReports.UI.XtraReport
    {
        BL.AtSummonDetailManager detailManager = new Book.BL.AtSummonDetailManager();
        IList<Model.AtSummonDetail> oList = new List<Model.AtSummonDetail>();

        public XRAdiary(ConditionAdiary condition)
        {
            InitializeComponent();
            decimal? a = 0;
            decimal? b = 0;

            this.lblCompanyName.Text = BL.Settings.CompanyChineseName;

            string SummonCatetoryType = string.Empty;
            switch (condition.SummonCatetory)
            {
                case (int)SummonCatetoryEnum.SC_ZhuanZhangCP:
                    SummonCatetoryType = "Transfer summons";
                    break;
                case (int)SummonCatetoryEnum.SC_XianJinZhiChuCP:
                    SummonCatetoryType = "Cash expenditures summons";
                    break;
                case (int)SummonCatetoryEnum.SC_XianJinShouRuCP:
                    SummonCatetoryType = "Cash income summons";
                    break;
            }

            this.lblReprotName.Text = Properties.Resources.AtAdiary + "-" + SummonCatetoryType + " " + condition.StartDate.ToShortDateString() + "To" + condition.EndDate.ToShortDateString();

            IList<Model.AtSummonDetail> list = detailManager.SelectAndSCtype(condition.StartDate, condition.EndDate, SummonCatetoryType);

            this.lblPrintDate.Text += DateTime.Now.ToShortDateString();

            this.DataSource = list;

            decimal DebitTotal = 0;
            decimal CreaditTotal = 0;

            foreach (Model.AtSummonDetail d in list)
            {
                if (d.Equals("Borrow"))
                {
                    DebitTotal += d.AMoney.HasValue ? d.AMoney.Value : 0;
                }
                else
                {
                    CreaditTotal += d.AMoney.HasValue ? d.AMoney.Value : 0;
                }
            }

            this.lblDebitTotal.Text = DebitTotal.ToString();
            this.lblCreditTotal.Text = CreaditTotal.ToString();

            this.xrTableCellDate.DataBindings.Add("Text", this.DataSource, "Summon." + Model.AtSummon.PRO_SummonDate, "{0:yyyy-MM-dd}");
            this.xrTableCellSummonId.DataBindings.Add("Text", this.DataSource, "Summon." + Model.AtSummon.PRO_Id);
            this.xrTableCellSubjectId.DataBindings.Add("Text", this.DataSource, "Subject." + Model.AtAccountSubject.PRO_Id);

            this.xrTableCellSubjectName.DataBindings.Add("Text", this.DataSource, "Subject." + Model.AtAccountSubject.PRO_SubjectName);
            this.xrTableCellSummary.DataBindings.Add("Text", this.DataSource, Model.AtSummonDetail.PRO_Summary);

            this.xrTableCellCreditMoney.DataBindings.Add("Text", this.DataSource, "E", "{0:0}");
            this.xrTableCellDebitMoney.DataBindings.Add("Text", this.DataSource, "F", "{0:0}");           
        }

    }
}
