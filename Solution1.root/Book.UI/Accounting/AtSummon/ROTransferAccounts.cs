using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Accounting.AtSummon
{
    public partial class ROTransferAccounts : DevExpress.XtraReports.UI.XtraReport
    {
        public ROTransferAccounts(Model.AtSummon atSummon)
        {
            InitializeComponent();

            this.lbl_CompanyName.Text = BL.Settings.CompanyChineseName;
            this.lbl_Id.Text = atSummon.Id;
            this.lblDate.Text = atSummon.SummonDate.HasValue ? atSummon.SummonDate.Value.ToString("yyyy-MM-dd") : "";

            this.DataSource = atSummon.Details;

            this.TC_Jiedai.DataBindings.Add("Text", this.DataSource, Model.AtSummonDetail.PRO_Lending);
            this.TCSubId.DataBindings.Add("Text", this.DataSource, "Subject." + Model.AtAccountSubject.PRO_Id);
            this.TC_SubName.DataBindings.Add("Text", this.DataSource, "Subject." + Model.AtAccountSubject.PRO_SubjectName);
            this.TC_Note.DataBindings.Add("Text", this.DataSource, Model.AtSummonDetail.PRO_Summary);
            this.TC_JMoney.DataBindings.Add("Text", this.DataSource, "JMoney", "{0:0.##}");
            this.TC_DMoney.DataBindings.Add("Text", this.DataSource, "DMoney", "{0:0.##}");

            this.TCJTotal.Text = atSummon.TotalDebits.Value.ToString("0.##");
            this.TCDTotal.Text = atSummon.CreditTotal.Value.ToString("0.##");
        }

    }
}
